using AdventureAdmin.Data.Context;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services
{
    public class PersonService(AdventureWorksContext context)
         : Aplicada1.Core.IService<Data.Models.Person, int>
    {
        public Task<Data.Models.Person?> Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Data.Models.Person>> GetList(Expression<Func<Data.Models.Person, bool>> criterio)
        {
            return Task.FromResult(context.People
                .Where(criterio)
                .ToList());
        }

        public async Task<bool> Guardar(Data.Models.Person entidad)
        {
            await context.People.AddAsync(entidad);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }
    }
}
