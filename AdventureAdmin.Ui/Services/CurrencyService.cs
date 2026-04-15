using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class CurrencyService(
    AdventureWorksContext context
    ) : Aplicada1.Core.IService<Currency, string>
{
    public async Task<Currency?> Buscar(string id)
    {
        return await context.Currencies.FindAsync(id);
    }

    public async Task<bool> Eliminar(string id)
    {
        var ubicacion = await context.Currencies.FindAsync(id);
        if (ubicacion == null) return false;

        context.Currencies.Remove(ubicacion);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<List<Data.Models.Currency>> GetList(Expression<Func<Data.Models.Currency, bool>> criterio)
    {
        return await context.Currencies
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(Currency entidad)
    {
        await context.Currencies.AddAsync(entidad);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
