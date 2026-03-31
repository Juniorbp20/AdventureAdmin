using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class CurrencyService(
    AdventureWorksContext context
    ) : Aplicada1.Core.IService<Currency, string>
{
    public Task<Currency?> Buscar(string id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(string id)
    {
        throw new NotImplementedException();
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
