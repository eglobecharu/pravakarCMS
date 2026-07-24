using EVENTBOOKING.Domain.Entities.Common;

namespace EVENTBOOKING.Domain.Entities;

/// <summary>One row of editable SEO fields, owned by exactly one Hotel OR one Page
/// (never both) — a shared table instead of duplicating these columns on every content
/// type that needs SEO.</summary>
public class SeoMetadata : BaseEntity
{
    public int? HotelId { get; set; }
    public Hotel? Hotel { get; set; }
    public int? PageId { get; set; }
    public Page? Page { get; set; }

    public string? Title { get; set; }
    public string? MetaDescription { get; set; }
    public string? Keywords { get; set; }
    public string? Canonical { get; set; }
    public string? OgTitle { get; set; }
    public string? OgDescription { get; set; }
    public string? OgImage { get; set; }
    public string? TwitterCard { get; set; }
    public string? Robots { get; set; } = "index, follow";
    public string? SchemaMarkup { get; set; } // raw JSON-LD
}
