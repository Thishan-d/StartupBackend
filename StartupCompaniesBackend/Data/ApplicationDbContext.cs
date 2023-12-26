using Microsoft.EntityFrameworkCore;
using StartupCompanyDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartupCompanyInfrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<StartupCompany> StartupCompanies { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StartupCompany>().Property(p => p.GrossSales).HasColumnType("decimal(18,4)");
            modelBuilder.Entity<StartupCompany>().Property(p => p.NetSales).HasColumnType("decimal(18,4)");
        }
    }

}
