using Microsoft.EntityFrameworkCore;
using MockAPI.Data;
using MockAPI.Dtos;
using MockAPI.Entities;
using MockAPI.Mapping;

namespace MockAPI.Endpoints;

public static class PalettesEndpoints
{
    const string GetPaletteEndpointName = "GetPalette";

    public static RouteGroupBuilder MapPalettesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("palettes");

        // GET
        group.MapGet("/", async (ColorPalettesContext dbContext) =>
        {
            return await dbContext.Palettes.Select(palette => palette.ToDto()).AsNoTracking().ToListAsync();
        });

        // GET
        group.MapGet("/{id}", async (int Id, ColorPalettesContext dbContext) =>
        {
            Palette? palette = await dbContext.Palettes.FindAsync(Id);

            if (palette is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(palette);
        }).WithName(GetPaletteEndpointName);

        // POST
        group.MapPost("/", async (CreatePaletteDto newPalette, ColorPalettesContext dbContext) =>
        {
            Palette palette = newPalette.ToEntity();
            dbContext.Palettes.Add(palette);

            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetPaletteEndpointName, new { Id = palette.Id }, palette);
        });

        // PUT
        group.MapPut("/{id}", async (int Id, UpdatePaletteDto updatedPalette, ColorPalettesContext dbContext) =>
        {
            var existingPalette = await dbContext.Palettes.FindAsync(Id);

            if (existingPalette is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingPalette).CurrentValues.SetValues(updatedPalette.ToEntity(Id));
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        // DELETE
        group.MapDelete("/{id}", async (int Id, ColorPalettesContext dbContext) =>
        {
            await dbContext.Palettes.Where(palette => palette.Id == Id).ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;
    }
}
