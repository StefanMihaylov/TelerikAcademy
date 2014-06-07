namespace PrintStatistics
{
    using System;

    public class Statistics
    {
        public static void Main()
        {
            double[] statisticalData = new double[50];

            // initialize random data
            Random randomGenerator = new Random();            
            for (int i = 0; i < statisticalData.Length; i++)
            {
                statisticalData[i] = randomGenerator.Next(-100, 101);
            }

            PrintStatistics(statisticalData);
        }

        public static void PrintStatistics(double[] statisticData)
        {
            double maxValue = Max(statisticData);
            Console.WriteLine("Maximal value: {0}", maxValue);

            double minValue = Min(statisticData);
            Console.WriteLine("Minimal value: {0}", minValue);

            double averageValue = Average(statisticData);
            Console.WriteLine("Average value: {0}", averageValue);
        }

        private static double Max(double[] inputData)
        {
            if (inputData == null || inputData.Length == 0)
            {
                throw new ArgumentNullException("Input array shold not be null or empty");
            }

            double maxValue = inputData[0];
            for (int i = 1; i < inputData.Length; i++)
            {
                if (inputData[i] > maxValue)
                {
                    maxValue = inputData[i];
                }
            }

            return maxValue;
        }

        private static double Min(double[] inputData)
        {
            if (inputData == null || inputData.Length == 0)
            {
                throw new ArgumentNullException("Input array shold not be null or empty");
            }

            double minValue = inputData[0];
            for (int i = 1; i < inputData.Length; i++)
            {
                if (inputData[i] < minValue)
                {
                    minValue = inputData[i];
                }
            }

            return minValue;
        }

        private static double Sum(double[] inputData)
        {
            if (inputData == null || inputData.Length == 0)
            {
                throw new ArgumentNullException("Input array shold not be null or empty");
            }

            double sum = 0;
            for (int i = 0; i < inputData.Length; i++)
            {
                sum += inputData[i];
            }

            return sum;
        }

        private static double Average(double[] inputData)
        {
            return Sum(inputData) / inputData.Length;
        }
    }
}