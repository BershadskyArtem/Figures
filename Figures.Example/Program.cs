using Figures.Core.Logic.Extensions;
using Figures.Core.Logic.Implementations;

FiguresSolver solver = new FiguresSolver();

solver.RegisterFigure<CircleFigure>();
solver.RegisterFigure<TriangleFigure>();

solver.FigureOutFigureByArgs(1);
