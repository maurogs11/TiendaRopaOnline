using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaRopaOnline.DataAccess.DataContext;
using TiendaRopaOnline.Models;

namespace TiendaRopaOnline.DataAccess.Repository
{
    public class ProductRepository : IBaseRepository<Product>
    {
        private readonly TiendaOnlineContext _dbContext;

        public ProductRepository(TiendaOnlineContext context)
        {
            _dbContext = context;
        }

        public async Task<bool> Add(Product entity)
        {
            _dbContext.Products.Add(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            Product entity = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            _dbContext.Products.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Edit(Product entity)
        {
            _dbContext.Products.Update(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Product>> FindAll() =>
            _dbContext.Products;

        public async Task<Product> FindById(int id) =>
            await _dbContext.Products.FindAsync(id);
    }
}
