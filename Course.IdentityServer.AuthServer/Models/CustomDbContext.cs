using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using Microsoft.EntityFrameworkCore;

namespace Course.IdentityServer.AuthServer.Model
{
    public class CustomDbContext : DbContext
    {
        public CustomDbContext(DbContextOptions opts):base(opts)
        {
            
        }

        public DbSet<CustomUser> CustomUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomUser>().HasData(new List<CustomUser>()
            {
                new CustomUser
                {
                    Id = 1,
                    Email = "mikbal1@outlook.com",
                    Password = "1234",
                    City = "ist1",
                    UserName = "mikbal1"
                },
                new CustomUser
                {
                    Id = 2,
                    Email = "mikbal2@outlook.com",
                    Password = "1234",
                    City = "ist2",
                    UserName = "mikbal2"
                },
                new CustomUser
                {
                    Id = 3,
                    Email = "mikbal3@outlook.com",
                    Password = "1234",
                    City = "ist3",
                    UserName = "mikbal3"
                }
            });
            base.OnModelCreating(modelBuilder);
        }
    }
    
}
