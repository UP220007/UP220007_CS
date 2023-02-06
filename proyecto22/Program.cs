using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace casting
{
  class Program
  {
    static void Main(string[]args){
      int[,] matrix = new int[11, 11];

            // Inicializar la primera fila y columna con coordenadas
            for (int i = 0; i < 11; i++)
            {
                matrix[0, i] = i;
                matrix[i, 0] = i;
            }

            // Modificar los datos desde la segunda fila y segunda columna
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    Console.WriteLine("Ingrese el valor para la posición [" + i + "," + j + "]:");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            // Imprimir la matriz original
            Console.WriteLine("Matriz original:");
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
            // Modificar la matriz
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    Console.WriteLine("Ingrese el nuevo valor para la posición [" + i + "," + j + "]:");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            // Imprimir la matriz modificada
            Console.WriteLine("Matriz modificada:");
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
      Console.Read();
    }
  }
}