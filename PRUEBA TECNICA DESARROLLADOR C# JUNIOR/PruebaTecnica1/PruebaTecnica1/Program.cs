using System;

namespace PruebaTecnica1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = new int[5] { 1, 10, 5, 4, 5};
            int mayor = 0;
            for(var i = 0; i<myArray.Length; i++)
            {
                if (mayor < myArray[i])
                {
                    mayor = myArray[i];
                }
            }
            Console.WriteLine(mayor);
        }
    }
}
