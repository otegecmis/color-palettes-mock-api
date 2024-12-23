namespace MockAPI.Dtos;

public record class PaletteDto(int Id, List<string> Colors, bool Highlighted, List<string>? Tags);
