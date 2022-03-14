using LanguageExt;

namespace Minesweeper.Domain;

public record Covered(ICell Inner = default) : ICell;
