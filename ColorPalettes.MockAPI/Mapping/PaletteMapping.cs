using ColorPalettes.MockAPI.Dtos;
using ColorPalettes.MockAPI.Entities;

namespace ColorPalettes.MockAPI.Mapping;

public static class PaletteMapping
{
    public static PaletteDto ToPaletteDto(this Palette palette)
    {
        return new PaletteDto(
            palette.Id,
            palette.Colors,
            palette.Highlighted,
            palette.Tags
        );
    }

    public static Palette ToPaletteEntity(this CreatePaletteDto createPaletteDto)
    {
        return new Palette()
        {
            Colors = createPaletteDto.Colors,
            Highlighted = createPaletteDto.Highlighted,
            Tags = createPaletteDto.Tags
        };
    }
}
