using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int[] numeros = { 1, 5, 8, 9, 17, 22 };
            
            try
            {
                Console.WriteLine(numeros[6]);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}

