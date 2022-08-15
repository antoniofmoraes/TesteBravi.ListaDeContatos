using Microsoft.EntityFrameworkCore;
using TesteBravi.ListaDeContatos.Data;
using TesteBravi.ListaDeContatos.Exceptions;
using TesteBravi.ListaDeContatos.Models;

namespace TesteBravi.ListaDeContatos.Repositories
{
    public class ContatosRepository : RepositoryBase, IContatosRepository
    {
        private readonly ListaDeContatosContext _context;

        public ContatosRepository(ListaDeContatosContext context) : base(context)
        {
            _context = context;
        }

        public List<Contato> GetMany()
        {
            //var result = from Pessoa in _context.Pessoas
            //             join Contato in _context.Contatos on 
            //             select Contato;
            var result = _context.Contatos;
           
            return result.ToList();
        }

        public List<Contato> GetManyByPessoaId(int pessoaId)
        {
            var result = _context.Pessoas?
                .Include(p => p.Contatos)?
                .FirstOrDefault(p => p.Id == pessoaId)?
                .Contatos;

            return result;
        }

        public Contato? Get(int id)
        {
            return _context.Contatos.FirstOrDefault(p => p.Id == id);
        }

        public Contato? Add(Contato contato, int pessoaId)
        {
            var pessoa = _context.Pessoas?.Find(pessoaId);

            pessoa.Contatos?.Add(contato);

            return contato;
        }

        public Contato? Update(int id, Contato contato)
        {
            var contatoAtualizado = _context.Contatos.FirstOrDefault(p => p.Id == id);

            if (contato?.Tipo is not null)
            {
                contatoAtualizado.Tipo = contato.Tipo;
            }
            if (contato?.Dado is not null)
            {
                contatoAtualizado.Dado = contato.Dado;
            }

            return contatoAtualizado;
        }

        public void Delete(int id)
        {
            var contato = _context.Contatos.FirstOrDefault(p => p.Id == id);

            _context.Contatos.Remove(contato);
        }

        public bool ContatoExistePorId(int id)
        {
            return _context.Contatos.Any(c => c.Id == id);
        }

        public bool ContatoExistePorTipoDado(int pessoaId, string tipo, string dado)
        {
            var result = _context.Pessoas?
                .Include(p => p.Contatos)?
                .FirstOrDefault(p => p.Id == pessoaId)?
                .Contatos
                .Any(c => c.Tipo == tipo && c.Dado == dado)
                ?? false;

            return result;
        }
    }
}
