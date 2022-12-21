using CodeChallenge.Core.Interfaces;
using CodeChallenge.Core.Models;
using CodeChallenge.Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Infrastructure.Repositories
{
    public class UnitOfWork<T> : IUnitOfWork<T>
        where T : BaseEntity
    {
        private readonly CodeChallengeContext _context;
        private readonly IRepository<T>  _repository;


        public UnitOfWork(CodeChallengeContext context, IRepository<T> repository)
        {
            _context= context;
            _repository= repository;
        }

        public IRepository<T> Repository => _repository ?? new BaseRepository<T>(_context);
        public void Dispose()
        {
            if (_context == null)
            {
                _context.Dispose();
            }
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
