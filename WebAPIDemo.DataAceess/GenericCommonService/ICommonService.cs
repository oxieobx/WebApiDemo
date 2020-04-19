using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIDemo.DataAceess.GenericCommonService
{
    public interface ICommonService<TEntity> where TEntity : class
    {
        Task<IList<TEntity>> GetAll();
        Task<int> Add(TEntity entity);
        Task<int> Update(TEntity entity);
        Task<int> Delete(int id);
        Task<TEntity> Find(int id);
    }
}
