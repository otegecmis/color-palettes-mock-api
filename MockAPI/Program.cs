using Microsoft.EntityFrameworkCore;
using MockAPI.Data;
using MockAPI.Interfaces;
using MockAPI.Repositories;
using MockAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("ColorPalettes");

builder.Services.AddSqlite<ColorPalettesContext>(connString);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPaletteRepository, PaletteRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ColorPalettesContext>();
    var launchSetting = builder.Configuration.GetValue<bool>("RecreateDatabaseOnStart");

    if (launchSetting)
    {
        await context.Database.EnsureDeletedAsync();
    }

    await context.Database.MigrateAsync();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Color Palettes Mock API"); });
}

app.MapPalettesEndpoints().WithTags("Palettes");
await app.MigrateDatabase();

app.Run();
