using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class PhoneNumberTypeService(AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.PhoneNumberType, int>
{
    public async Task<Data.Models.PhoneNumberType?> Buscar(int id)
    {
        return await context.PhoneNumberTypes.FindAsync(id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var ubicacion = await context.PhoneNumberTypes.FindAsync(id);
        if (ubicacion == null) return false;

        context.PhoneNumberTypes.Remove(ubicacion);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
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
