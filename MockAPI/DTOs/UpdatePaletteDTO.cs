using System.ComponentModel.DataAnnotations;

namespace MockAPI.DTOs;

public record class UpdatePaletteDTO(
    [Required] string[] Colors,
    bool Highlighted,
    List<string>? Tags
);