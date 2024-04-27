using Microsoft.EntityFrameworkCore;
using ProjetSessionBackend.Core.Database.Models;
using ProjetSessionBackend.Core.Interfaces.Services;
using ProjetSessionBackend.Core.Services;

namespace ProjetSessionBackend.Core.Database;

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
        modelBuilder.Entity<Role>().HasData(
            new Role { RoleId = 1 },
            new Role { RoleId = 2 },
            new Role { RoleId = 3 }
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
                RoleId = 2
            }
        );
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseNpgsql(ConnectionString);
    }
}