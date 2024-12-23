namespace MockAPI.Dtos;

public record PaletteDto(int Id, List<string> Colors, bool Highlighted, List<string>? Tags);
