using liveraryIdentity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace liveraryIdentity.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Training> Trainings { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<Rating> Ratings { get; set; }
}
