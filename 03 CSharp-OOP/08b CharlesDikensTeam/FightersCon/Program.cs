using System;
using FightersCon.MovableObjects;
using FightersCon.StaticObjects;

namespace FightersCon
{
    public class Program
    {
        public const int ConsoleRows = 39;
        public const int ConsoleCols = 100;
        private const int HeroDataArealength = 12;

        public const int LevelExitExperience = 500;        

        static void Main()
        {
            Console.SetBufferSize(ConsoleCols + HeroDataArealength, ConsoleRows);
            Console.SetWindowSize(ConsoleCols + HeroDataArealength, ConsoleRows);

            Engine engine = new Engine(new ConsoleRenderer(ConsoleRows, ConsoleCols, 0), new KeyboardInterface());
            try
            {
                int level = 1;
                while (true)
                {
                    FillTheMap(engine, level);

                    engine.Run(100);

                    level = 2;
                }
            }
            catch (InvalidPowerValueException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        public static void FillTheMap(Engine engine, int i)
        {
            if (i == 1)
            {
                engine.AddObject(new SuperHero(new MatrixCoords(34, 0), new MatrixCoords(0, 0), 500, 300));

                engine.AddObject(new House(new MatrixCoords(0, 86)));
                engine.AddObject(new Tree(new MatrixCoords(28, 42)));
                engine.AddObject(new Tree(new MatrixCoords(5, 20)));
                engine.AddObject(new Tree(new MatrixCoords(9, 50)));

                engine.AddObject(new Warrior(new MatrixCoords(25, 100), new MatrixCoords(1, -1), 550));
                engine.AddObject(new Wolf(new MatrixCoords(32, 60), new MatrixCoords(-1, 0), 520));
                engine.AddObject(new Rabbit(new MatrixCoords(0, 26), new MatrixCoords(1, 1)));
                engine.AddObject(new Monkey(new MatrixCoords(15, 0), new MatrixCoords(-1, -1)));
            }
            else if (i == 2)
            {                
                SuperHero ourHero = (SuperHero)engine.AllObjects.Find(h => h is SuperHero);
                ourHero.TopLeft = new MatrixCoords(34, 0);

                engine.StaticObjects.Clear();
                engine.AllObjects.Clear();
                engine.MovingObjects.Clear();

                engine.AddObject(ourHero);
                engine.AddObject(new House(new MatrixCoords(0, 86)));
                engine.AddObject(new Tree(new MatrixCoords(0, 72)));
                engine.AddObject(new Tree(new MatrixCoords(7, 72)));
                engine.AddObject(new Tree(new MatrixCoords(7, 82)));
                engine.AddObject(new Tree(new MatrixCoords(25, 42)));
                engine.AddObject(new Tree(new MatrixCoords(5, 10)));
                engine.AddObject(new Tree(new MatrixCoords(9, 50)));

                engine.AddObject(new Warrior(new MatrixCoords(25, 100), new MatrixCoords(0, -1), 800));
                engine.AddObject(new Wolf(new MatrixCoords(32, 60), new MatrixCoords(-1, 0), 730));
                engine.AddObject(new Rabbit(new MatrixCoords(0, 26), new MatrixCoords(1, 0)));
                engine.AddObject(new Monkey(new MatrixCoords(15, 0), new MatrixCoords(0, 1)));
            }
        }
    }
}
