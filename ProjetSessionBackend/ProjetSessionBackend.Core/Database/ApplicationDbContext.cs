using Microsoft.EntityFrameworkCore;

namespace ProjetSessionBackend.Core.Database;

// CREATE TABLE IF NOT EXISTS person
// (
//     person_id SERIAL,
//     firstname TEXT,
//     lastname TEXT,
//     email TEXT,
//     phone TEXT,
//     CONSTRAINT pk_person_id PRIMARY KEY (person_id)
// );

public class Person
{
    public int PersonId { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure your model here if needed
    }
}