using CL.Core.Domain;
using CL.Manager.Interfaces;
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

        // GET: api/<ClientesController>
        [HttpGet]
        //public IEnumerable<Cliente> Get()
        public async Task<IActionResult> Get()
        {
            return Ok(await clienteManager.GetClientesAsync());
            //return Ok(new List<Cliente>() { 
            //  new Cliente { Id = 1, Nome = "Erick Moreira", DataNascimento = new DateTime(1995,04,11)},
            //    new Cliente { Id = 2, Nome = "Raissa Teles", DataNascimento = new DateTime(1993,04,13)}
            //});
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await clienteManager.GetClienteAsync(id));
        }

        // POST api/<ClientesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
