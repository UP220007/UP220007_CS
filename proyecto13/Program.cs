using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace casting
{
  class Program
  {
    
    static void Main(string[]args){
      Random x = new Random();
      for (int i = 0; i < 10; i++)
      {
        int aleatorio =x.Next();
        Console.WriteLine("Numero Aleatorio: "+ aleatorio);
      }
      Console.Read();
    }
  }
}