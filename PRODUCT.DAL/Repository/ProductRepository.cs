using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PRODUCT.DAL.Repository.Interfaces;
using PRODUCT.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRODUCT.DAL.Repository
{
    public class ProductRepository : RepositoryBase<Product, int>, IProductRepository
    {
        private readonly ILogger<ProductRepository> _logger;
        public ProductRepository(ProductDbContext context, ILogger<ProductRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<Product>> GetProductByPagination(int take, int skip)
        {
            try
            {
                return await Task.Run(() => this.Entities.OrderByDescending(item => item.DateCreate).Skip(skip).Take(take));
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot retrieve product", ex);
            }
        }
    }
}
