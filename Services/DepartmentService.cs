using CrudASPNEW.CORE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudASPNEW.CORE.Models;

namespace CrudASPNET.CORE.Services
{
    public class DepartmentService
    {
        private readonly CrudASPNETCOREContext __Context;

        public DepartmentService(CrudASPNETCOREContext cotext)
        {
            __Context = cotext;
        }
        
        public List<Depa> FindAll()
        {
            return __Context.Depa.OrderBy(x => x.Nome).ToList();
        }
    }
}
