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
    }
}
