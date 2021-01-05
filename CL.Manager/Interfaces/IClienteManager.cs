using CL.Core.Domain;
using CL.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CL.Manager.Interfaces
{
    public interface IClienteManager
    {
        Task<Cliente> GetClienteAsync(int id);
        Task DeleteClienteAsync(int id);

        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task<Cliente> InsertClienteAsync(NovoCliente cliente);
        Task<Cliente> UpdateClienteAsync(AlterarCliente cliente);
    }
}