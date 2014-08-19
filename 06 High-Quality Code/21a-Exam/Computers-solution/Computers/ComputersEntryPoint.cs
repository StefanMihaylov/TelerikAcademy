namespace Computers
{
    using System;
    using System.IO;
    using Computers.AbstractFactory;

    public class ComputersEntryPoint
    {
        public const string ExitCommand = "Exit";
        public const string ChangeCommand = "Charge";
        public const string ProcessCommand = "Process";
        public const string PlayCommand = "Play";
        public const string InvalidCommand = "Invalid command!";

        public static void Main()
        { 
            // Load data from local HDD if program is run in VS
            if (Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug"))
            {
                Console.SetIn(new StreamReader(@"..\..\Input_1.txt"));
            }

            string manufacturer = Console.ReadLine();
            var factory = new SimpleFactory();

            var computerManufacturer = factory.MakeComputer(manufacturer);
            Computer pc = computerManufacturer.MakePcComputer();
            Computer server = computerManufacturer.MakeServerComputer();
            Computer laptop = computerManufacturer.MakeLaptopComputer();

            while (true)
            {
                var command = Console.ReadLine();
                if (command == null || command.StartsWith(ExitCommand))
                {
                    break;
                }

                var commandPieces = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (commandPieces.Length != 2)
                {
                    throw new ArgumentException(InvalidCommand);
                }

                var commandName = commandPieces[0];
                var commandArgument = int.Parse(commandPieces[1]);

                if (commandName == ChangeCommand)
                {
                    ((LaptopComputer)laptop).ChargeBattery(commandArgument);
                }
                else if (commandName == ProcessCommand)
                {
                    server.Process(commandArgument);
                }
                else if (commandName == PlayCommand)
                {
                    pc.Play(commandArgument);
                }
                else
                {
                    throw new ArgumentException(InvalidCommand);
                }
            }
        }
    }
}