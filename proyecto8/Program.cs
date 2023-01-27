using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace casting
{
  class Program
  {
    static void Main(string[]args){
      int [,] matriz_estatica = {{10,20,30,40},{50,60,70,80}};//new int [2,4] ;
      int i;
      int j;
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