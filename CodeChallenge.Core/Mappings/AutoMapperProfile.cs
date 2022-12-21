using AutoMapper;
using CodeChallenge.Core.DTOs;
using CodeChallenge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Core.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dst => dst.Company, opt => opt.MapFrom(org => org.Company.Name));
            CreateMap<ProductDTO, Product>();
            CreateMap<Company, CompanyDTO>().ReverseMap();
        }
    }
}
