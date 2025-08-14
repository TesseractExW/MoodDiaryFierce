using Microsoft.EntityFrameworkCore;
using MoodDiaryFierce.Models.Databases;

namespace MoodDiaryFierce.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }
    public DbSet<UserModel> Users { get; set; }
    public DbSet<MoodModel> Moods { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
