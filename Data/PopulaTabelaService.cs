using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CrudASPNEW.CORE.Models;
using CrudASPNEW.CORE.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
/*
File nameVariables and nameFunctions default: 
 for function name                =>  NameFunction_
 for normal variable              =>  NameNormalVariable__
 for especial or control Variable =>  __NameEpecialVariable
 */

namespace CrudASPNEW.CORE.Data
{
    public class PopulaTabelaService
    {
        private CrudASPNETCOREContext __Context;

        public HistoricoVendas[] Vendas__ = new HistoricoVendas[30];
        public Depa[] Departamento__ = new Depa[4];
        public Vendedor[] Vendedor__ = new Vendedor[6];

        public PopulaTabelaService(CrudASPNETCOREContext context)
        {
            __Context = context;
        }

        public void Popula()
        {
            if (__Context.Depa.Any() ||
                __Context.vendedor.Any() ||
                __Context.RecordeVendas.Any()) { }
            else
            {
                PopulaObjeto_();

                __Context.Depa.AddRange(Departamento__[0], Departamento__[1], Departamento__[2], Departamento__[3]);

                __Context.vendedor.AddRange(Vendedor__[0], Vendedor__[1], Vendedor__[2], Vendedor__[3], Vendedor__[4], Vendedor__[5]);

                __Context.RecordeVendas.AddRange(
                    Vendas__[0], Vendas__[1], Vendas__[2], Vendas__[3], Vendas__[4], Vendas__[5], Vendas__[6], Vendas__[7], Vendas__[8], Vendas__[9],
                    Vendas__[10], Vendas__[11], Vendas__[12], Vendas__[13], Vendas__[14], Vendas__[15], Vendas__[16], Vendas__[17], Vendas__[18], Vendas__[19],
                        Vendas__[20], Vendas__[21], Vendas__[22], Vendas__[23], Vendas__[24], Vendas__[25], Vendas__[26], Vendas__[27], Vendas__[28], Vendas__[29]);
                InsertAllValues();

            }
        }

        #region Sql Methods
        private void InsertAllValues()
        {
            InsertValues_(Departamento__);
            InsertValues_(Vendedor__);
            InsertValues_(Vendas__);
        }

        private void InsertValues_(Depa[] __objeto)
        {
            foreach (Depa Item__ in __objeto)
            {
                __Context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Depa ON INSERT INTO Depa(Id,Nome) values(@Id, @Nome)",
                    new SqlParameter("@Id", Item__.Id),
                    new SqlParameter("@Nome", Item__.Nome));
            }
        }
        private void InsertValues_(HistoricoVendas[] __objeto)
        {
            foreach (HistoricoVendas Item__ in __objeto)
            {
                __Context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT RecordeVendas ON INSERT INTO RecordeVendas(Id,Data,Quantia,Status,vendedorId) values(@Id,@Data,@Quantia,@Status,@Vendedor)",
                    new SqlParameter("@Id", Item__.Id),
                    new SqlParameter("@Data", Item__.Data),
                    new SqlParameter("@Quantia", Item__.Quantia),
                    new SqlParameter("@Status", Item__.Status),
                    new SqlParameter("@Vendedor", Item__.Vendedor.Id)
                    );
            }
        }
        private void InsertValues_(Vendedor[] __objeto)
        {
            foreach (Vendedor Item__ in __objeto)
            {
                __Context.Database.ExecuteSqlCommand($"SET IDENTITY_INSERT vendedor ON INSERT INTO vendedor(Id,Name,Email,BirthDate,BaseSalary,DepartmentId) values(@Id, @Name, @Email, @BirthDate, @BaseSalary, @DepartmentId)",
                    new SqlParameter("@Id", Item__.Id),
                    new SqlParameter("@Name", Item__.Name),
                    new SqlParameter("@Email", Item__.Email),
                    new SqlParameter("@BirthDate", Item__.BirthDate),
                    new SqlParameter("@BaseSalary", Item__.BaseSalary),
                    new SqlParameter("@DepartmentId", Item__.DepartmentId)
                    );
            }
        }
        #endregion

        #region Functions
        private void PopulaObjeto_()
        {
            Departamento__[0] = new Depa(1, "Computadores");
            Departamento__[1] = new Depa(2, "Livros");
            Departamento__[2] = new Depa(3, "Eletrônicos");
            Departamento__[3] = new Depa(4, "Roupas");

            Vendedor__[0] = new Vendedor(1, "Odair", "Odair12@gmail.com", new DateTime(1998, 04, 21), 1000.0, Departamento__[0]);
            Vendedor__[1] = new Vendedor(2, "Ruan", "Ruan12@gmail.com", new DateTime(1979, 12, 31), 3500.0, Departamento__[1]);
            Vendedor__[2] = new Vendedor(3, "Lucas", "Lucas12@gmail.com", new DateTime(1998, 01, 15), 2200.0, Departamento__[0]);
            Vendedor__[3] = new Vendedor(4, "Raul", "Raul12@gmail.com", new DateTime(1993, 11, 30), 3000.0, Departamento__[3]);
            Vendedor__[4] = new Vendedor(5, "Alex", "Jose12@gmail.com", new DateTime(1997, 03, 04), 4000.0, Departamento__[2]);
            Vendedor__[5] = new Vendedor(6, "Jose", "Raul12@gmail.com", new DateTime(1993, 11, 30), 3000.0, Departamento__[1]);


            Vendas__[0] = new HistoricoVendas(1, new DateTime(2018, 09, 25), 11000.0, StatusVenda.Pago, Vendedor__[0]);
            Vendas__[1] = new HistoricoVendas(2, new DateTime(2018, 09, 04), 7000.00, StatusVenda.Pago, Vendedor__[4]);
            Vendas__[2] = new HistoricoVendas(3, new DateTime(2018, 09, 13), 4000.00, StatusVenda.Cancelado, Vendedor__[3]);
            Vendas__[3] = new HistoricoVendas(4, new DateTime(2018, 09, 01), 8000.00, StatusVenda.Pago, Vendedor__[0]);
            Vendas__[4] = new HistoricoVendas(5, new DateTime(2018, 09, 21), 3000.00, StatusVenda.Pago, Vendedor__[2]);
            Vendas__[5] = new HistoricoVendas(6, new DateTime(2018, 09, 15), 2000.00, StatusVenda.Pago, Vendedor__[0]);
            Vendas__[6] = new HistoricoVendas(7, new DateTime(2018, 09, 28), 13000.0, StatusVenda.Pago, Vendedor__[1]);
            Vendas__[7] = new HistoricoVendas(8, new DateTime(2018, 09, 11), 4000.00, StatusVenda.Pago, Vendedor__[3]);
            Vendas__[8] = new HistoricoVendas(9, new DateTime(2018, 09, 14), 11000.0, StatusVenda.Pendente, Vendedor__[5]);
            Vendas__[9] = new HistoricoVendas(10, new DateTime(2018, 09, 07), 9000.00, StatusVenda.Pago, Vendedor__[5]);
            Vendas__[10] = new HistoricoVendas(11, new DateTime(2018, 09, 13), 6000.00, StatusVenda.Pago, Vendedor__[1]);
            Vendas__[11] = new HistoricoVendas(12, new DateTime(2018, 09, 25), 7000.00, StatusVenda.Pendente, Vendedor__[2]);
            Vendas__[12] = new HistoricoVendas(13, new DateTime(2018, 09, 29), 10000.0, StatusVenda.Pago, Vendedor__[3]);
            Vendas__[13] = new HistoricoVendas(14, new DateTime(2018, 09, 04), 3000.00, StatusVenda.Pago, Vendedor__[4]);
            Vendas__[14] = new HistoricoVendas(15, new DateTime(2018, 09, 12), 4000.00, StatusVenda.Pago, Vendedor__[0]);
            Vendas__[15] = new HistoricoVendas(16, new DateTime(2018, 10, 05), 2000.00, StatusVenda.Pago, Vendedor__[3]);
            Vendas__[16] = new HistoricoVendas(17, new DateTime(2018, 10, 01), 12000.0, StatusVenda.Pago, Vendedor__[0]);
            Vendas__[17] = new HistoricoVendas(18, new DateTime(2018, 10, 24), 6000.00, StatusVenda.Pago, Vendedor__[2]);
            Vendas__[18] = new HistoricoVendas(19, new DateTime(2018, 10, 22), 8000.00, StatusVenda.Pago, Vendedor__[4]);
            Vendas__[19] = new HistoricoVendas(20, new DateTime(2018, 10, 15), 8000.00, StatusVenda.Pago, Vendedor__[5]);
            Vendas__[20] = new HistoricoVendas(21, new DateTime(2018, 10, 17), 9000.00, StatusVenda.Pago, Vendedor__[1]);
            Vendas__[21] = new HistoricoVendas(22, new DateTime(2018, 10, 24), 4000.00, StatusVenda.Pago, Vendedor__[3]);
            Vendas__[22] = new HistoricoVendas(23, new DateTime(2018, 10, 19), 11000.0, StatusVenda.Cancelado, Vendedor__[1]);
            Vendas__[23] = new HistoricoVendas(24, new DateTime(2018, 10, 12), 8000.00, StatusVenda.Pago, Vendedor__[4]);
            Vendas__[24] = new HistoricoVendas(25, new DateTime(2018, 10, 31), 7000.00, StatusVenda.Pago, Vendedor__[2]);
            Vendas__[25] = new HistoricoVendas(26, new DateTime(2018, 10, 06), 5000.00, StatusVenda.Pago, Vendedor__[3]);
            Vendas__[26] = new HistoricoVendas(27, new DateTime(2018, 10, 13), 9000.00, StatusVenda.Pendente, Vendedor__[0]);
            Vendas__[27] = new HistoricoVendas(28, new DateTime(2018, 10, 07), 4000.00, StatusVenda.Pago, Vendedor__[2]);
            Vendas__[28] = new HistoricoVendas(29, new DateTime(2018, 10, 23), 12000.0, StatusVenda.Pago, Vendedor__[4]);
            Vendas__[29] = new HistoricoVendas(30, new DateTime(2018, 10, 12), 5000.00, StatusVenda.Pago, Vendedor__[1]);
        }
        #endregion

    }
}
