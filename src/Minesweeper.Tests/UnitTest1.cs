using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;
using static Minesweeper.Prelude;

namespace Minesweeper.Tests;

public class CellSpec
{
    [Theory, AutoMoqData]
    public void Covered(Covered cell)
    {
        cell.ToString().Should().Be(".");
    }

    [Fact]
    public void Clicked()
    {
        var cell = new Covered(new One());
        var ret = click(cell);

        ret.Should().BeOfType<One>();
    }
}
