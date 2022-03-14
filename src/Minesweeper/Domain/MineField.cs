using LanguageExt;

namespace Minesweeper.Domain;

public readonly record struct MineField(Width Width, Height Height, Arr<ICell> Cells);
