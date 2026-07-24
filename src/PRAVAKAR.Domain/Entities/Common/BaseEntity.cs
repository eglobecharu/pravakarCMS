namespace PRAVAKAR.Domain.Entities.Common;

/// <summary>Base for every entity keyed by an auto-increment int.</summary>
public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}

/// <summary>Adds soft publish-state tracking, mirroring the CMS's draft/publish workflow.</summary>
public abstract class PublishableEntity : BaseEntity
{
    public bool IsActive { get; set; } = true;
    public bool IsPublished { get; set; } = false;
    public DateTime? PublishedAt { get; set; }
    public string? LastUpdatedBy { get; set; }
}
