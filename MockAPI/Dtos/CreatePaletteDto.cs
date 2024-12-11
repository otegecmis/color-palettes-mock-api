using System.ComponentModel.DataAnnotations;

namespace MockAPI.Dtos;

public record class CreatePaletteDto(
    [Required] string[] Colors
);
