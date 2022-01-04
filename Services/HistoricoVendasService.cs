using CrudASPNEW.CORE.Data;
using CrudASPNEW.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace CrudASPNET.CORE.Services
{
    public class HistoricoVendasService
    {
        private readonly CrudASPNETCOREContext __Context;

        public HistoricoVendasService(CrudASPNETCOREContext cotext)
        {
            __Context = cotext;
        }

        public async  Task<List<HistoricoVendas>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in __Context.RecordeVendas select obj;

            if (minDate.HasValue)
                result = result.Where(x => x.Data >= minDate.Value);
            
            if (maxDate.HasValue)
                result = result.Where(x => x.Data <= maxDate.Value);
            

            return await result
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Department)
                .OrderByDescending(x => x.Data)
                .ToListAsync();
        }
        public async Task<List< IGrouping<Depa, HistoricoVendas>>> FindByDateGroupingtAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in __Context.RecordeVendas select obj;

            if (minDate.HasValue)
                result = result.Where(x => x.Data >= minDate.Value);

            if (maxDate.HasValue)
                result = result.Where(x => x.Data <= maxDate.Value);


            return await result
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Department)
                .OrderByDescending(x => x.Data)
                .GroupBy(x => x.Vendedor.Department)
                .ToListAsync();
        }
    }
}
