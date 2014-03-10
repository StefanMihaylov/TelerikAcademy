namespace SubstringExtention
{
    using System;
    using System.Text;

    class SubstringTest
    {
        // 1. Implement an extension method Substring(int index, int length) for the class StringBuilder that returns new StringBuilder and has the same functionality as Substring in the class String.

        static void Main()
        {
            StringBuilder text = new StringBuilder();
            text.Append("Implement an extension method Substring(int index, int length) for the class StringBuilder");

            // first overload
            StringBuilder result = text.Substring(13);
            Console.WriteLine(result);
            // second overload
            result = text.Substring(13, 16);
            Console.WriteLine(result);
        }
    }
}
