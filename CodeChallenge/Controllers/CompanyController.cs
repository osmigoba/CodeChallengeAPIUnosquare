using AutoMapper;
using CodeChallenge.Api.Constants;
using CodeChallenge.Api.Entities;
using CodeChallenge.Core.DTOs;
using CodeChallenge.Core.Models;
using CodeChallenge.Core.Services.Implementation;
using CodeChallenge.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private readonly IBaseService<Company, CompanyDTO> _baseService;
        public CompanyController(IBaseService<Company, CompanyDTO> baseService)
        {

            _baseService= baseService;
        }

        [HttpGet]
        [Route("getCompanies")]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _baseService.GetAll(null);

            APIResponse response = new APIResponse(Messages.GeneralApplicationSuccess,
                companies,
                false);
            return Ok(response);
        }
    }
}
