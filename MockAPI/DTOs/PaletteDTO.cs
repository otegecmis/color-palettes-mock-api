namespace MockAPI.DTOs;

public record class PaletteDTO(int Id, List<string> Colors, bool Highlighted, List<string>? Tags);
