using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteBravi.ListaDeContatos.Models;
using TesteBravi.ListaDeContatos.UseCases;
using TesteBravi.ListaDeContatos.Exceptions;

namespace TesteBravi.ListaDeContatos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        private readonly GetContatosUseCase _getContatosUseCase;
        private readonly GetContatosByPessoaIdUseCase _getContatosByPessoaIdUseCase;
        private readonly InsertContatoUseCase _insertContatoUseCase;
        private readonly UpdateContatoUseCase _updateContatoUseCase;
        private readonly DeleteContatoUseCase _deleteContatoUseCase;

        public ContatosController(GetContatosUseCase getContatosUseCase, GetContatosByPessoaIdUseCase getContatosByPessoaIdUseCase, InsertContatoUseCase insertContatoUseCase, UpdateContatoUseCase updateContatoUseCase, DeleteContatoUseCase deleteContatoUseCase)
        {
            _getContatosUseCase = getContatosUseCase;
            _getContatosByPessoaIdUseCase = getContatosByPessoaIdUseCase;
            _insertContatoUseCase = insertContatoUseCase;
            _updateContatoUseCase = updateContatoUseCase;
            _deleteContatoUseCase = deleteContatoUseCase;
        }

        // GET: 
        [HttpGet]
        public ActionResult<List<Contato>> GetContatos()
        {
            return _getContatosUseCase.GetContatos();
        }

        // GET: 
        [HttpGet("Pessoas/{pessoaId}/Contatos")]
        public ActionResult<IEnumerable<Contato?>> GetContatosByPessoaId(int pessoaId)
        {
            return _getContatosByPessoaIdUseCase.GetContatosByPessoaId(pessoaId);
        }

        // PUT: 
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult<Contato> PutContato(int id, Contato contato)
        {
            contato.ValidarContato();
            return _updateContatoUseCase.UpdateContato(id, contato);
        }

        // POST: 
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Pessoas/{pessoaId}/Contatos")]
        public ActionResult<Contato> PostContato(Contato contato, int pessoaId)
        {
            return _insertContatoUseCase.InsertContato(contato, pessoaId);
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteContato(int id)
        {
            var sucesso = _deleteContatoUseCase.DeleteContato(id);
            return Ok();
        }
    }
}
