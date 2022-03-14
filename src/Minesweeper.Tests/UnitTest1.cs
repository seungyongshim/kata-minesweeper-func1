using AutoFixture.Xunit2;
using FluentAssertions;
using Minesweeper.Domain;
using Xunit;
using static Minesweeper.Prelude;

namespace Minesweeper.Tests;

public class CellSpec
{
    [Fact]
    public void Clicked()
    {
        var cell = new Covered(one);
        show(cell).Should().Be(".");

        var ret = click(cell);
        ret.Should().BeOfType<One>();
    }

    [Fact]
    public void CreateMineField()
    {
        var sut = newMineField(3)(3);
        sut.Cells.Count.Should().Be(9);

        var sut2 = ReplaceItem(sut)(1)(1)(x => bomb);
        sut2.Cells.Count(x => x is Bomb).Should().Be(1);
    }

    [Fact]
    public void ShowSuccess()
    {
        show(one).Should().Be("1");
        show(two).Should().Be("2");
        show(three).Should().Be("3");
        show(four).Should().Be("4");
        show(five).Should().Be("5");
        show(six).Should().Be("6");
        show(seven).Should().Be("7");
        show(eight).Should().Be("8");
        show(bomb).Should().Be("*");
    }

    [Fact]
    public void PlusSuccess()
    {
        plus(zero).Should().BeOfType<One>();
        plus(one).Should().BeOfType<Two>();
        plus(two).Should().BeOfType<Three>();
        plus(three).Should().BeOfType<Four>();
        plus(four).Should().BeOfType<Five>();
        plus(five).Should().BeOfType<Six>();
        plus(six).Should().BeOfType<Seven>();
        plus(seven).Should().BeOfType<Eight>();
        plus(eight).Should().BeOfType<Eight>();
        plus(bomb).Should().BeOfType<Bomb>();
    }
}
