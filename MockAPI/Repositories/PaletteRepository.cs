using Microsoft.EntityFrameworkCore;
using MockAPI.Data;
using MockAPI.Entities;
using MockAPI.Dtos;
using MockAPI.Interfaces;

namespace MockAPI.Repositories;

public class PaletteRepository(ColorPalettesContext context) : IPaletteRepository
{
    public async Task<List<Palette>> GetAll(bool? highlighted, string? tags)
    {
        var query = context.Palettes.AsQueryable();

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
        return await context.Palettes.FindAsync(id);
    }

    public async Task<Palette> Create(Palette createdPalette)
    {
        await context.Palettes.AddAsync(createdPalette);
        await context.SaveChangesAsync();

        return createdPalette;
    }

    public async Task<Palette?> UpdateById(int id, UpdatePaletteDto updatedPaletteDto)
    {
        var existingPalette = await context.Palettes.FindAsync(id);

        if (existingPalette is null)
        {
            return null;
        }

        existingPalette.Colors = updatedPaletteDto.Colors;
        existingPalette.Highlighted = updatedPaletteDto.Highlighted;
        existingPalette.Tags = updatedPaletteDto.Tags;

        await context.SaveChangesAsync();

        return existingPalette;
    }

    public async Task<Palette?> DeleteById(int id)
    {
        var existingPalette = await context.Palettes.FindAsync(id);

        if (existingPalette is null)
        {
            return null;
        }

        context.Palettes.Remove(existingPalette);
        await context.SaveChangesAsync();

        return existingPalette;
    }
}
