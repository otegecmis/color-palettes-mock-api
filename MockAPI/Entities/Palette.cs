namespace MockAPI.Entities;

public class Palette
{
    public int Id { get; set; }
    public required string[] Colors { get; set; }
    public bool Highlighted { get; set; }
    public List<string>? Tags { get; set; }
}
