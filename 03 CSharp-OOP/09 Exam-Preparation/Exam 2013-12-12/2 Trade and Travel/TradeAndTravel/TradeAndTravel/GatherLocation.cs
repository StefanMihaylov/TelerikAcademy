namespace TradeAndTravel
{
    public abstract class GatherLocation : Location, IGatheringLocation
    {
        public GatherLocation(string name, ItemType gatheredType, ItemType RequiredType, LocationType type)
            : base(name, type)
        {
            this.GatheredType = gatheredType;
            this.RequiredItem = RequiredType;
        }

        public ItemType GatheredType { get; protected set; }

        public ItemType RequiredItem { get; protected set; }

        public abstract Item ProduceItem(string name);
    }
}
