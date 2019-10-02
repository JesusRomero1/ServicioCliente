using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServicio.Models
{
    public class ABDContext : DbContext
    {
        public ABDContext(DbContextOptions<ABDContext> options)
            :base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
