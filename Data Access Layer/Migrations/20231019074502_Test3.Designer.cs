﻿// <auto-generated />
using DataAccessLayer.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20231019074502_Test3")]
    partial class Test3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DataAccessLayer.Entities.Division", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Subdivision")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Divisions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Финансовый",
                            Subdivision = "Финансовый"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Логистики",
                            Subdivision = "Финансовый"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Закупок",
                            Subdivision = "Финансовый"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Развлечений",
                            Subdivision = "Развлечений"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Кадров",
                            Subdivision = "Финансовый"
                        });
                });

            modelBuilder.Entity("DataAccessLayer.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Salary")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "example@example.com",
                            LastName = "Иваныч",
                            Name = "Иван",
                            Salary = 150,
                            Surname = "Иванов"
                        },
                        new
                        {
                            Id = 2,
                            Email = "temp@example.com",
                            LastName = "Витальевич",
                            Name = "Евгений",
                            Salary = 200,
                            Surname = "Сизов"
                        },
                        new
                        {
                            Id = 3,
                            Email = "Check@example.com",
                            LastName = "Борисович",
                            Name = "Павел",
                            Salary = 300,
                            Surname = "Честаков"
                        },
                        new
                        {
                            Id = 4,
                            Email = "myMail@example.com",
                            LastName = "Артемович",
                            Name = "Константин",
                            Salary = 250,
                            Surname = "Лебидин"
                        },
                        new
                        {
                            Id = 5,
                            Email = "Test@example.com",
                            LastName = "Данилович",
                            Name = "Виталий",
                            Salary = 170,
                            Surname = "Шобасов"
                        },
                        new
                        {
                            Id = 6,
                            Email = "Kocherga@example.com",
                            LastName = "Борисович",
                            Name = "Иван",
                            Salary = 120,
                            Surname = "Кочерга"
                        });
                });

            modelBuilder.Entity("DataAccessLayer.Entities.UserDivision", b =>
                {
                    b.Property<int>("UserDivisionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserDivisionID"));

                    b.Property<int>("DivisionID")
                        .HasColumnType("integer");

                    b.Property<int>("UserID")
                        .HasColumnType("integer");

                    b.HasKey("UserDivisionID");

                    b.HasIndex("DivisionID");

                    b.HasIndex("UserID");

                    b.ToTable("UsersDivisions");

                    b.HasData(
                        new
                        {
                            UserDivisionID = 1,
                            DivisionID = 2,
                            UserID = 1
                        },
                        new
                        {
                            UserDivisionID = 2,
                            DivisionID = 2,
                            UserID = 2
                        },
                        new
                        {
                            UserDivisionID = 3,
                            DivisionID = 2,
                            UserID = 3
                        },
                        new
                        {
                            UserDivisionID = 4,
                            DivisionID = 2,
                            UserID = 4
                        },
                        new
                        {
                            UserDivisionID = 5,
                            DivisionID = 2,
                            UserID = 5
                        },
                        new
                        {
                            UserDivisionID = 6,
                            DivisionID = 1,
                            UserID = 6
                        },
                        new
                        {
                            UserDivisionID = 7,
                            DivisionID = 4,
                            UserID = 1
                        },
                        new
                        {
                            UserDivisionID = 8,
                            DivisionID = 3,
                            UserID = 1
                        },
                        new
                        {
                            UserDivisionID = 9,
                            DivisionID = 1,
                            UserID = 1
                        });
                });

            modelBuilder.Entity("DataAccessLayer.Entities.UserDivision", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.Division", "Division")
                        .WithMany("User")
                        .HasForeignKey("DivisionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Entities.User", "User")
                        .WithMany("Division")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Division");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.Division", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.User", b =>
                {
                    b.Navigation("Division");
                });
#pragma warning restore 612, 618
        }
    }
}
