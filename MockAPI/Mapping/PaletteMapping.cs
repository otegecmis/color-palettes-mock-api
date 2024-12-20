using MockAPI.Entities;
using MockAPI.DTOs;

namespace MockAPI.Mapping;

public static class PaletteMapping
{
    public static PaletteDTO ToDTO(this Palette palette)
    {
        return new PaletteDTO(
            palette.Id,
            palette.Colors,
            palette.Highlighted,
            palette.Tags
        );
    }

    public static Palette ToEntity(this CreatePaletteDTO palette)
    {
        return new Palette()
        {
            Colors = palette.Colors,
            Highlighted = palette.Highlighted,
            Tags = palette.Tags
        };
    }

    public static Palette ToEntity(this UpdatePaletteDTO palette, int Id)
    {
        return new Palette()
        {
            Id = Id,
            Colors = palette.Colors,
            Highlighted = palette.Highlighted,
            Tags = palette.Tags
        };
    }
}
