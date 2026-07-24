using EVENTBOOKING.Domain.Entities.Common;

namespace EVENTBOOKING.Domain.Entities;

/// <summary>The single parent brand (e.g. "Pravakars Hospitality"). One row expected.</summary>
public class Company : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? LogoPath { get; set; }
    public string? Tagline { get; set; }
    public string? Address { get; set; }
    public string? PrimaryEmail { get; set; }
    public string? SecondaryEmail { get; set; }
    public string? PrimaryPhone { get; set; }
    public string? WhatsApp { get; set; }
    public string? CopyrightText { get; set; }
    public string? PolicyLinksText { get; set; }
}

/// <summary>Optional grouping above a Hotel (e.g. "JMD Group"). A Hotel may belong to one.</summary>
public class HotelChain : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? LogoPath { get; set; }
    public string? Description { get; set; }

    public ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
}

/// <summary>
/// The unique root entity for a property — everything else (rooms, gallery, dining,
/// amenities, ...) hangs off this by HotelId. Slug is the human-readable unique key used
/// in URLs and cross-references (Offers.HotelId, EventVenues.HotelId, etc. all point here).
/// </summary>
public class Hotel : PublishableEntity
{
    public string Slug { get; set; } = string.Empty;               // e.g. "hotel-jmk"
    public string ExternalPropertyId { get; set; } = string.Empty; // external booking-engine id
    public int? HotelChainId { get; set; }
    public HotelChain? HotelChain { get; set; }

    public string Name { get; set; } = string.Empty;
    public string? Eyebrow { get; set; }
    public string? Tag { get; set; }
    public string? Address { get; set; }
    public string? Phone1 { get; set; }
    public string? Phone2 { get; set; }
    public string? Email { get; set; }
    public string? WhatsApp { get; set; }
    public string? CheckIn { get; set; }
    public string? CheckOut { get; set; }
    public decimal? Rating { get; set; }
    public int? ReviewCount { get; set; }
    public string? MapQuery { get; set; }
    public string? AirportNote { get; set; }
    public string? AirportNote2 { get; set; }
    public string? ThumbnailImagePath { get; set; }
    public string? BookingUrl { get; set; }
    public string? RoomsSubheading { get; set; }
    public int FooterSortOrder { get; set; }

    // About section
    public string? AboutEyebrow { get; set; }
    public string? AboutHeading { get; set; }
    public string? AboutParagraph { get; set; }
    public string? AboutParagraph2 { get; set; }
    public string? AboutMainImagePath { get; set; }
    public string? AboutFloatingImagePath { get; set; }
    public string? AboutStatNumber { get; set; }
    public string? AboutStatLabel { get; set; }

    // Dining feature block (this property's own in-house dining copy)
    public string? DiningEyebrow { get; set; }
    public string? DiningHeading { get; set; }
    public string? DiningSectionParagraph { get; set; }
    public string? DiningParagraph { get; set; }
    public string? DiningImagePath { get; set; }

    // Business feature block
    public string? BusinessHeading { get; set; }
    public string? BusinessTag { get; set; }
    public string? BusinessParagraph1 { get; set; }
    public string? BusinessParagraph2 { get; set; }
    public string? BusinessImage1Path { get; set; }
    public string? BusinessImage2Path { get; set; }

    public string? FooterBlurb { get; set; }

    // Navigation
    public ICollection<HeroSlide> HeroSlides { get; set; } = new List<HeroSlide>();
    public ICollection<AboutFeature> AboutFeatures { get; set; } = new List<AboutFeature>();
    public ICollection<AboutFeatureCard> AboutFeatureCards { get; set; } = new List<AboutFeatureCard>();
    public ICollection<Room> Rooms { get; set; } = new List<Room>();
    public ICollection<DiningTiming> DiningTimings { get; set; } = new List<DiningTiming>();
    public ICollection<Facility> Facilities { get; set; } = new List<Facility>();
    public ICollection<GalleryImage> GalleryImages { get; set; } = new List<GalleryImage>();
    public ICollection<HotelAmenity> HotelAmenities { get; set; } = new List<HotelAmenity>();
    public SeoMetadata? Seo { get; set; }
}
