using Nasa.MarsRover.LandingSurface;
using Nasa.MarsRover.Rovers;

namespace Nasa.MarsRover.Command
{
    public class RoverDeployCommand : IRoverDeployCommand
    {
        public Coordinate DeployCoordinate { get; set; }
        public CardinalDirection DeployDirection { get; set; }
        private IRover rover;
        private ISurface landingSurface;

        public RoverDeployCommand(Coordinate aCoordinate, CardinalDirection aDirection)
        {
            DeployCoordinate = aCoordinate;
            DeployDirection = aDirection;
        }

        public CommandType GetCommandType()
        {
            return CommandType.RoverDeployCommand;
        }

        public void Execute()
        {
            rover.Deploy(landingSurface, DeployCoordinate, DeployDirection);
        }

        public void SetReceivers(IRover aRover, ISurface aLandingSurface)
        {
            rover = aRover;
            landingSurface = aLandingSurface;
        }
    }
}
