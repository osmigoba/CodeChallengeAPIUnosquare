using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Core.Models
{
    public class Product : BaseEntity
    {

        public int? AgeRestriction { get; set; }
        public double Price { get; set; }
        public int Company_Id { get; set; }
        public virtual Company? Company { get; set; }
    }
}
