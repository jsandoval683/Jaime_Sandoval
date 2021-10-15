using System;

namespace PruebaTecnica3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = new int[6] { 1, 8, 6, 7, 2, 5 };
            for(var i = 0; i < myArray.Length; i++)
            {
                for(var j = i; j < myArray.Length; j++)
                {
                    if (i == j)
                    {

                    }else
                    {
                        if (myArray[i] + myArray[j] == 10)
                        {
                            Console.WriteLine(myArray[i] + " " + myArray[j]);
                        }
                    }
                    
                }
            }
        }
    }
}
