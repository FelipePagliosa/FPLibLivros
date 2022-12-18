using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryLivros.Domain.Models
{
    public class User : BaseModel
    {
        public List<Livro> Livros { get; set; }
    }
}