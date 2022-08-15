using Microsoft.AspNetCore.Mvc;
using TesteBravi.ListaDeContatos.Repositories;
using TesteBravi.ListaDeContatos.Exceptions;

namespace TesteBravi.ListaDeContatos.UseCases
{
    public class DeletePessoaUseCase : UseCaseBase
    {
        public readonly IPessoasRepository _repository;

        public DeletePessoaUseCase(IPessoasRepository repository)
        {
            _repository = repository;
        }

        public bool DeletePessoa(int id)
        {
            if (!_repository.PessoaExiste(id))
            {
                throw new PessoaNaoEncontradaException();
            }

            _repository.Delete(id);

            bool sucesso = _repository.Save() > 0;

            if (!sucesso)
            {
                throw new Exception();
            }

            return sucesso;
        }
    }
}
