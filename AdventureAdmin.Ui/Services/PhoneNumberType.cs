using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class PhoneNumberType(AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.PhoneNumberType, int>
{
    public Task<Data.Models.PhoneNumberType?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Data.Models.PhoneNumberType>> GetList(Expression<Func<Data.Models.PhoneNumberType, bool>> criterio)
    {
        return context.PhoneNumberTypes
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(Data.Models.PhoneNumberType entidad)
    {
        await context.PhoneNumberTypes.AddAsync(entidad);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
