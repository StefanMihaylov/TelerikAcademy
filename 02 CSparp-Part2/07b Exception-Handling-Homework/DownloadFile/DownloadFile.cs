using System;
using System.Net;

class DownloadFile
{
    // Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg) and stores it the current directory. Find in Google how to download files in C#. Be sure to catch all exceptions and to free any used resources in the finally block.


    static void Main()
    {
        string fileWebAddress = @"http://www.devbg.org/img/Logo-BASD.jpg";
        string destination = @"..\..\";

        string filename = fileWebAddress.Substring(fileWebAddress.LastIndexOf("/") + 1);

        WebClient webClient = new WebClient();
        try
        {            
            Console.Write(" Please wait...");
            webClient.DownloadFile(fileWebAddress, destination + filename);
            Console.WriteLine();
            Console.WriteLine(" File downloaded successfully");            
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Null file web address is not supported");
        }
        catch (WebException)
        {
            Console.WriteLine(" File does not exist or invalid filename");
        }
        catch (Exception ex)
        {
            Console.WriteLine(" {0}",ex.Message);
        }
        finally
        {
            webClient.Dispose();
        }
    }
}

