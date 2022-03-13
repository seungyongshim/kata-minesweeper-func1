using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageExt;

namespace Minesweeper;

public static class Prelude
{
    public static ICell click(ICell cell) => cell switch
    {
        Covered c => c.Inner,
        _ => cell
    };

    public static string toString(ICell cell) => cell switch
    {
        Covered => ".",
        Zero => " ",
        One => "1",
        Two => "2",
        Three => "3",
        Four => "4",
        Five => "5",
        Six => "6",
        Seven => "7",
        Eight => "8",
        Bomb => "*",
    };

    public static MineField createMineField(int width, int height) =>
        new MineField(width, height, new Lst<ICell> (Enumerable.Repeat(new Zero(), width * height)));

    public static int index1D(X x, Y y, MineField @this) =>
        x.Value + (y.Value * @this.Width.Value);

    public static MineField setBomb(X x, Y y, MineField @this) => @this[y, x].Case switch
    {
        Bomb => @this,
        null => @this,
        _ => @this with { Cells = @this.Cells.SetItem(index1D(x, y, @this), new Bomb()) }
    };
}

public record Width(int Value)
{
    public static implicit operator Width(int v) => new(v);
}

public record Height(int Value)
{
    public static implicit operator Height(int v) => new(v);
}

public record X(int Value)
{
    public static implicit operator X(int v) => new(v);
}

public record Y(int Value)
{
    public static implicit operator Y(int v) => new(v);
}

