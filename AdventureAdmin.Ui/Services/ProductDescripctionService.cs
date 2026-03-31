using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class ProductDescripctionService(AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.ProductDescription, int>
{
    public Task<ProductDescription?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ProductDescription>> GetList(Expression<Func<ProductDescription, bool>> criterio)
    {
        return await context.ProductDescriptions
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(ProductDescription entidad)
    {
        await context.ProductDescriptions.AddAsync(entidad);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
