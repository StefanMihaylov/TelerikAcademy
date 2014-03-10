namespace AcademyEcosystem
{
    public class Zombie : Animal, ICarnivore
    {
        public Zombie(string name, Point location)
            : base(name, location, 0)
        {

        }

        public int TryEatAnimal(Animal animal)
        {
            return 0;
        }

        public override int GetMeatFromKillQuantity()
        {
            return 10;
        }
    }
}
