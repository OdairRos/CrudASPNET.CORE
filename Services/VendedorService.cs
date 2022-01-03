using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CrudASPNEW.CORE.Data;
using CrudASPNEW.CORE.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudASPNET.CORE.Services
{
    public class VendedorService
    {
        private readonly CrudASPNETCOREContext __Context;

        public VendedorService(CrudASPNETCOREContext cotext)
        {
            __Context = cotext;
        }

        public List<Vendedor> FindAll()
        {
            return __Context.vendedor.ToList();
        }

        public void Insert(Vendedor obj)
        {
            obj.Id = __Context.vendedor.Last().Id + 1;
            __Context.Add(obj);
            InsertValue(obj);
        }

        public void InsertValue(Vendedor Item__)
        {
            __Context.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT  vendedor ON INSERT INTO vendedor(Id, Name,Email,BirthDate,BaseSalary,DepartmentId) values(@Id, @Name, @Email, @BirthDate, @BaseSalary, @DepartmentId)",
                     new SqlParameter("@Id", Item__.Id),
                     new SqlParameter("@Name", Item__.Name),
                     new SqlParameter("@Email", Item__.Email),
                     new SqlParameter("@BirthDate", Item__.BirthDate),
                     new SqlParameter("@BaseSalary", Item__.BaseSalary),
                     new SqlParameter("@DepartmentId", Item__.DepartmentId)
                     );
        }
    }
}
