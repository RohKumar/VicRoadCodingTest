using System.Collections.Generic;
using Nasa.MarsRover.LandingSurface;

namespace Nasa.MarsRover.Rovers
{
    public interface IRover
    {
        Coordinate Position { get; set; }
        CardinalDirection CardinalDirection { get; set; }
        void Deploy(ISurface aLandingSurface, Coordinate aCoordinate, CardinalDirection aDirection);
        void Move(IEnumerable<Direction> Directions);
        bool IsDeployed();
    }
}