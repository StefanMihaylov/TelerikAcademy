using System;
using System.Text;
using System.IO;

class ReadFile
{
    // Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console. Find in MSDN how to use System.IO.File.ReadAllText(…). Be sure to catch all possible exceptions and print user-friendly error messages.
    
    static void Main()
    {
        Console.Write(" Enters file name along with its full file path: ");
        string filePath = Console.ReadLine();

        try
        {
            string fileContents = File.ReadAllText(filePath);
            Console.WriteLine(fileContents);
        }
        catch (ArgumentException)
        {
            Console.WriteLine(" File path is not valid");
        }
        catch (PathTooLongException)
        {
            Console.WriteLine(" File path or file name are too long");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine(" File path or file could not be found");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine(" File is read-only, you specified a directory or you does not have the required permission");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine(" The file was not found");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine(" The file path is in invalid format");
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0}",ex.Message);
        }

    }
}
