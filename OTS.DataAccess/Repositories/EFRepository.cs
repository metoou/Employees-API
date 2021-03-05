using Microsoft.EntityFrameworkCore;
using OTS.Core.Abstractions.Repositories;
using OTS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.DataAccess.Repositories
{
    public class EFRepository<T>
        : IRepository<T>
        where T :BaseEntity
    {
        protected IEnumerable<T> Data { get; set; }

        private readonly AppDbContext _context;
        public EFRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await _context.Set<T>().ToListAsync();
            return entities;
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            return entity;

        }
        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

        }
        public async Task UpdateAsync(T entity)
        {
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();

        }
        public Task<IEnumerable<T>> GetByCondition(Func<T, bool> predicate)
        {
            var data = Data as List<T>;
            return Task.FromResult(data.Where(predicate).AsEnumerable());
        }

    }
}
