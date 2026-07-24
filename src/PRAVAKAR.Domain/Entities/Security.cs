using PRAVAKAR.Domain.Entities.Common;
using PRAVAKAR.Domain.Enums;

namespace PRAVAKAR.Domain.Entities;

/// <summary>A granular permission, e.g. "Hotels.Create", "Offers.Delete" — assigned to
/// Identity roles via RolePermission. Kept in the Domain (not Identity) so it can be
/// referenced from anywhere without depending on Identity's assembly.</summary>
public class Permission : BaseEntity
{
    public string Name { get; set; } = string.Empty;     // "Hotels.Create"
    public string Category { get; set; } = string.Empty; // "Hotels"
    public string? Description { get; set; }

    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}

/// <summary>Join table between an Identity role (by Id, kept as a plain string here to
/// avoid a hard dependency on the Identity package from the Domain layer) and a Permission.</summary>
public class RolePermission
{
    public string RoleId { get; set; } = string.Empty;
    public int PermissionId { get; set; }
    public Permission? Permission { get; set; }
}

public class AuditLog : BaseEntity
{
    public string? UserId { get; set; }
    public string? UserName { get; set; }
    public string EntityType { get; set; } = string.Empty; // "Hotel", "Offer", ...
    public string? EntityKey { get; set; }                  // slug or id, as a string
    public AuditAction Action { get; set; }
    public string? Description { get; set; }
    public string? BeforeJson { get; set; }
    public string? AfterJson { get; set; }
    public string? IpAddress { get; set; }
}
