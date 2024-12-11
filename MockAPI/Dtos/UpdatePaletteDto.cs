using System.ComponentModel.DataAnnotations;

namespace MockAPI.Dtos;

public record class UpdatePaletteDto(
    [Required] string[] Colors,
    bool Highlighted,
    List<string>? Tags
);