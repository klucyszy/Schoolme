using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schoolme.Common.Aggregates.Database;
using Schoolme.Domain.Aggregates;
using Schoolme.Domain.Entities;
using Schoolme.Domain.ValueObjects;
using Schoolme.Infrastructure.Outbox.Entities;
using Schoolme.Infrastructure.Students.Database.Configurations;

namespace Schoolme.Infrastructure.Students.Database;

public class StudentsDbContext : DbContext
{
    public StudentsDbContext()
    {
    }

    public StudentsDbContext(DbContextOptions<StudentsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<CourseEnrollment> CourseEnrollments { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<OutboxEvent> Outbox { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(StudentsOptions.SchemaName);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentsDbContext).Assembly);
    }
}

internal sealed class StudentsEntityTypeConfiguration : AggregateRootEntityTypeConfiguration<Student>
{
    public override void Configure(EntityTypeBuilder<Student> builder)
    {
        base.Configure(builder);
        
        builder.OwnsOne(b => b.HomeAddress, builder =>
        {
            builder.Property(p => p.Street)
                .HasColumnName(nameof(HomeAddress.Street))
                .HasMaxLength(450);
            builder.Property(p => p.City)
                .HasColumnName(nameof(HomeAddress.City))
                .HasMaxLength(450);
            builder.Property(p => p.PostalCode)
                .HasColumnName(nameof(HomeAddress.PostalCode))
                .HasMaxLength(20);
            builder.Property(p => p.Country)
                .HasColumnName(nameof(HomeAddress.Country))
                .HasMaxLength(450);
        });
        
        builder.OwnsOne(b => b.PeselNumber, builder =>
        {
            builder.Property(p => p.Value)
                .HasColumnName(nameof(PeselNumber))
                .HasMaxLength(11);
        });
    }
}