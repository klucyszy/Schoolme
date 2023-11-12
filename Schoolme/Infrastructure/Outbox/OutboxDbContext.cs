using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schoolme.Infrastructure.Outbox.Configurations;
using Schoolme.Infrastructure.Outbox.Entities;

namespace Schoolme.Infrastructure.Outbox;

internal sealed class OutboxDbContext : DbContext
{
    public OutboxDbContext()
    {
    }

    public OutboxDbContext(DbContextOptions<OutboxDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<OutboxEvent> OutboxEvents { get; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(OutboxOptions.SchemaName);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OutboxDbContext).Assembly);
    }
}

public sealed class OutboxEventEntityTypeConfiguration : IEntityTypeConfiguration<OutboxEvent>
{
    public void Configure(EntityTypeBuilder<OutboxEvent> builder)
    {
        builder.HasKey(b => b.Id);
    }
}