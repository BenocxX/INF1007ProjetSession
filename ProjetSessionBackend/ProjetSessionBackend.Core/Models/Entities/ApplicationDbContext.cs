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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        InitializeStructure(modelBuilder);
        InitializeData(modelBuilder);
    }

    private void InitializeStructure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Navigation(u => u.Role)
            .AutoInclude();
        
        modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany()
            .HasForeignKey(u => u.RoleId);
    }

    private void InitializeData(ModelBuilder modelBuilder)
    {
        var now = DateTime.UtcNow; // current datetime
        
        modelBuilder.Entity<Role>().HasData(
            new Role
            {
                RoleId = 1, 
                Name = "Admin",
                CreatedAt = now,
                UpdatedAt = now,
            },
            new Role
            {
                RoleId = 2, 
                Name = "Employee",
                CreatedAt = now,
                UpdatedAt = now,
            },
            new Role
            {
                RoleId = 3, 
                Name = "Client",
                CreatedAt = now,
                UpdatedAt = now,
            }
        );
        
        modelBuilder.Entity<User>().HasData(
            new User
            {
                UserId = 1,
                Firstname = "Admin", 
                Lastname = "Admin", 
                Email = "admin@outlook.com", 
                Phone = "1234567890",
                Password = _hashService.Hash("Omega123*"),
                CreatedAt = now,
                UpdatedAt = now,
                RoleId = 1
            },
            new User
            {
                UserId = 2,
                Firstname = "Bob",
                Lastname = "Dole",
                Email = "bob.dole@outlook.com",
                Phone = "1234567890",
                Password = _hashService.Hash("Omega123*"),
                CreatedAt = now,
                UpdatedAt = now,
                RoleId = 2
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