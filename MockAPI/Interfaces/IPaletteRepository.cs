using MockAPI.Dtos;
using MockAPI.Entities;

namespace MockAPI.Interfaces;

public interface IPaletteRepository
{
    Task<List<Palette>> GetAll(bool? highlighted, string? tags);
    Task<Palette?> GetById(int id);
    Task<Palette> Create(Palette createdPalette);
    Task<Palette?> UpdateById(int id, UpdatePaletteDto updatedPaletteDto);
    Task<Palette?> DeleteById(int id);
}
