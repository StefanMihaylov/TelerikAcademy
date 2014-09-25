namespace BiDictionary
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var dict = new BiDictionary<string, string, string>();

            dict.Add("Ivan", "Ivanov", "Algorithms");
            dict.Add("Peter", "Ivanov", "Javascript");
            dict.Add("Peter", "Petrov", "Databases");
            dict.Add("Ivan", "Petrov", "Cloud");
            dict.Add("Ivan", "Ivanov", "C#");

            var name = "Ivan";
            var result = dict.FindByFirstKey(name);
            Console.WriteLine("Name {0} => Courses: {1}", name, string.Join(", ", result));

            name = "Ivanov";
            result = dict.FindBySecondKey(name);
            Console.WriteLine("Name {0} => Courses: {1}", name, string.Join(", ", result));

            name = "Ivan";
            var name2 = "Ivanov";
            result = dict.FindByBothKeys(name,name2);
            Console.WriteLine("Name {0} {2} => Courses: {1}", name, string.Join(", ", result), name2);
        }
    }
}
