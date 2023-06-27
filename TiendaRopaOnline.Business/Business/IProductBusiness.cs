using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaRopaOnline.Models;

namespace TiendaRopaOnline.Business.Business
{
    public interface IProductBusiness 
    {
        Task<bool> Add(Product entity);
        Task<bool> Delete(int id);
        Task<bool> Edit(Product entity);
        Task<Product> FindById(int id);
        Task<IQueryable<Product>> FindAll();
    }
}
