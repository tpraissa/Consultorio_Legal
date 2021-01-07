using CL.Core.Domain;
using CL.Core.Shared.ModelViews;
using CL.Manager.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CL.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteManager clienteManager;

        public ClientesController(IClienteManager clienteManager)
        {
            this.clienteManager = clienteManager;
        }

        /// <summary>
        /// Retorna todos os Clientes.
        /// </summary>

        [HttpGet]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            return Ok(await clienteManager.GetClientesAsync());
            //return Ok(new List<Cliente>() { 
            //  new Cliente { Id = 1, Nome = "Erick Moreira", DataNascimento = new DateTime(1995,04,11)},
            //    new Cliente { Id = 2, Nome = "Raissa Teles", DataNascimento = new DateTime(1993,04,13)}
            //});
        }

        /// <summary>
        /// Retorna um cliente buscado pelo Id.
        /// </summary>
        /// <param name="id">Id do cliente.</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await clienteManager.GetClienteAsync(id));
        }

        /// <summary>
        /// Cria um novo cliente na base de dados
        /// </summary>
        /// <param name="novoCliente">As informações do novo cliente.</param>
        [HttpPost]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(NovoCliente novoCliente)
        {
            var clienteInserido = await clienteManager.InsertClienteAsync(novoCliente);
            return CreatedAtAction(nameof(Get), new { id = clienteInserido.Id }, clienteInserido);
        }

        /// <summary>
        /// Altera as informações do cliente pelo seu Id.
        /// </summary>
        /// <param name="alterarCliente">Atualiza os dados do cliente</param>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(AlterarCliente alterarCliente)
        {
            var clienteAtualizado = await clienteManager.UpdateClienteAsync(alterarCliente);
            if (clienteAtualizado == null)
            {
                return NotFound();
            }
            return Ok(clienteAtualizado);
        }

        /// <summary>
        /// Exclui o Cliente da base de dados pelo seu Id.
        /// </summary>
        /// <param name="id">Id do cliente a ser excluido.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await clienteManager.DeleteClienteAsync(id);
            return NoContent();
        }
    }
}
