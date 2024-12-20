using Microsoft.EntityFrameworkCore;

namespace MockAPI.Data;

public static class DataExtensions
{
    public static async Task MigrateDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ColorPalettesContext>();

        await context.Database.MigrateAsync();
    }
}
