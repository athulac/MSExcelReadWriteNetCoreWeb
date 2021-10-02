using Microsoft.EntityFrameworkCore;
using PracticalTest.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Domain
{
    public class ApplicaitonDbContext : DbContext
    {
        public ApplicaitonDbContext(DbContextOptions<ApplicaitonDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
                
        public DbSet<Sat> Sat { get; set; }
        public DbSet<Act> Act { get; set; }        
        public DbSet<Acadamic> Acadamic { get; set; }
        public DbSet<Ethnicity> Ethnicity { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Student> Student { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Status>().HasData(
               new Status { Id = 1, Name = "FT" },
               new Status { Id = 2, Name = "TRANSFER" },
               new Status { Id = 3, Name = "FTFT" },
               new Status { Id = 4, Name = "FTGRAD" }
               );

            modelBuilder.Entity<Ethnicity>().HasData(
             new Ethnicity { Id = 1, Name = "Hispanic" },
             new Ethnicity { Id = 2, Name = "Race/ethnicity unknown" },
             new Ethnicity { Id = 3, Name = "White" },
             new Ethnicity { Id = 4, Name = "Asian" },
             new Ethnicity { Id = 5, Name = "Hispanic" }            
             );
        }
    }
}
