using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CrudASPNET.CORE.Services.Exceptions;
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

        #region Find Methods
        public async Task<List<Vendedor>> FindAllAsync()
        {
            return await __Context.vendedor.ToListAsync();
        }
        public async Task<Vendedor> FindByIdAsync(int id)
        {
            return await __Context.vendedor
                .Include(obj => obj.Department)
                .FirstOrDefaultAsync(obj => obj.Id == id);
        }
        #endregion

        #region ControlData Methods
        public async Task InsertAsync(Vendedor obj)
        {
            obj.Id = __Context.vendedor.LastAsync().Id + 1;
            await __Context.AddAsync(obj);
            InsertValueAsync(obj);
        }

        public async Task UpdateAsync(Vendedor obj)
        {
            if (!(await __Context.vendedor.AnyAsync(item => item.Id == obj.Id)))
                throw new NotFoundException("Id not found");

            try
            {
                __Context.Update(obj);
                UpdateValueAsync(obj);
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await __Context.vendedor.FindAsync(id);

                __Context.vendedor.Remove(obj);
                await DeleteValueAsync(obj.Id);
 
            }
            catch (Exception e)
            {
                throw new IntegrityException(e.Message);
            }

        }
        #endregion

        #region Sql Methods
        public async Task InsertValueAsync(Vendedor Item__)
        {
            await __Context.Database.ExecuteSqlCommandAsync(@"SET IDENTITY_INSERT  vendedor ON INSERT INTO vendedor(Id, Name,Email,BirthDate,BaseSalary,DepartmentId) values(@Id, @Name, @Email, @BirthDate, @BaseSalary, @DepartmentId)",
                    new SqlParameter("@Id", Item__.Id),
                    new SqlParameter("@Name", Item__.Name),
                    new SqlParameter("@Email", Item__.Email),
                    new SqlParameter("@BirthDate", Item__.BirthDate),
                    new SqlParameter("@BaseSalary", Item__.BaseSalary),
                    new SqlParameter("@DepartmentId", Item__.DepartmentId)
                    );
        }

        public async Task UpdateValueAsync(Vendedor Item__)
        {
            await __Context.Database.ExecuteSqlCommandAsync(@"UPDATE vendedor SET Name=@Name, Email=@Email, BirthDate=@BirthDate, BaseSalary=@BaseSalary, DepartmentId=@DepartmentId WHERE Id=@Id",
                     new SqlParameter("@Name", Item__.Name),
                     new SqlParameter("@Email", Item__.Email),
                     new SqlParameter("@BirthDate", Item__.BirthDate),
                     new SqlParameter("@BaseSalary", Item__.BaseSalary),
                     new SqlParameter("@DepartmentId", Item__.DepartmentId),
                     new SqlParameter("@Id", Item__.Id)
                     );
        }

        public async Task DeleteValueAsync(int id)
        {
            await __Context.Database.ExecuteSqlCommandAsync("DELETE vendedor where Id = @Id", new SqlParameter("@Id", id));
        }
        #endregion
    }
}
