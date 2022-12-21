using AutoMapper;
using CodeChallenge.Core.DTOs;
using CodeChallenge.Core.Interfaces;
using CodeChallenge.Core.Models;
using CodeChallenge.Core.Services.Interfaces;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Core.Services.Implementation
{
    public class BaseService<T, S> : IBaseService<T, S> 
        where T : BaseEntity
        where S : BaseEntityDTO
    {
        private readonly IUnitOfWork<T> _unitOfWork;
        private readonly IMapper _mapper;
        public BaseService(IUnitOfWork<T> unitOfWork, IMapper mapper)
        {
            _unitOfWork= unitOfWork;
            _mapper= mapper;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _unitOfWork.Repository.FirstOrDefault(ent => ent.Id == id);
            if (entity == null)
            {
                return false;
            }
            _unitOfWork.Repository.DeleteById(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<S> Get(int id)
        {

            var regModel = await _unitOfWork.Repository.FirstOrDefault(ent => ent.Id == id, "Company");
            var regDto = _mapper.Map<S>(regModel);
            return regDto;
        }

        public async Task<S> Get(Expression<Func<T, bool>>? predicate, params string[]? includeProperties)
        {
            var regModel = await _unitOfWork.Repository.FirstOrDefault(predicate, includeProperties);
            var regDto = _mapper.Map<S>(regModel);
            return regDto;
        }

        public async Task<IEnumerable<S>> GetAll()
        {
            
            var regs = await _unitOfWork.Repository.GetAll(null);
            var regsDto = _mapper.Map<IEnumerable<S>>(regs);
            return regsDto;
        }

        public async Task<IEnumerable<S>> GetAll(Expression<Func<T, bool>>? predicate, params string[]? includeProperties)
        {
            var regs = await _unitOfWork.Repository.GetAll(null);
            var regsDto = _mapper.Map<IEnumerable<S>>(regs);
            return regsDto;
        }

        public async Task<S> Insert(S entity)
        {
            var reg = _mapper.Map<T>(entity);
            await _unitOfWork.Repository.Insert(reg);
            await _unitOfWork.SaveChangesAsync();
            var regResponse = _mapper.Map<S>(reg);
            return regResponse;

        }

        public Task<bool> Update(S entity)
        {
            throw new NotImplementedException();
        }
    }
}
