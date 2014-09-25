namespace DataConvert.Client
{
    using DataConvert.Client.ServiceReferenceTest;
    using System;

    class Test
    {
        static void Main()
        {
            ConvertServiceClient client = new ConvertServiceClient();

            var someDate = new DateTime(2011, 05, 17);
            string day = client.Convert(someDate);
            Console.WriteLine(" {0} -> {1}", someDate.ToShortDateString(), day);

            Console.WriteLine(" Today -> {0}", client.Convert(DateTime.Now));
        }
    }
}
