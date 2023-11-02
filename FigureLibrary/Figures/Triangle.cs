namespace FigureLibrary;

public class Triangle : IShape
{
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }

    public double CalculateArea()
    {
        var isValid = IsValidTriangle(SideA, SideB, SideC);
        if (!isValid)
        {
            throw new ArgumentException("Invalid triangle side values.");
        }

        var s = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
    }


    
    private static bool IsValidTriangle(double a, double b, double c)
    {
        var hasNonNegativeSides = a > 0 && b > 0 && c > 0;
        var satisfiesTriangleInequality = a + b > c && a + c > b && b + c > a;

        return hasNonNegativeSides && satisfiesTriangleInequality;
    }
}
