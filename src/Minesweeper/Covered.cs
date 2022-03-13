namespace Minesweeper;

public record Covered(ICell? Inner = default) : ICell
{
    public override string ToString() => ".";
}
