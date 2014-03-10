namespace SubsetSumExample
{
    using System;

    class SubsetSum
    {
        // We are given 5 integer numbers. Write a program that checks if the sum of some subset of them is 0. 
        // Example: 3, -2, 1, 1, 8 -> 1+1-2=0

        static void Main()
        {
            // Enter 5 integers 
            int[] numbers = new int[5];
            for (int i = 0; i < 5; i++)
            {
                while (true)
                {
                    Console.Write("\t Enter integer I{0}: ", i + 1);
                    if (int.TryParse(Console.ReadLine(), out numbers[i]))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\t\t Invalid value. Try again");
                    }
                }
            }
            
            int[] mask = new int[5];
            int sum;
            int counter = 0;
            for (int i = 1; i < 32; i++)
            {
                // Convert int to array of bits. 
                // Subset of the array elements is formed as range of numbers from 1 to 31 in binary format
                string intAsString = Convert.ToString(i, 2).PadLeft(5, '0');
                for (int j = 0; j < 5; j++)
                {
                    if (intAsString[j]=='1')
                    {
                        mask[j] = 1;
                    }
                    else
                    {
                        mask[j] = 0;
                    }
                }

                //calculate the sum of the subset.
                sum=0;
                for (int j = 0; j < 5; j++)
                {
                    sum += numbers[j] * mask[j];
                }
                if (sum == 0)
                {
                    counter++;
                    // print the result
                    Console.Write("\t Subset of elements #{0}: ",counter);
                    for (int j = 0; j < 5; j++)
                    {
                        if (mask[j]==1)
                        {
                            Console.Write("I{0} = {1,2}  ",j+1, numbers[j]);
                        }
                    }
                    Console.WriteLine();
                }
            }
            if (counter==0)
            {
                Console.WriteLine("\t Subset of elements do not exist");
            }
        }
    }
}
