using System;
using MockAPI.Dtos;
using MockAPI.Entities;

namespace MockAPI.Mapping;

public static class PaletteMapping
{
    public static PaletteDto ToDto(this Palette palette)
    {
        return new PaletteDto(palette.Id, palette.Colors);
    }

    public static Palette ToEntity(this CreatePaletteDto palette)
    {
        return new Palette()
        {
            Colors = palette.Colors
        };
    }

    public static Palette ToEntity(this UpdatePaletteDto palette, int Id)
    {
        return new Palette()
        {
            Id = Id,
            Colors = palette.Colors
        };
    }
}
