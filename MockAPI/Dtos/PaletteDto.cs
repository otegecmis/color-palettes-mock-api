namespace MockAPI.Dtos;

public record class PaletteDto(int Id, string[] Colors, bool Highlighted, List<string>? Tags);
