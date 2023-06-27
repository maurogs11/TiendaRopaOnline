using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaRopaOnline.DataAccess.Repository
{
    public interface IBaseRepository<TEntityModel> where TEntityModel : class
    {
        Task<bool> Add(TEntityModel entity);
        Task<bool> Delete(int id);
        Task<bool> Edit(TEntityModel entity);
        Task<TEntityModel> FindById(int id);
        Task<IQueryable<TEntityModel>> FindAll();

    }
}
