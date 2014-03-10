using MobilePhone;
using System;

class GSMCallHistoryTest
{
    /* 12. Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
         - Create an instance of the GSM class.
         - Add few calls.
         - Display the information about the calls.
         - Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
         - Remove the longest call from the history and calculate the total price again.
         - Finally clear the call history and print it. */

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        GSM hayriePhone = new GSM("Galaxy S4", "Samsung", 1200, "Hayrie Listopadska",
                new Battery("2600 mAh", BatteryType.LiIon, 320, 17), new Display(1920, 1080, 16000000));

        hayriePhone.AddCall("+359888987654", 12);
        hayriePhone.AddCall("+359899123456", 321);
        hayriePhone.AddCall("+359877654321", 120);
        hayriePhone.AddCall("+35921234567", 86);

        foreach (var call in hayriePhone.CalledPhoneNumers)
        {
            Console.WriteLine(call);
        }

        Console.WriteLine();
        Console.WriteLine("Total price of the calls in the history: {0:c}", hayriePhone.CalculatePrice(0.37m));

        int index = 0;
        int maxDuration = hayriePhone.CalledPhoneNumers[index].Duration;
        for (int i = 1; i < hayriePhone.CalledPhoneNumers.Count; i++)
        {
            if (hayriePhone.CalledPhoneNumers[i].Duration > maxDuration)
            {
                maxDuration = hayriePhone.CalledPhoneNumers[i].Duration;
                index = i;
            }
        }
        hayriePhone.DeleteCall(index);
        Console.WriteLine();
        Console.WriteLine("Total price after removing the longest call: {0:c}", hayriePhone.CalculatePrice(0.37m));

        hayriePhone.ClearCalls();
        Console.WriteLine();
        Console.WriteLine("Printing the calls (if any) after list clearing)");
        foreach (var call in hayriePhone.CalledPhoneNumers)
        {
            Console.WriteLine(call);
        }
    }
}

