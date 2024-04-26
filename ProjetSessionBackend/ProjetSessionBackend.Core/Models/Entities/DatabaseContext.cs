using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjetSessionBackend.Core.Models.Entities;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuItem> MenuItems { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=projet-session;Username=dev;Password=dev");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("project", "order_status", new[] { "OPEN", "PREPARING", "PICK-UP", "SHIPPED", "PAYED", "ARCHIVED" })
            .HasPostgresEnum("project", "payment_method", new[] { "CASH", "DEBIT", "CREDIT" })
            .HasPostgresEnum("project", "user_type", new[] { "EMPLOYEE", "MANAGER", "ADMIN", "PRESIDENT" })
            .HasPostgresExtension("project", "pgcrypto");

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("pk_client_id");

            entity.ToTable("client", "project");

            entity.HasIndex(e => e.PersonId, "client_person_id_key").IsUnique();

            entity.HasIndex(e => e.UserId, "client_user_id_key").IsUnique();

            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Address)
                .HasColumnType("character varying")
                .HasColumnName("address");
            entity.Property(e => e.CardName)
                .HasColumnType("character varying")
                .HasColumnName("card_name");
            entity.Property(e => e.CardNumber)
                .HasColumnType("character varying")
                .HasColumnName("card_number");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Cvv)
                .HasColumnType("character varying")
                .HasColumnName("cvv");
            entity.Property(e => e.ExpiryDate)
                .HasColumnType("character varying")
                .HasColumnName("expiry_date");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Person).WithOne(p => p.Client)
                .HasForeignKey<Client>(d => d.PersonId)
                .HasConstraintName("fk_client_person_id");

            entity.HasOne(d => d.User).WithOne(p => p.Client)
                .HasForeignKey<Client>(d => d.UserId)
                .HasConstraintName("fk_client_user_id");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("pk_menu_id");

            entity.ToTable("menu", "project");

            entity.Property(e => e.MenuId).HasColumnName("menu_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasDefaultValueSql("project.get_user_id()")
                .HasColumnName("updated_by");
        });

        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity.HasKey(e => e.MenuItemId).HasName("pk_meal_id");

            entity.ToTable("menu_item", "project");

            entity.Property(e => e.MenuItemId).HasColumnName("menu_item_id");
            entity.Property(e => e.Available)
                .HasDefaultValueSql("true")
                .HasColumnName("available");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("0")
                .HasColumnName("price");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasMany(d => d.Menus).WithMany(p => p.MenuItems)
                .UsingEntity<Dictionary<string, object>>(
                    "MenuMenuItem",
                    r => r.HasOne<Menu>().WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_menu_menu_item_menu"),
                    l => l.HasOne<MenuItem>().WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_menu_menu_item_menu_item"),
                    j =>
                    {
                        j.HasKey("MenuItemId", "MenuId").HasName("pk_menu_menu_item");
                        j.ToTable("menu_menu_item", "project");
                    });
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("pk_order_id");

            entity.ToTable("order", "project");

            entity.HasIndex(e => e.ClientId, "order_client_id_key").IsUnique();

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Subtotal)
                .HasPrecision(20, 2)
                .HasDefaultValueSql("0.0")
                .HasColumnName("subtotal");
            entity.Property(e => e.Total)
                .HasPrecision(20, 2)
                .HasDefaultValueSql("0.0")
                .HasColumnName("total");
            entity.Property(e => e.TpsValue)
                .HasDefaultValueSql("5")
                .HasColumnName("tps_value");
            entity.Property(e => e.TvqValue)
                .HasDefaultValueSql("9.975")
                .HasColumnName("tvq_value");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Client).WithOne(p => p.Order)
                .HasForeignKey<Order>(d => d.ClientId)
                .HasConstraintName("fk_client_id");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("pk_person_id");

            entity.ToTable("person", "project");

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Firstname).HasColumnName("firstname");
            entity.Property(e => e.Lastname).HasColumnName("lastname");
            entity.Property(e => e.Phone).HasColumnName("phone");
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.HasKey(e => e.RestaurantId).HasName("pk_restaurant_id");

            entity.ToTable("restaurant", "project");

            entity.HasIndex(e => e.MenuId, "restaurant_menu_id_key").IsUnique();

            entity.Property(e => e.RestaurantId).HasColumnName("restaurant_id");
            entity.Property(e => e.Address)
                .HasColumnType("character varying")
                .HasColumnName("address");
            entity.Property(e => e.MenuId).HasColumnName("menu_id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");

            entity.HasOne(d => d.Menu).WithOne(p => p.Restaurant)
                .HasForeignKey<Restaurant>(d => d.MenuId)
                .HasConstraintName("fk_menu_id");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("pk_role_id");

            entity.ToTable("role", "project");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("pk_user_id");

            entity.ToTable("user", "project");

            entity.HasIndex(e => e.PersonId, "user_person_id_key").IsUnique();

            entity.HasIndex(e => e.RoleId, "user_role_id_key").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.PasswordSalt)
                .HasColumnType("character varying")
                .HasColumnName("password_salt");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Person).WithOne(p => p.User)
                .HasForeignKey<User>(d => d.PersonId)
                .HasConstraintName("fk_user_person_id");

            entity.HasOne(d => d.Role).WithOne(p => p.User)
                .HasForeignKey<User>(d => d.RoleId)
                .HasConstraintName("fk_user_role_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
