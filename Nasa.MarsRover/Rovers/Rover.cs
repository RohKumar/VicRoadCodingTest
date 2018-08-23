using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Nasa.MarsRover.LandingSurface;

namespace Nasa.MarsRover.Rovers
{
    public class Rover : IRover
    {
        public Coordinate Position { get; set; }
        public CardinalDirection CardinalDirection { get; set; }
        private bool isDeployed;
        private readonly IDictionary<Direction, Action> DirectionMethodDictionary;
        private readonly IDictionary<CardinalDirection, Action> leftMoveDictionary;
        private readonly IDictionary<CardinalDirection, Action> rightMoveDictionary;
        private readonly IDictionary<CardinalDirection, Action> forwardMoveDictionary;

        public Rover()
        {
            DirectionMethodDictionary = new Dictionary<Direction, Action>
            {
                {Direction.Left, () => leftMoveDictionary[CardinalDirection].Invoke()},
                {Direction.Right, () => rightMoveDictionary[CardinalDirection].Invoke()},
                {Direction.Forward, () => forwardMoveDictionary[CardinalDirection].Invoke()}
            };

            leftMoveDictionary = new Dictionary<CardinalDirection, Action>
            {
                {CardinalDirection.North, () => CardinalDirection = CardinalDirection.West},
                {CardinalDirection.East, () => CardinalDirection = CardinalDirection.North},
                {CardinalDirection.South, () => CardinalDirection = CardinalDirection.East},
                {CardinalDirection.West, () => CardinalDirection = CardinalDirection.South}
            };

            rightMoveDictionary = new Dictionary<CardinalDirection, Action>
            {
                {CardinalDirection.North, () => CardinalDirection = CardinalDirection.East},
                {CardinalDirection.East, () => CardinalDirection = CardinalDirection.South},
                {CardinalDirection.South, () => CardinalDirection = CardinalDirection.West},
                {CardinalDirection.West, () => CardinalDirection = CardinalDirection.North}
            };
            
            forwardMoveDictionary = new Dictionary<CardinalDirection, Action>
            {
                {CardinalDirection.North, () => {Position = new Coordinate(Position.X, Position.Y + 1);}},
                {CardinalDirection.East, () => {Position = new Coordinate(Position.X + 1, Position.Y);}},
                {CardinalDirection.South, () => {Position = new Coordinate(Position.X, Position.Y - 1);}},
                {CardinalDirection.West, () => {Position = new Coordinate(Position.X - 1, Position.Y);}}
            };
        }

        public void Deploy(ISurface aLandingSurface, Coordinate aCoordinate, CardinalDirection aDirection)
        {
            if (aLandingSurface.IsValid(aCoordinate))
            {
                Position = aCoordinate;
                CardinalDirection = aDirection;
                isDeployed = true;
                return;
            }

            throwDeployException(aLandingSurface, aCoordinate);
        }

        public void Move(IEnumerable<Direction> Directions)
        {
            foreach (var Direction in Directions)
            {
                DirectionMethodDictionary[Direction].Invoke();
            }
        }

        public bool IsDeployed()
        {
            return isDeployed;
        }

        private static void throwDeployException(ISurface aLandingSurface, Coordinate aCoordinate)
        {
            var size = aLandingSurface.GetSize();
            var exceptionMessage = String.Format("Deploy failed for Coordinate ({0},{1}). Landing surface size is {2} x {3}.",
                aCoordinate.X, aCoordinate.Y, size.Width, size.Height);
            throw new RoverDeployException(exceptionMessage);
        }
    }
}
