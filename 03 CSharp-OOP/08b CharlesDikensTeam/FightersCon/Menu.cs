namespace FightersCon
{
    using System;
    using System.Linq;
    using FightersCon.MovableObjects;

    public class Menu
    {
        public event EventHandler ExitGame;

        private static string[] menuItems;
        private int index;
        private static bool stayInMenu;
        private static bool[] active;
        private readonly SuperHero superHero;
        private readonly MovableObject enemy;

        public Menu(SuperHero hero, MovableObject movableObject)
        {
            this.superHero = hero;
            this.enemy = movableObject;
            this.index = 0;
            stayInMenu = true;
        }

        public void ShowMenu()
        {
            MenuInitialize();
            DrawMenu();

            while (stayInMenu)
            {
                GetKeyboardState();
                DrawMenu();
            }
        }

        public static void MenuInitialize()
        {
            menuItems = new string[] { "1. Attack", "2. Escape" }; //, "3. Buy LIFE", "4. Buy ARMOUR", "5. Buy AMMUNITION", "6. Buy ATTACK", "7. Exit from this menuItems." };

            active = new bool[menuItems.Length];
            for (int i = 0; i < active.Length; i++)
            {
                active[i] = true;
            }
        }

        public void GetKeyboardState()
        {
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.DownArrow)
            {
                if (index < menuItems.Length - 1)
                {
                    index++;
                }
            }
            if (info.Key == ConsoleKey.UpArrow)
            {
                if (index > 0)
                {
                    index--;
                }
            }
            if (info.Key == ConsoleKey.Enter)
            {
                this.EnterMenu(index);
            }

            while (Console.KeyAvailable)
            {
                Console.ReadKey();
            }
        }

        public void DrawMenu()
        {
            int cursorTop = 13;
            int cursorLeft = 40;

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.SetCursorPosition(cursorLeft, cursorTop + i);
                if (i == this.index && active[i] == true)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(menuItems[i]);
                }
                else if (i == this.index && active[i] == false)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(menuItems[i]);
                }
                else if (active[i] == true)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(menuItems[i]);
                }
                else if (active[i] == false)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(menuItems[i]);
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void EnterMenu(int index)
        {
            switch (index)
            {
                case 0: //attack
                    {
                        if (this.superHero.Attack(this.enemy))
                        {
                            enemy.IsDestroyed = true;
                        }
                        else
                        {
                            ExitGame(this.superHero, new EventArgs());
                        }
                        stayInMenu = false;
                    }

                    break;

                case 1: //escape
                    {
                        MatrixCoords newCoords = enemy.Speed;
                        if (CollisionDispatcher.IsCollided(this.superHero, this.enemy, DirectionType.Bottom))
                        {
                            newCoords.Row = 1;
                        }
                        if (CollisionDispatcher.IsCollided(this.superHero, this.enemy, DirectionType.Top))
                        {
                            newCoords.Row = -1;
                        }
                        if (CollisionDispatcher.IsCollided(this.superHero, this.enemy, DirectionType.Left))
                        {
                            newCoords.Col = -1;
                        }
                        if (CollisionDispatcher.IsCollided(this.superHero, this.enemy, DirectionType.Right))
                        {
                            newCoords.Col = 1;
                        }
                        enemy.Speed = newCoords;

                        stayInMenu = false;
                    }

                    break;
            }
        }
    }
}