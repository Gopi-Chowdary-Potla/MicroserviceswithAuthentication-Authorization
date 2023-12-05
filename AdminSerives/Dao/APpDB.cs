using AdminSerives.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace AdminSerives.Dao
{
    public class APpDB : DbContext
    {
        public APpDB(DbContextOptions<APpDB> options) : base(options) { 
        }
        public DbSet<Admin> Admin { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Admin>().HasData(new Admin
            {
                Autoid=1,
                Name="Srinu",
                Salary="10000"
            });
            modelBuilder.Entity<Admin>().HasData(new Admin
            {
                Autoid = 2,
                Name="Gopi",
                Salary="20000"
            });
                
        }

    }
}
