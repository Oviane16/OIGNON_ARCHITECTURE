using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PRODUCT.DAL.Repository.Interfaces
{
    public interface IRepositoryBase<T, TKey>
    {
        Task<IQueryable<T>> GetListByPagination(int take, int skip);
        Task<T?> GetByIdAsync(TKey id);
        Task<T> CreateAsync(T entity);
        Task<int> GetCountAsync();
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(TKey id);

    }
}
