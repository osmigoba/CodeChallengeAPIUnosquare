using AutoMapper;
using CodeChallenge.Api.Constants;
using CodeChallenge.Api.Entities;
using CodeChallenge.Core.DTOs;
using CodeChallenge.Core.Models;
using CodeChallenge.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IBaseService<Product, ProductDTO> _baseService;

        public ProductController(IBaseService<Product, ProductDTO> baseService)
        {
            _baseService = baseService;
        }
        /// <summary>
        /// Get Every Product.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var productsDTO = await _baseService.GetAll(null, "Company");
            APIResponse response = new APIResponse(Messages.GeneralApplicationSuccess,
                productsDTO,
                false);
            return Ok(response);
        }

        [HttpGet]
        [Route("getProductById/{id:int}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var productDTO = await _baseService.Get(ent => ent.Id == id, "Company");
            var response = new APIResponse(Messages.GeneralApplicationSuccess, 
                productDTO, false);
            return Ok(response);    
        }
        [HttpPost]
        [Route("insertProduct")]
        public async Task<IActionResult> PostProduct([FromBody]ProductDTO productDTO)
        {

            var resultDTO = await _baseService.Insert(productDTO);
            var response = new APIResponse(Messages.GeneralApplicationSuccess,
                resultDTO, false);
            return Ok(response);
        }

        [HttpPut]
        [Route("updateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDTO productDTO)
        {

            var resultService = await _baseService.Update(productDTO);
            if (resultService) 
            {
                var response = new APIResponse(Messages.GeneralApplicationSuccess,
                    productDTO, false);
                return Ok(response);
            }
            return BadRequest(new APIResponse(Messages.ProductNotFound,
                    productDTO, false));

        }

        [HttpDelete]
        [Route("deleteProduct/{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var resultService = await _baseService.Delete(id);
            if (resultService)
            {
                var response = new APIResponse(Messages.ProductDeleted, null, false);
                return Ok(response);
            }
            var responseNotFound = new APIResponse(Messages.ProductNotFound, null, true);
            return BadRequest(responseNotFound);


        }
    }
}
