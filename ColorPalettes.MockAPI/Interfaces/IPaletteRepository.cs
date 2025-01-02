using ColorPalettes.MockAPI.Entities;

namespace ColorPalettes.MockAPI.Interfaces;

public interface IPaletteRepository
{
    Task<List<Palette>> GetAll(bool? highlighted, string? tags);
    Task<Palette?> GetById(int id);
    Task<Palette> Create(Palette createdPalette);
    Task<Palette?> UpdateById(int id, Palette updatedPalette);
    Task<Palette?> DeleteById(int id);
}
