using MockAPI.Data;
using MockAPI.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("ColorPalettes");

builder.Services.AddSqlite<ColorPalettesContext>(connString);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ColorPalettesContext>();
    var launchSetting = builder.Configuration.GetValue<bool>("RecreateDatabaseOnStart");

    if (launchSetting)
    {
        await dbContext.Database.EnsureDeletedAsync();
        await dbContext.Database.MigrateAsync();
    }
    else
    {
        await dbContext.Database.MigrateAsync();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Color Palettes Mock API");
    });
}

app.MapPalettesEndpoints().WithTags("Palettes");

await app.MigrateDbAsync();

app.Run();
