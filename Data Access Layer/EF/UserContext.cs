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
        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Division> Divisions { get; set; } = null!;

        public DbSet<UserDivision> UsersDivisions { get; set; }

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {}

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
                new User { Id = 1, Surname = "Иванов", Name = "Иван", LastName = "Иваныч", Email = "example@example.com", Salary = 150},
                new User { Id = 2, Surname = "Сизов", Name = "Евгений", LastName = "Витальевич", Email = "temp@example.com", Salary = 200 },
                new User { Id = 3, Surname = "Честаков", Name = "Павел", LastName = "Борисович", Email = "Check@example.com", Salary = 300 },
                new User { Id = 4, Surname = "Лебидин", Name = "Константин", LastName = "Артемович", Email = "myMail@example.com", Salary = 250},
                new User { Id = 5, Surname = "Шобасов", Name = "Виталий", LastName = "Данилович", Email = "Test@example.com", Salary = 170},
                new User { Id = 6, Surname = "Кочерга", Name = "Иван", LastName = "Борисович", Email = "Kocherga@example.com", Salary = 120}
            };

            var listCommonDivisions = new List<UserDivision>()
            {
                new UserDivision{UserDivisionID = 1, UserID = 1, DivisionID = 2},
                new UserDivision{UserDivisionID = 2, UserID = 2, DivisionID = 2},
                new UserDivision{UserDivisionID = 3, UserID = 3, DivisionID = 2},
                new UserDivision{UserDivisionID = 4, UserID = 4, DivisionID = 2},
                new UserDivision{UserDivisionID = 5, UserID = 5, DivisionID = 2},
                new UserDivision{UserDivisionID = 6, UserID = 6, DivisionID = 1},
                 new UserDivision{UserDivisionID = 7, UserID = 1, DivisionID = 4},
                  new UserDivision{UserDivisionID = 8, UserID = 1, DivisionID = 3},
                   new UserDivision{UserDivisionID = 9, UserID = 1, DivisionID = 1},
            };

            modelBuilder.Entity<User>().HasData(listUser);
            modelBuilder.Entity<Division>().HasData(listDivision);
            modelBuilder.Entity<UserDivision>().HasData(listCommonDivisions);

            modelBuilder.Entity<User>()
                .HasMany(d => d.Divisions)
                .WithMany(u => u.Users)
                .UsingEntity(j => j.ToTable("Enrollments"));
        }


    }
}
