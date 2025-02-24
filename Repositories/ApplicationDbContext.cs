using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<ContactEntity> Contacts { get; set; }

    }
}
