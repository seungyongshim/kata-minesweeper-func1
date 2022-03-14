namespace Minesweeper.Domain;

public record X(int Value)
{
    public static implicit operator X(int v) => new(v);
}

