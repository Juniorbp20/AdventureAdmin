using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class CountryRegionService(AdventureWorksContext Context
    ) : Aplicada1.Core.IService<CountryRegion, string>
{
    public Task<CountryRegion?> Buscar(string id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<CountryRegion>> GetList(Expression<Func<CountryRegion, bool>> criterio)
    {
        return await Context.CountryRegions
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(CountryRegion entidad)
    {
        await Context.CountryRegions.AddAsync(entidad);
        var cantidad = await Context.SaveChangesAsync();
        return cantidad > 0;
    }
}
