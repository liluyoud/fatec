using Fatec.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fatec.Api.Controllers
{
    [Route("Pessoas")]
    public class PessoasController : Controller
    {
        private readonly FatecDb db;

        public PessoasController(FatecDb db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<Pessoa> Todos()
        {
            return db.Pessoas.ToList();
        }

        [HttpGet("{id}", Name = "Consultar")]
        public Pessoa Consultar(long id)
        {
            return db.Pessoas.FirstOrDefault(e => e.Id == id);
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody]Pessoa item)
        {
            try
            {
                if (item == null) return BadRequest("Objeto nulo");
                if (!ModelState.IsValid) return BadRequest("Pedido mal formado");
                db.Pessoas.Add(item);
                db.SaveChanges();
            }
            catch
            {
                return BadRequest("Não foi possível adicionar item");
            }
            return new ObjectResult(new { Id = item.Id, Mensagem = "Pessoa adicionada com sucesso."});
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(long id, [FromBody]Pessoa item)
        {
            try
            {
                if (item == null) return BadRequest("Objeto nulo");
                if (item.Id != id || !ModelState.IsValid) return BadRequest("Pedido mal formado");

                var objeto = db.Pessoas.FirstOrDefault(e => e.Id == id);
                if (objeto == null) return NotFound();

                objeto.Nome = item.Nome;
                objeto.Cpf = item.Cpf;
                objeto.Email = item.Email;
                objeto.Telefone = item.Telefone;
                db.Pessoas.Update(objeto);
                db.SaveChanges();
            }
            catch
            {
                return BadRequest("Não foi possível alterar item");
            }
            return new ObjectResult("Item atualizado com sucesso!");
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(long id)
        {
            try
            {
                var objeto = db.Pessoas.FirstOrDefault(e => e.Id == id);
                if (objeto == null) return NotFound();
                db.Pessoas.Remove(objeto);
                db.SaveChanges();
            }
            catch
            {
                return BadRequest("Não foi possível excluir item");
            }
            return new NoContentResult();
        }
    }
}
