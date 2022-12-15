using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FlagsEnumEFCore
{
    internal class MyDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var student = modelBuilder.Entity<User>();
            student.HasKey(s => s.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=localhost;integrated security=True;Database=FlagsEnumEFCore;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
