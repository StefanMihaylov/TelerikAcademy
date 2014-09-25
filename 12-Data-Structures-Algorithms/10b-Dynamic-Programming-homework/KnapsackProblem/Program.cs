namespace KnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {

            Console.WriteLine("Test products #1:");
            var products = new List<Product>()
            {
                new Product(){Type = "beer", Weight=3, Cost=2},
                new Product(){Type = "vodka", Weight=8, Cost=12},
                new Product(){Type = "cheese", Weight=4, Cost=5},
                new Product(){Type = "nuts", Weight=1, Cost=4}, // in result
                new Product(){Type = "ham", Weight=2, Cost=3},
                new Product(){Type = "whiskey", Weight=8, Cost=13} // in result
            };

            var result = Solve(products, 10);
            Console.WriteLine("Max weight: {0}, Max Cost: {1}", result.Sum(p => p.Weight), result.Sum(p => p.Cost));
            Console.WriteLine("Products: {0}", string.Join(", ", result.OrderBy(p => p.Weight).Select(p => p.Type)));
            
            //---------------------------------
            Console.WriteLine();
            Console.WriteLine("Test products #2:");
            products = new List<Product>()
            {
                new Product(){Type = "Troyanska slivova", Weight=3, Cost=5},
                new Product(){Type = "Water", Weight=2, Cost=3},
                new Product(){Type = "Trushiya", Weight=1, Cost=4},
            };

            result = Solve(products, 5);
            Console.WriteLine("Max weight: {0}, Max Cost: {1}", result.Sum(p => p.Weight), result.Sum(p => p.Cost));
            Console.WriteLine("Products: {0}", string.Join(", ", result.OrderBy(p => p.Weight).Select(p => p.Type)));
        }

        private static IList<Product> Solve(IList<Product> products, int maxWeight)
        {
            int size = products.Count;
            var costMatrix = new int[size + 1, maxWeight + 1];
            var unitMatrix = new int[size + 1, maxWeight + 1];

            // initialize first row and first column, (it not needed for type int :) )
            for (int col = 0; col < costMatrix.GetLength(0); col++)
            {
                costMatrix[0, col] = 0;
                unitMatrix[0, col] = 0;
            }

            // fill the matrix
            for (int unit = 1; unit < costMatrix.GetLength(0); unit++)
            {
                int currentConst = products[unit - 1].Cost;
                int currentWeight = products[unit - 1].Weight;

                for (int weigth = 1; weigth < costMatrix.GetLength(1); weigth++)
                {
                    var previousCost = costMatrix[unit - 1, weigth];
                    var newCost = 0;

                    if (currentWeight <= weigth)
                    {
                        newCost = currentConst + costMatrix[unit - 1, weigth - currentWeight];
                    }

                    if (previousCost < newCost)
                    {
                        costMatrix[unit, weigth] = newCost;
                        unitMatrix[unit, weigth] = 1;
                    }
                    else
                    {
                        costMatrix[unit, weigth] = previousCost;
                        unitMatrix[unit, weigth] = 0;
                    }
                }
            }

           // Print(costMatrix);
           // Print(unitMatrix);

            var result = FindTheResult(unitMatrix, products);
            return result;
        }

        private static IList<Product> FindTheResult(int[,] unitMatrix, IList<Product> products)
        {
            var result = new List<Product>();

            int weigth = unitMatrix.GetLength(1) - 1;
            for (int i = unitMatrix.GetLength(0) - 1; i >= 0; i--)
            {
                if (unitMatrix[i, weigth] != 0)
                {
                    result.Add(products[i - 1]);
                    weigth -= products[i - 1].Weight;
                }
            }

            return result;
        }

        private static void Print(int[,] matrix)
        {
            int length = 3 * matrix.GetLength(1) + 1;
            Console.WriteLine(new string('-', length));
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("|{0,2}", matrix[row, col]);
                }
                Console.WriteLine("|");
                Console.WriteLine(new string('-', length));
            }
        }
    }
}
