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

    public static One one { get; private set; } = new One();
    public static Two two { get; private set; } = new Two();
    public static Three three { get; private set; } = new Three();
    public static Four four { get; private set; } = new Four();
    public static Five five { get; private set; } = new Five();
    public static Six six { get; private set; } = new Six();
    public static Seven seven { get; private set; } = new Seven();
    public static Eight eight { get; private set; } = new Eight();


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
            new MineField(width, height, new Arr<ICell>(Enumerable.Repeat(new Zero(), width.Value * height.Value)));

    public static Option<int> index1D(X x, Y y, MineField @this) => (x.Value, y.Value) switch
    {
        ( < 0, _) => None,
        (_, < 0) => None,
        (var a, _) when a >= @this.Width.Value => None,
        (_, var a) when a >= @this.Height.Value => None,
        (var a, var b) => Some(b + a * @this.Width.Value)
    };

    public static Func<Bomb> newBomb { get; private set; } =
        () => new();

    public static Func<MineField, Func<X, Func<Y, Func<Func<ICell, ICell>, MineField>>>> ReplaceItem { get; private set; } =
        @this => x => y => hof =>
            index1D(x, y, @this).Match(r => @this with
            {
                Cells = @this.Cells.SetItem(r, hof(@this.Cells[r]))
            }, () => @this);
}

