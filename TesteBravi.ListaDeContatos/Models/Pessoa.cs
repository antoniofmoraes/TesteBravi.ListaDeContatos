using System.Collections.Generic;

namespace TesteBravi.ListaDeContatos.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public List<Contato> Contatos { get; set; } = new List<Contato>();
    }
}
