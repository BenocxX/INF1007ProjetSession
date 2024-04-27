﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjetSessionBackend.Core.Models.Entities;

#nullable disable

namespace ProjetSessionBackend.Core.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProjetSessionBackend.Core.Models.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RoleId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            RoleId = 2,
                            Name = "Employee"
                        },
                        new
                        {
                            RoleId = 3,
                            Name = "Client"
                        });
                });

            modelBuilder.Entity("ProjetSessionBackend.Core.Models.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "admin@outlook.com",
                            Firstname = "Admin",
                            Lastname = "Admin",
                            Password = "$2a$12$q270ybKSH1s5BR6euoLiXuAOYkVxu9W6HBwGfKTUgUbXnOPWA1fHa",
                            Phone = "1234567890",
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            Email = "bob.dole@outlook.com",
                            Firstname = "Bob",
                            Lastname = "Dole",
                            Password = "$2a$12$E.t9A2pO7pZlxfL4bi72gukjaqI3GGYcd2nI1GtjRo7zs7UOLlqy2",
                            Phone = "1234567890",
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("ProjetSessionBackend.Core.Models.Entities.User", b =>
                {
                    b.HasOne("ProjetSessionBackend.Core.Models.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
