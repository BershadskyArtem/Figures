using Figures.Core.Logic.Abstractions;

namespace Figures.Core.Logic.Implementations;

public class CircleFigure : IFigure
{
    private readonly double _radius;

    public CircleFigure(double radius)
    {
        _radius = radius;
    }
    
    public string Name { get; } = nameof(CircleFigure);
    
    public double GetArea()
    {
        return 2 * Math.PI * _radius;
    }
}