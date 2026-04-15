using AdventureAdmin.Data.Context;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;


public class CreditCardService(
    AdventureWorksContext context
    ) : IService<Data.Models.CreditCard, int>
{
    public async Task<bool> Guardar(Data.Models.CreditCard nuevaTarjeta)
    {
        await context.CreditCards.AddAsync(nuevaTarjeta);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<Data.Models.CreditCard?> Buscar(int id)
    {
        return await context.CreditCards.FindAsync(id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var region = await context.CreditCards.FindAsync(id);
        if (region == null) return false;

        context.CreditCards.Remove(region);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<List<Data.Models.CreditCard>> GetList(Expression<Func<Data.Models.CreditCard, bool>> criterio)
    {
        return await context.CreditCards
            .Where(criterio)
            .ToListAsync();
    }
}

