using LanguageExt;
using Minesweeper.Domain;
using static LanguageExt.Prelude;

namespace Minesweeper;

public static class Prelude
{
    public static ICell click(ICell cell) => cell switch
    {
        Covered c => c.Inner,
        _ => cell
    };

    public static ICell plus(ICell cell) => cell switch
    {
        Zero => one,
        One => two,
        Two => three,
        Three => four,
        Four => five,
        Five => six,
        Six => seven,
        Seven => eight,
        _ => cell
    };

    public static Bomb bomb { get; } = new();
    public static Zero zero { get; } = new();
    public static One one { get; } = new();
    public static Two two { get; } = new();
    public static Three three { get; } = new();
    public static Four four { get; } = new();
    public static Five five { get; } = new();
    public static Six six { get; } = new();
    public static Seven seven { get; } = new();
    public static Eight eight { get; } = new();

    public static string show(ICell cell) => cell switch
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

    public static Func<Width, Func<Height, MineField>> newMineField { get; private set; } =
        width => height =>
            new MineField(width, height, Enumerable.Repeat<ICell>(zero, width.Value * height.Value).ToArr());

    public static Option<int> index1D(X x, Y y, MineField @this) => (x.Value, y.Value) switch
    {
        ( < 0, _) => None,
        (_, < 0) => None,
        (var a, _) when a >= @this.Width.Value => None,
        (_, var a) when a >= @this.Height.Value => None,
        (var a, var b) => Some(b + a * @this.Width.Value)
    };

    public static Func<MineField, Func<X, Func<Y, Func<Func<ICell, ICell>, MineField>>>> ReplaceItem { get; private set; } =
        @this => x => y => hof =>
            index1D(x, y, @this).Match(r => @this with
            {
                Cells = @this.Cells.SetItem(r, hof(@this.Cells[r]))
            }, () => @this);
}

