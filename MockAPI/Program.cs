using MockAPI.Data;
using MockAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("ColorPalettes");

builder.Services.AddSqlite<ColorPalettesContext>(connString);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Color Palettes Mock API");
    });
}

app.MapPalettesEndpoints();

await app.MigrateDbAsync();

app.Run();
