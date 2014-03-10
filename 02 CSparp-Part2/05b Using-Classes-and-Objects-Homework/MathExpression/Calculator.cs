using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace MathExpression
{
    class Calculator
    {
        /* * Write a program that calculates the value of given arithmetical expression. The expression can contain the following elements only:
                Real numbers, e.g. 5, 18.33, 3.14159, 12.6
                Arithmetic operators: +, -, *, / (standard priorities)
                Mathematical functions: ln(x), sqrt(x), pow(x,y)
                Brackets (for changing the default priorities)
	      Examples:
	            (3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7)  ~ 10.6
	            pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3)  ~ 21.22
	       Hint: Use the classical "shunting yard" algorithm and "reverse Polish notation". */

        static List<string> functions = new List<string>() { "ln", "pow", "sqrt" };
        static List<string> aritmaticOperations = new List<string>() { "+", "-", "*", "/" };

        static List<string> SeparateTokens(string input)
        {
            var result = new List<string>();
            var number = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '-' && (i==0 || input[i-1] == ',' || input[i-1] == '(')) // negative number
                {
                    number.Append("-");
                }
                else if(char.IsDigit(input[i]) || input[i]=='.')  // number
                {
                    number.Append(input[i]);
                }
                else if(!char.IsDigit(input[i]) && input[i]!='.' && number.Length>0) // end of number
	            {
                    result.Add(number.ToString());
                    number.Clear();
                    i--;
	            }
                else if (input[i] == '(' || input[i] == ')') // Brackets
                {
                    result.Add(input[i].ToString());
                }
                else if (aritmaticOperations.Contains(input[i].ToString())) // Arithmetic operators
                {
                    result.Add(input[i].ToString());
                }
                else if (input[i] == ',') // function argument separator
                {
                    result.Add(",");
                }
                else if (i < input.Length - 1 && input.Substring(i, 2).ToLower() == "ln")
                {
                    result.Add("ln");
                    i++;
                }
                else if (i < input.Length - 2 && input.Substring(i, 3).ToLower() == "pow")
                {
                    result.Add("pow");
                    i += 2;
                }
                else if (i < input.Length - 3 && input.Substring(i, 4).ToLower() == "sqrt")
                {
                    result.Add("sqrt");
                    i += 3;
                }
                else
                {
                    throw new ArgumentException("invalid expression");
                }
            }

            if (number.Length > 0)
            {
                result.Add(number.ToString());
            }

            return result;
        }

        static int Precedence(string aritmOperator)
        {
            if (aritmOperator == "+" || aritmOperator == "-")
            {
                return 1;
            }
            else
	        {
                return 2;
	        }             
        }

        static Queue<string> ConvertToReversePolishNotation(List<string> tokens)
        {
            Stack<string> stack = new Stack<string>();
            Queue<string> queue = new Queue<string>();

            double number;

            for (int i = 0; i < tokens.Count; i++)
            {
                var currentToken = tokens[i];
                if (double.TryParse(currentToken,out number))
                {
                    queue.Enqueue(currentToken);
                }
                else if (functions.Contains(currentToken))
                {
                    stack.Push(currentToken);
                }
                else if (currentToken == ",")
                {
                    if (!stack.Contains("(") || stack.Count == 0)
                    {
                        throw new ArgumentException("invalid brackets or function separator");
                    }
                    while (stack.Count != 0 && stack.Peek() != "(")
                    {
                        queue.Enqueue(stack.Pop());
                    }
                }
                else if (aritmaticOperations.Contains(currentToken))
                {
                    while (stack.Count!=0  && aritmaticOperations.Contains(stack.Peek()) && 
                        Precedence(currentToken) <= Precedence(stack.Peek()))
                    {
                        queue.Enqueue(stack.Pop());
                    }
                    stack.Push(currentToken);
                }
                else if (currentToken == "(")
                {
                    stack.Push("(");
                }
                else if (currentToken == ")")
                {
                    if (!stack.Contains("(") || stack.Count == 0)
                    {
                        throw new ArgumentException("invalid brackets position");
                    }
                    while (stack.Count != 0 && stack.Peek() != "(")
                    {
                        queue.Enqueue(stack.Pop());
                    }
                    stack.Pop(); // delete "("

                    if (stack.Count != 0 && functions.Contains(stack.Peek()))  // function before "(" 
                    {
                        queue.Enqueue(stack.Pop());
                    }
                }
            }
            while (stack.Count != 0)
            {
                if (stack.Peek() == "(" || stack.Peek() == ")")
                {
                    throw new ArgumentException("invalid brackets position");
                }
                queue.Enqueue(stack.Pop());
            }


            return queue;
        }

        static double CalculateResult(Queue<string> queue)
        {
            Stack<double> stack = new Stack<double>();

            while (queue.Count != 0)
            {
                string currentToken = queue.Dequeue();
                double number;
                if (double.TryParse(currentToken,out number))
                {
                    stack.Push(number);
                }
                else if( aritmaticOperations.Contains(currentToken))
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid Expression");
                    }
                    double value1 = stack.Pop();
                    double value2 = stack.Pop();

                    if (currentToken == "+")
                    {
                        stack.Push(value2 + value1);
                    }
                    else if (currentToken == "-")
                    {
                         stack.Push(value2 - value1);
                    }
                    else if (currentToken == "*")
                    {
                        stack.Push(value2 * value1);
                    }
                    else if (currentToken == "/")
                    {
                        stack.Push(value2 / value1);
                    }
                }
                else if(currentToken == "pow")
                {
                    if (stack.Count < 2)
                    {
                        throw new ArgumentException("Invalid Expression");
                    }
                    double value1 = stack.Pop();
                    double value2 = stack.Pop();
                    stack.Push(Math.Pow(value2,value1));
                }
                else if (currentToken == "sqrt")
                {
                    if (stack.Count < 1)
                    {
                        throw new ArgumentException("Invalid Expression");
                    }
                    double value = stack.Pop();
                    stack.Push(Math.Sqrt(value));
                }
                else if (currentToken == "ln")
                {
                    if (stack.Count < 1)
                    {
                        throw new ArgumentException("Invalid Expression");
                    }
                    double value = stack.Pop();
                    stack.Push(Math.Log(value));
                }
            }

            if (stack.Count == 1)
            {
                return stack.Pop();
            }
            else
            {
                throw new ArgumentException("Invalid Expression");   
            }
        }

        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            while (true)
            {
                Console.WriteLine(" Enter \"1\" to calculate first default expression");
                Console.WriteLine(" Enter \"2\" to calculate second default expression");
                Console.WriteLine(" Enter \"3\" to calculate your expression");
                Console.Write(" Enter \"4\" for exit. Enter your choise [1..4]: ");
                int choise = int.Parse(Console.ReadLine());
                Console.WriteLine();

                string input;
                switch (choise)
                {
                    case 1:
                        input = "(3 + 5.3) * 2.7 - ln(22) / pow(2.2, -1.7)";
                        Console.WriteLine(" Expression: {0}", input);
                        break;
                    case 2:
                        input = "pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5 * 0.3)";
                        Console.WriteLine(" Expression: {0}", input);
                        break;
                    case 3:
                        Console.Write(" Expression: ");
                        input = Console.ReadLine();
                        break;
                    default:
                        return;
                }  

                input = input.Trim();
                string trimmedInput = input.Replace(" ", string.Empty);

                try
                {
                    var listOfTokens = SeparateTokens(trimmedInput);
                    var reversePolishNotation = ConvertToReversePolishNotation(listOfTokens);
                    var finalResult = CalculateResult(reversePolishNotation);
                    Console.WriteLine(" Result: {0:f3}", finalResult);
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }
        }        
    }
}
