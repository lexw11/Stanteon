using Microsoft.EntityFrameworkCore;

namespace StanteonApi.Models;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; } = null!;
}