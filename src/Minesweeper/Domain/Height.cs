namespace Minesweeper.Domain;

public readonly record struct Height(int Value)
{
    public static implicit operator Height(int v) => new(v);
}

