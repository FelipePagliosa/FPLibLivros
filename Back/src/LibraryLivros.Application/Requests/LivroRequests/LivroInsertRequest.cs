using LibraryLivros.Domain.Enums;

namespace LibraryLivros.Application.Requests.LivroRequests;

public class LivroInsertRequest
{
    public string Nome { get; set; }
    public string Autor { get; set; }
    public string QuantidadePaginas { get; set; }
}
