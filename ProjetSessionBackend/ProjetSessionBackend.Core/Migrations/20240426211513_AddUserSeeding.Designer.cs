﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjetSessionBackend.Core.Models.Entities;

#nullable disable

namespace ProjetSessionBackend.Core.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240426211513_AddUserSeeding")]
    partial class AddUserSeeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProjetSessionBackend.Core.Database.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RoleId"));

                    b.Property<int>("UserRole")
                        .HasColumnType("integer");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            UserRole = 0
                        },
                        new
                        {
                            RoleId = 2,
                            UserRole = 1
                        },
                        new
                        {
                            RoleId = 3,
                            UserRole = 2
                        });
                });

            modelBuilder.Entity("ProjetSessionBackend.Core.Database.Models.User", b =>
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
                            Phone = "1234567890",
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            Email = "bob.dole@outlook.com",
                            Firstname = "Bob",
                            Lastname = "Dole",
                            Phone = "1234567890",
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("ProjetSessionBackend.Core.Database.Models.User", b =>
                {
                    b.HasOne("ProjetSessionBackend.Core.Database.Models.Role", "Role")
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
