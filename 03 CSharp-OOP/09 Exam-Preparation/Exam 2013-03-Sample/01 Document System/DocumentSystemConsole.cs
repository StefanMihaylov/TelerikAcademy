using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentSystem
{
    // UNFINISHED

    public class DocumentSystemConsole
    {
        static DocumentSystem system;
        static void Main()
        {
            system = new DocumentSystem();
            IList<string> allCommands = ReadAllCommands();
            ExecuteCommands(allCommands);
        }

        private static IList<string> ReadAllCommands()
        {
            List<string> commands = new List<string>();
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == string.Empty)
                {
                    // End of commands
                    break;
                }
                commands.Add(commandLine);
            }
            return commands;
        }

        private static void ExecuteCommands(IList<string> commands)
        {
            foreach (var commandLine in commands)
            {
                int paramsStartIndex = commandLine.IndexOf("[");
                string cmd = commandLine.Substring(0, paramsStartIndex);
                int paramsEndIndex = commandLine.IndexOf("]");
                string parameters = commandLine.Substring(
                    paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
                ExecuteCommand(cmd, parameters);
            }
        }

        private static void ExecuteCommand(string cmd, string parameters)
        {
            string[] cmdAttributes = parameters.Split(
                new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (cmd == "AddTextDocument")
            {
                Console.WriteLine(system.AddTextDocument(cmdAttributes));
            }
            else if (cmd == "AddPDFDocument")
            {
                Console.WriteLine(system.AddPdfDocument(cmdAttributes));
            }
            else if (cmd == "AddWordDocument")
            {
                Console.WriteLine(system.AddWordDocument(cmdAttributes));
            }
            else if (cmd == "AddExcelDocument")
            {
                Console.WriteLine(system.AddExcelDocument(cmdAttributes));
            }
            else if (cmd == "AddAudioDocument")
            {
                Console.WriteLine(system.AddAudioDocument(cmdAttributes));
            }
            else if (cmd == "AddVideoDocument")
            {
                Console.WriteLine(system.AddVideoDocument(cmdAttributes));
            }
            else if (cmd == "ListDocuments")
            {
                Console.WriteLine(system.ListDocuments());
            }
            else if (cmd == "EncryptDocument")
            {
                Console.WriteLine(system.EncryptDocument(parameters));
            }
            else if (cmd == "DecryptDocument")
            {
                Console.WriteLine(system.DecryptDocument(parameters));
            }
            else if (cmd == "EncryptAllDocuments")
            {
                Console.WriteLine(system.EncryptAllDocuments());
            }
            else if (cmd == "ChangeContent")
            {
                Console.WriteLine(system.ChangeContent(cmdAttributes[0], cmdAttributes[1]));
            }
            else
            {
                throw new InvalidOperationException("Invalid command: " + cmd);
            }
        }
       
    }
}
