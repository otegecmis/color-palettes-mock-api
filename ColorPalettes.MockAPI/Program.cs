using ColorPalettes.MockAPI.Data;
using ColorPalettes.MockAPI.Interfaces;
using ColorPalettes.MockAPI.Repositories;
using ColorPalettes.MockAPI.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("SQLiteConnectionString");

builder.Services.AddSqlite<ApplicationDbContext>(connString);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPaletteRepository, PaletteRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var launchSetting = bool.Parse(builder.Configuration.GetValue<string>("RecreateDatabaseOnStart") ?? "false");

    if (launchSetting)
    {
        await context.Database.EnsureDeletedAsync();
    }

    await app.MigrateDatabase();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Color Palettes Mock API"); });
}

app.MapPalettesEndpoints().WithTags("Palettes");

app.Run();
