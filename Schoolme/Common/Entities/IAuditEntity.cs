namespace Schoolme.Common.Entities;

public interface IAuditEntity
{
    Guid CreatedBy { get; protected set; }
    DateTimeOffset CreatedOn { get; protected set; }
    Guid? ModifiedBy { get; protected set; }
    DateTimeOffset? ModifiedOn { get; protected set; }

    void AuditCreation(Guid userId)
    {
        CreatedBy = userId;
        CreatedOn = DateTimeOffset.UtcNow;
    }

    void AuditModification(Guid userId)
    {
        ModifiedBy = userId;
        ModifiedOn = DateTimeOffset.UtcNow;
    }
}