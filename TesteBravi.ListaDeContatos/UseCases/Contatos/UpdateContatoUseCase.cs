using Microsoft.EntityFrameworkCore;
using TesteBravi.ListaDeContatos.Models;
using TesteBravi.ListaDeContatos.Repositories;
using TesteBravi.ListaDeContatos.Exceptions;

namespace TesteBravi.ListaDeContatos.UseCases
{
    public class UpdateContatoUseCase : UseCaseBase
    {
        public readonly IContatosRepository _repository;

        public UpdateContatoUseCase(IContatosRepository repository)
        {
            _repository = repository;
        }

        public Contato? UpdateContato(int id, Contato contato)
        {
            if (!_repository.ContatoExistePorId(id))
            {
                throw new ContatoNaoEncontradoException();
            }

            var contatoAtualizado = _repository.Update(id, contato);

            _repository.Save();

            return contatoAtualizado;
        }
    }
}
