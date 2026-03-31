using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class ShipMethodServices(AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.ShipMethod, int>
{
    public Task<ShipMethod?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ShipMethod>> GetList(Expression<Func<ShipMethod, bool>> criterio)
    {
        return await context.ShipMethods
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(ShipMethod entidad)
    {
        await context.ShipMethods.AddAsync(entidad);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
