using CrudASPNEW.CORE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudASPNEW.CORE.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudASPNET.CORE.Services
{
    public class DepartmentService
    {
        private readonly CrudASPNETCOREContext __Context;

        public DepartmentService(CrudASPNETCOREContext cotext)
        {
            __Context = cotext;
        }
        
        public async Task<List<Depa>> FindAllAsync()
        {
            return await __Context.Depa.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
