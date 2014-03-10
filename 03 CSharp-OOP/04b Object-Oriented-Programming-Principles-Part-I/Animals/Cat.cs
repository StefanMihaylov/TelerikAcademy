namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string name, int age, string sex)
            : base(name, age, sex)
        {

        }

        public override string ProduseSound()
        {
            return "Miawww";
        }
    }
}
