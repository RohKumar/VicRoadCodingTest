using Nasa.MarsRover.LandingSurface;

namespace Nasa.MarsRover.Command
{
    public interface ISurfaceSizeCommand : ICommand
    {
        Dimension Dimension { get; }
        void SetReceiver(ISurface aLandingSurface);
    }
}