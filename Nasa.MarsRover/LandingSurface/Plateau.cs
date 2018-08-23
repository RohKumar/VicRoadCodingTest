namespace Nasa.MarsRover.LandingSurface
{
    public class Plateau : ISurface
    {
        private Dimension size { get; set; }

        public void SetSize(Dimension aSize)
        {
            size = aSize;
        }

        public Dimension GetSize()
        {
            return size;
        }

        public bool IsValid(Coordinate aCoordinate)
        {
            var isValidX = aCoordinate.X >= 0 && aCoordinate.X <= size.Width;
            var isValidY = aCoordinate.Y >= 0 && aCoordinate.Y <= size.Height;
            return isValidX && isValidY;
        }
    }
}
