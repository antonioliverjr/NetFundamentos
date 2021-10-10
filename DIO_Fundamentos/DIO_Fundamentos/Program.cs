using System;
using System.Collections.Generic;
using System.Linq;

namespace DIO_Fundamentos
{
    class Program
    {
        static void Main(string[] args)
        {
            var totalDeCasosDeTeste = int.Parse(Console.ReadLine());
            // Implemente a solução aqui
            
            for (int i = 0; i < totalDeCasosDeTeste; i++)
            {
                var qtdClientes = int.Parse(Console.ReadLine());
                for(int c = 0; c < qtdClientes; c++)
                {
                    List<string> lista = new List<string>(Console.ReadLine().Split(" "));
                    List<int> listaOrdem = new List<int>();

                    List<int> listagem = lista.ConvertAll(l => Int32.Parse(l));

                    foreach (int item in listagem)
                    {
                        Console.Write(item);
                    }

                    foreach (int item in listagem)
                    {
                        listaOrdem.Add(item);
                    }
                    
                    listaOrdem.Sort();
                    listaOrdem.Reverse();

                    int modifi = 0;
                    
                    Console.WriteLine();
                    foreach (int item in listaOrdem)
                    {
                        Console.Write(item);
                    }

                    for (int o = 0; o < lista.Count; o++)
                    {
                        if(listagem[o] == listaOrdem[o])
                        {
                            modifi += 1;
                        }
                    }
                    Console.WriteLine(modifi);
                }
            }

        }
    }
}
