using System.ComponentModel.DataAnnotations;

namespace MockAPI.Dtos;

public record CreatePaletteDto(
    [Required] List<string> Colors,
    [Required] bool Highlighted,
    List<string>? Tags
);
