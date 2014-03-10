namespace TradeAndTravel
{
    class Program
    {
        static void Main()
        {
            var engine = new Engine(new AdvancedInteractiveManager());
            engine.Start();
        }
    }
}
