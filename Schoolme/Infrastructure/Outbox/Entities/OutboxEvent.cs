namespace Schoolme.Infrastructure.Outbox.Entities;

public sealed class OutboxEvent
{
    public int Id { get; set; }
    public string Type { get; private set; }
    public string Data { get; private set; }
    public string IsProcessed { get; private set; }
    public DateTime CreatedAt { get; private set; }
}