namespace Schoolme.Infrastructure.Students.Database.Configurations;

public sealed record StudentsOptions
{
    public const string Name = "Students";
    public const string SchemaName = "students";
    public const string EfHistoryTableName = "__EFMigrationHistory_Students";
    
    public bool UseInMemory { get; init; } = true;
    public bool UseInMemoryOutbox { get; init; } = true;
}