using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
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
            // Change Accordingly
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-MNTPTOQP\\SQLEXPRESS;Initial Catalog=EksamensCsharpDB;Integrated Security=SSPI; TrustServerCertificate=true");
            //optionsBuilder.UseSqlServer("Data Source=FONMU-FCBTUU1FT\\SQLEXPRESS;Initial Catalog=EksamensCsharpDB;Integrated Security=SSPI; TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ferry>().HasData(new Ferry[]
            {
                new Ferry(1, "FerryExpress", 10),
                new Ferry(2, "Luling Ferry", 15)
            });
            modelBuilder.Entity<Guest>().HasData(new Guest[]
            {
                new Guest(1, "Maria", "Female", null, 1),
                new Guest(2, "Gunner", "Male", 1, null),
                new Guest(3, "Emily", "Female", null, 2)
            });

            modelBuilder.Entity<Car>().HasData(new Car[]
            {
                new Car(1, "DF12345", 1)
            });
        }

        public DbSet<Ferry> Ferries { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
