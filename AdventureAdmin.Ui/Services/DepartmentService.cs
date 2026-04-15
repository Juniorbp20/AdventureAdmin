using AdventureAdmin.Data.Context;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace AdventureAdmin.Ui.Services
{
    public class DepartmentService(AdventureWorksContext context
        ) : Aplicada1.Core.IService<Data.Models.Department, short>
    {
        public async Task<Data.Models.Department?> Buscar(short id)
        {
            return await context.Departments.FindAsync(id);
        }

        public async Task<bool> Eliminar(short id)
        {
            var ubicacion = await context.Departments.FindAsync(id);
            if (ubicacion == null) return false;

            context.Departments.Remove(ubicacion);
            var cantidad = await context.SaveChangesAsync();
            return cantidad > 0;
        }

        public async Task<List<Data.Models.Department>> GetList(Expression<Func<Data.Models.Department, bool>> criterio)
        {
            return await context.Departments
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<bool> Guardar(Data.Models.Department entidad)
        {
            await context.Departments.AddAsync(entidad);
            var cantidad = await context.SaveChangesAsync();
            return cantidad > 0;
        }
    }
}
