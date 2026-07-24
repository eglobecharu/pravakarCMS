using Microsoft.AspNetCore.Identity;

namespace EVENTBOOKING.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
    public string? ProfileImagePath { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class ApplicationRole : IdentityRole
{
    public string? Description { get; set; }

    public ApplicationRole() : base() { }
    public ApplicationRole(string roleName) : base(roleName) { }
}
