using TesteBravi.ListaDeContatos.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TesteBravi.ListaDeContatos.Repositories
{
    public interface IPessoasRepository : IRepositoryBase
    {
        public List<Pessoa> GetMany();
        public Pessoa? Get(int id);
        public Pessoa? Add(Pessoa pessoa);
        public Pessoa? Update(int id, Pessoa pessoa);
        public void Delete(int id);
        public bool PessoaExiste(int id);
    }
}
