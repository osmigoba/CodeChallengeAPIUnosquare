using AutoMapper;
using CodeChallenge.Core.DTOs;
using CodeChallenge.Core.Interfaces;
using CodeChallenge.Core.Models;
using CodeChallenge.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Core.Services.Implementation
{
    public class CompanyService : BaseService<Company, CompanyDTO>, ICompanyService
    {
        private readonly IUnitOfWork<Company> _unitOfWork;
        private readonly IMapper _mapper;
        public CompanyService(IUnitOfWork<Company> unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //public async Task<bool> DeleteCompany(int id)
        //{
        //    var entity = await _unitOfWork.Repository.GetById(id);
        //    if (entity == null)
        //    {
        //        return false;
        //    }
        //    await _unitOfWork.Repository.DeleteById(entity);
        //    return true;
        //}

        //public async Task<IEnumerable<Company>> GetCompanies()
        //{
        //    return await _unitOfWork.Repository.GetAll();
        //}

        //public async Task<Company> GetCompany(int id)
        //{
        //    return await _unitOfWork.Repository.GetById(id);
        //}

        //public async Task<Company> InsertCompany(Company entity)
        //{
        //    await _unitOfWork.Repository.Add(entity);
        //    await _unitOfWork.SaveChangesAsync();
        //    return entity;
        //}

        //public async Task<bool> UpdateCompany(Company entity)
        //{
        //    var company = await _unitOfWork.Repository.GetById(entity.Id);
        //    if (company != null)
        //    {
        //        await _unitOfWork.Repository.Update(entity);
        //        await _unitOfWork.SaveChangesAsync();
        //        return true;
        //    }
        //    return false;
        //}
    }
}
