namespace FigureLibrary;

public interface IShapeVerifier<TShape> where TShape: IShape
{
    public bool Verify(TShape shape);
}