using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class BusinessEntityService(AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.BusinessEntity, int>
{
    public Task<BusinessEntity?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<BusinessEntity>> GetList(Expression<Func<BusinessEntity, bool>> criterio)
    {
        return await context.BusinessEntities
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(BusinessEntity entidad)
    {
        await context.BusinessEntities.AddAsync(entidad);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
