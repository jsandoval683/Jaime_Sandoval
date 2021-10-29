using System;

namespace PruebaTecnica2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = new int[10];

            Console.WriteLine("Escriba 10 números del 1 al 5");

            for(int i = 0; i < myArray.Length; i++)
            {
                leer:
                var num = Convert.ToInt32(Console.ReadLine());

                if(num < 1 || num > 5)
                {
                    Console.WriteLine("El número no está entre 1 y 5, ingrese uno correcto");
                    goto leer;
                }
                else
                {
                    myArray[i] = num;
                }
            }

            Console.Clear();

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
