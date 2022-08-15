using Microsoft.EntityFrameworkCore;
using TesteBravi.ListaDeContatos.Data;
using TesteBravi.ListaDeContatos.Exceptions;
using TesteBravi.ListaDeContatos.Models;

namespace TesteBravi.ListaDeContatos.Repositories
{
    public class PessoasRepository : RepositoryBase, IPessoasRepository
    {
        private readonly ListaDeContatosContext _context;

        public PessoasRepository(ListaDeContatosContext context) : base(context)
        {
            _context = context;
        }

        public List<Pessoa> GetMany()
        {
            return _context.Pessoas. Include(p => p.Contatos).ToList();
        }

        public Pessoa? Get(int id)
        {
            return _context.Pessoas.Include(p => p.Contatos).FirstOrDefault(p => p.Id == id);
        }

        public Pessoa? Add(Pessoa pessoa)
        {
            var result = _context.Pessoas.Add(pessoa);

            return result.Entity;
        }

        public Pessoa? Update(int id, Pessoa pessoa)
        {
            var pessoaEdit = _context.Pessoas.Include(p => p.Contatos).FirstOrDefault(p => p.Id == id);

            
            if (pessoa?.Nome is not null)
            {
                pessoaEdit.Nome = pessoa.Nome;
            }
            if (pessoa?.Contatos?.Count() > 0)
            {
                pessoaEdit.Contatos = pessoa.Contatos;
            }

            return pessoaEdit;
        }

        public void Delete(int id)
        {
            var pessoa = _context.Pessoas.Include(pessoa => pessoa.Contatos).FirstOrDefault(p => p.Id == id);

            _context.Pessoas.Remove(pessoa);
        }

        public bool PessoaExiste(int id)
        {
            return _context.Pessoas.Any(c => c.Id == id);
        }
    }
}
