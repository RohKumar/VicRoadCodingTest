using Nasa.MarsRover.LandingSurface;

namespace Nasa.MarsRover.Command
{
    public class LandingSurfaceSizeCommand : ISurfaceSizeCommand
    {
        public Dimension Dimension { get; private set; }
        private ISurface landingSurface;

        public LandingSurfaceSizeCommand(Dimension aSize)
        {
            Dimension = aSize;
        }

        public CommandType GetCommandType()
        {
            return CommandType.LandingSurfaceSizeCommand;
        }

        public void Execute()
        {
            landingSurface.SetSize(Dimension);
        }

        public void SetReceiver(ISurface aLandingSurface)
        {
            landingSurface = aLandingSurface;
        }
    }
}
