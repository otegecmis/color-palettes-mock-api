using MockAPI.DTOs;
using MockAPI.Services;

namespace MockAPI.Endpoints;

public static class PalettesEndpoints
{
    private const string GetPaletteEndpoint = "GetPalette";

    public static RouteGroupBuilder MapPalettesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("palettes").WithTags("Palettes");

        group.MapGet("/", GetPalettes);
        group.MapGet("/{id:int}", GetPaletteById).WithName(GetPaletteEndpoint);
        group.MapPost("/", CreatePalette);
        group.MapPut("/{id:int}", UpdatePaletteById);
        group.MapDelete("/{id:int}", DeletePaletteById);

        return group;
    }

    private static async Task<IResult> GetPalettes(bool? highlighted, string? tags, IPalettesService palettesService)
    {
        var palettes = await palettesService.GetPalettes(highlighted, tags);
        return Results.Ok(palettes);
    }

    private static async Task<IResult> GetPaletteById(int id, IPalettesService palettesService)
    {
        var palette = await palettesService.GetPaletteById(id);

        if (palette is null)
        {
            Results.NotFound();
        }

        return Results.Ok(palette);
    }

    private static async Task<IResult> CreatePalette(CreatePaletteDTO createdPalette, IPalettesService palettesService)
    {
        var palette = await palettesService.CreatePalette(createdPalette);
        return Results.CreatedAtRoute(GetPaletteEndpoint, new { id = palette.Id }, palette);
    }

    private static async Task<IResult> UpdatePaletteById(int id, UpdatePaletteDTO updatedPalette, IPalettesService palettesService)
    {
        var isUpdated = await palettesService.UpdatePaletteById(id, updatedPalette);
        return !isUpdated ? Results.NotFound() : Results.NoContent();
    }

    private static async Task<IResult> DeletePaletteById(int id, IPalettesService palettesService)
    {
        var isDeleted = await palettesService.DeletePaletteById(id);
        return !isDeleted ? Results.NotFound() : Results.NoContent();
    }
}
