using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Core.Models
{
    public class Company : BaseEntity
    {
        public virtual ICollection<Product>? Product { get; set; }
    }
}
