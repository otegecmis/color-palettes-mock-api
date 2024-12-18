using System.ComponentModel.DataAnnotations;

namespace MockAPI.DTOs;

public record class UpdatePaletteDTO(
    [Required] List<string> Colors,
    bool Highlighted,
    List<string>? Tags
);