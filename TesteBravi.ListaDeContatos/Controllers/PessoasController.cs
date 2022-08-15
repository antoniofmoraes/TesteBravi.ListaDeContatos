using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteBravi.ListaDeContatos.Data;
using TesteBravi.ListaDeContatos.Exceptions;
using TesteBravi.ListaDeContatos.Models;
using TesteBravi.ListaDeContatos.Repositories;
using TesteBravi.ListaDeContatos.UseCases;

namespace TesteBravi.ListaDeContatos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly GetPessoasUseCase _getPessoasUseCase;
        private readonly GetPessoaUseCase _getPessoaUseCase;
        private readonly InsertPessoaUseCase _insertPessoaUseCase;
        private readonly UpdatePessoaUseCase _updatePessoaUseCase;
        private readonly DeletePessoaUseCase _deletePessoaUseCase;

        public PessoasController(GetPessoasUseCase getPessoasUseCase, GetPessoaUseCase getPessoaUseCase, InsertPessoaUseCase insertPessoaUseCase, UpdatePessoaUseCase updatePessoaUseCase, DeletePessoaUseCase deletePessoaUseCase)
        {
            _getPessoasUseCase = getPessoasUseCase;
            _getPessoaUseCase = getPessoaUseCase;
            _insertPessoaUseCase = insertPessoaUseCase;
            _updatePessoaUseCase = updatePessoaUseCase;
            _deletePessoaUseCase = deletePessoaUseCase;
        }

        // GET: api/Pessoas
        [HttpGet]
        public ActionResult<List<Pessoa>> GetPessoas()
        {
            return _getPessoasUseCase.GetPessoas();
        }

        // GET: api/Pessoas/5
        [HttpGet("{id}")]
        public ActionResult<Pessoa?> GetPessoa(int id)
        {
            return _getPessoaUseCase.GetPessoa(id);
        }

        // PUT: api/Pessoas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult<Pessoa?> PutPessoa(int id, Pessoa pessoa)
        {
            return _updatePessoaUseCase.UpdatePessoa(id, pessoa);
        }

        // POST: api/Pessoas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Pessoa> PostPessoa(Pessoa pessoa)
        {
            return _insertPessoaUseCase.InsertPessoa(pessoa);
        }

        // DELETE: api/Pessoas/5
        [HttpDelete("{id}")]
        public IActionResult DeletePessoa(int id)
        {
            var sucesso = _deletePessoaUseCase.DeletePessoa(id);
            return Ok();
        }
    }
}
