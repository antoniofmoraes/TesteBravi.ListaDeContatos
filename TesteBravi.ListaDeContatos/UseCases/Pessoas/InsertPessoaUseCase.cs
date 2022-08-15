using Microsoft.EntityFrameworkCore;
using TesteBravi.ListaDeContatos.Models;
using TesteBravi.ListaDeContatos.Repositories;
using TesteBravi.ListaDeContatos.Exceptions;

namespace TesteBravi.ListaDeContatos.UseCases
{
    public class InsertPessoaUseCase : UseCaseBase
    {
        public readonly IPessoasRepository _repository;

        public InsertPessoaUseCase(IPessoasRepository repository)
        {
            _repository = repository;
        }
        
        public Pessoa InsertPessoa(Pessoa pessoa)
        {
            if (pessoa.Nome == null || pessoa.Nome.Length <= 2)
            {
                throw new NomeCurtoOuInexistenteException();
            }

            foreach(var contato in pessoa.Contatos)
            {
                contato.ValidarContato();
            }

            var novaPessoa = _repository.Add(pessoa);
            _repository.Save();

            return novaPessoa;
        }
    }
}
