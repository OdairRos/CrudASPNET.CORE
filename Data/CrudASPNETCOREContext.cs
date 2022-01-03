using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CrudASPNEW.CORE.Models;

namespace CrudASPNEW.CORE.Data
{
    public class CrudASPNETCOREContext : DbContext
    {
        public CrudASPNETCOREContext (DbContextOptions<CrudASPNETCOREContext> options)
            : base(options)
        {
        }

        public CrudASPNETCOREContext()
        {

        }

        public DbSet<CrudASPNEW.CORE.Models.Depa> Depa { get; set; }
        public DbSet<Vendedor> vendedor { get; set; }
        public DbSet<RecordeVendas> RecordeVendas { get; set; }
    }
}
