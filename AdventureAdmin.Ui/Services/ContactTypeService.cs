using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services
{
    public class ContactTypeService(AdventureWorksContext context
        ) : Aplicada1.Core.IService<Data.Models.ContactType, int>
    {
        public Task<ContactType?> Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ContactType>> GetList(Expression<Func<ContactType, bool>> criterio)
        {
            return await context.ContactTypes
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<bool> Guardar(ContactType entidad)
        {
            await context.ContactTypes.AddAsync(entidad);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }
    }
}
