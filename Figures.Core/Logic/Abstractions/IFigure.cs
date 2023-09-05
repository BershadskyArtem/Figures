namespace Figures.Core.Logic.Abstractions;

public interface IFigure
{
    public string Name { get; }
    public double GetArea();
}