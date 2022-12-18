using System.Security.Claims;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LibraryLivros.Application.Interfaces;
using LibraryLivros.Application.Requests.LivroRequests;
using LibraryLivros.Domain.Enums;
using LibraryLivros.Domain.Exceptions;

namespace LibraryLivros.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LivroController : ControllerBase
{
    private readonly ILivroService _livroService;

    public LivroController(ILivroService livroService)
    {
        _livroService = livroService;
    }


    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _livroService.GetAll());
    }

    [HttpPost]
    public async Task<IActionResult> Post(LivroInsertRequest request)
    {
        try
        {
            await _livroService.Add(request);
            return Ok();
        }
        catch (LibraryLivrosExceptions e)
        {
            return new JsonResult(new { message = e.Message }) { StatusCode = StatusCodes.Status400BadRequest };
        }
        catch (Exception e)
        {
            return new JsonResult(new { message = e.Message }) { StatusCode = StatusCodes.Status500InternalServerError };
        }

    }

    [HttpPut]
    public async Task<IActionResult> Put(LivroUpdateRequest request)
    {
        await _livroService.Update(request);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = nameof(Perfil.Medico))]
    public async Task<IActionResult> Delete(int id)
    {
        await _livroService.Delete(id);
        return Ok();
    }
}

