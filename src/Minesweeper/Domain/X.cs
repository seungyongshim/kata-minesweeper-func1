namespace Minesweeper.Domain;

public readonly record struct X(int Value)
{
    public static implicit operator X(int v) => new(v);
}

