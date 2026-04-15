using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services
{
    public class ProductCategoryService(AdventureWorksContext context)
         : Aplicada1.Core.IService<Data.Models.ProductCategory, int>
    {
        public async Task<ProductCategory?> Buscar(int id)
        {
            return await context.ProductCategories.FindAsync(id);
        }

        public async Task<bool> Eliminar(int id)
        {
            var ubicacion = await context.ProductCategories.FindAsync(id);
            if (ubicacion == null) return false;

            context.ProductCategories.Remove(ubicacion);
            var cantidad = await context.SaveChangesAsync();
            return cantidad > 0;
        }

        public  async Task<List<ProductCategory>> GetList(Expression<Func<ProductCategory, bool>> criterio)
        {
            return await context.ProductCategories
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<bool> Guardar(ProductCategory entidad)
        {
            await context.ProductCategories.AddAsync(entidad);
            var resultado = await context.SaveChangesAsync();
            return resultado > 0;
        }
    }
}