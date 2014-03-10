using System;

namespace PersonExercise
{
    class Test
    {
        static void Main()
        {
            Person pesho = new Person("Pesho");
            pesho.Age = 15;
            Console.WriteLine(pesho);

            pesho.Age = null;
            Console.WriteLine(pesho);
        }
    }
}
