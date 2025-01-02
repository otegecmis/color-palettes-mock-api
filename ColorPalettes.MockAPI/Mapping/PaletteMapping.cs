using ColorPalettes.MockAPI.Dtos;
using ColorPalettes.MockAPI.Entities;

namespace ColorPalettes.MockAPI.Mapping;

public static class PaletteMapping
{
    public static PaletteDto ToDto(this Palette palette)
    {
        return new PaletteDto(
            palette.Id,
            palette.Colors,
            palette.Highlighted,
            palette.Tags
        );
    }

    public static Palette ToEntity(this CreatePaletteDto createPaletteDto)
    {
        return new Palette()
        {
            Colors = createPaletteDto.Colors,
            Highlighted = createPaletteDto.Highlighted,
            Tags = createPaletteDto.Tags
        };
    }

    public static Palette ToEntity(this UpdatePaletteDto updatePaletteDto, int id)
    {
        return new Palette()
        {
            Id = id,
            Colors = updatePaletteDto.Colors,
            Highlighted = updatePaletteDto.Highlighted,
            Tags = updatePaletteDto.Tags
        };
    }
}
