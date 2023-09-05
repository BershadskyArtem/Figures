using Figures.Core.Logic.Abstractions;

namespace Figures.Core.Logic.Implementations;

public class TriangleFigure : IFigure
{
    private readonly double _a;
    private readonly double _b;
    private readonly double _c;

    public string Name { get; protected set; } = nameof(TriangleFigure);

    public TriangleFigure(double a, double b, double c)
    {
        _a = a;
        _b = b;
        _c = c;
        
        CheckRightTriangle(a, b, c);
    }

    private void CheckRightTriangle(double a, double b, double c)
    {
        bool isRight = false;
        if (a > b && a > c)
        {
            isRight = IsRightTriangle(b, c, a);
        }
        else if (b > a && b > c)
        {
            isRight = IsRightTriangle(a, c, b);
        }
        else if (c > a && c > b)
        {
            isRight = IsRightTriangle(a, b, c);
        }

        Name += isRight ? ":RightTriangle" : string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a">catheter</param>
    /// <param name="b">catheter</param>
    /// <param name="c">hypotenuse </param>
    /// <returns></returns>
    private bool IsRightTriangle(double a, double b, double c)
    {
        return Math.Abs(a * a + b * b - c * c) < 0.0000001;
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
}