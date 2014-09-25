namespace SubStringCounter.Client
{
    using SubStringCounter.Client.ServiceReferenceTest;
    using System;

    class Test
    {
        static void Main()
        {
            string text = "ala bala nitza";
            string searched = "a";

            StringOccurrenceClient client = new StringOccurrenceClient();

            using (client)
            {
                int result = client.CountSubString(text, searched);
                Console.WriteLine("\n\tString \"{0}\" is found {1} times in \"{2}\"!",searched, result, text);
            }
        }
    }
}
