namespace TradeAndTravel
{
    public class Weapon : Item
    {
        private const int GeneralWeaponValue = 10;

        public Weapon(string name, Location location = null)
            : base(name, GeneralWeaponValue, ItemType.Weapon, location)
        {

        }
    }
}
