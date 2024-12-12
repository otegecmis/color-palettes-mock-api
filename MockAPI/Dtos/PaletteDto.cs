namespace MockAPI.DTOs;

public record class PaletteDTO(int Id, string[] Colors, bool Highlighted, List<string>? Tags);
