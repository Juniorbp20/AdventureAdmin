using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class CountryRegionService(AdventureWorksContext context
    ) : Aplicada1.Core.IService<CountryRegion, string>
{
    public async Task<CountryRegion?> Buscar(string id)
    {
        return await context.CountryRegions.FindAsync(id);
    }

    public async Task<bool> Eliminar(string id)
    {
        var region = await context.CountryRegions.FindAsync(id);
        if (region == null) return false;

        context.CountryRegions.Remove(region);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<List<CountryRegion>> GetList(Expression<Func<CountryRegion, bool>> criterio)
    {
        return await context.CountryRegions
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(CountryRegion entidad)
    {
        await context.CountryRegions.AddAsync(entidad);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
