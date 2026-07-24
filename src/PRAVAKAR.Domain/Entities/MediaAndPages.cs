using PRAVAKAR.Domain.Entities.Common;
using PRAVAKAR.Domain.Enums;

namespace PRAVAKAR.Domain.Entities;

/// <summary>Backs the admin Media Library — one row per file physically saved under
/// wwwroot/uploads/&lt;folder&gt;/. Content entities store their own ImagePath string for
/// simple, join-free rendering; this table exists so every uploaded file can be browsed,
/// searched, and reused from one place.</summary>
public class MediaFile : BaseEntity
{
    public string FileName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty; // relative, e.g. /uploads/hotels/xyz.webp
    public UploadFolder Folder { get; set; }
    public string? AltText { get; set; }
    public long FileSizeBytes { get; set; }
    public string? MimeType { get; set; }
    public string? UploadedByUserId { get; set; }
}

/// <summary>A standalone site page (Home, Offers, Events, Dining, Experiences, Contact,
/// Our Story, Our Hotels) — not a Hotel's own page. Carries the page-level fields plus a
/// dynamic PageSections collection for flexible content blocks.</summary>
public class Page : PublishableEntity
{
    public string Slug { get; set; } = string.Empty;      // e.g. "home", "offers", "our-story"
    public string Title { get; set; } = string.Empty;
    public string? Template { get; set; }                 // Razor view name this page renders with

    public ICollection<PageSection> Sections { get; set; } = new List<PageSection>();
    public SeoMetadata? Seo { get; set; }
}

/// <summary>A flexible, ordered content block within a Page — used for things like the
/// Our Story hero/intro/quote copy that don't warrant their own dedicated table.</summary>
public class PageSection : BaseEntity
{
    public int PageId { get; set; }
    public Page? Page { get; set; }
    public string SectionKey { get; set; } = string.Empty; // e.g. "hero", "intro", "teaser"
    public string? Eyebrow { get; set; }
    public string? Heading { get; set; }
    public string? Body { get; set; }
    public string? ImagePath { get; set; }
    public string? CtaLabel { get; set; }
    public string? CtaHref { get; set; }
    public int SortOrder { get; set; }
}

public class Menu : BaseEntity
{
    public string Name { get; set; } = string.Empty; // "Header", "Footer - Company"
    public MenuLocation Location { get; set; }

    public ICollection<MenuItem> Items { get; set; } = new List<MenuItem>();
}

public class MenuItem : BaseEntity
{
    public int MenuId { get; set; }
    public Menu? Menu { get; set; }
    public string Label { get; set; } = string.Empty;
    public string? Url { get; set; }
    public int? ParentMenuItemId { get; set; }
    public MenuItem? ParentMenuItem { get; set; }
    public int SortOrder { get; set; }
}

public class SocialLink : BaseEntity
{
    public string Platform { get; set; } = string.Empty; // Instagram, Facebook, Twitter, LinkedIn
    public string Url { get; set; } = string.Empty;
    public string? Icon { get; set; }
    public int SortOrder { get; set; }
}

/// <summary>Strongly-typed singleton for the settings that used to live in _global.json —
/// one row (Id = 1).</summary>
public class SiteSettings : BaseEntity
{
    public string BookNowLabel { get; set; } = "Book Now";
    public int FooterQuickLinksCount { get; set; } = 5;
}

/// <summary>Free-form key/value overflow for settings that don't need a dedicated column.</summary>
public class SettingEntry : BaseEntity
{
    public string Key { get; set; } = string.Empty;
    public string? Value { get; set; }
    public string? Category { get; set; }
}
