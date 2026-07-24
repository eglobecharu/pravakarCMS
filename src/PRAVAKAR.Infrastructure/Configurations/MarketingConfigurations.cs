using PRAVAKAR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PRAVAKAR.Infrastructure.Configurations;

public class OfferConfiguration : IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> b)
    {
        b.HasIndex(x => x.Slug).IsUnique();
        b.Property(x => x.Slug).HasMaxLength(150).IsRequired();
        b.Property(x => x.Title).HasMaxLength(300).IsRequired();
        b.HasOne(x => x.Hotel).WithMany().HasForeignKey(x => x.HotelId).OnDelete(DeleteBehavior.SetNull);
    }
}

public class EventVenueConfiguration : IEntityTypeConfiguration<EventVenue>
{
    public void Configure(EntityTypeBuilder<EventVenue> b)
    {
        b.Property(x => x.Name).HasMaxLength(300).IsRequired();
        b.HasOne(x => x.Hotel).WithMany().HasForeignKey(x => x.HotelId).OnDelete(DeleteBehavior.SetNull);
        b.HasMany(x => x.Features).WithOne(x => x.EventVenue!).HasForeignKey(x => x.EventVenueId).OnDelete(DeleteBehavior.Cascade);
    }
}

public class TestimonialConfiguration : IEntityTypeConfiguration<Testimonial>
{
    public void Configure(EntityTypeBuilder<Testimonial> b)
    {
        b.Property(x => x.GuestName).HasMaxLength(200).IsRequired();
        b.HasOne(x => x.Hotel).WithMany().HasForeignKey(x => x.HotelId).OnDelete(DeleteBehavior.SetNull);
    }
}

public class SeoMetadataConfiguration : IEntityTypeConfiguration<SeoMetadata>
{
    public void Configure(EntityTypeBuilder<SeoMetadata> b)
    {
        b.HasIndex(x => x.HotelId).IsUnique().HasFilter("[HotelId] IS NOT NULL");
        b.HasIndex(x => x.PageId).IsUnique().HasFilter("[PageId] IS NOT NULL");
    }
}

public class PageConfiguration : IEntityTypeConfiguration<Page>
{
    public void Configure(EntityTypeBuilder<Page> b)
    {
        b.HasIndex(x => x.Slug).IsUnique();
        b.Property(x => x.Slug).HasMaxLength(100).IsRequired();
        b.HasMany(x => x.Sections).WithOne(x => x.Page!).HasForeignKey(x => x.PageId).OnDelete(DeleteBehavior.Cascade);
        b.HasOne(x => x.Seo).WithOne(s => s.Page!).HasForeignKey<SeoMetadata>(s => s.PageId).OnDelete(DeleteBehavior.Cascade);
    }
}

public class MenuConfiguration : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> b)
    {
        b.HasMany(x => x.Items).WithOne(x => x.Menu!).HasForeignKey(x => x.MenuId).OnDelete(DeleteBehavior.Cascade);
    }
}

public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
{
    public void Configure(EntityTypeBuilder<MenuItem> b)
    {
        b.HasOne(x => x.ParentMenuItem)
            .WithMany()
            .HasForeignKey(x => x.ParentMenuItemId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> b)
    {
        b.HasKey(x => new { x.RoleId, x.PermissionId });
        b.HasOne(x => x.Permission).WithMany(p => p.RolePermissions).HasForeignKey(x => x.PermissionId).OnDelete(DeleteBehavior.Cascade);
    }
}

public class SiteSettingsConfiguration : IEntityTypeConfiguration<SiteSettings>
{
    public void Configure(EntityTypeBuilder<SiteSettings> b)
    {
        b.HasData(new SiteSettings { Id = 1, BookNowLabel = "Book Now", FooterQuickLinksCount = 5, CreatedAt = new DateTime(2026, 1, 1) });
    }
}
