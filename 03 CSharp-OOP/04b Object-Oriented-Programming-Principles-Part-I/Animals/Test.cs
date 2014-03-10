namespace Animals
{
    using System;
    using System.Linq;

    class Test
    {
        static void Main()
        {
            Animal[] animals = new Animal[] 
            {
                new Tomcat("Tom", 8),
                new Tomcat("Puss in boots", 5),
                new Kitten("Betty", 1),
                new Kitten("Catwoman", 4),
                new Dog("Sharo", 6, "male"),
                new Dog("Liubka", 3, "female"),
                new Frog("Penka",1,"female"),
                new Frog("Mehmed",2,"male"),
            };

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }

            // average age   
            var averageAgeCollection = Animal.AverageAge(animals);

            Console.WriteLine();
            foreach (var animal in averageAgeCollection)
            {
                Console.WriteLine("Animal: {0}, Average age: {1}", animal.Key, animal.Value);
            }
            Console.WriteLine();

        }
    }
}
