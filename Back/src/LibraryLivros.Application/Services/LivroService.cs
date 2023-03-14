using AutoMapper;
using Microsoft.EntityFrameworkCore;
using LibraryLivros.Application.Interfaces;
using LibraryLivros.Application.Requests.LivroRequests;
using LibraryLivros.Domain.Exceptions;
using LibraryLivros.Domain.Models;
using LibraryLivros.Domain.Repository;

namespace LibraryLivros.Application.Services;

public class LivroService : ILivroService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public LivroService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task Add(LivroInsertRequest livroInsertRequest)
    {
        var existente = await LivroExists(livroInsertRequest.Nome);

        if(existente){
            throw new LibraryLivrosExceptions("Este Livro já existe");
        }

        _unitOfWork.Iniciar();

        var livro = _mapper.Map<Livro>(livroInsertRequest);

        _unitOfWork.LivroRepository.Add(livro);

        await _unitOfWork.CommitarAsync();
    }

    public async Task Update(LivroUpdateRequest livroUpdateRequest)
    {
        var existente = await _unitOfWork.LivroRepository.GetLivroByIdAsync(livroUpdateRequest.Id);

        if (livroUpdateRequest.Id == 0 || existente == null){
            return;
        }

        _unitOfWork.Iniciar();

        existente.Nome = livroUpdateRequest.Nome;
        existente.QuantidadePaginas = livroUpdateRequest.QuantidadePaginas;
        existente.Autor = livroUpdateRequest.Autor;

        _unitOfWork.LivroRepository.Update(existente);
        await _unitOfWork.CommitarAsync();
    }

    //link livro to user 
    public async Task LinkLivroToUser(LivroLinkRequest livroLinkRequest)
    {
        var existente = await _unitOfWork.LivroRepository.GetLivroByIdAsync(livroLinkRequest.IdLivro);
        var existenteUser = await _unitOfWork.UserRepository.GetUserByIdGatewayAsync(livroLinkRequest.IdUser);

        //create user if it doesn't exist 
        if (livroLinkRequest.IdUser == 0 || existenteUser == null){
            _unitOfWork.Iniciar();

            var user = new User();
            user.Id = livroLinkRequest.IdUser;
            _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.CommitarAsync();

            existenteUser = await _unitOfWork.UserRepository.GetUserByIdGatewayAsync(livroLinkRequest.IdUser);
        }

        if (livroLinkRequest.IdLivro == 0 || existente == null || existenteUser == null ){
            return;
        }

        _unitOfWork.Iniciar();

        existente.Users.Add(existenteUser);

        _unitOfWork.LivroRepository.Update(existente);
        await _unitOfWork.CommitarAsync();
    }

    //check all books from a user
    public async Task<List<Livro>> GetLivrosByUser(int userId)
    {
        var existenteUser = await _unitOfWork.UserRepository.GetUserByIdAsync(userId);

        if (existenteUser == null){
            return null;
        }

        return await _unitOfWork.LivroRepository.GetLivrosByUserAsync(userId);
    }

    public async Task Delete(int livroId)
    {

        var livro = await _unitOfWork.LivroRepository
            .GetLivroByIdAsync(livroId)
        ;
        if (livro == null) throw new LibraryLivrosExceptions("Registro não encontrado.");

        _unitOfWork.Iniciar();
        _unitOfWork.LivroRepository.Delete(livro);
        await _unitOfWork.CommitarAsync();
    }

    private async Task<bool> LivroExists(string nome)
    {
        var Livro =  await _unitOfWork.LivroRepository.GetLivroByNomeAsync(nome);
        return Livro != null;
    }

    public async Task<List<Livro>> GetAll()
    {
        return await _unitOfWork.LivroRepository.GetLivrosAsync();
    }

    public async Task<List<Livro>> GetLivrosByFilter(LivroFilter filtro)
    {
        return await _unitOfWork.LivroRepository.GetLivrosByFilterAsync(filtro);
    }
}
