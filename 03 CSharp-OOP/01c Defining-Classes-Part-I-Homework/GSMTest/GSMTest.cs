using MobilePhone;
using System;
using System.Collections.Generic;

class GSMTest
{
    /* 7. Write a class GSMTest to test the GSM class:
            - Create an array of few instances of the GSM class.
            - Display the information about the GSMs in the array.
            - Display the information about the static property IPhone4S. */
    // check rest of exercise conditions in Exercises.txt

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        List<GSM> gsmList = new List<GSM>();

        GSM ferhondePhone = new GSM("Nokia 207", "Nokia", 50, "Ferhonde Guven",
            new Battery("1020 mAh", BatteryType.LiIon, 490, 12), new Display(320, 240, 262000));
        GSM hayriePhone = new GSM("Galaxy S4", "Samsung", 1200, "Hayrie Tekin",
            new Battery("2600 mAh", BatteryType.LiIon, 320, 17), new Display(1920, 1080, 16000000));

        gsmList.Add(ferhondePhone);
        gsmList.Add(hayriePhone);
        gsmList.Add(GSM.IPhone4S); // add static class property

        foreach (var phone in gsmList)
        {
            Console.WriteLine(phone);
        }
    }
}

