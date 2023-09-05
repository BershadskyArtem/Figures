namespace Figures.Core.Logic.Abstractions;

public interface IFiguresSolver
{
    public double CalculateArea(IFigure figure);
    public double CalculateArea(IEnumerable<IFigure> figures, string expectedType);
}