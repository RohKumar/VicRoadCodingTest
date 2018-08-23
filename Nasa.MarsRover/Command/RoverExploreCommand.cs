using System.Collections.Generic;
using Nasa.MarsRover.Rovers;

namespace Nasa.MarsRover.Command
{
    public class RoverExploreCommand : IRoverExploreCommand
    {
        public IList<Direction> Directions { get; private set; }
        private IRover rover;
        
        public RoverExploreCommand(IList<Direction> someDirections)
        {
            Directions = someDirections;
        }

        public CommandType GetCommandType()
        {
            return CommandType.RoverExploreCommand;
        }

        public void Execute()
        {
            rover.Move(Directions);
        }

        public void SetReceiver(IRover aRover)
        {
            rover = aRover;
        }
    }
}
