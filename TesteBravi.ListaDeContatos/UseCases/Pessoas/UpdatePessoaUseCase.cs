using Microsoft.EntityFrameworkCore;
using TesteBravi.ListaDeContatos.Models;
using TesteBravi.ListaDeContatos.Exceptions;
using TesteBravi.ListaDeContatos.Repositories;

namespace TesteBravi.ListaDeContatos.UseCases
{
    public class UpdatePessoaUseCase : UseCaseBase
    {
        public readonly IPessoasRepository _repository;

        public UpdatePessoaUseCase(IPessoasRepository repository)
        {
            _repository = repository;
        }

        public Pessoa UpdatePessoa(int id, Pessoa pessoa)
        {
            if (!_repository.PessoaExiste(id))
            {
                throw new PessoaNaoEncontradaException();
            }

            foreach (var contato in pessoa.Contatos)
            {
                contato.ValidarContato();
            }

            var pessoaAtualizada = _repository.Update(id, pessoa);

            _repository.Save();

            return pessoaAtualizada;
        }
    }
}
