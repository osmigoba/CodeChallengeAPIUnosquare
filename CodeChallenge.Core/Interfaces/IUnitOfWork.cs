using CodeChallenge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Core.Interfaces
{
    public interface IUnitOfWork<T> : IDisposable 
        where T : BaseEntity
    {
        //IRepository<T> Repository { get; }
        IRepository<T> Repository { get; }
        //IRepository<T> CompanyRepository { get; }
        //IProductRepository ProductRepostory { get; }
        Task SaveChangesAsync();

    }
}
