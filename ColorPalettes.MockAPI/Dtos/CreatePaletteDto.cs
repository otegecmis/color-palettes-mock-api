using System.ComponentModel.DataAnnotations;

namespace ColorPalettes.MockAPI.Dtos;

public record CreatePaletteDto(
    [Required] List<string> Colors,
    [Required] bool Highlighted,
    List<string>? Tags
);
