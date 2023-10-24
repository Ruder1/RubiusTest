using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessLayer.EF
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Division> Divisions { get; set; }

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Data Source=helloapp.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var listDivision = new List<Division>()
            {
                new Division { Id =1, Name = "Финансовый", Subdivision = "Финансовый" },
                new Division { Id = 2, Name = "Логистики", Subdivision = "Финансовый" },
                new Division { Id = 3, Name = "Закупок", Subdivision = "Финансовый" },
                new Division { Id = 4, Name = "Развлечений", Subdivision = "Развлечений" },
                new Division { Id = 5, Name = "Кадров", Subdivision = "Финансовый" }
            };

            var listUser = new List<User>()
            {
               new User { Id = 1, Surname = "Иванов", Name = "Иван", LastName = "Иваныч", Email = "example@example.com", Salary = 150, DivisionId = 1},
                new User { Id = 2, Surname = "Сизов", Name = "Евгений", LastName = "Витальевич", Email = "temp@example.com", Salary = 200, DivisionId = 2 },
                new User { Id = 3, Surname = "Честаков", Name = "Павел", LastName = "Борисович", Email = "Check@example.com", Salary = 300, DivisionId =3 },
                new User { Id = 4, Surname = "Лебидин", Name = "Константин", LastName = "Артемович", Email = "myMail@example.com", Salary = 250, DivisionId =1 },
                new User { Id = 5, Surname = "Шобасов", Name = "Виталий", LastName = "Данилович", Email = "Test@example.com", Salary = 170, DivisionId = 2 },
                new User { Id = 6, Surname = "Кочерга", Name = "Иван", LastName = "Борисович", Email = "Kocherga@example.com", Salary = 120, DivisionId =4 }
            };

            modelBuilder.Entity<User>().HasData(listUser);
            modelBuilder.Entity<Division>().HasData(listDivision);
        }


    }
}
