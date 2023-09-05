namespace Figures.Core.Logic.Abstractions;

public interface IFigure
{
    /// <summary>
    /// Get name of this figure. Just in case we will need to see what figure we are working with.
    /// </summary>
    public abstract string Name { get; }
    /// <summary>
    /// Gets area of this figure
    /// </summary>
    /// <returns></returns>
    public abstract double GetArea();
    /// <summary>
    /// Gets a similarity score based on dimensions. 
    /// </summary>
    /// <returns>Less than zero => Figure is invalid.</returns>
    public abstract double GetSimilarityCoefficient();
}