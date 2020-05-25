using Hahn.ApplicatonProcess.May2020.Data.DbContext;
using Hahn.ApplicatonProcess.May2020.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Data.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        protected readonly HahnDbContext _context;
        public GenericRepository(HahnDbContext context)
        {
            _context = context;
        }

        public virtual Task<T> GetItemByIdAsync(int id)
        {
            return _context.Set<T>().Where(c => c.ID.Equals(id)).FirstOrDefaultAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            try 
            {
                entity.UpdatedDate = DateTime.UtcNow;
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public virtual async Task<T> RemoveAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}

