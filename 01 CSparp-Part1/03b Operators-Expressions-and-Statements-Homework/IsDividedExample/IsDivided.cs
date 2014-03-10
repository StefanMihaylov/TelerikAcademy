namespace IsDividedExample
{
    using System;

    class IsDivided
    {
        // Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.

        static void Main()
        {
            int check = 20; //70;
            bool isDivided = check % 7 == 0 && check % 5 == 0;
            Console.WriteLine("\t {0}",isDivided);
        }
    }
}
