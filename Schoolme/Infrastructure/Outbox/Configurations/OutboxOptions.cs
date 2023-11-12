namespace Schoolme.Infrastructure.Outbox.Configurations;

public sealed record OutboxOptions
{
    public const string Name = "Outbox";
    public const string SchemaName = "outbox";
    public const string EfHistoryTableName = "__EFMigrationHistory_Outbox";
    
    public bool UseInMemoryOutbox { get; init; } = true;
}