using System;

namespace ShipDamage
{
    class Program
    {
        static void Main()
        {
            int Sx1 = int.Parse(Console.ReadLine());
            int Sy1 = int.Parse(Console.ReadLine());
            int Sx2 = int.Parse(Console.ReadLine());
            int Sy2 = int.Parse(Console.ReadLine());
            int H = int.Parse(Console.ReadLine());
            int C1x = int.Parse(Console.ReadLine());
            int C1y = int.Parse(Console.ReadLine());
            int C2x = int.Parse(Console.ReadLine());
            int C2y = int.Parse(Console.ReadLine());
            int C3x = int.Parse(Console.ReadLine());
            int C3y = int.Parse(Console.ReadLine());

            int temp;
            if (Sx1>Sx2)
            {
                temp = Sx2;
                Sx2 = Sx1;
                Sx1 = temp;
            }
            if (Sy2 > Sy1)
            {
                temp = Sy2;
                Sy2 = Sy1;
                Sy1 = temp;
            }

            int result = 0;

            int bombX;
            int bombY;
            bombX = C1x;
            if (C1y < H)
            {
                bombY = C1y + 2 * Math.Abs(C1y - H);
            }
            else bombY = C1y - 2 * Math.Abs(C1y - H);

            if ( Sx1 < bombX && Sx2 > bombX && Sy1 > bombY && Sy2 < bombY )
            {
                result += 100;
            }
            else if ((Sx1 == bombX && Sy1 == bombY) || (Sx2 == bombX && Sy1 == bombY) ||
                    (Sx1 == bombX && Sy2 == bombY) || (Sx2 == bombX && Sy2 == bombY))
            {
                result += 25;
            }
            else if (((Sx1 == bombX || Sx2 == bombX) && (Sy1 > bombY && Sy2 < bombY)) ||
                ((Sy1 == bombY || Sy2 == bombY) && (Sx1 < bombX && Sx2 > bombX)))
            {
                result += 50;
            }

            bombX = C2x;
            if (C2y < H)
            {
                bombY = C2y + 2 * Math.Abs(C2y - H);
            }
            else bombY = C2y - 2 * Math.Abs(C2y - H);

            if (Sx1 < bombX && Sx2 > bombX && Sy1 > bombY && Sy2 < bombY)
            {
                result += 100;
            }
            else if ((Sx1 == bombX && Sy1 == bombY) || (Sx2 == bombX && Sy1 == bombY) ||
                    (Sx1 == bombX && Sy2 == bombY) || (Sx2 == bombX && Sy2 == bombY))
            {
                result += 25;
            }
            else if (((Sx1 == bombX || Sx2 == bombX) && (Sy1 > bombY && Sy2 < bombY)) ||
                ((Sy1 == bombY || Sy2 == bombY) && (Sx1 < bombX && Sx2 > bombX)))
            {
                result += 50;
            }

            bombX = C3x;
            if (C3y < H)
            {
                 bombY = C3y + 2 * Math.Abs(C3y - H);
            }
            else bombY = C3y - 2 * Math.Abs(C3y - H);

            if (Sx1 < bombX && Sx2 > bombX && Sy1 > bombY && Sy2 < bombY)
            {
                result += 100;
            }
            else if ((Sx1 == bombX && Sy1 == bombY) || (Sx2 == bombX && Sy1 == bombY) ||
                    (Sx1 == bombX && Sy2 == bombY) || (Sx2 == bombX && Sy2 == bombY))
            {
                result += 25;
            }
            else if (((Sx1 == bombX || Sx2 == bombX) && (Sy1 > bombY && Sy2 < bombY)) ||
                ((Sy1 == bombY || Sy2 == bombY) && (Sx1 < bombX && Sx2 > bombX)))
            {
                result += 50;
            }

            Console.WriteLine(result+"%");
        }
    }
}
