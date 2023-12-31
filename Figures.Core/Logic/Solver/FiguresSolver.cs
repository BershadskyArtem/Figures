﻿using Figures.Core.Logic.Abstractions;
using Figures.Core.Logic.Implementations;

namespace Figures.Core.Logic.Solver;

public class FiguresSolver
{
    private readonly List<Type> _registeredFigures = new();

    /// <summary>
    /// Register figure. Needed as necessary hints for FigureOutFigureByArgs method.
    /// </summary>
    /// <typeparam name="T">Derived type from Figure</typeparam>
    public void RegisterFigure<T>() where T : IFigure
    {
        if (_registeredFigures.Contains(typeof(T)))
            return;
        _registeredFigures.Add(typeof(T));
    }

    public double FigureOutFigureByArgsCompTime(double arg)
    {
        return new CircleFigure(arg).GetArea();
    }
    
    public double FigureOutFigureByArgsCompTime(double arg, double arg2, double arg3)
    {
        return new TriangleFigure(arg, arg2, arg3).GetArea();
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="args">Tries to predict and calculate area of figure with arbitrary amount of arguments (dimensions).
    /// To provide types for prediction dictionary use RegisterFigure method.
    /// </param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public double FigureOutFigureByArgs(params double[] args)
    {
        //Sanity check
        if (args.Length == 0)
            throw new ArgumentException("Not enough arguments to figure out this figure");
        
        //Find every type with constructor that has the same number of parameters as args.Length.
        //This process can be CACHED when registering type, but type can have more than one constructor with different number of arguments so this will become problematic IMO.  
        var matches = _registeredFigures
            .Where(
                x => x
                    .GetConstructors()
                    .Any(
                        cif => cif.GetParameters().Length == args.Length))
            .ToList();
        
        if (!matches.Any())
            throw new ArgumentException("Unable to retrieve a type of this figure");
        //Prepare arguments
        var objArgs = args.Cast<object>().ToArray();
        //Init all potentially good figures 
        var o = matches.Select(x => Activator.CreateInstance(x, objArgs )).Cast<IFigure>();

        //Order them by their score
        var orderedMatches = o.OrderBy(b => b.GetSimilarityCoefficient());

        //The best of the best. Good boy. 
        var theOne = orderedMatches.First();
        
        if(theOne is null)
            throw new ArgumentException("Unable to retrieve a type of this figure");
        
        if(theOne.GetSimilarityCoefficient() <= 0)
            throw new ArgumentException("Unable to retrieve a type of this figure");
        
        return theOne.GetArea();
    }
    
    
    
    
    
}