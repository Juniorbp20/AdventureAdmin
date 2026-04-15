using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services
{
    public class addressTypeService(AdventureWorksContext context)
        : Aplicada1.Core.IService<Data.Models.AddressType, string>
    {
        public async Task<AddressType?> Buscar(string id)
        {
            return await context.AddressTypes.FindAsync(id);
        }

        public async Task<bool> Eliminar(string id)
        {
            var tipo = await context.AddressTypes.FindAsync(id);
            if (tipo == null) return false;

            context.AddressTypes.Remove(tipo);
            var cantidad = await context.SaveChangesAsync();
            return cantidad > 0;
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
