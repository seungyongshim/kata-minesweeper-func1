namespace Minesweeper.Domain;

public readonly record struct X(int Value)
{
    public static implicit operator X(int v) => new(v);

    public static X operator +(X a, X b) => new(a.Value + b.Value);
}

