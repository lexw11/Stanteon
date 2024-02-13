using Microsoft.EntityFrameworkCore;
using StanteonApi.Models.Users;

namespace StanteonApi.Models;

public class StanteonContext : DbContext
{
    public StanteonContext(DbContextOptions<StanteonContext> options) : base(options) { }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Member> Members { get; set; } = null!;
    public DbSet<Creator> Creators { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().UseTpcMappingStrategy();
    }

}