using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class LocationServices(AdventureWorksContext context)
    : Aplicada1.Core.IService<Data.Models.Location, int>
{
    public async Task<Data.Models.Location?> Buscar(int id)
    {
        return await context.Locations.FindAsync(id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var ubicacion = await context.Locations.FindAsync(id);
        if (ubicacion == null) return false;

        context.Locations.Remove(ubicacion);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<List<Data.Models.Location>> GetList(Expression<Func<Data.Models.Location, bool>> criterio)
    {
        return await context.Locations
        .Where(criterio)
        .ToListAsync();
    }

    public async Task<bool> Guardar(Data.Models.Location entidad)
    {
        await context.Locations.AddAsync(entidad);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
