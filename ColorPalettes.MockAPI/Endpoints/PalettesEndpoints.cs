using ColorPalettes.MockAPI.Dtos;
using ColorPalettes.MockAPI.Interfaces;
using ColorPalettes.MockAPI.Mapping;

namespace ColorPalettes.MockAPI.Endpoints;

public static class PalettesEndpoints
{
    private const string GetByIdEndpoint = "GetPalette";

    public static RouteGroupBuilder MapPalettesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("palettes").WithTags("Palettes");

        group.MapGet("/", GetAll);
        group.MapGet("/{id:int}", GetById).WithName(GetByIdEndpoint);
        group.MapPost("/", Create).WithParameterValidation();
        group.MapPut("/{id:int}", UpdateById).WithParameterValidation();
        group.MapDelete("/{id:int}", DeleteById);

        return group;
    }

    private static async Task<IResult> GetAll(bool? highlighted, string? tags, IPaletteRepository paletteRepository)
    {
        var palettes = await paletteRepository.GetAll(highlighted, tags);
        return Results.Ok(palettes.Select(p => p.ToDto()));
    }

    private static async Task<IResult> GetById(int id, IPaletteRepository paletteRepository)
    {
        var palette = await paletteRepository.GetById(id);
        return palette == null ? Results.NotFound() : Results.Ok(palette.ToDto());
    }

    private static async Task<IResult> Create(CreatePaletteDto createdPalette, IPaletteRepository paletteRepository)
    {
        var palette = await paletteRepository.Create(createdPalette.ToEntity());
        return Results.CreatedAtRoute(GetByIdEndpoint, new { id = palette.Id }, palette.ToDto());
    }

    private static async Task<IResult> UpdateById(int id, UpdatePaletteDto updatedPalette, IPaletteRepository paletteRepository)
    {
        var palette = await paletteRepository.UpdateById(id, updatedPalette.ToEntity(id));
        return palette == null ? Results.NotFound() : Results.Ok(palette.ToDto());
    }

    private static async Task<IResult> DeleteById(int id, IPaletteRepository paletteRepository)
    {
        var palette = await paletteRepository.DeleteById(id);
        return palette == null ? Results.NotFound() : Results.NoContent();
    }
}
