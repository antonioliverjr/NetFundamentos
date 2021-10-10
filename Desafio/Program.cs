using System;

namespace Desafio
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Para realizar a divisão, informe quantos resultados deseja dividir:");
            // int n = Int32.Parse(Console.ReadLine());
            // for(int i = 0; i < n; i++)
            // {
            //     Console.WriteLine("Informe dois valores para divisão: (Ex: 2 1)");
            //     string[] line = Console.ReadLine().Split(" ");
            //     double x = double.Parse(line[0]);
            //     double y = double.Parse(line[1]);
            //     if(y == 0)
            //     {
            //         Console.WriteLine("Divisão impossível!");
            //     }
            //     else
            //     {
            //         double divide = x / y;
            //         Console.WriteLine(divide.ToString("N1"));
            //     }
            // }
            // Console.WriteLine("Esse é meu primeiro código C#"); 

            string t = Console.ReadLine();
            char[] arr = t.ToCharArray();
            if(arr.Length <= 140) //complete a condicional
                Console.WriteLine("TWEET");
            else
                Console.WriteLine("MUTE");
        }
    }
}
