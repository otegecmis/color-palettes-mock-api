using Microsoft.EntityFrameworkCore;
using MockAPI.Entities;

namespace MockAPI.Data;

public class ColorPalettesContext(DbContextOptions<ColorPalettesContext> options) : DbContext(options)
{
    public DbSet<Palette> Palettes => Set<Palette>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Palette>().HasData(
            new Palette
            {
                Id = 1,
                Colors = new[] { "#e24511", "#534b68", "#3c73a0", "#e75db5" },
                Highlighted = true,
                Tags = new List<string> { "warm", "modern", "bold" }
            }
        );
    }
}
