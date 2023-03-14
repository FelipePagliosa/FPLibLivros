﻿// <auto-generated />
using LibraryLivros.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryLivros.Infra.Migrations
{
    [DbContext(typeof(LibraryLivrosContext))]
    [Migration("20230314070950_TremAcompHistorico04")]
    partial class TremAcompHistorico04
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("LibraryLivros.Domain.Models.Livro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Autor")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("QuantidadePaginas")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Livro");
                });

            modelBuilder.Entity("LibraryLivros.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdUserGateway")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("LivroUser", b =>
                {
                    b.Property<int>("LivrosId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LivrosId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("LivroUser");
                });

            modelBuilder.Entity("LivroUser", b =>
                {
                    b.HasOne("LibraryLivros.Domain.Models.Livro", null)
                        .WithMany()
                        .HasForeignKey("LivrosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryLivros.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
