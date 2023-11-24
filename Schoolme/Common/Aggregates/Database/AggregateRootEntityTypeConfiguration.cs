using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Schoolme.Common.Aggregates.Database;

public abstract class AggregateRootEntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : AggregateRoot
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Ignore(b => b.DomainEvents);
    }
}

