using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services
{
    public class ProductCategoryService(AdventureWorksContext context)
         : Aplicada1.Core.IService<Data.Models.ProductCategory, int>
    {
        public Task<ProductCategory?> Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
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