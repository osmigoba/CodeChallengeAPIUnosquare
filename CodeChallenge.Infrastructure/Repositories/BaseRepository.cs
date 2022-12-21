using CodeChallenge.Core.Interfaces;
using CodeChallenge.Core.Models;
using CodeChallenge.Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly CodeChallengeContext _context;
        private readonly DbSet<T> _entities;
        public BaseRepository(CodeChallengeContext context)
        {
            _context= context;
            _entities = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _entities.FirstOrDefaultAsync(reg => reg.Id == id);
        }
        public async Task Insert(T entity)
        {
            await _entities.AddAsync(entity);         
        }

        public void DeleteById(T entity)
        {

            _entities.Remove(entity);
        }



        public async Task Update(T entity)
        {
              _entities.Update(entity);
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? predicate, params string[]? includeProperties)
        {
            IQueryable<T> query = _entities;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties != null)
            {
                query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }
            return await query.ToListAsync();


        }


        public async Task<T?> FirstOrDefault(Expression<Func<T, bool>>? predicate, params string[]? includeProperties)
        {
            IQueryable<T> query = _entities;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties != null)
            {
                query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            }

            return await query.FirstOrDefaultAsync();
        }
    }
}
