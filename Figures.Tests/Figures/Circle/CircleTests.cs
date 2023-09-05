using Figures.Core.Logic.Implementations;
using Xunit;

namespace Figures.Tests.Figures.Circle;

public class CircleTests
{
    
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(4.15)]
    public void AreaShouldBeEqualToExpected(double radius)
    {
        //Init
        CircleFigure sut = new CircleFigure(radius);
        
        //Run
        var result = sut.GetArea();
        
        //Assert
        Assert.Equal(result, radius * radius * Math.PI, 3);
    }

    [Theory]
    [InlineData(-1)]
    public void ShouldThrowWhenRadiusIsNegative(double radius)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            CircleFigure sut = new CircleFigure(radius);
        });
    }
    
}