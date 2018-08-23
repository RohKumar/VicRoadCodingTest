using Nasa.MarsRover.LandingSurface;

namespace Nasa.MarsRover
{
    public interface ICommandMain
    {
        void Execute(string commandString);
        ISurface GetLandingSurface();
        string GetCombinedRoverReport();
    }
}
