using CodeChallenge.Core.DTOs;
using CodeChallenge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Core.Services.Interfaces
{
    public interface IBaseService<T, S> 
        where T : BaseEntity
        where S : BaseEntityDTO
    {
        Task<IEnumerable<S>> GetAll(Expression<Func<T, bool>>? predicate, params string[]? includeProperties);
        Task<S> Get(Expression<Func<T, bool>>? predicate, params string[]? includeProperties);
        Task<S> Insert(S entity);
        Task<bool> Delete(int id);
        Task<bool> Update(S entity);
    }
}
