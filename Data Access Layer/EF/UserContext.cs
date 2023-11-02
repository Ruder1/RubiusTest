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

        public DbSet<Enrollment> Enrollments { get; set; } = null!;

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var listDivision = new List<Division>
            {
                new Division { Id = 1, Name = "Финансовый" },
                new Division { Id = 2, Name = "Логистики", ParentId = 1 },
                new Division { Id = 3, Name = "Закупок", ParentId = 1 },
                new Division { Id = 4, Name = "Развлечений" },
                new Division { Id = 5, Name = "Кадров", ParentId = 1 }
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

            var listEnrolments = new List<Enrollment>()
            {
                new Enrollment {DivisionId = 1, UserId = 1},
                new Enrollment {DivisionId = 1, UserId = 3},
                new Enrollment {DivisionId = 2, UserId = 1},
                new Enrollment {DivisionId = 3, UserId = 2},
                new Enrollment {DivisionId = 2, UserId = 4},
                new Enrollment {DivisionId = 4, UserId = 5},
                new Enrollment {DivisionId = 5, UserId = 6},
            };

            modelBuilder.Entity<User>().HasData(listUser);

            modelBuilder.Entity<Division>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name);
                entity.HasOne(x => x.Parent)
                    .WithMany(x => x.Children)
                    .HasForeignKey(x => x.ParentId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasData(listDivision);
            });

            modelBuilder.Entity<Enrollment>().HasData(listEnrolments);

            modelBuilder.Entity<User>()
                .HasMany(d => d.Divisions)
                .WithMany(u => u.Users)
                .UsingEntity<Enrollment>();
        }
    }
}
