using Nasa.MarsRover.LandingSurface;
using Nasa.MarsRover.Rovers;

namespace Nasa.MarsRover.Command
{
    public interface IRoverDeployCommand : ICommand
    {
        Coordinate DeployCoordinate { get; set; }
        CardinalDirection DeployDirection { get; set; }
        void SetReceivers(IRover aRover, ISurface aLandingSurface);
    }
}