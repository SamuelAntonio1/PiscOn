using Microsoft.AspNetCore.Mvc;
using PiscOn.Api.Classes.Commands;
using PiscOn.Api.Classes.Models;
using PiscOn.Api.Classes.Repositories;

namespace PiscOn.Api.Controllers
{
    public class ContatosController : Controller
    {
        private readonly ContatoRepository contatoRepository;

        public ContatosController(ContatoRepository contatoRepository)
        {
            this.contatoRepository = contatoRepository;
        }

        [HttpGet("lista")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Contato>> Lista()
        {
            var lista = contatoRepository.Lista();

            return Ok(lista);
        }

        [HttpGet("{codigo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Contato> Recuperar([FromRoute] int codigo)
        {
            if (codigo == 0)
                return BadRequest("Código inválido");

            var contato = contatoRepository.Recuperar(codigo);

            if (contato == null)
                return NotFound();

            return Ok(contato);
        }

        [HttpPost("adicionar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Contato> Adicionar([FromBody] ContatoCommand command)
        {
            var contato = new Contato
            {
                Celular = command.Celular,
                CPF = command.CPF,
                Email = command.Email,
                Nome = command.Nome
            };

            contatoRepository.Inserir(contato);

            return CreatedAtAction(nameof(Adicionar), contato);
        }

        [HttpPut("atualizar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Atualizar([FromBody] ContatoCommand command)
        {
            if (command.Codigo == 0)
                return BadRequest("Código inválido");

            var contato = contatoRepository.Recuperar(command.Codigo);

            if (contato == null)
                return NotFound($"O contato {command.Nome} (CPF {command.CPF}) não existe no banco de dados");

            contato.Nome = command.Nome;
            contato.Email = command.Email; 
            contato.Celular = command.Celular;
            
            contatoRepository.Atualizar(contato);

            return NoContent();
        }

        [HttpDelete("{codigo}/excluir")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Excluir([FromRoute] int codigo)
        {
            if (codigo == 0)
                return BadRequest("Código inválido");

            var contato = contatoRepository.Recuperar(codigo);

            if (contato == null)
                return NotFound();

            contatoRepository.Excluir(contato);

            return Ok();
        }
    }
}
