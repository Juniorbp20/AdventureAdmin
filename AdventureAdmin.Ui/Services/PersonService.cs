using AdventureAdmin.Data.Context;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services
{
    public class PersonService(AdventureWorksContext context)
         : Aplicada1.Core.IService<Data.Models.Person, int>
    {
        public async  Task<Data.Models.Person?> Buscar(int id)
        {
            return await context.People.FindAsync(id);
        }

        public async Task<bool> Eliminar(int id)
        {
            var ubicacion = await context.People.FindAsync(id);
            if (ubicacion == null) return false;

            context.People.Remove(ubicacion);
            var cantidad = await context.SaveChangesAsync();
            return cantidad > 0;
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
