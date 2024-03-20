using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Database
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "Welcome.db";
            string databasePath = Path.Combine(solutionFolder, databaseFile);
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseUser>().Property(e => e.Id).ValueGeneratedOnAdd();
            
            // Create a user
            var user = new DatabaseUser() { 
                Id = 1,
                Names = "John Doe",
                Password = "password",
                Role = Welcome.Others.UserRolesEnum.ADMIN,
                Expires = DateTime.Now.AddYears(10)
            };

            modelBuilder.Entity<DatabaseUser>().HasData(user);

            var user1 = new DatabaseUser()
            {
                Id = 2,
                Names = "Gaby",
                Password = "123",
                Role = Welcome.Others.UserRolesEnum.ANONYMOUS,
                Expires = DateTime.Now.AddYears(5)
            };

            modelBuilder.Entity<DatabaseUser>().HasData(user1);

            var user2 = new DatabaseUser()
            {
                Id = 3,
                Names = "Petar",
                Password = "1234",
                Role = Welcome.Others.UserRolesEnum.INSPECTOR,
                Expires = DateTime.Now.AddYears(7)
            };

            modelBuilder.Entity<DatabaseUser>().HasData(user2);
        }

        public DbSet<DatabaseUser> Users { get; set; }
    }
}
