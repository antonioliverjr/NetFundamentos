using System;

namespace DigitalInnovationOne
{
    class Program
    {
        public static void Main()
        {
            /*
             * string[] args
             * int numeroDeVezes = 10;

            for(int i=0; i <= numeroDeVezes; i++)
            {
                Console.WriteLine($"Bem Vindo ao curso de .NET {i}");
            }*/
            int tc, a, i;

            int Interval = 0;
            int outInterval = 0;

            tc = int.Parse(Console.ReadLine());

            for (i = 0; i < tc; i++)
            {
                a = int.Parse(Console.ReadLine());

                if (a >= 10 && a <= 20)
                {
                  Interval += 1; 
                }
                else                                                             //Insira sua lógica nos espaços em branco
                {
                  outInterval += 1;
                }

            }
            Console.WriteLine("{0} in", Interval);
            Console.WriteLine("{0} out", outInterval);
            Console.ReadLine();
        }
    }
}
