namespace Nasa.MarsRover.LandingSurface
{
    public interface ISurface
    {
        void SetSize(Dimension aSize);
        Dimension GetSize();
        bool IsValid(Coordinate aCoordinate);
    }
}