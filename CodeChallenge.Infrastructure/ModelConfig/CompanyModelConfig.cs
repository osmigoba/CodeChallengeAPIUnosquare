using CodeChallenge.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Infrastructure.ModelConfig
{
    public static class CompanyModelConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Company> company)
        {
            company.ToTable("Company");
            company.HasKey(x => x.Id);
            company.Property(x => x.Name).HasMaxLength(50);
            company.Property(x => x.Description).HasMaxLength(200);
        }
    }
}
