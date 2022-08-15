using TesteBravi.ListaDeContatos.Data;
using TesteBravi.ListaDeContatos.Models;
using TesteBravi.ListaDeContatos.Exceptions;
using TesteBravi.ListaDeContatos.Repositories;

namespace TesteBravi.ListaDeContatos.UseCases;

public class GetContatosByPessoaIdUseCase
{
    public readonly IContatosRepository _repository;
    public readonly IPessoasRepository _pessoasRepository;


    public GetContatosByPessoaIdUseCase(IContatosRepository repository, IPessoasRepository pessoasRepository)
    {
        _repository = repository;
        _pessoasRepository = pessoasRepository;
    }

    public List<Contato> GetContatosByPessoaId(int pessoaId)
    {
        if (!_pessoasRepository.PessoaExiste(pessoaId))
        {
            throw new PessoaNaoEncontradaException();
        }

        return _repository.GetManyByPessoaId(pessoaId);
    }

}
