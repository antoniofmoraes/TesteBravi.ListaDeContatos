using Microsoft.EntityFrameworkCore;
using System;
using TesteBravi.ListaDeContatos.Models;

namespace TesteBravi.ListaDeContatos.Data
{
    public class ListaDeContatosContext : DbContext
    {
        public ListaDeContatosContext(DbContextOptions<ListaDeContatosContext> options) : base(options)
        {
        }

        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
