using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services
{
    public class ScrapReasonService(AdventureWorksContext context)
         : Aplicada1.Core.IService<Data.Models.ScrapReason, string>
    {
        public Task<Data.Models.ScrapReason?> Buscar(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Data.Models.ScrapReason>> GetList(Expression<Func<Data.Models.ScrapReason, bool>> criterio)
        {
            return await context.ScrapReasons
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<bool> Guardar(Data.Models.ScrapReason entidad)
        {
            await context.ScrapReasons.AddAsync(entidad);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }
    }
}
