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
    public static class ProductModelConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Product> product)
        {
            product.ToTable("Product");
            product.HasKey(x => x.Id);
            product.Property(x => x.Name).HasMaxLength(50).IsRequired();
            product.Property(x => x.Description).HasMaxLength(100);
            product.HasOne(x => x.Company)
                .WithMany(x => x.Product)
                .HasForeignKey(x => x.Company_Id);
            product.Property(x => x.Price).IsRequired();
        }
    }
}
