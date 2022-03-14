namespace Minesweeper.Domain;

public readonly record struct Y(int Value)
{
    public static implicit operator Y(int v) => new(v);
}

