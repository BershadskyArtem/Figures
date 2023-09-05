using Figures.Core.Logic.Abstractions;

namespace Figures.Core.Logic.Implementations;

public class CircleFigure : IFigure
{
    public string Name { get; } = nameof(CircleFigure);
    private readonly double _radius;

    public CircleFigure(double radius)
    {
        if (radius < 0)
            throw new ArgumentException("Radius cannot be less then zero");

        _radius = radius;
    }

    public double GetArea()
    {
        return Math.PI * _radius * _radius;
    }

    public double GetSimilarityCoefficient()
    {
        return _radius >= 0 ? 1 : -1;
    }
}