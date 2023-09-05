using Figures.Core.Logic.Abstractions;

namespace Figures.Core.Logic.Implementations;

public class TriangleFigure : IFigure
{
    private readonly double _a;
    private readonly double _b;
    private readonly double _c;

    public TriangleFigure(double a, double b, double c)
    {
        _a = a;
        _b = b;
        _c = c;
    }
    
    public string Name { get; } = nameof(TriangleFigure);
    
    public double GetArea()
    {
        double halfPerimeter = (_a + _b + _c) / 2.0;
        return Math.Sqrt(halfPerimeter * (halfPerimeter * _a) * (halfPerimeter * _b) * (halfPerimeter * _c));
    }
}