namespace Minesweeper;

public record Number(int Value) : ICell
{
    public override string ToString() => Value.ToString();
}
