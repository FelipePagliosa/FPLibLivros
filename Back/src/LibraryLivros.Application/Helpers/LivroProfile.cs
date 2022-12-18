using System;
using AutoMapper;
using LibraryLivros.Application.Requests.LivroRequests;
using LibraryLivros.Domain.Models;

namespace LibraryLivros.Application.Helpers;
public class LivroProfile : Profile
{
    public LivroProfile()
    {
        CreateMap<Livro, LivroUpdateRequest>().ReverseMap();
        CreateMap<Livro, LivroInsertRequest>().ReverseMap();
    }
}

