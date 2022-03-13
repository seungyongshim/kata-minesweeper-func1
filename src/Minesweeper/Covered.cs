namespace Minesweeper;

public record Covered(ICell? Inner = default) : ICell;
