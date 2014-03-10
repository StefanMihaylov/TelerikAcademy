using System;

namespace AddPolinomialExample
{
    class AddPolinomial
    {
        // 11: Write a method that adds two polynomials. Represent them as arrays of their coefficients as in the example below:
		// x2 + 5 = 1x2 + 0x + 5 -> [1 0 5]

        // 12: Extend the program to support also subtraction and multiplication of polynomials

        static int[] AddPolynomials(int[] polynom1, int[] polynom2)
        {
            int[] output = new int[Math.Max(polynom1.Length, polynom2.Length)];
            for (int index = 0; index < output.Length; index++)
            {
                if (index < polynom1.Length && index < polynom2.Length)
                {
                    output[output.Length - index - 1] = polynom1[polynom1.Length - index - 1] + 
                                                        polynom2[polynom2.Length - index - 1];
                }
                else if (index < polynom1.Length)
                {
                    output[output.Length - index - 1] = polynom1[polynom1.Length - index - 1];
                }
                else
                {
                    output[output.Length - index - 1] = polynom2[polynom2.Length - index - 1];
                }
            }
            return output;
        }

        static int[] SubtractPolynomials(int[] polynom1, int[] polynom2)
        {
            int[] output = new int[polynom1.Length];
            for (int index = 0; index < output.Length; index++)
            {
                output[output.Length - index - 1] = polynom1[polynom1.Length - index - 1] - polynom2[polynom2.Length - index - 1]; 
            }
            return output;
        }

        static int[] MultiplyPolynomials(int[] polynom1, int[] polynom2)
        {
            int[] result = { };
            int[] currentRow = new int[polynom1.Length];
            for (int index2 = 0; index2 < polynom2.Length; index2++)
            {
                for (int index1 = 0; index1 < polynom1.Length; index1++)
                {
                    currentRow[index1] = polynom1[index1] * polynom2[polynom2.Length - index2 - 1];
                }
                result = AddPolynomials(result, ShiftArray(currentRow, index2));
            }
            return result;
        }

        static int[] ShiftArray(int[] polynom, int position)
        {
            int[] result = new int[polynom.Length + position];
            for (int index = 0; index < result.Length; index++)
            {
                if (index < polynom.Length)
                {
                    result[index] = polynom[index];
                }
            }
            return result;
        } 

        public static void printPolynomial(int[] polynom)
        {
            // It is easy to see polynomials as array [5 4 -3 2], not as math expression 5*x^3 + 4*x^2 - 3*x + 2
            Console.Write(" Polynomial:");
            for (int index = 0; index < polynom.GetLength(0); index++)
            {
                Console.Write(" {0,3}", polynom[index]);
            }
            Console.WriteLine();
        }

        public static void printPolynomialMath(int[] polynom)
        {
            // print polynomials as math expression
            Console.Write(" Polynomial:");
            int number;
            for (int index = 0; index < polynom.Length; index++)
            {
                number = polynom[index];
                if (number != 0)
                {
                    Console.Write(" {1} {0}", Math.Abs(number), Math.Sign(number)==1?"+":"-");
                    if (index < polynom.Length - 2)
                    {
                        Console.Write("*X^{0}", polynom.Length - index - 1);
                    }
                    else if (index == polynom.Length - 2)
                    {
                        Console.Write("*X");
                    }
                }
            }
            Console.WriteLine();
        }

        static void RandomPolynomials(int[] polynom1, int[] polynom2, int minElement, int maxElement)
        {
            // Initialize random polinomials
            Random randomGenerator = new Random();
            for (int index = 0; index < polynom1.GetLength(0); index++)
            {
                polynom1[index] = randomGenerator.Next(minElement, maxElement + 1);
                polynom2[index] = randomGenerator.Next(minElement, maxElement + 1);
            }
        }

        public static void UserPolynomial(int[] polynom)
        {
            // initialize polynomial entered by the user
            for (int index = 0; index < polynom.GetLength(0); index++)
            {
                polynom[index] = ArrayLibrary.intInput(string.Format(" Coefficient  X^{0} = ", polynom.Length - index - 1));
            }
        }

        static void Main()
        {
            int polynomLength = ArrayLibrary.intInput(" Enter the degree of the polynomials", 1, 15);
            polynomLength++;
            int[] polynom1 = new int[polynomLength];
            int[] polynom2 = new int[polynomLength];

            Console.WriteLine("  Enter \"1\" to test random polynomials");
            Console.WriteLine("  Enter \"2\" to test your polynomials");
            int choise = ArrayLibrary.intInput("  Enter your choise", 1, 2);
            switch (choise)
            {
                case 1:
                    RandomPolynomials(polynom1,polynom2, -10, 10);    // random polynomials filled with elements from -10 to 10
                    break;
                case 2:
                    Console.WriteLine(" Enter polynomial 1");
                    UserPolynomial(polynom1);
                    Console.WriteLine(" Enter polynomial 2");
                    UserPolynomial(polynom2);
                    break;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                printPolynomialMath(polynom1);
                printPolynomialMath(polynom2);

                Console.WriteLine();
                Console.WriteLine("  Enter \"0\" to exit");
                Console.WriteLine("  Enter \"1\" to add polynomials");
                Console.WriteLine("  Enter \"2\" to subtract polynomials");
                Console.WriteLine("  Enter \"3\" to multiply polynomials");
                choise = ArrayLibrary.intInput("  Enter your choise", 0, 3);
                int[] result = { };
                char operation = ' ';
                switch (choise)
                {
                    case 0:
                        return; // exit
                    case 1:
                        result = AddPolynomials(polynom1, polynom2);
                        operation = '+';
                        break;
                    case 2:
                        result = SubtractPolynomials(polynom1, polynom2);
                        operation = '-';
                        break;
                    case 3:
                        result = MultiplyPolynomials(polynom1, polynom2);
                        operation = '*';
                        break;
                }

                // Print result
                Console.WriteLine();
                printPolynomial(polynom1);
                Console.WriteLine("    {0}", operation);
                printPolynomial(polynom2);
                Console.WriteLine(new string('-', 40));            
                printPolynomial(result);
                Console.WriteLine();

                printPolynomialMath(result);
                Console.WriteLine();
                Console.Write(" Press any key to open the menu again ");
                Console.ReadKey();
            }
        }
    }
}
