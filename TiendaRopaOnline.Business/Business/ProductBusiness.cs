using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaRopaOnline.DataAccess.Repository;
using TiendaRopaOnline.Models;

namespace TiendaRopaOnline.Business.Business
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IBaseRepository<Product> _repository;

        public ProductBusiness(IBaseRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Add(Product entity) =>
            await _repository.Add(entity);

        public async Task<bool> Delete(int id) =>
            await _repository.Delete(id);

        public async Task<bool> Edit(Product entity) =>
            await _repository.Edit(entity);

        public async Task<IQueryable<Product>> FindAll() =>
            await _repository.FindAll();

        public async Task<Product> FindById(int id) =>
            await _repository.FindById(id);
    }
}
