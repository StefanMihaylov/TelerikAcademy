namespace IfStatements
{
    public class CookPotato
    {
        public static void Main()
        {
            Potato potato = new Potato();

            if (potato != null)
            {
                if (potato.IsPeeled && !potato.IsRotten)
                {
                    Cook(potato);
                }
            }
        }

        public static void Cook(Potato potato)
        {
        }
    }
}
