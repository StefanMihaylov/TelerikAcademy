namespace ForumSystem.Data.Migrations
{
    using System;

    public class RandomGenerator : IRandomGenerator
    {
        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private static IRandomGenerator randomGenerator;
        private readonly Random random;

        private RandomGenerator()
        {
            this.random = new Random();
        }

        public static IRandomGenerator Instance
        {
            get
            {
                if (randomGenerator == null)
                {
                    randomGenerator = new RandomGenerator();
                }

                return randomGenerator;
            }
        }

        public int GetNumber(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public string GetString(int length)
        {
            var randomString = new char[length];
            int numberOfLetters = Letters.Length;
            for (int i = 0; i < randomString.Length; i++)
            {
                int randomIndex = this.GetNumber(0, numberOfLetters - 1);
                randomString[i] = Letters[randomIndex];
            }

            return string.Join(string.Empty, randomString);
        }

        public string GetString(int min, int max)
        {
            int randomLength = this.GetNumber(min, max);
            return this.GetString(randomLength);
        }

        public bool GetChance(int persent)
        {
            int value = this.GetNumber(0, 100);
            return value <= persent;
        }
    }
}
