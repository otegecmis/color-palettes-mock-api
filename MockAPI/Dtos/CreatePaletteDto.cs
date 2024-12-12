using System.ComponentModel.DataAnnotations;

namespace MockAPI.DTOs;

public record class CreatePaletteDTO(
    [Required] string[] Colors,
    bool Highlighted,
    List<string>? Tags
);
