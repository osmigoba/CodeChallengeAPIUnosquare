using CodeChallenge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? predicate, params string[]? includeProperties);
        Task<T?> FirstOrDefault(Expression<Func<T, bool>>? predicate, params string[]? includeProperties);
        Task Insert(T entity);
        Task Update(T entity);
        void DeleteById(T entity);
    }
}
