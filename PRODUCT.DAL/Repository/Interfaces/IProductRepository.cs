using PRODUCT.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRODUCT.DAL.Repository.Interfaces
{
    public interface IProductRepository : IRepositoryBase<Product, int>
    {
        Task<IEnumerable<Product>> GetProductByPagination(int take, int skip);

    }
}
