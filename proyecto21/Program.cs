using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace casting
{
  class Program
  {
    static void Main(string[]args){
      Console.Clear();
      string[,] tablero = new string[11, 11];
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        tablero[i, j] = "";
                    }
                    else if (i == 0)
                    {
                        tablero[i, j] = j.ToString();
                    }
                    else if (j == 0)
                    {
                        tablero[i, j] = i.ToString();
                    }
                    else
                    {
                        tablero[i, j] = "";
                    }
                }
            }
            Console.Read();
            Console.WriteLine("Ingrese los valores para la matriz:");
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    Console.Write("Ingrese el valor para la coordenada " + i + "," + j + ": ");
                    tablero[i, j] = Console.ReadLine();
                    Console.Clear();
                }
            }
            Console.Clear();
            Console.WriteLine("\nMatriz modificada:");
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    Console.Write(tablero[i, j] + "\t");
                }
                Console.WriteLine();
            }
            
      Console.Read();
      Console.Clear();
      Console.ReadKey();
      Console.Clear();
    }
  }
}