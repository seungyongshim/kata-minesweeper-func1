using LanguageExt;

namespace Minesweeper.Domain;

public record MineField(Width Width, Height Height, Arr<ICell> Cells);
