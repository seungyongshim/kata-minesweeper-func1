namespace Minesweeper.Domain;

public readonly record struct Y(int Value)
{
    public static implicit operator Y(int v) => new(v);

    public static Y operator +(Y a, Y b) => new(a.Value + b.Value);
}

