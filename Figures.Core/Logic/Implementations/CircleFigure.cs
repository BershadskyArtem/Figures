using Figures.Core.Logic.Abstractions;

namespace Figures.Core.Logic.Implementations;

public class CircleFigure : IFigure
{
    public string Name { get; } = nameof(CircleFigure);
    private readonly double _radius;

    public CircleFigure(double radius)
    {
        _radius = radius;
    }

    public double GetArea()
    {
        return 2 * Math.PI * _radius;
    }

    public double GetSimilarityCoefficient()
    {
        return _radius >= 0 ? 1 : -1;
    }
}