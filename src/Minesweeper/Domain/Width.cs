namespace Minesweeper.Domain;

public readonly record struct Width(int Value)
{
    public static implicit operator Width(int v) => new(v);
}

