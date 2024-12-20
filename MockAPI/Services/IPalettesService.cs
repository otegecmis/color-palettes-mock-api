using MockAPI.Entities;
using MockAPI.DTOs;

namespace MockAPI.Services;

public interface IPalettesService
{
    Task<List<PaletteDTO>> GetPalettes(bool? highlighted, string? tags);
    Task<PaletteDTO?> GetPaletteById(int id);
    Task<Palette> CreatePalette(CreatePaletteDTO createdPalette);
    Task<bool> UpdatePaletteById(int id, UpdatePaletteDTO updatedPalette);
    Task<bool> DeletePaletteById(int id);
}
