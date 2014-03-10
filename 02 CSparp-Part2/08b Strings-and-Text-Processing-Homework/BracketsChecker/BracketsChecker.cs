using System;
using System.Text;

class BracketsChecker
{
    // Write a program to check if in a given expression the brackets are put correctly.
    // Example of correct expression: ((a+b)/5-d).
    // Example of incorrect expression: )(a+b)).

    static bool IsBracketsCorrect(string expression)
    {
        int openBracketCounter = 0;
        int closedBracketCounter = 0;
        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(')
            {
                openBracketCounter++;
            }
            else if (expression[i] == ')')
            {
                closedBracketCounter++;
            }
            if (closedBracketCounter > openBracketCounter)
            {
                return false;
            }
        }

        if (closedBracketCounter == openBracketCounter)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static void Main()
    {
        string expression = @"((a+b)/5-d)";
        bool result = IsBracketsCorrect(expression);
        Console.WriteLine(" Expression \"{0}\" is {1}correct", expression, result ? "" : "in");

        expression = @")(a+b))";
        result = IsBracketsCorrect(expression);
        Console.WriteLine(" Expression \"{0}\" is {1}correct", expression, result ? "" : "in");

        expression = @"(((a+b)+c/2)*d";
        result = IsBracketsCorrect(expression);
        Console.WriteLine(" Expression \"{0}\" is {1}correct", expression, result ? "" : "in");
    }
}

