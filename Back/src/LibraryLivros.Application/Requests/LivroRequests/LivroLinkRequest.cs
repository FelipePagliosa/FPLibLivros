using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryLivros.Application.Requests.LivroRequests
{
    public class LivroLinkRequest
    {
        public int IdLivro { get; set; }
        public int IdUser { get; set; }
    }
}