using System;

namespace PruebaTecnica1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = new int[5];

            int mayor = 0;

            Console.WriteLine("Ingrese 5 números enteros");

            for (var i = 0; i < myArray.Length; i++)
            {
                leer:
                var aux = Convert.ToInt32(Console.ReadLine());
                if (aux < 1 || aux > 100)
                {
                    Console.WriteLine("Debe ingresar un valor entre 1 y 100");
                    goto leer;
                }
                else
                {
                    myArray[i] = aux;
                }

            }

            for(var i = 0; i < myArray.Length; i++)
            {
                if (mayor < myArray[i])
                {
                    mayor = myArray[i];
                }
            }

            Console.Clear();

            Console.WriteLine(mayor);
        }
    }
}
