using Microsoft.EntityFrameworkCore;
using ProjetSessionBackend.Core.Interfaces.Services;
using ProjetSessionBackend.Core.Services;

namespace ProjetSessionBackend.Core.Models.Entities;

public class ApplicationDbContext : DbContext
{
    public static string ConnectionString { get; set; } = string.Empty;
    
    private readonly IHashService _hashService = new HashService();
    
    public ApplicationDbContext() { }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<MenuMenuItem> MenuMenuItems { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<ClientBillingInfo> ClientBillingInfos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        InitializeStructure(modelBuilder);
        InitializeData(modelBuilder);
    }

    private void InitializeStructure(ModelBuilder modelBuilder)
    {
        // Navigation properties
        modelBuilder.Entity<User>()
            .Navigation(user => user.Role)
            .AutoInclude();
        
        modelBuilder.Entity<Menu>()
            .Navigation(menu => menu.MenuItems)
            .AutoInclude();

        // Relationships
        modelBuilder.Entity<User>()
            .HasOne(user => user.Role)
            .WithMany()
            .HasForeignKey(user => user.RoleId);

        modelBuilder.Entity<Menu>()
            .HasMany(menu => menu.MenuItems)
            .WithMany(menuItem => menuItem.Menus);
        
        modelBuilder.Entity<MenuMenuItem>()
            .HasKey(menuMenuItem => new { menuMenuItem.MenuId, menuMenuItem.MenuItemId });

        modelBuilder.Entity<Restaurant>()
            .HasOne(restaurant => restaurant.Menu)
            .WithMany()
            .HasForeignKey(restaurant => restaurant.MenuId);

        modelBuilder.Entity<ClientBillingInfo>()
            .HasOne(clientBillingInfo => clientBillingInfo.User)
            .WithOne();
    }

    private void InitializeData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(
            new Role { RoleId = 1, Name = "Admin" },
            new Role { RoleId = 2, Name = "Employee" },
            new Role { RoleId = 3, Name = "Client" }
        );
        
        modelBuilder.Entity<User>().HasData(
            new User { UserId = 1, Firstname = "Admin", Lastname = "Admin", Email = "admin@outlook.com", Phone = "1234567890", Password = _hashService.Hash("Omega123*"), RoleId = 1 },
            new User { UserId = 2, Firstname = "Bob", Lastname = "Dole", Email = "bob.dole@outlook.com", Phone = "1234567890", Password = _hashService.Hash("Omega123*"), RoleId = 2 },
            new User { UserId = 3, Firstname = "John", Lastname = "Doe", Email = "john.doe@outlook.com", Phone = "1234567890", Password = _hashService.Hash("Omega123*"), RoleId = 3 }
        );

        modelBuilder.Entity<MenuItem>().HasData(
            new List<MenuItem>
            {
                new() { MenuItemId = 1, Name = "Poutine", Description = "Frites, sauce, fromage", Price = new decimal(10.99) },
                new() { MenuItemId = 2, Name = "Pizza", Description = "Tomate, fromage, pepperoni", Price = new decimal(12.99) },
                new() { MenuItemId = 3, Name = "Poulet", Description = "Poulet, frites", Price = new decimal(15.99) },
                new() { MenuItemId = 4, Name = "Salade", Description = "Laitue, tomate, concombre", Price = new decimal(8.99) },
                new() { MenuItemId = 5, Name = "Poisson", Description = "Poisson, riz", Price = new decimal(14.99) },
                new() { MenuItemId = 6, Name = "Pâtes", Description = "Pâtes, sauce, fromage", Price = new decimal(11.99) }
            }
        );
        
        modelBuilder.Entity<Menu>().HasData(
            new List<Menu>
            {
                new() { MenuId = 1, Name = "Menu classique" },
                new() { MenuId = 2, Name = "Menu santé" },
                new() { MenuId = 3, Name = "Menu végétarien" },
                new() { MenuId = 4, Name = "Menu enfant" }
            }
        );

        modelBuilder.Entity<MenuMenuItem>().HasData(
            new List<MenuMenuItem>
            {
                new() { MenuId = 1, MenuItemId = 1 },
                new() { MenuId = 1, MenuItemId = 2 },
                new() { MenuId = 1, MenuItemId = 3 },
                new() { MenuId = 1, MenuItemId = 4 },
                new() { MenuId = 1, MenuItemId = 5 },
                new() { MenuId = 1, MenuItemId = 6 },
                new() { MenuId = 2, MenuItemId = 4 },
                new() { MenuId = 2, MenuItemId = 5 },
                new() { MenuId = 2, MenuItemId = 6 },
                new() { MenuId = 3, MenuItemId = 4 },
                new() { MenuId = 3, MenuItemId = 6 },
                new() { MenuId = 4, MenuItemId = 4 },
                new() { MenuId = 4, MenuItemId = 6 }
            }
        );

        modelBuilder.Entity<Restaurant>().HasData(
            new List<Restaurant>
            {
                new() { RestaurantId = 1, Name = "Sorel-Tracy", Address = "123 rue de la rue", MenuId = 1 },
                new() { RestaurantId = 2, Name = "Montréal", Address = "456 rue de la rue", MenuId = 2 },
                new() { RestaurantId = 3, Name = "Québec", Address = "789 rue de la rue", MenuId = 3 },
                new() { RestaurantId = 4, Name = "Laval", Address = "1011 rue de la rue", MenuId = 4 },
                new() { RestaurantId = 5, Name = "Longueuil", Address = "1213 rue de la rue", MenuId = 1 },
                new() { RestaurantId = 6, Name = "Sherbrooke", Address = "1415 rue de la rue", MenuId = 2 },
                new() { RestaurantId = 7, Name = "Trois-Rivières", Address = "1617 rue de la rue", MenuId = 3 }
            }
        );
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseNpgsql(ConnectionString);
    }
    
    public override int SaveChanges()
    {
        AddTimestamps();
        return base.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        AddTimestamps();
        return await base.SaveChangesAsync();
    }
    
    private void AddTimestamps()
    {
        var entities = ChangeTracker.Entries()
            .Where(entity => entity is
            {
                Entity: BaseEntity, 
                State: EntityState.Added or EntityState.Modified
            });

        foreach (var entity in entities)
        {
            var now = DateTime.UtcNow; // current datetime

            if (entity.State == EntityState.Added)
            {
                ((BaseEntity)entity.Entity).CreatedAt = now;
            }
            ((BaseEntity)entity.Entity).UpdatedAt = now;
        }
    }
}