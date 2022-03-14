using LanguageExt;

namespace Minesweeper.Domain;

public readonly record struct Covered(ICell Inner = default) : ICell;
