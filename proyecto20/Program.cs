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
      int game=0;
      int pairs=0;
      int[,] matrix = new int[n, m];
      Random rand = new Random();

      int aleatorio=0;
      while (c==1)
      {
        string salida="  ";
        do
        {
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
          game=2;
          pairs =0;
        } while (game==1);
        while (game==2)
        {
          Console.WriteLine("aqui va eljuego");
          printmatrix(matrix,n,m);
          do
          {
            Console.WriteLine("coordenadas del onjetivo 1");
            string coordinates1=Console.ReadLine();
            Console.WriteLine("coordenadas del onjetivo 2");
            string coordinates2=Console.ReadLine();
            verificar(matrix,coordinates1,coordinates2);
            if (verificar(matrix,coordinates1,coordinates2)==true)
            {
              pairs++;
            }
          } while (finish(pairs)==false);
          
          game=3;
        }
        while (game==3)
        {
          Console.WriteLine("aqui se da el resultado de victoria");
          game=0;
        }
        printmatrix(matrix,n,m);

        Console.WriteLine("Deseas volver a jugar ?");
        salida =Console.ReadLine();
        if ( salida.ToLower() =="si")
        {
          c=1;
          for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 7; j++) {
              matrix[i, j] = 0;
            }
          game=1;
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
    static void printmatrix(int[,] matrix,int n, int m){
      for (int i = 0; i < n; i++)
      {
        for (int j = 0; j < m; j++)
        {
          Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
      }
    }
    static bool verificar (int[,] matrix,string coordinates1,string coordinates2){
      int coodenada1 = (int)char.GetNumericValue(coordinates1[coordinates1.IndexOf(",")-1])-1;
      int coodenada2 = (int)char.GetNumericValue(coordinates1[coordinates1.IndexOf(",")+1])-1;
      int coodenada3 = (int)char.GetNumericValue(coordinates2[coordinates2.IndexOf(",")-1])-1;
      int coodenada4 = (int)char.GetNumericValue(coordinates2[coordinates2.IndexOf(",")+1])-1;
      if ((matrix[coodenada1,coodenada2] + matrix[coodenada3,coodenada4])==29)
      {
        Console.WriteLine("coincidencia");
        return true;
      }else{
        Console.WriteLine("error");
        return false;
      }
    }
    static bool finish(int pairs){
      if (pairs==29)
      {
        return true;
      }else
      {
        return false;
      }
    }
  }

}