using System;
using System.Collections.Generic;
using System.Linq;
using FightersCon.MovableObjects;
using FightersCon.StaticObjects;

namespace FightersCon
{
    public static class CollisionDispatcher
    {

        public static bool HandleCollisions(List<MovableObject> movingObjects, List<StaticObject> staticObjects) // this method calls a second method for a collision of moving andstatic onjects
        {
            //HandleMovingWithStaticCollisions(MovingObjects, StaticObjects);
            bool exitCollision = false;

            var movingObjectWithoutHero = new List<MovableObject>();

            int superHeroIndex = 0;
            int index = 0;
            foreach (var hero in movingObjects)
            {
                if (hero is SuperHero)
                {
                    superHeroIndex = index;
                }
                else
                {
                    movingObjectWithoutHero.Add(hero);
                }
                index++;
            }

            SuperHero superHero = movingObjects[superHeroIndex] as SuperHero;

            foreach (var movingObject in movingObjectWithoutHero)
            {
                if (IsCollided(superHero, movingObject, DirectionType.All))
                {
                    //Menu.MainMenu(superHero, movingObject);
                    Menu menu = new Menu(superHero, movingObject);
                    menu.ExitGame += new EventHandler(ShowExitMessage);
                    menu.ShowMenu();
                }
            }

            foreach (var staticObject in staticObjects)
            {
                if (IsCollided(superHero, staticObject, DirectionType.All))
                {
                    if ((staticObject is House) && superHero.Experience >= Program.LevelExitExperience)
                    {
                        Console.SetCursorPosition(50, 13);
                        Console.Write("YOU WON");
                        Console.SetCursorPosition(35, 14);
                        Console.Write("Press \"Enter\" to start next level");
                        while (true)
                        {
                            var keyInfo = Console.ReadKey();
                            if (keyInfo.Key.Equals(ConsoleKey.Enter))
                            {
                                exitCollision = true;
                                break;
                            }
                            while (Console.KeyAvailable)
                            {
                                Console.ReadKey();
                            }
                        }
                    }
                }
            }

            foreach (var moving in movingObjectWithoutHero)
            {
                foreach (var staticObject in staticObjects)
                {
                    MatrixCoords newSpeed = moving.Speed;
                    if (IsCollided(moving, staticObject, DirectionType.Top) ||
                        IsCollided(moving, staticObject, DirectionType.Bottom))
                    {
                        newSpeed.Row *= -1;
                    }
                    if (IsCollided(moving, staticObject, DirectionType.Left) ||
                        IsCollided(moving, staticObject, DirectionType.Right))
                    {
                        newSpeed.Col *= -1;
                    }
                    moving.Speed = newSpeed;
                }
            }

            for (int i = 0; i < movingObjectWithoutHero.Count; i++)
            {
                for (int j = i + 1; j < movingObjectWithoutHero.Count; j++)
                {
                    MovableObject obj1 = movingObjectWithoutHero[i];
                    MovableObject obj2 = movingObjectWithoutHero[j];

                    if (IsCollided(obj1, obj2, DirectionType.All))
                    {
                        MatrixCoords newSpeed = new MatrixCoords(obj1.Speed.Row, obj1.Speed.Col);
                        newSpeed.Row *= -1;
                        newSpeed.Col *= -1;
                        obj1.Speed = newSpeed;
                        newSpeed = new MatrixCoords(obj2.Speed.Row, obj2.Speed.Col);
                        newSpeed.Row *= -1;
                        newSpeed.Col *= -1;
                        obj2.Speed = newSpeed;
                    }
                }
            }

            return exitCollision;
        }

        public static bool IsCollided(WorldObject first, WorldObject second, DirectionType direction)
        {
            int firstTop = first.TopLeft.Row;
            int firstLeft = first.TopLeft.Col;
            int firstHeight = first.GetImage().GetLength(0);
            int firstWidth = first.GetImage().GetLength(1);
            int firstBottom = first.TopLeft.Row + firstHeight;
            int firstRight = first.TopLeft.Col + firstWidth;

            int secondTop = second.TopLeft.Row;
            int secondLeft = second.TopLeft.Col;
            int secondHeight = second.GetImage().GetLength(0);
            int secondWidth = second.GetImage().GetLength(1);
            int secondBottom = second.TopLeft.Row + secondHeight;
            int secondRight = second.TopLeft.Col + secondWidth;

            bool horizontalMatch = false;
            if (firstHeight >= secondHeight)
            {
                if (secondTop >= firstTop && secondTop <= firstBottom ||
                    secondBottom >= firstTop && secondBottom <= firstBottom)
                {
                    horizontalMatch = true;
                }
            }
            else
            {
                if (firstTop >= secondTop && firstTop <= secondBottom ||
                    firstBottom >= secondTop && firstBottom <= secondBottom)
                {
                    horizontalMatch = true;
                }
            }
            bool verticalMatch = false;
            if (firstWidth >= secondWidth)
            {
                if (secondLeft >= firstLeft && secondLeft <= firstRight ||
                    secondRight >= firstLeft && secondRight <= firstRight)
                {
                    verticalMatch = true;
                }
            }
            else
            {
                if (firstLeft >= secondLeft && firstLeft <= secondRight ||
                    firstRight >= secondLeft && firstRight <= secondRight)
                {
                    verticalMatch = true;
                }
            }

            bool right = (firstRight >= secondLeft && firstRight < secondRight) && horizontalMatch;
            bool left = (firstLeft > secondLeft && firstLeft <= secondRight) && horizontalMatch;
            bool top = (firstTop > secondTop && firstTop <= secondBottom) && verticalMatch;
            bool bottom = (firstBottom >= secondTop && firstBottom <= secondBottom) && verticalMatch;

            switch (direction)
            {
                case DirectionType.Bottom: return bottom;
                case DirectionType.Left: return left;
                case DirectionType.Right: return right;
                case DirectionType.Top: return top;
                case DirectionType.All: return bottom || left || right || top;
                default: return false;
            }
        }


        public static void ShowExitMessage(object sender, EventArgs e)
        {
            Console.Clear();
            Console.SetCursorPosition(40, 13);
            Console.Write("GAME OVER!");
            SuperHero hero = sender as SuperHero;
            if (hero != null)
            {
                Console.SetCursorPosition(34, 14);
                Console.WriteLine("Your experience: {0}", hero.Experience);
            }
            Console.SetCursorPosition(35, 15);
            Console.WriteLine("Press any key to EXIT");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
