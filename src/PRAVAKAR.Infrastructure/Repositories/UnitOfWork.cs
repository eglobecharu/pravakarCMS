using PRAVAKAR.Domain.Entities;
using PRAVAKAR.Domain.Interfaces;
using PRAVAKAR.Infrastructure.Data;

namespace PRAVAKAR.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    private IRepository<Company>? _companies;
    private IRepository<HotelChain>? _hotelChains;
    private IRepository<Hotel>? _hotels;
    private IRepository<HeroSlide>? _heroSlides;
    private IRepository<AboutFeature>? _aboutFeatures;
    private IRepository<AboutFeatureCard>? _aboutFeatureCards;
    private IRepository<Room>? _rooms;
    private IRepository<RoomDetail>? _roomDetails;
    private IRepository<DiningTiming>? _diningTimings;
    private IRepository<Facility>? _facilities;
    private IRepository<GalleryImage>? _galleryImages;
    private IRepository<Amenity>? _amenities;
    private IRepository<MediaFile>? _mediaFiles;
    private IRepository<Page>? _pages;
    private IRepository<PageSection>? _pageSections;
    private IRepository<Menu>? _menus;
    private IRepository<MenuItem>? _menuItems;
    private IRepository<SocialLink>? _socialLinks;
    private IRepository<SiteSettings>? _siteSettings;
    private IRepository<SettingEntry>? _settingEntries;
    private IRepository<Offer>? _offers;
    private IRepository<EventVenue>? _eventVenues;
    private IRepository<EventFeature>? _eventFeatures;
    private IRepository<ExperienceCategory>? _experienceCategories;
    private IRepository<Testimonial>? _testimonials;
    private IRepository<SeoMetadata>? _seoMetadata;
    private IRepository<Permission>? _permissions;
    private IRepository<RolePermission>? _rolePermissions;
    private IRepository<AuditLog>? _auditLogs;

    public UnitOfWork(ApplicationDbContext context) => _context = context;

    public IRepository<Company> Companies => _companies ??= new Repository<Company>(_context);
    public IRepository<HotelChain> HotelChains => _hotelChains ??= new Repository<HotelChain>(_context);
    public IRepository<Hotel> Hotels => _hotels ??= new Repository<Hotel>(_context);
    public IRepository<HeroSlide> HeroSlides => _heroSlides ??= new Repository<HeroSlide>(_context);
    public IRepository<AboutFeature> AboutFeatures => _aboutFeatures ??= new Repository<AboutFeature>(_context);
    public IRepository<AboutFeatureCard> AboutFeatureCards => _aboutFeatureCards ??= new Repository<AboutFeatureCard>(_context);
    public IRepository<Room> Rooms => _rooms ??= new Repository<Room>(_context);
    public IRepository<RoomDetail> RoomDetails => _roomDetails ??= new Repository<RoomDetail>(_context);
    public IRepository<DiningTiming> DiningTimings => _diningTimings ??= new Repository<DiningTiming>(_context);
    public IRepository<Facility> Facilities => _facilities ??= new Repository<Facility>(_context);
    public IRepository<GalleryImage> GalleryImages => _galleryImages ??= new Repository<GalleryImage>(_context);
    public IRepository<Amenity> Amenities => _amenities ??= new Repository<Amenity>(_context);
    public IRepository<MediaFile> MediaFiles => _mediaFiles ??= new Repository<MediaFile>(_context);
    public IRepository<Page> Pages => _pages ??= new Repository<Page>(_context);
    public IRepository<PageSection> PageSections => _pageSections ??= new Repository<PageSection>(_context);
    public IRepository<Menu> Menus => _menus ??= new Repository<Menu>(_context);
    public IRepository<MenuItem> MenuItems => _menuItems ??= new Repository<MenuItem>(_context);
    public IRepository<SocialLink> SocialLinks => _socialLinks ??= new Repository<SocialLink>(_context);
    public IRepository<SiteSettings> SiteSettings => _siteSettings ??= new Repository<SiteSettings>(_context);
    public IRepository<SettingEntry> SettingEntries => _settingEntries ??= new Repository<SettingEntry>(_context);
    public IRepository<Offer> Offers => _offers ??= new Repository<Offer>(_context);
    public IRepository<EventVenue> EventVenues => _eventVenues ??= new Repository<EventVenue>(_context);
    public IRepository<EventFeature> EventFeatures => _eventFeatures ??= new Repository<EventFeature>(_context);
    public IRepository<ExperienceCategory> ExperienceCategories => _experienceCategories ??= new Repository<ExperienceCategory>(_context);
    public IRepository<Testimonial> Testimonials => _testimonials ??= new Repository<Testimonial>(_context);
    public IRepository<SeoMetadata> SeoMetadata => _seoMetadata ??= new Repository<SeoMetadata>(_context);
    public IRepository<Permission> Permissions => _permissions ??= new Repository<Permission>(_context);
    public IRepository<RolePermission> RolePermissions => _rolePermissions ??= new Repository<RolePermission>(_context);
    public IRepository<AuditLog> AuditLogs => _auditLogs ??= new Repository<AuditLog>(_context);

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}
