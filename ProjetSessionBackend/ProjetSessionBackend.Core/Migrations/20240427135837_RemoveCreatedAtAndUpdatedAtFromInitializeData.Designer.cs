﻿// <auto-generated />
using System;
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
    [Migration("20240427135837_RemoveCreatedAtAndUpdatedAtFromInitializeData")]
    partial class RemoveCreatedAtAndUpdatedAtFromInitializeData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MenuMenuItem", b =>
                {
                    b.Property<int>("MenuItemsMenuItemId")
                        .HasColumnType("integer");

                    b.Property<int>("MenusMenuId")
                        .HasColumnType("integer");

                    b.HasKey("MenuItemsMenuItemId", "MenusMenuId");

                    b.HasIndex("MenusMenuId");

                    b.ToTable("MenuMenuItem");
                });

            modelBuilder.Entity("ProjetSessionBackend.Core.Models.Entities.Menu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MenuId"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("MenuId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("ProjetSessionBackend.Core.Models.Entities.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MenuItemId"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MenuId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("MenuItemId");

                    b.ToTable("MenuItem");
                });

            modelBuilder.Entity("ProjetSessionBackend.Core.Models.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RoleId"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

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

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

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

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

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
                            Password = "$2a$12$03LIDJyTvxVQ5IijY9WhYuVbgqeaFNNt/kbXsAuOQKb75J2cEsgmi",
                            Phone = "1234567890",
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            Email = "bob.dole@outlook.com",
                            Firstname = "Bob",
                            Lastname = "Dole",
                            Password = "$2a$12$3yXAFk4muT2zfwGAc8zzy.RR4NojvV1i2fTftZR2mBP8DRN8.0bIm",
                            Phone = "1234567890",
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("MenuMenuItem", b =>
                {
                    b.HasOne("ProjetSessionBackend.Core.Models.Entities.MenuItem", null)
                        .WithMany()
                        .HasForeignKey("MenuItemsMenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetSessionBackend.Core.Models.Entities.Menu", null)
                        .WithMany()
                        .HasForeignKey("MenusMenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
