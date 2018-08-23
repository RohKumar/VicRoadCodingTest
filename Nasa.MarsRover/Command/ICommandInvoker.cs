using System.Collections.Generic;
using Nasa.MarsRover.LandingSurface;
using Nasa.MarsRover.Rovers;

namespace Nasa.MarsRover.Command
{
    public interface ICommandInvoker
    {
        void SetLandingSurface(ISurface aLandingSurface);
        void SetRovers(IList<IRover> someRovers);
        void Assign(IEnumerable<ICommand> aCommandList);
        void InvokeAll();
    }
}