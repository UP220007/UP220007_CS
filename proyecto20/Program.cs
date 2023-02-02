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
      string [] coordinates1 = new string[2];
      string coordinates2;
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
            for (int i = 0; i < 2; i++)
            {
              do{
                Console.WriteLine("coordenadas del onjetivo "+ (i+1)+" en forjato\"(x,y)\"");
                //coordinates1[i]=Console.ReadLine();
                coordinates1[i]=",,,,,";
                //int a=1;
              } while (verificar_coordenadas(coordinates1[i])==false);
            }
            /*do
            {
              Console.WriteLine("coordenadas del onjetivo 2");
              coordinates2=Console.ReadLine();
            } while (verificar_coordenadas(coordinates2)==false);*/
            verificar(matrix,coordinates1[0],coordinates1[1]);
            if (verificar(matrix,coordinates1[0],coordinates1[1])==true)
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
    static bool verificar_coordenadas(string coordinates1){
      if (coordinates1.Length<5||coordinates1.Length>5||string.IsNullOrEmpty(coordinates1)==true)
      {
        return false;
      }else
      {
        if (coordenadas_recorrer(coordinates1)==true)
        {
          if (verificador_repeticiones(coordinates1)==true)
          {
            if (verificar_formato(coordinates1) == false)
            {
              return false;
            } else
            {
              return true;
            } 
          }else
          {
            return false;
          }
        }else
        {
          return false;
        }
      }
    }
    static bool coordenadas_recorrer(string coordinates1){
      /*int contador =0;
      string bloqueos = "qwertyuiopasdfghjklñzxcvbnm<.-{}+´¿'!#$%&/=?¡¨*[]:_;QWERTYUIOPASDFGHJKLÑZ>XCVBNM<^`~\"\\";
      for (int i = 0; i <= coordinates1.Length; i++)
      {
        for (int j = 0; j <= bloqueos.Length; j++)
        {
          if (coordinates1[i]!=bloqueos[j])
          {
            contador++;
          }
        }
      }
      if (contador==coordinates1.Length)
      {
        return true;
      }else
      {
        return false;
      }*/
      string input = "123,456(789)";
      bool valid = true;
      for (int i = 0; i < coordinates1.Length; i++)
      {
        char c = coordinates1[i];
        if (!(char.IsDigit(c) || c == ',' || c == '(' || c == ')'))
        {
          valid = false;
          break;
        }
      }
      if (valid)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    static bool verificar_formato(string coordenadas){
      char a= coordenadas[coordenadas.IndexOf(",")-1];
      char b= coordenadas[coordenadas.IndexOf(",")+1];//desborde
      char c= coordenadas[0];
      char d= coordenadas[4];
      Console.WriteLine(a+" "+b+" "+c+" "+d);
      if (char.IsDigit(a)&&char.IsDigit(b)&&c=='('&&d==')')
      {
        return true;
      }else
      {
        return false;
      }
    }
    static bool verificador_repeticiones(string coordenadas){
      int parentecis=0;
      int comas=0;
      int parentesis2=0;
      for (int i = 0; i <= coordenadas.Length; i++)
      {
        if (coordenadas[i]=='(')
        {
          parentecis++;
        } else if(coordenadas[i]==')')
        {
          parentesis2++;
        }else if (coordenadas[i]==',')
        {
          comas++;
        }
      }
      if (parentecis==1&&parentesis2==1&&comas==1)
      {
        return true;
      }else
      {
        return false;
      }
    }
  }

}