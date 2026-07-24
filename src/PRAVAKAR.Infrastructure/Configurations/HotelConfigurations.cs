using PRAVAKAR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PRAVAKAR.Infrastructure.Configurations;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> b)
    {
        b.HasIndex(x => x.Slug).IsUnique();
        b.HasIndex(x => x.ExternalPropertyId).IsUnique();
        b.Property(x => x.Slug).HasMaxLength(100).IsRequired();
        b.Property(x => x.Name).HasMaxLength(200).IsRequired();
        b.Property(x => x.Rating).HasPrecision(3, 2);

        b.HasOne(x => x.HotelChain)
            .WithMany(c => c.Hotels)
            .HasForeignKey(x => x.HotelChainId)
            .OnDelete(DeleteBehavior.SetNull);

        b.HasMany(x => x.HeroSlides).WithOne(x => x.Hotel!).HasForeignKey(x => x.HotelId).OnDelete(DeleteBehavior.Cascade);
        b.HasMany(x => x.AboutFeatures).WithOne(x => x.Hotel!).HasForeignKey(x => x.HotelId).OnDelete(DeleteBehavior.Cascade);
        b.HasMany(x => x.AboutFeatureCards).WithOne(x => x.Hotel!).HasForeignKey(x => x.HotelId).OnDelete(DeleteBehavior.Cascade);
        b.HasMany(x => x.Rooms).WithOne(x => x.Hotel!).HasForeignKey(x => x.HotelId).OnDelete(DeleteBehavior.Cascade);
        b.HasMany(x => x.DiningTimings).WithOne(x => x.Hotel!).HasForeignKey(x => x.HotelId).OnDelete(DeleteBehavior.Cascade);
        b.HasMany(x => x.Facilities).WithOne(x => x.Hotel!).HasForeignKey(x => x.HotelId).OnDelete(DeleteBehavior.Cascade);
        b.HasMany(x => x.GalleryImages).WithOne(x => x.Hotel!).HasForeignKey(x => x.HotelId).OnDelete(DeleteBehavior.Cascade);

        b.HasOne(x => x.Seo)
            .WithOne(s => s.Hotel!)
            .HasForeignKey<SeoMetadata>(s => s.HotelId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> b)
    {
        b.Property(x => x.Name).HasMaxLength(200).IsRequired();
        b.HasMany(x => x.RoomDetails).WithOne(x => x.Room!).HasForeignKey(x => x.RoomId).OnDelete(DeleteBehavior.Cascade);
    }
}

public class AmenityConfiguration : IEntityTypeConfiguration<Amenity>
{
    public void Configure(EntityTypeBuilder<Amenity> b)
    {
        b.HasIndex(x => x.Name).IsUnique();
        b.Property(x => x.Name).HasMaxLength(150).IsRequired();
    }
}

public class HotelAmenityConfiguration : IEntityTypeConfiguration<HotelAmenity>
{
    public void Configure(EntityTypeBuilder<HotelAmenity> b)
    {
        b.HasKey(x => new { x.HotelId, x.AmenityId });
        b.HasOne(x => x.Hotel).WithMany(h => h.HotelAmenities).HasForeignKey(x => x.HotelId).OnDelete(DeleteBehavior.Cascade);
        b.HasOne(x => x.Amenity).WithMany(a => a.HotelAmenities).HasForeignKey(x => x.AmenityId).OnDelete(DeleteBehavior.Cascade);
    }
}

public class RoomAmenityConfiguration : IEntityTypeConfiguration<RoomAmenity>
{
    public void Configure(EntityTypeBuilder<RoomAmenity> b)
    {
        b.HasKey(x => new { x.RoomId, x.AmenityId });
        b.HasOne(x => x.Room).WithMany(r => r.RoomAmenities).HasForeignKey(x => x.RoomId).OnDelete(DeleteBehavior.Cascade);
        b.HasOne(x => x.Amenity).WithMany(a => a.RoomAmenities).HasForeignKey(x => x.AmenityId).OnDelete(DeleteBehavior.Cascade);
    }
}
