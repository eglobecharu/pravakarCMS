using PRAVAKAR.Domain.Entities.Common;

namespace PRAVAKAR.Domain.Entities;

public class HeroSlide : BaseEntity
{
    public int HotelId { get; set; }
    public Hotel? Hotel { get; set; }
    public string ImagePath { get; set; } = string.Empty;
    public string? AltText { get; set; }
    public int SortOrder { get; set; }
}

public class AboutFeature : BaseEntity
{
    public int HotelId { get; set; }
    public Hotel? Hotel { get; set; }
    public string FeatureText { get; set; } = string.Empty;
    public int SortOrder { get; set; }
}

public class AboutFeatureCard : BaseEntity
{
    public int HotelId { get; set; }
    public Hotel? Hotel { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int SortOrder { get; set; }
}

/// <summary>A room tier at a property. Uses EITHER a simple amenity list (RoomAmenities)
/// OR detailed feature cards (RoomDetails) — never both, mirroring how the original site
/// authored room content.</summary>
public class Room : BaseEntity
{
    public int HotelId { get; set; }
    public Hotel? Hotel { get; set; }
    public string? Tier { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Meta { get; set; }
    public string? Price { get; set; }
    public string? ImagePath { get; set; }
    public int SortOrder { get; set; }

    public ICollection<RoomAmenity> RoomAmenities { get; set; } = new List<RoomAmenity>();
    public ICollection<RoomDetail> RoomDetails { get; set; } = new List<RoomDetail>();
}

public class RoomDetail : BaseEntity
{
    public int RoomId { get; set; }
    public Room? Room { get; set; }
    public string? Icon { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int SortOrder { get; set; }
}

public class DiningTiming : BaseEntity
{
    public int HotelId { get; set; }
    public Hotel? Hotel { get; set; }
    public string Label { get; set; } = string.Empty;
    public string? Value { get; set; }
    public int SortOrder { get; set; }
}

/// <summary>A property-level facility tile (the "Everything You Need" grid) — e.g.
/// "Free Wi-Fi", "Airport Shuttle". Distinct from the shared Amenity catalog, which is a
/// reusable master list referenced by both Hotels and Rooms via join tables.</summary>
public class Facility : BaseEntity
{
    public int HotelId { get; set; }
    public Hotel? Hotel { get; set; }
    public string? Icon { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int SortOrder { get; set; }
}

public class GalleryImage : BaseEntity
{
    public int HotelId { get; set; }
    public Hotel? Hotel { get; set; }
    public string ImagePath { get; set; } = string.Empty;
    public string? Caption { get; set; }
    public int SortOrder { get; set; }
}

/// <summary>Master, reusable amenity catalog (e.g. "Free Wi-Fi", "Pool", "Parking") —
/// referenced by Hotels and Rooms through join tables instead of duplicating the amenity
/// name as a free-text string on every row.</summary>
public class Amenity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Icon { get; set; }

    public ICollection<HotelAmenity> HotelAmenities { get; set; } = new List<HotelAmenity>();
    public ICollection<RoomAmenity> RoomAmenities { get; set; } = new List<RoomAmenity>();
}

public class HotelAmenity
{
    public int HotelId { get; set; }
    public Hotel? Hotel { get; set; }
    public int AmenityId { get; set; }
    public Amenity? Amenity { get; set; }
}

public class RoomAmenity
{
    public int RoomId { get; set; }
    public Room? Room { get; set; }
    public int AmenityId { get; set; }
    public Amenity? Amenity { get; set; }
}
