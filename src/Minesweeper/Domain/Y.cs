namespace Minesweeper.Domain;

public record Y(int Value)
{
    public static implicit operator Y(int v) => new(v);
}

