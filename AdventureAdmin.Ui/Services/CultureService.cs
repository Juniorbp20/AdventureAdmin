using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services
{
    public class CultureService(AdventureWorksContext context)
         : Aplicada1.Core.IService<Data.Models.Culture, string>
    {
        public Task<Culture?> Buscar(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Culture>> GetList(Expression<Func<Culture, bool>> criterio)
        {
            return await context.Cultures
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<bool> Guardar(Culture entidad)
        {
            await context.Cultures.AddAsync(entidad);
            var cantidad = await context.SaveChangesAsync();
            return cantidad > 0;
        }
    }
}
