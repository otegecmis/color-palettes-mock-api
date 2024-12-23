using System.ComponentModel.DataAnnotations;

namespace MockAPI.Dtos;

public record UpdatePaletteDto(
    [Required] List<string> Colors,
    [Required] bool Highlighted,
    List<string>? Tags
);
