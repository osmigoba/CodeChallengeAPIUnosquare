using CodeChallenge.Core.DTOs;
using CodeChallenge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Core.Services.Interfaces
{
    public interface IProductService : IBaseService<Product, ProductDTO>
    {
        //Task<IEnumerable<Product>> GetProducts();
        Task<ProductDTO> GetByIdInclude(int id);
        Task<IEnumerable<ProductDTO>> GetAllInclude();
        //Task<Product> InsertProduct(Product entity);
        //Task<bool>  DeleteProduct(int id);
        //Task<bool> UpdateProduct(Product entity);

    }
}
