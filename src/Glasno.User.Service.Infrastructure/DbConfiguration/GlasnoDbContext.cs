using Microsoft.EntityFrameworkCore;

namespace Glasno.User.Service.Infrastructure.DbConfiguration;

public partial class GlasnoDbContext : DbContext
{
    public GlasnoDbContext()
    {
    }

    public GlasnoDbContext(DbContextOptions<GlasnoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Domain.Entities.User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=:5432;Database=glasno_db;Username=glasno;Password=12345");

   
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}