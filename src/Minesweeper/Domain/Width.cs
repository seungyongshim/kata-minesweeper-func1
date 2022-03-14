namespace Minesweeper.Domain;

public record Width(int Value)
{
    public static implicit operator Width(int v) => new(v);
}

