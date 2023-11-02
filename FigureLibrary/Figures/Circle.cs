namespace FigureLibrary;

public class Circle : IShape
{
    public double Radius { get; set; }

    public double CalculateArea()
    {
        if (Radius <= 0)
        {
            throw new ArgumentException("The radius must be a positive number.");
        }

        return Math.PI * Math.Pow(Radius, 2);
    }
}