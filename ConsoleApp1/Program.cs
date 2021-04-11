using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static int BuscarMayor(int[] elementos)
        {
            int mayor = -1;
            //if (elementos == null)
            //{
            //    throw new NullReferenceException();
            //}
            try
            {
                
                for (int i = 0; i < elementos.Length; i++)
                {
                    int item = elementos[i];
                    if (item > mayor)
                    {
                        mayor = item;
                    }
                }
                
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

            }
            return mayor;
          
        }
        static void Main(string[] args)
        {
            //int num1 = int.Parse(Console.ReadLine());
            //int resultado;
            //bool howWas = int.TryParse(Console.ReadLine(),out resultado);


            int[] numeritos = null;
            //List<int> numeritos = new List<int>() {4,7,2,9,15 };
            try
            {
                int respuesta = BuscarMayor(numeritos);
                Console.WriteLine(respuesta);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
            
            

            
            Console.ReadKey();
        }
    }
}
