using Figures.Core.Logic.Abstractions;

namespace Figures.Core.Logic.Extensions;

public class FiguresSolver
{
    private readonly List<Type> _registeredFigures = new();

    public  void RegisterFigure<T>() where T : IFigure
    {
        if (_registeredFigures.Contains(typeof(T)))
            return;
        _registeredFigures.Add(typeof(T));
    }
    
    public double FigureOutFigureByArgs(params double[] args)
    {
        if (args.Length == 0)
            throw new ArgumentException("Not enough arguments to figure out this figure");
        
        var matches = _registeredFigures
            .Where(
                x => x
                    .GetConstructors()
                    .Any(
                        cif => cif.GetParameters().Length == 1))
            .ToList();

        if (!matches.Any())
            throw new ArgumentException("Unable to retrieve a type of this figure");

        var o = matches.Select(x => Activator.CreateInstance(x, new object[] { args.Length })).Cast<IFigure>();

        var orderedMatches = o.OrderBy(b => b.GetSimilarityCoefficient());

        var theOne = orderedMatches.First();
        
        if(theOne is null)
            throw new ArgumentException("Unable to retrieve a type of this figure");
        
        if(theOne.GetSimilarityCoefficient() <= 0)
            throw new ArgumentException("Unable to retrieve a type of this figure");
        
        return theOne.GetArea();
    }
    
}