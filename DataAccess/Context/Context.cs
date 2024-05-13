using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace DataAccess.Context
{
    internal class Context : DbContext
    {
        public Context() 
        {
            bool created = Database.EnsureCreated();
            if (created)
            {
                Debug.WriteLine("Database created");
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-MNTPTOQP\\SQLEXPRESS;Initial Catalog=EksamensCsharpDB;Integrated Security=SSPI; TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ferry>().HasData(new Ferry[]
            {
                new Ferry{Id = 1, Name="FerryExpress", MaxCars = 10},
                new Ferry{Id = 2, Name="Luling Ferry", MaxCars = 15}
            });
            modelBuilder.Entity<Guest>().HasData(new Guest[]
            {
                new Guest{Id = 1, Name = "Maria", Sex = "Female", CarId = null, FerryId = 1},
                new Guest{Id = 2, Name = "Gunner", Sex = "Male", CarId = 1, FerryId = null},
                new Guest{Id = 3, Name = "Emily", Sex = "Female", CarId = null, FerryId = 2}
            });

            modelBuilder.Entity<Car>().HasData(new Car[]
            {
                new Car{Id = 1, NumberPlate = "DF12345", FerryId = 1}
            });
        }

        public DbSet<Ferry> Ferries { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
