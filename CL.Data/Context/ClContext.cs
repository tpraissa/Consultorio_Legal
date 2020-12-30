using CL.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Data.Context
{
    public class ClContext : DbContext
    {
        //declarar objetos para ser mapeados
        public DbSet<Cliente> Clientes { get; set; }

        public ClContext(DbContextOptions options) : base(options)
        {
        }
    }
}
