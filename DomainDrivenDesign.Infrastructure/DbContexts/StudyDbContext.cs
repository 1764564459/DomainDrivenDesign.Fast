using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DomainDrivenDesign.Infrastructure.Mappings;

namespace DomainDrivenDesign.Infrastructure.DbContexts
{
    public class StudyDbContext:DbContext
    {
        public DbSet<object> Student { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new StudentMap());
        }
    }
}
