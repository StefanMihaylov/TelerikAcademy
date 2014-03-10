namespace TradeAndTravel
{
    public class Forest : GatherLocation
    {
        public Forest(string name)
            : base(name, ItemType.Wood, ItemType.Weapon, LocationType.Forest)
        {

        }

        public override Item ProduceItem(string name)
        {
            return new Wood(name, this);
        }
    }
}
