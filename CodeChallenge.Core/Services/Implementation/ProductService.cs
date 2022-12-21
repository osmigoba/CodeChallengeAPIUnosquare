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
    public class ProductService : BaseService<Product, ProductDTO>, IProductService
    {
        private readonly IUnitOfWork<Product> _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork<Product> unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<IEnumerable<ProductDTO>> GetAllInclude()
        {
            var resultQuery = await _unitOfWork.Repository.GetAll(null, "Company");
            var productsDto = _mapper.Map<IEnumerable<ProductDTO>>(resultQuery);
            return productsDto;
        }

        public async Task<ProductDTO> GetByIdInclude(int id)
        {
            var resultQuery = await _unitOfWork.Repository.FirstOrDefault(ent => ent.Id == id, "Company");
            var productDto = _mapper.Map<ProductDTO>(resultQuery);
            return productDto;
        }

    }
}
