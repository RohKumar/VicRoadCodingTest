using System;
using System.Reflection;
using System.Text;
using Autofac;

namespace Nasa.MarsRover
{
    public class Program
    {
        static void Main(string[] args)
        {
            var commandString = buildCommand();
            var containerBuilder = createContainerBuilder();

            using (var container = containerBuilder.Build())
            {
                var commandMain = container.Resolve<ICommandMain>();
                commandMain.Execute(commandString);
                var Reports = commandMain.GetCombinedRoverReport();
                Display(commandString, Reports);
            }
        }

        private static ContainerBuilder createContainerBuilder()
        {
            var programAssembly = Assembly.GetExecutingAssembly();

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(programAssembly)
                .AsImplementedInterfaces();

            return builder;
        }

        private static void Display(string commandString, string Reports)
        {
            Console.WriteLine("Input:");
            Console.WriteLine(commandString);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Output:");
            Console.WriteLine(Reports);
            Console.Write(Environment.NewLine);
            Console.Write("Press <enter> to exit...");
            Console.ReadLine();
        }

        private static string buildCommand()
        {
            var commandStringBuilder = new StringBuilder();
            commandStringBuilder.AppendLine("5 5");
            commandStringBuilder.AppendLine("1 2 N");
            commandStringBuilder.AppendLine("LMLMLMLMM");
            commandStringBuilder.AppendLine("3 3 E");
            commandStringBuilder.Append("MMRMMRMRRM");
            return commandStringBuilder.ToString();
        }
    }
}
