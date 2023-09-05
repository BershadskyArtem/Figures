using Figures.Core.Logic.Implementations;
using Xunit;

namespace Figures.Tests.Figures.Triangle;

public class TriangleTests
{
    [Theory]
    [InlineData(1.5, 1, 2)]
    [InlineData(2.5, 6, 5)]
    public void AreaShouldBeEqualToExpected(double a, double b, double c)
    {
        //Init
        TriangleFigure sut = new TriangleFigure(a, b, c);

        //Run
        var result = sut.GetArea();

        double halfPerimeter = (a + b + c) / 2.0;
        double area = Math.Sqrt(halfPerimeter * (halfPerimeter * a) * (halfPerimeter * b) * (halfPerimeter * c));

        //Assert
        Assert.Equal(result, area);
    }

    [Theory]
    [InlineData(1, 2, 3)]
    public void ShouldThrowWhenInvalidTriangle(double a, double b, double c)
    {
        
        TriangleFigure sut = new TriangleFigure(a, b, c);
        
        Assert.True(sut.GetSimilarityCoefficient() < 0);
    }
}