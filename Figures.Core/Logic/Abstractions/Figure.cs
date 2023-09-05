namespace Figures.Core.Logic.Abstractions;

public interface IFigure
{
    public abstract string Name { get; }
    public abstract double GetArea();
    public abstract double GetSimilarityCoefficient();
}