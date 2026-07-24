using EVENTBOOKING.Domain.Entities;
using EVENTBOOKING.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EVENTBOOKING.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Company> Companies => Set<Company>();
    public DbSet<HotelChain> HotelChains => Set<HotelChain>();
    public DbSet<Hotel> Hotels => Set<Hotel>();
    public DbSet<HeroSlide> HeroSlides => Set<HeroSlide>();
    public DbSet<AboutFeature> AboutFeatures => Set<AboutFeature>();
    public DbSet<AboutFeatureCard> AboutFeatureCards => Set<AboutFeatureCard>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<RoomDetail> RoomDetails => Set<RoomDetail>();
    public DbSet<DiningTiming> DiningTimings => Set<DiningTiming>();
    public DbSet<Facility> Facilities => Set<Facility>();
    public DbSet<GalleryImage> GalleryImages => Set<GalleryImage>();
    public DbSet<Amenity> Amenities => Set<Amenity>();
    public DbSet<HotelAmenity> HotelAmenities => Set<HotelAmenity>();
    public DbSet<RoomAmenity> RoomAmenities => Set<RoomAmenity>();
    public DbSet<MediaFile> MediaFiles => Set<MediaFile>();
    public DbSet<Page> Pages => Set<Page>();
    public DbSet<PageSection> PageSections => Set<PageSection>();
    public DbSet<Menu> Menus => Set<Menu>();
    public DbSet<MenuItem> MenuItems => Set<MenuItem>();
    public DbSet<SocialLink> SocialLinks => Set<SocialLink>();
    public DbSet<SiteSettings> SiteSettings => Set<SiteSettings>();
    public DbSet<SettingEntry> SettingEntries => Set<SettingEntry>();
    public DbSet<Offer> Offers => Set<Offer>();
    public DbSet<EventVenue> EventVenues => Set<EventVenue>();
    public DbSet<EventFeature> EventFeatures => Set<EventFeature>();
    public DbSet<ExperienceCategory> ExperienceCategories => Set<ExperienceCategory>();
    public DbSet<Testimonial> Testimonials => Set<Testimonial>();
    public DbSet<SeoMetadata> SeoMetadataEntries => Set<SeoMetadata>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
