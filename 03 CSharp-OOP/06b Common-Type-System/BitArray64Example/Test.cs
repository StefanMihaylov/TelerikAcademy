namespace BitArray64Example
{
    using System;

    class Test
    {
        static void Main()
        {
            BitArray64 array = new BitArray64();

            array[1] = 1;
            array[3] = 1;
            array[6] = 1;
            array[11] = 1;
            array[18] = 1;
            array[29] = 1;
            array[37] = 1;
            array[51] = 1;
            array[62] = 1;
           // array[64] = 1;   // throw exception

            for (int index = 0; index < array.Length; index+=2)
            {
                Console.WriteLine("Array[{0,2}] : {1} | Array[{2,2}] : {3}", index, array[index], index+1, array[index+1]);
            }

            // only elements with "1"
            Console.WriteLine();
            for (int index = 0; index < array.Length; index ++)
            {
                if (array[index]==1)
                {
                    Console.WriteLine("Array[{0,2}] : {1}", index, array[index]);
                }                
            }
        }
    }
}
