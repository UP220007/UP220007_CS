using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace casting
{
  class Program
  {
    static void Main(string[]args){
      int [,] matriz_estatica = new int [2,4] ;
      int i;
      int j;
      int y=0;
      for ( i = 0; i < 2; i++)
      {
        for ( j = 0; j < 4; j++)
        {
          y++;
          Console.WriteLine(" introduce el dato  " + y );
          matriz_estatica[i,j]=Convert.ToInt32(Console.ReadLine());
        }
        Console.WriteLine("");
      }
      for ( i = 0; i < 2; i++)
      {
        for ( j = 0; j < 4; j++)
        {
          Console.Write(" " + matriz_estatica[i,j]);
        }
        Console.WriteLine("");
      }
    Console.Read();
    }
  }
}