using TesteBravi.ListaDeContatos.Models;
using Microsoft.AspNetCore.Mvc;
using TesteBravi.ListaDeContatos.Data;
using Microsoft.EntityFrameworkCore;
using TesteBravi.ListaDeContatos.Repositories;

namespace TesteBravi.ListaDeContatos.UseCases
{
    public class GetContatosUseCase : UseCaseBase
    {
        public readonly IContatosRepository _repository;

        public GetContatosUseCase(IContatosRepository repository)
        {
            _repository = repository;
        }

        public List<Contato> GetContatos()
        {
            var Contatos = _repository.GetMany();

            return Contatos;
        }
    }
}