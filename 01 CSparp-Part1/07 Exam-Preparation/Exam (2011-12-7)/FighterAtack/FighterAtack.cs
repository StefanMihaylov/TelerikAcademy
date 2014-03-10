using System;

namespace FighterAtack
{
    class FighterAtack
    {
        static void Main()
        {
            int Px1 = int.Parse(Console.ReadLine());
            int Py1 = int.Parse(Console.ReadLine());
            int Px2 = int.Parse(Console.ReadLine());
            int Py2 = int.Parse(Console.ReadLine());
            int Fx = int.Parse(Console.ReadLine());
            int Fy = int.Parse(Console.ReadLine());
            int D = int.Parse(Console.ReadLine());

            int damage = 0;

            int bombX = Fx + D;
            int bombY = Fy;

            int temp;
            if (Px1 > Px2)
            {
                temp = Px2;
                Px2 = Px1;
                Px1 = temp;
            }
            if (Py1 > Py2)
            {
                temp = Py2;
                Py2 = Py1;
                Py1 = temp;
            }

            if (bombX >= Px1 && bombX <= Px2 && bombY >= Py1 && bombY <= Py2)
            {
                damage += 100;
            }
            if ((bombX+1) >= Px1 && (bombX+1) <= Px2 && bombY >= Py1 && bombY <= Py2)
            {
                damage += 75;
            }
            if (bombX >= Px1 && bombX <= Px2 && (bombY+1) >= Py1 && (bombY+1) <= Py2)
            {
                damage += 50;
            }
            if (bombX >= Px1 && bombX <= Px2 && (bombY - 1) >= Py1 && (bombY - 1) <= Py2)
            {
                damage += 50;
            }

            Console.WriteLine(damage+"%");
        }
    }
}
