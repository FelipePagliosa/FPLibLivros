using System.Runtime.Serialization;
using LibraryLivros.Domain.Enums;

namespace LibraryLivros.Domain.Models;

public class Livro : BaseModel
{
    public string Nome { get; set; }
    public string Autor { get; set; }
    public string QuantidadePaginas { get; set; }
    public List<User> Users { get; set; }
}


