using CL.Core.Domain;
using CL.Data.Context;
using CL.Manager.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Data.Repository
{
    public class ClienteRepository : IClienteRepository    
    {
        private readonly ClContext context;

        public ClienteRepository(ClContext context) 
        {
            this.context = context;
        }

        //metodo lista
        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await context.Clientes.AsNoTracking().ToListAsync();
        }   

        //metodo cliente expecifico
        public async Task<Cliente> GetClienteAsync(int id)
        {
            return await context.Clientes.AsNoTracking().Where(c => c.Id == id).FirstOrDefaultAsync();
            //return await context.Clientes.SingleOrDefaultAsync(c => c.Id == id);  
            //return await context.Clientes.FindAsync(id);
        }

        //Insert
        public async Task<Cliente> InsertClienteAsync(Cliente cliente)
        {
            await context.Clientes.AddAsync(cliente);
            await context.SaveChangesAsync();
            return cliente;
        }

        //Update
        public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
        {
            //verificar se cliente ja existe
            var clienteConsultado = await context.Clientes.FindAsync(cliente.Id);
            if (clienteConsultado == null)
            {
                return null;
            }
            //clienteConsultado.Nome = cliente.Nome;
            //clienteConsultado.DataNascimento = cliente.DataNascimento;
            //context.Clientes.Update(clienteConsultado);
            //Forma mais otimizada
            context.Entry(clienteConsultado).CurrentValues.SetValues(cliente);

            await context.SaveChangesAsync();
            return clienteConsultado;            
        }

        //Delete
        public async Task DeleteClienteAsync(int id)
        {
            var clienteConsultado = await context.Clientes.FindAsync(id);
            context.Clientes.Remove(clienteConsultado);
            await context.SaveChangesAsync();
        }

    }
}
