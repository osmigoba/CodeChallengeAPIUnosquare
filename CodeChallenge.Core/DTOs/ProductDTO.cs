using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Core.DTOs
{
    public class ProductDTO :  BaseEntityDTO
    {        
        public int? AgeRestriction { get; set; }
        public double Price { get; set; }
        public string? Company { get; set; }
        public int Company_Id { get; set; }
    }
}
