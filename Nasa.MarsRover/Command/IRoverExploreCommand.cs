using System.Collections.Generic;
using Nasa.MarsRover.Rovers;

namespace Nasa.MarsRover.Command
{
    public interface IRoverExploreCommand : ICommand
    {
        IList<Direction> Directions { get; }
        void SetReceiver(IRover aRover);
    }
}