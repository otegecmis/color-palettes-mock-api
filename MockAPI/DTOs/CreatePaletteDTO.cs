using System.ComponentModel.DataAnnotations;

namespace MockAPI.DTOs;

public record class CreatePaletteDTO(
    [Required] List<string> Colors,
    bool Highlighted,
    List<string>? Tags
);
