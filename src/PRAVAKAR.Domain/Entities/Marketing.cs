using PRAVAKAR.Domain.Entities.Common;

namespace PRAVAKAR.Domain.Entities;

/// <summary>An offer/promotion. Optionally tied to one Hotel (blank = applies to all
/// properties) — drives the header dropdown, homepage section, and offers page from one
/// list instead of three separately maintained copies.</summary>
public class Offer : PublishableEntity
{
    public string Slug { get; set; } = string.Empty; // unique, used in enquiry links
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? ImagePath { get; set; }
    public string? DiscountValue { get; set; }  // e.g. "10%", "3=2", "Free"
    public string? DiscountUnit { get; set; }   // e.g. "Off", "Nights", "Pickup"
    public string? PromoCode { get; set; }
    public int? HotelId { get; set; }
    public Hotel? Hotel { get; set; }
    public int SortOrder { get; set; }
}

/// <summary>A flagship event venue/spotlight. Optionally tied to one Hotel.</summary>
public class EventVenue : PublishableEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Eyebrow { get; set; }
    public string? ImagePath { get; set; }
    public string? AltText { get; set; }
    public string? Description { get; set; }
    public int? HotelId { get; set; }
    public Hotel? Hotel { get; set; }
    public string? CtaLabel { get; set; }
    public int SortOrder { get; set; }

    public ICollection<EventFeature> Features { get; set; } = new List<EventFeature>();
}

public class EventFeature : BaseEntity
{
    public int EventVenueId { get; set; }
    public EventVenue? EventVenue { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Tag { get; set; }
    public int SortOrder { get; set; }
}

/// <summary>A sitewide guest-experience category (not property-specific) — e.g.
/// "Business & Conference", "Signature Restaurants".</summary>
public class ExperienceCategory : PublishableEntity
{
    public string? ImagePath { get; set; }
    public string? AltText { get; set; }
    public string? Eyebrow { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? CtaLabel { get; set; }
    public string? CtaHref { get; set; }
    public int SortOrder { get; set; }
}

public class Testimonial : PublishableEntity
{
    public string Quote { get; set; } = string.Empty;
    public string GuestName { get; set; } = string.Empty;
    public int? HotelId { get; set; }
    public Hotel? Hotel { get; set; }
    public string? Meta { get; set; } // "New Delhi, India · June 2026"
    public int Rating { get; set; } = 5;
    public int SortOrder { get; set; }
}
