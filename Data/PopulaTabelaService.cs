using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudASPNEW.CORE.Models;
using CrudASPNEW.CORE.Models.Enums;

namespace CrudASPNEW.CORE.Data
{
    public class PopulaTabelaService
    {
        private CrudASPNEWCOREContext _Context;

        public PopulaTabelaService(CrudASPNEWCOREContext context)
        {
            _Context = context;
        }

        public void Popula()
        {
            if (_Context.Depa.Any() ||
                _Context.vendedor.Any() ||
                _Context.RecordeVendas.Any()) { }
            else
            {

            
                Depa d1 = new Depa(1, "Computadores");
                Depa d2 = new Depa(2, "Livros");
                Depa d3 = new Depa(3, "Eletrônicos");
                Depa d4 = new Depa(4, "Roupas");

                Vendedor v1 = new Vendedor(1, "Odair", "Odair12@gmail.com", new DateTime(1998, 04, 21), 1000.0, d1);
                Vendedor v2 = new Vendedor(2, "Ruan" , "Ruan12@gmail.com" , new DateTime(1979, 12, 31), 3500.0, d2);
                Vendedor v3 = new Vendedor(3, "Lucas", "Lucas12@gmail.com", new DateTime(1998, 01, 15), 2200.0, d1);
                Vendedor v4 = new Vendedor(4, "Raul" , "Raul12@gmail.com" , new DateTime(1993, 11, 30), 3000.0, d4);
                Vendedor v5 = new Vendedor(5, "Alex" , "Jose12@gmail.com" , new DateTime(1997, 03, 04), 4000.0, d3);
                Vendedor v6 = new Vendedor(6, "Jose" , "Raul12@gmail.com" , new DateTime(1993, 11, 30), 3000.0, d2);

                RecordeVendas r1 = new RecordeVendas(1, new DateTime(2018, 08, 25), 11000.0, StatusVenda.Pago,v1);
            }

        }
    }
}
