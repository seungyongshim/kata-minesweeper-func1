namespace Minesweeper;

public record Covered : ICell
{
    public override string ToString() => ".";
}
