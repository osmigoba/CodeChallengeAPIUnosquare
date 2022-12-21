using CodeChallenge.Core.Models;
using CodeChallenge.Infrastructure.ModelConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Infrastructure.Base
{
    public class CodeChallengeContext : DbContext
    {

        public DbSet<Product> Product { get; set; }
        public DbSet<Company> Company { get; set; }
        public CodeChallengeContext(DbContextOptions<CodeChallengeContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ProductModelConfig.SetEntityBuilder(modelBuilder.Entity<Product>());
            CompanyModelConfig.SetEntityBuilder(modelBuilder.Entity<Company>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
