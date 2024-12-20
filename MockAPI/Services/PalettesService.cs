using Microsoft.EntityFrameworkCore;
using MockAPI.Data;
using MockAPI.Entities;
using MockAPI.DTOs;
using MockAPI.Mapping;

namespace MockAPI.Services;

public class PalettesService(ColorPalettesContext context) : IPalettesService
{
    private readonly ColorPalettesContext _context = context;

    public async Task<List<PaletteDTO>> GetPalettes(bool? highlighted, string? tags)
    {
        var query = _context.Palettes.AsQueryable();

        if (highlighted.HasValue)
        {
            query = query.Where(palette => palette.Highlighted == highlighted.Value);
        }

        if (!string.IsNullOrEmpty(tags))
        {
            var tagList = tags?.Split(',')
                .Select(tag => tag.Trim())
                .ToList();

            query = query.Where(palette => palette.Tags != null && palette.Tags.Any(tag => tagList!.Contains(tag)));
        }

        return await query.Select(palette => palette.ToDTO()).AsNoTracking().ToListAsync();
    }

    public async Task<PaletteDTO?> GetPaletteById(int id)
    {
        var palette = await _context.Palettes.FindAsync(id);
        return palette?.ToDTO();
    }

    public async Task<Palette> CreatePalette(CreatePaletteDTO createdPalette)
    {
        var palette = createdPalette.ToEntity();
        _context.Palettes.Add(palette);
        await _context.SaveChangesAsync();

        return palette;
    }

    public async Task<bool> UpdatePaletteById(int id, UpdatePaletteDTO updatedPalette)
    {
        var existingPalette = await _context.Palettes.FindAsync(id);

        if (existingPalette is null)
        {
            return false;
        }

        _context.Entry(existingPalette).CurrentValues.SetValues(updatedPalette.ToEntity(id));
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeletePaletteById(int id)
    {
        var existingPalette = await _context.Palettes.FindAsync(id);

        if (existingPalette is null)
        {
            return false;
        }

        await _context.Palettes.Where(palette => palette.Id == id).ExecuteDeleteAsync();

        return true;
    }
}
