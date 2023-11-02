namespace FigureLibrary;

public class TriangleVerifier : IShapeVerifier<Triangle>
{
    public bool Verify(Triangle shape)
    {
        var sides = new[] { shape.SideA, shape.SideB, shape.SideC };
        Array.Sort(sides);
        return Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) == Math.Pow(sides[2], 2);
    }
}