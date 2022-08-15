using TesteBravi.ListaDeContatos.Repositories;
using TesteBravi.ListaDeContatos.Exceptions;

namespace TesteBravi.ListaDeContatos.UseCases
{
    public class DeleteContatoUseCase : UseCaseBase
    {
        public readonly IContatosRepository _repository;

        public DeleteContatoUseCase(IContatosRepository repository)
        {
            _repository = repository;
        }

        public bool DeleteContato(int id)
        {
            if (!_repository.ContatoExistePorId(id))
            {
                throw new ContatoNaoEncontradoException();
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
