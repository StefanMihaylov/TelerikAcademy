using System;
using System.Collections.Generic;
using FightersCon.MovableObjects;

namespace FightersCon
{
    public class KeyboardInterface : IUserInterface
    {
        public void ProcessInput(WorldObject hero, List<WorldObject> otherObjects)
        {
            if (!Console.KeyAvailable) return;

            bool collisionLeft = false;
            bool collisionRight = false;
            bool collisionTop = false;
            bool collisionBottom = false;
            foreach (var item in otherObjects)
            {
                if ((item is SuperHero) == false)
                {
                    if (CollisionDispatcher.IsCollided(hero, item, DirectionType.Left)) 
                    {
                        collisionLeft = true;
                    }
                    if (CollisionDispatcher.IsCollided(hero, item, DirectionType.Right))
                    {
                        collisionRight = true;
                    }
                    if (CollisionDispatcher.IsCollided(hero, item, DirectionType.Top))
                    {
                        collisionTop = true;
                    }
                    if (CollisionDispatcher.IsCollided(hero, item, DirectionType.Bottom))
                    {
                        collisionBottom = true;
                    }
                }
            }

            var keyInfo = Console.ReadKey();
            var oneLeft = new MatrixCoords(0, -2);
            var oneRight = new MatrixCoords(0, 2);
            var oneUp = new MatrixCoords(-1, 0);
            var oneDown = new MatrixCoords(1, 0);
            if (keyInfo.Key.Equals(ConsoleKey.LeftArrow))
            {
                if (hero.TopLeft.Col > 0 && !collisionLeft)
                {
                    hero.TopLeft = hero.TopLeft + oneLeft;
                }


            }
            else if (keyInfo.Key.Equals(ConsoleKey.RightArrow))
            {
                if ((hero.TopLeft.Col < (Program.ConsoleCols - hero.GetImage().GetLength(1) - 1)) && !collisionRight)
                {
                    hero.TopLeft = hero.TopLeft + oneRight;
                }

            }
            else if (keyInfo.Key.Equals(ConsoleKey.UpArrow))
            {
                if (hero.TopLeft.Row > 0 && !collisionTop)
                {
                    hero.TopLeft = hero.TopLeft + oneUp;
                }

            }
            else if (keyInfo.Key.Equals(ConsoleKey.DownArrow))
            {
                if ((hero.TopLeft.Row < (Program.ConsoleRows - hero.GetImage().GetLength(0))) && !collisionBottom)
                {
                    hero.TopLeft = hero.TopLeft + oneDown;
                }

            }
            else if (keyInfo.Key.Equals(ConsoleKey.Spacebar)) // shooting
            {

            }
            while (Console.KeyAvailable)
            {
                Console.ReadKey();
            }
        }



    }
}
