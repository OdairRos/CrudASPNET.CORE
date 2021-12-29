using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CrudASPNEW.CORE.Models;

namespace CrudASPNEW.CORE.Data
{
    public class CrudASPNEWCOREContext : DbContext
    {
        public CrudASPNEWCOREContext(DbContextOptions<CrudASPNEWCOREContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
    }
}
