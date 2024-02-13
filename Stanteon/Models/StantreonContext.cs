using Microsoft.EntityFrameworkCore;
using StantreonApi.Models.Users;

namespace StantreonApi.Models;

public class StantreonContext : DbContext
{
    public StantreonContext(DbContextOptions<StantreonContext> options) : base(options) { }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Member> Members { get; set; } = null!;
    public DbSet<Creator> Creators { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().UseTpcMappingStrategy();
    }

}