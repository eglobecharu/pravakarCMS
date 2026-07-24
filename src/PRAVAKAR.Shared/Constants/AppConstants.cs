namespace PRAVAKAR.Shared.Constants;

public static class Roles
{
    public const string SuperAdmin = "SuperAdmin";
    public const string Admin = "Admin";
    public const string Editor = "Editor";
    public const string ContentManager = "ContentManager";

    public static readonly string[] All = { SuperAdmin, Admin, Editor, ContentManager };
}

public static class PermissionCategories
{
    public const string Hotels = "Hotels";
    public const string Rooms = "Rooms";
    public const string Gallery = "Gallery";
    public const string Offers = "Offers";
    public const string Events = "Events";
    public const string Dining = "Dining";
    public const string Experiences = "Experiences";
    public const string Testimonials = "Testimonials";
    public const string Seo = "Seo";
    public const string Media = "Media";
    public const string Users = "Users";
    public const string Settings = "Settings";
}
