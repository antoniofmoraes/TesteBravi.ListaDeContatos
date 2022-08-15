using Microsoft.AspNetCore.Mvc;
using TesteBravi.ListaDeContatos.Models;
using TesteBravi.ListaDeContatos.Repositories;

namespace TesteBravi.ListaDeContatos.UseCases
{
    public class GetPessoasUseCase : UseCaseBase
    {
        public readonly IPessoasRepository _repository;

        public GetPessoasUseCase(IPessoasRepository repository)
        {
            _repository = repository;
        }

        public List<Pessoa> GetPessoas()
        {
            var pessoas = _repository.GetMany();

            return pessoas;
        }
    }
}
