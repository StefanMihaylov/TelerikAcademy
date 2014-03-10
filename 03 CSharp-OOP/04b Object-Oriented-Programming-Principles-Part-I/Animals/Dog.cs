namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string name, int age, string sex)
            : base(name, age, sex)
        {

        }

        public override string ProduseSound()
        {
            return "Woof-Woof";
        }
    }
}
