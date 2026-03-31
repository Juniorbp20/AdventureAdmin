using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class SpecialOfferService(AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.SpecialOffer, int>
{
    public Task<SpecialOffer?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        
        throw new NotImplementedException();
    }

    public Task<List<SpecialOffer>> GetList(Expression<Func<SpecialOffer, bool>> criterio)
    {
        return Task.FromResult(context.SpecialOffers
            .Where(criterio)
            .ToList());
    }

    public async Task<bool> Guardar(SpecialOffer entidad)
    {
        await context.SpecialOffers.AddAsync(entidad);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
