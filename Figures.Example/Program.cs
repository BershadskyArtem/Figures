using Figures.Core.Logic.Extensions;
using Figures.Core.Logic.Implementations;

FiguresSolver solver = new FiguresSolver();

solver.RegisterFigure<CircleFigure>();
solver.RegisterFigure<TriangleFigure>();

solver.FigureOutFigureByArgs(1);

double radius = 10;
var circle = new CircleFigure(radius);
Console.WriteLine($"Area of circle with radius {radius} is {circle.GetArea()}");