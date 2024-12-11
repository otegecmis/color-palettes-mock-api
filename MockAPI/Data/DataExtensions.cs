using Microsoft.EntityFrameworkCore;

namespace MockAPI.Data;

public static class DataExtensions
{
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ColorPalettesContext>();

        await dbContext.Database.MigrateAsync();
    }
}
