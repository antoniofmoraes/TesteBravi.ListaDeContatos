using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteBravi.ListaDeContatos.Models;
using TesteBravi.ListaDeContatos.Repositories;
using TesteBravi.ListaDeContatos.Exceptions;

namespace TesteBravi.ListaDeContatos.UseCases
{
    public class InsertContatoUseCase : UseCaseBase
    {
        public readonly IContatosRepository _repository;
        public readonly IPessoasRepository _pessoasPepository;

        public InsertContatoUseCase(IContatosRepository repository, IPessoasRepository pessoasPepository)
        {
            _repository = repository;
            _pessoasPepository = pessoasPepository;
        }

        public Contato InsertContato(Contato contato, int pessoaId)
        {
            contato.ValidarContato();

            if (_repository.ContatoExistePorTipoDado(pessoaId, contato.Tipo, contato.Dado))
            {
                throw new ContatoJaExistenteException();
            }

            if (!_pessoasPepository.PessoaExiste(pessoaId))
            {
                throw new PessoaNaoEncontradaException();
            }

            var contatoAdicionado = _repository.Add(contato, pessoaId);

            _repository.Save();
            
            return contatoAdicionado;
        }
    }
}
