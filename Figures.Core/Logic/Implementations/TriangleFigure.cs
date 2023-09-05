using Figures.Core.Logic.Abstractions;

namespace Figures.Core.Logic.Implementations;

public class TriangleFigure : IFigure
{
    private readonly double _a;
    private readonly double _b;
    private readonly double _c;

    public string Name { get; } = nameof(TriangleFigure);

    public TriangleFigure(double a, double b, double c)
    {
        _a = a;
        _b = b;
        _c = c;
    }

    public double GetArea()
    {
        double halfPerimeter = (_a + _b + _c) / 2.0;
        return Math.Sqrt(halfPerimeter * (halfPerimeter * _a) * (halfPerimeter * _b) * (halfPerimeter * _c));
    }

    public double GetSimilarityCoefficient()
    {
        return _a + _b > _c && _a + _c > _b && _b + _c > _a ? 1 : -1;
    }


    private double GetSimilarityCoefficient(params double[] dimensions)
    {
        if (dimensions.Length != 3)
            return -999999;

        var a = dimensions[0];
        var b = dimensions[1];
        var c = dimensions[2];

        return (a + b > c && a + c > b && b + c > a) ? 1 : -99999;
    }
}