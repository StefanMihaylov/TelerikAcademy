using System;

class AcademyTasks
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] tasks = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            tasks[i] = int.Parse(input[i]);
        }

        int limit = int.Parse(Console.ReadLine());

        int result = tasks.Length;
        for (int i = 0; i < tasks.Length; i++)
        {
            for (int j = i + 1; j < tasks.Length; j++)
            {
                int difference = Math.Abs(tasks[i] - tasks[j]);
                if (difference >= limit)
                {
                    int currentDistance = (i + 3) / 2; // първата, стартовата и броя на скоците през 2 задачи
                    currentDistance += (j - i + 1) / 2; // скоци през 2 в интервала, като +1 дава решаване на още една задача ако не скочим до желаната (четни, нечетни и т.н.)
                    result = Math.Min(result, currentDistance);
                }
            }
        }
        Console.WriteLine(result);
    }
}