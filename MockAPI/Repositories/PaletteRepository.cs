using Microsoft.EntityFrameworkCore;
using MockAPI.Data;
using MockAPI.Entities;
using MockAPI.Dtos;
using MockAPI.Interfaces;

namespace MockAPI.Repositories;

public class PaletteRepository : IPaletteRepository
{
    private readonly ColorPalettesContext _context;

    public PaletteRepository(ColorPalettesContext context)
    {
        _context = context;
    }

    public async Task<List<Palette>> GetAll(bool? highlighted, string? tags)
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

        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<Palette?> GetById(int id)
    {
        return await _context.Palettes.FindAsync(id);
    }

    public async Task<Palette> Create(Palette createdPalette)
    {
        await _context.Palettes.AddAsync(createdPalette);
        await _context.SaveChangesAsync();

        return createdPalette;
    }

    public async Task<Palette?> UpdateById(int id, UpdatePaletteDto updatedPaletteDto)
    {
        var existingPalette = await _context.Palettes.FindAsync(id);

        if (existingPalette is null)
        {
            return null;
        }

        existingPalette.Colors = updatedPaletteDto.Colors;
        existingPalette.Highlighted = updatedPaletteDto.Highlighted;
        existingPalette.Tags = updatedPaletteDto.Tags;

        await _context.SaveChangesAsync();

        return existingPalette;
    }

    public async Task<Palette?> DeleteById(int id)
    {
        var existingPalette = await _context.Palettes.FindAsync(id);

        if (existingPalette is null)
        {
            return null;
        }

        _context.Palettes.Remove(existingPalette);
        await _context.SaveChangesAsync();

        return existingPalette;
    }
}
