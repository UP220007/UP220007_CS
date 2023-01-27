using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace casting
{
  class Program
  {
    static void Main(string[]args){
      int c=1;
      int filas=4;
      int columnas=7;
      int activador_aleatorio=1;
      int esatado=0;
      int[,] matrix = new int[4, 7];

      var random = new Random();
      

      int aleatorio=0;
      while (c==1)
      {
        string salida="  ";
        var numbers = Enumerable.Range(1, matrix.Length).OrderBy(x => random.Next()).ToArray();
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 7; j++) {
                matrix[i, j] = numbers[i * 7 + j];
            }
        }

        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 7; j++) {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Deseas volver a jugar ?");
        salida =Console.ReadLine();
        if ( salida.ToLower() =="si")
        {
          c=1;
          for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 7; j++) {
              matrix[i, j] = 0;
            }
        }
          Console.WriteLine("a jugar");
        }else if ( salida.ToLower() =="no")
        {
          c=0;
          Console.WriteLine("adios");
        }
      }
      Console.Read();
    }
  }
}