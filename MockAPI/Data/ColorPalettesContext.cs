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
                Colors = new List<string> { "#e24511", "#534b68", "#3c73a0", "#e75db5" },
                Highlighted = true,
                Tags = new List<string> { "warm", "modern", "bold" }
            },
            new Palette
            {
                Id = 2,
                Colors = new List<string> { "#ffffff", "#000000", "#ff0000", "#00ff00" },
                Highlighted = false,
                Tags = new List<string> { "contrast", "classic", "bold" }
            },
            new Palette
            {
                Id = 3,
                Colors = new List<string> { "#123456", "#654321", "#abcdef", "#fedcba" },
                Highlighted = true,
                Tags = new List<string> { "unique", "vibrant", "modern" }
            },
            new Palette
            {
                Id = 4,
                Colors = new List<string> { "#0f0f0f", "#f0f0f0", "#aabbcc", "#ccbbaa" },
                Highlighted = false,
                Tags = new List<string> { "neutral", "soft", "classic" }
            },
            new Palette
            {
                Id = 5,
                Colors = new List<string> { "#ff5733", "#c70039", "#900c3f", "#581845" },
                Highlighted = true,
                Tags = new List<string> { "vibrant", "bold", "warm" }
            },
            new Palette
            {
                Id = 6,
                Colors = new List<string> { "#f4e04d", "#f2a541", "#f08a5d", "#b83b5e" },
                Highlighted = false,
                Tags = new List<string> { "warm", "modern", "soft" }
            },
            new Palette
            {
                Id = 7,
                Colors = new List<string> { "#6a0572", "#a40a3c", "#ff1e56", "#ffc93c" },
                Highlighted = true,
                Tags = new List<string> { "bold", "unique", "vibrant" }
            },
            new Palette
            {
                Id = 8,
                Colors = new List<string> { "#283c63", "#928a97", "#f2f4f3", "#e2dfd2" },
                Highlighted = false,
                Tags = new List<string> { "neutral", "classic", "modern" }
            }
        );
    }
}
