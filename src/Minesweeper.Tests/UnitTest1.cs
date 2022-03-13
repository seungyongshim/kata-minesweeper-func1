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

    [Fact]
    public void CreateMineField()
    {
        var sut = createMineField(3, 3);

        sut.Cells.Count.Should().Be(9);
    }
}
