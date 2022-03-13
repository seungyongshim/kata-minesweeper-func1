using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageExt;
using static LanguageExt.Prelude;

namespace Minesweeper;

public record MineField(Width Width, Height Height, Lst<ICell> Cells)
{
    public Option<ICell> this[Y y, X x] => (x.Value, y.Value) switch
    {
        (< 0, _) => None,
        (_, < 0) => None,
        (var a, _) when a >= Width.Value  => None,
        (_, var a) when a >= Height.Value => None,
        (var a, var b) => Some(Cells[b + (a * Width.Value)])
    };
}
