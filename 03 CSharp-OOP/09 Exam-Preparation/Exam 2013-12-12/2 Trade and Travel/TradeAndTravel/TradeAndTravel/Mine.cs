namespace TradeAndTravel
{
    public class Mine : GatherLocation
    {
        public Mine(string name)
            : base(name, ItemType.Iron, ItemType.Armor, LocationType.Mine)
        {

        }

        public override Item ProduceItem(string name)
        {
            return new Iron(name, this);
        }
    }
}
