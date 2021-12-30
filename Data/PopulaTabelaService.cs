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
         
            
            Depa d1 = new Depa(1, "Computadores");
            Depa d2 = new Depa(2, "Livros");
            Depa d3 = new Depa(3, "Eletrônicos");
            Depa d4 = new Depa(4, "Roupas");

            Vendedor s1 = new Vendedor(1, "Odair", "Odair12@gmail.com", new DateTime(1998, 04, 21), 1000.0, d1);
            Vendedor s2 = new Vendedor(2, "Ruan" , "Ruan12@gmail.com" , new DateTime(1979, 12, 31), 3500.0, d2);
            Vendedor s3 = new Vendedor(3, "Lucas", "Lucas12@gmail.com", new DateTime(1998, 01, 15), 2200.0, d1);
            Vendedor s4 = new Vendedor(4, "Raul" , "Raul12@gmail.com" , new DateTime(1993, 11, 30), 3000.0, d4);
            Vendedor s5 = new Vendedor(5, "Alex" , "Jose12@gmail.com" , new DateTime(1997, 03, 04), 4000.0, d3);
            Vendedor s6 = new Vendedor(6, "Jose" , "Raul12@gmail.com" , new DateTime(1993, 11, 30), 3000.0, d2);

            RecordeVendas r1  = new RecordeVendas(1,  new DateTime(2018, 09, 25), 11000.0,  StatusVenda.Pago, s1);
            RecordeVendas r2  = new RecordeVendas(2,  new DateTime(2018, 09, 04), 7000.00,  StatusVenda.Pago, s5);
            RecordeVendas r3  = new RecordeVendas(3,  new DateTime(2018, 09, 13), 4000.00,  StatusVenda.Cancelado, s4);
            RecordeVendas r4  = new RecordeVendas(4,  new DateTime(2018, 09, 01), 8000.00,  StatusVenda.Pago, s1);
            RecordeVendas r5  = new RecordeVendas(5,  new DateTime(2018, 09, 21), 3000.00,  StatusVenda.Pago, s3);
            RecordeVendas r6  = new RecordeVendas(6,  new DateTime(2018, 09, 15), 2000.00,  StatusVenda.Pago, s1);
            RecordeVendas r7  = new RecordeVendas(7,  new DateTime(2018, 09, 28), 13000.0,  StatusVenda.Pago, s2);
            RecordeVendas r8  = new RecordeVendas(8,  new DateTime(2018, 09, 11), 4000.00,  StatusVenda.Pago, s4);
            RecordeVendas r9  = new RecordeVendas(9,  new DateTime(2018, 09, 14), 11000.0,  StatusVenda.Pendente, s6);
            RecordeVendas r10 = new RecordeVendas(10, new DateTime(2018, 09, 07), 9000.00,  StatusVenda.Pago, s6);
            RecordeVendas r11 = new RecordeVendas(11, new DateTime(2018, 09, 13), 6000.00,  StatusVenda.Pago, s2);
            RecordeVendas r12 = new RecordeVendas(12, new DateTime(2018, 09, 25), 7000.00,  StatusVenda.Pendente, s3);
            RecordeVendas r13 = new RecordeVendas(13, new DateTime(2018, 09, 29), 10000.0,  StatusVenda.Pago, s4);
            RecordeVendas r14 = new RecordeVendas(14, new DateTime(2018, 09, 04), 3000.00,  StatusVenda.Pago, s5);
            RecordeVendas r15 = new RecordeVendas(15, new DateTime(2018, 09, 12), 4000.00,  StatusVenda.Pago, s1);
            RecordeVendas r16 = new RecordeVendas(16, new DateTime(2018, 10, 05), 2000.00,  StatusVenda.Pago, s4);
            RecordeVendas r17 = new RecordeVendas(17, new DateTime(2018, 10, 01), 12000.0,  StatusVenda.Pago, s1);
            RecordeVendas r18 = new RecordeVendas(18, new DateTime(2018, 10, 24), 6000.00,  StatusVenda.Pago, s3);
            RecordeVendas r19 = new RecordeVendas(19, new DateTime(2018, 10, 22), 8000.00,  StatusVenda.Pago, s5);
            RecordeVendas r20 = new RecordeVendas(20, new DateTime(2018, 10, 15), 8000.00, StatusVenda.Pago, s6);
            RecordeVendas r21 = new RecordeVendas(21, new DateTime(2018, 10, 17), 9000.00,  StatusVenda.Pago, s2);
            RecordeVendas r22 = new RecordeVendas(22, new DateTime(2018, 10, 24), 4000.00,  StatusVenda.Pago, s4);
            RecordeVendas r23 = new RecordeVendas(23, new DateTime(2018, 10, 19), 11000.0,  StatusVenda.Cancelado, s2);
            RecordeVendas r24 = new RecordeVendas(24, new DateTime(2018, 10, 12), 8000.00,  StatusVenda.Pago, s5);
            RecordeVendas r25 = new RecordeVendas(25, new DateTime(2018, 10, 31), 7000.00,  StatusVenda.Pago, s3);
            RecordeVendas r26 = new RecordeVendas(26, new DateTime(2018, 10, 06), 5000.00,  StatusVenda.Pago, s4);
            RecordeVendas r27 = new RecordeVendas(27, new DateTime(2018, 10, 13), 9000.00,  StatusVenda.Pendente, s1);
            RecordeVendas r28 = new RecordeVendas(28, new DateTime(2018, 10, 07), 4000.00,  StatusVenda.Pago, s3);
            RecordeVendas r29 = new RecordeVendas(29, new DateTime(2018, 10, 23), 12000.0,  StatusVenda.Pago, s5);
            RecordeVendas r30 = new RecordeVendas(30, new DateTime(2018, 10, 12), 5000.00,   StatusVenda.Pago, s2);


            _Context.Depa.AddRange(d1, d2, d3, d4);

            _Context.vendedor.AddRange(s1, s2, s3, s4, s5, s6);

            _Context.RecordeVendas.AddRange(
                r1, r2, r3, r4, r5, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r17, r18,
                r19, r20, r21, r22, r23, r24, r25, r26, r27,
                r28, r29, r30);

            _Context.SaveChanges();// erro de insert
        }
    }
}
