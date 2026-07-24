using PRAVAKAR.Domain.Entities;

namespace PRAVAKAR.Domain.Interfaces;

/// <summary>One DbContext-backed transaction boundary, exposing a typed repository per
/// aggregate plus SaveChangesAsync. Services inject this rather than individual
/// repositories, so a multi-entity write commits atomically.</summary>
public interface IUnitOfWork : IDisposable
{
    IRepository<Company> Companies { get; }
    IRepository<HotelChain> HotelChains { get; }
    IRepository<Hotel> Hotels { get; }
    IRepository<HeroSlide> HeroSlides { get; }
    IRepository<AboutFeature> AboutFeatures { get; }
    IRepository<AboutFeatureCard> AboutFeatureCards { get; }
    IRepository<Room> Rooms { get; }
    IRepository<RoomDetail> RoomDetails { get; }
    IRepository<DiningTiming> DiningTimings { get; }
    IRepository<Facility> Facilities { get; }
    IRepository<GalleryImage> GalleryImages { get; }
    IRepository<Amenity> Amenities { get; }
    IRepository<MediaFile> MediaFiles { get; }
    IRepository<Page> Pages { get; }
    IRepository<PageSection> PageSections { get; }
    IRepository<Menu> Menus { get; }
    IRepository<MenuItem> MenuItems { get; }
    IRepository<SocialLink> SocialLinks { get; }
    IRepository<SiteSettings> SiteSettings { get; }
    IRepository<SettingEntry> SettingEntries { get; }
    IRepository<Offer> Offers { get; }
    IRepository<EventVenue> EventVenues { get; }
    IRepository<EventFeature> EventFeatures { get; }
    IRepository<ExperienceCategory> ExperienceCategories { get; }
    IRepository<Testimonial> Testimonials { get; }
    IRepository<SeoMetadata> SeoMetadata { get; }
    IRepository<Permission> Permissions { get; }
    IRepository<RolePermission> RolePermissions { get; }
    IRepository<AuditLog> AuditLogs { get; }

    Task<int> SaveChangesAsync();
}
