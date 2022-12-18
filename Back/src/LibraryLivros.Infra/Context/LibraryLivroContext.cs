using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryLivros.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryLivros.Infra.Context;

public class LibraryLivrosContext : DbContext
{
    public LibraryLivrosContext(DbContextOptions<LibraryLivrosContext> options) : base(options) { }
    public DbSet<User> User { get; set; }
    public DbSet<Livro> Livro { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
