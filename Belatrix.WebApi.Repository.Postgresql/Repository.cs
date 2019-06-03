using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.WebApi.Repository.Postgresql
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BelatrixDbContext _context;
        public Repository(BelatrixDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<T>> Read()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<bool> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
