namespace Schoolme.Common.Aggregates;

public abstract class AggregateRoot
{
    private readonly List<DomainEvent> _domainEvents = new();
    
    public Guid Id { get; protected set; }

    public int Version { get; private set; } = 1;
    
    public IReadOnlyList<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();
    
    protected void IncrementVersion()
    {
        Version++;
    }
    
    protected void AddDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
    
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}

public abstract record DomainEvent;