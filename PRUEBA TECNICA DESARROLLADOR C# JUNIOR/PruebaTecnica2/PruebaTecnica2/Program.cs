using System;

namespace PruebaTecnica2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = new int[10] { 1, 2, 1, 3, 3, 1, 2, 1, 5, 1 };

            for(var i = 1; i <= 5; i++)
            {
                Console.Write(i + ": ");
                for (var j = 0; j< myArray.Length; j++)
                {
                    if(i == myArray[j])
                    {
                        Console.Write("*");
                    }

                }
                Console.WriteLine("");
            }
        }
    }
}
