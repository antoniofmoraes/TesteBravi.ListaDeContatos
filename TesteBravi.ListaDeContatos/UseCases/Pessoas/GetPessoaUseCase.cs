using Microsoft.AspNetCore.Mvc;
using TesteBravi.ListaDeContatos.Exceptions;
using TesteBravi.ListaDeContatos.Models;
using TesteBravi.ListaDeContatos.Repositories;

namespace TesteBravi.ListaDeContatos.UseCases
{
    public class GetPessoaUseCase : UseCaseBase
    {
        public readonly IPessoasRepository _repository;

        public GetPessoaUseCase(IPessoasRepository repository)
        {
            _repository = repository;
        }

        public Pessoa? GetPessoa(int id)
        {
            if (!_repository.PessoaExiste(id))
            {
                throw new PessoaNaoEncontradaException();
            }

            var pessoa = _repository.Get(id);

            return pessoa;
        }
    }
}
