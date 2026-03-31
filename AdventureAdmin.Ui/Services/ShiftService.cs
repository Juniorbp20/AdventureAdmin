using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class ShiftService(AdventureWorksContext context
    ) : Aplicada1.Core.IService<Shift, int>

{
    public Task<Shift?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Shift>> GetList(Expression<Func<Shift, bool>> criterio)
    {
        return await context.Shifts
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(Shift entidad)
    {
        await context.Shifts.AddAsync(entidad);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
