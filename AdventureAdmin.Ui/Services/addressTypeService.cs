using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services
{
    public class addressTypeService(AdventureWorksContext context)
        : Aplicada1.Core.IService<Data.Models.AddressType, string>
    {
        public Task<AddressType?> Buscar(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AddressType>> GetList(Expression<Func<AddressType, bool>> criterio)
        {
            return await context.AddressTypes
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<bool> Guardar(AddressType entidad)
        {
            await context.AddressTypes.AddAsync(entidad);
            var cantidad = await context.SaveChangesAsync();
            return cantidad > 0;
        }
    }
}
