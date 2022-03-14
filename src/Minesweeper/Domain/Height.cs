namespace Minesweeper.Domain;

public record Height(int Value)
{
    public static implicit operator Height(int v) => new(v);
}

