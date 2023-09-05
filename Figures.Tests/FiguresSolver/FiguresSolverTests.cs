using Figures.Core.Logic.Implementations;
using Xunit;

namespace Figures.Tests.FiguresSolver;

public class FiguresSolverTests
{
    private readonly Core.Logic.Solver.FiguresSolver _sut = new();

    [Theory]
    [InlineData(1.0)]
    public void ShouldFigureOutWhenOnlyOneFigureIsRegistered(double arg)
    {
        _sut.RegisterFigure<CircleFigure>();

        var result = _sut.FigureOutFigureByArgs(arg);

        Assert.Equal(result, arg * arg * Math.PI);
    }
    
    [Theory]
    [InlineData(1.1)]
    public void ShouldThrownWhenCannotFind(double arg)
    {
        _sut.RegisterFigure<TriangleFigure>();

        Assert.Throws<ArgumentException>(() =>
        {
            var result = _sut.FigureOutFigureByArgs(arg);
        });
    }

    [Theory]
    [InlineData(1.1)]
    public void ShouldFindIfBothPresentCircle(double arg)
    {
        _sut.RegisterFigure<TriangleFigure>();
        _sut.RegisterFigure<CircleFigure>();

        var result = _sut.FigureOutFigureByArgs(arg);

        Assert.Equal(result, arg * arg * Math.PI, 3);
    }

    [Theory]
    [InlineData(2, 2, 3)]
    public void ShouldFindIfBothPresentTriangle(double arg, double arg2, double arg3)
    {
        _sut.RegisterFigure<TriangleFigure>();
        _sut.RegisterFigure<CircleFigure>();

        var result = _sut.FigureOutFigureByArgs(arg, arg2, arg3);

        double halfPerimeter = (arg + arg2 + arg3) / 2.0;
        double area = Math.Sqrt(halfPerimeter * (halfPerimeter * arg) * (halfPerimeter * arg2) * (halfPerimeter * arg3));
        
        Assert.Equal(result, area, 3);
    }
}