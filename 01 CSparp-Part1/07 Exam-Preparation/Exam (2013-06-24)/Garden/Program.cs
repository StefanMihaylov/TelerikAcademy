using System;

namespace Garden
{
    class Program
    {
        static void Main()
        {
            int totalArea = 250;
            decimal tomatoPrize = 0.5m;
            decimal cucumberPrize = 0.4m;
            decimal potatoPrize = 0.25m;
            decimal carrotPrize = 0.6m;
            decimal cabbagePrize = 0.3m;
            decimal beansPrize = 0.4m;

            int tomatoSeed = int.Parse(Console.ReadLine());
            int tomatoArea = int.Parse(Console.ReadLine());
            int cucumberSeed = int.Parse(Console.ReadLine());
            int cucumberArea = int.Parse(Console.ReadLine());
            int potatoSeed = int.Parse(Console.ReadLine());
            int potatoArea = int.Parse(Console.ReadLine());
            int carrotSeed = int.Parse(Console.ReadLine());
            int carrotArea = int.Parse(Console.ReadLine());
            int cabbageSeed = int.Parse(Console.ReadLine());
            int cabbageArea = int.Parse(Console.ReadLine());
            int beansSeed = int.Parse(Console.ReadLine());

            decimal totalCost = (tomatoSeed * tomatoPrize) + (cucumberSeed * cucumberPrize) + (potatoSeed * potatoPrize) +
                (carrotSeed * carrotPrize) + (cabbageSeed * cabbagePrize) + (beansSeed * beansPrize);
            Console.WriteLine("Total costs: {0:f2}",totalCost);

            int area = tomatoArea + cucumberArea + potatoArea + carrotArea + cabbageArea;
            if (area < totalArea)
            {
                Console.WriteLine("Beans area: {0}", totalArea - area);
            }
            else if (area == totalArea)
            {
                Console.WriteLine("No area for beans");
            }
            else
            {
                Console.WriteLine("Insufficient area");
            }
        }
    }
}
