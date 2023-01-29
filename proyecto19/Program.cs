using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//matriz random llenada aleatoriamente sin repetir daros 
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
      int n = 4;
      int m = 7;
      int[,] matrix = new int[n, m];
      Random rand = new Random();

      int aleatorio=0;
      while (c==1)
      {
        string salida="  ";

        for (int i = 0; i < n; i++)
        {
          for (int j = 0; j < m; j++)
          {
          int num = rand.Next(1, n * m + 1);
          while (isDuplicate(matrix, num))
            {
              num = rand.Next(1, n * m + 1);
            }
            matrix[i, j] = num;
          }
        }
        for (int i = 0; i < n; i++)
        {
          for (int j = 0; j < m; j++)
          {
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
    static bool isDuplicate(int[,] matrix, int num)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == num)
                {
                    return true;
                }
            }
        }
        return false;
    }  
  }

}