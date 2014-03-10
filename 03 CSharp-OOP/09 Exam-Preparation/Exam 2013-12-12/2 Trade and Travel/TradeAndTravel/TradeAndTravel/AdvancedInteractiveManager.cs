namespace TradeAndTravel
{
    using System.Linq;

    public class AdvancedInteractiveManager : InteractionManager
    {
        public AdvancedInteractiveManager()
            : base()
        {

        }

        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                default:
                    item = base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
                    break;
            }
            return item;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "forest":
                    location = new Forest(locationName);
                    break;
                case "mine":
                    location = new Mine(locationName);
                    break;
                default:
                    location = base.CreateLocation(locationTypeString, locationName);
                    break;
            }
            return location;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    HandleGatherInteraction(actor, commandWords[2]);
                    break;
                case "craft":                    
                    HandleCraftInteraction(actor, commandWords[2], commandWords[3]);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }

        }

        private void HandleCraftInteraction(Person actor, string craftItem, string itemName)
        {
            if (craftItem == "armor")
            {
                bool isItemPresent = actor.ListInventory().Any(item => item.ItemType == ItemType.Iron);
                if (isItemPresent)
                {
                    this.AddToPerson(actor, new Armor(itemName, null));
                }
            }
            else if (craftItem == "weapon")
            {
                bool isItemPresent = actor.ListInventory(). Any(item => item.ItemType == ItemType.Iron) && 
                                     actor.ListInventory(). Any(item => item.ItemType == ItemType.Wood);
                if (isItemPresent)
                {
                    this.AddToPerson(actor, new Weapon(itemName, null));
                }
            }
        }

        private void HandleGatherInteraction(Person actor, string itemName)
        {
            var gatherLocation = actor.Location as GatherLocation;
            if (gatherLocation != null)
            {
                bool isItemPresent = actor.ListInventory().Any(item => item.ItemType == gatherLocation.RequiredItem);
                if (isItemPresent)
                {
                    this.AddToPerson(actor, gatherLocation.ProduceItem(itemName));
                }
            }
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
             Person person = null;
             switch (personTypeString)
             {
                 case "merchant":
                     person = new Merchant(personNameString, personLocation);
                     break;
                 default:
                     person = base.CreatePerson(personTypeString, personNameString, personLocation);
                     break;
             }
             return person;
        }
    }
}
