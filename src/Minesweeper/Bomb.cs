namespace Minesweeper;

public record Bomb : ICell
{
    public override string ToString() => "*";
}
