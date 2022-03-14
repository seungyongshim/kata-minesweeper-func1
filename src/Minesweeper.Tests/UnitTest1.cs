using AutoFixture.Xunit2;
using FluentAssertions;
using Minesweeper.Domain;
using Xunit;
using static Minesweeper.Prelude;

namespace Minesweeper.Tests;

public class CellSpec
{
    [Theory, AutoMoqData]
    public void Covered(Covered cell)
    {
        show(cell).Should().Be(".");
    }

    [Fact]
    public void Clicked()
    {
        var cell = new Covered(one);
        var ret = click(cell);

        ret.Should().BeOfType<One>();
    }

    [Fact]
    public void CreateMineField()
    {
        var sut = newMineField(3)(3);

        sut.Cells.Count.Should().Be(9);
    }

    [Fact]
    public void ShowOne()
    {
        show(one).Should().Be("1");
    }
}
