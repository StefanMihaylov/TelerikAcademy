namespace Loops
{
    using System;

    public class ArrayTest
    {
        public static void Main()
        {
            int[] array = new int[100];
            Random rand = new Random();

            // Generate random numbers to fill the array
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(1, 51);
            }

            int expectedValue = 20;

            // expectedValue = array[20];
            bool isValueFound = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 10 == 0)
                {                   
                    if (array[i] == expectedValue)
                    {
                        isValueFound = true;                        
                        break;
                    }
                }
            }

            if (isValueFound)
            {
                Console.WriteLine("Value {0} Found", expectedValue);
            }
            else
            {
                Console.WriteLine("Value {0} Not Found", expectedValue);
            }
        }
    }
}
