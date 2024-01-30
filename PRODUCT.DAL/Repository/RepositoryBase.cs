using Microsoft.EntityFrameworkCore;
using PRODUCT.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRODUCT.DAL.Repository
{
    public class RepositoryBase<T, TKey> : IRepositoryBase<T, TKey> where T : class, new()
    {
        protected readonly ProductDbContext _context;

        protected readonly DbSet<T> Entities;
        public RepositoryBase(ProductDbContext context)
        {
            _context = context;
            Entities = context.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                Entities.Add(entity);
                await SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Insert object {nameof(entity)} failed ", ex);
            }
        }

        public async Task<int> DeleteAsync(TKey id)
        {
            try
            {
                var entity = Entities.Find(id);
                if (entity == null) throw new Exception("Object Not Found Exception");
                Entities.Remove(entity);
                return await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Delete entity failed - ID {id} ", ex);
            }
        }


        async Task<IQueryable<T>> IRepositoryBase<T, TKey>.GetListByPagination(int take, int skip)
        {
            try
            {
                return await Task.Run(() => this.Entities.AsQueryable().Skip(skip).Take(take));
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot retrieve the filtered list of entities ", ex);
            }
        }

        public async Task<T?> GetByIdAsync(TKey id)
        {
            try
            {
                return await Entities.FindAsync(id); ;
            }
            catch (Exception ex)
            {
                throw new Exception($"Cannot retrieve the entity - ID {id} ", ex);
            }
        }

        public async Task<int> GetCountAsync()
        {
            try
            {
                return await Entities.CountAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot get the count of the entities ", ex);
            }
        }

        public async Task<int> UpdateAsync(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                return await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Update object {nameof(entity)} failed ", ex);
            }
        }

        protected async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
