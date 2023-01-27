using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace casting
{
  class Program
  {
    static int PlusMetod(int x, int y){
      return x+y;
    } 
    static int PlusMetod(int x, int y, int z){
      return x+y+z;
    } 
    static double PlusMetod(double x, double y){
      return x+y;
    }
    static void Main(string[]args){
      int MyNun1 = PlusMetod(8,5);
      int MyNun3 = PlusMetod(8,5,15);
      double MyNum2 = PlusMetod(4.3,6.26);
      Console.WriteLine("int: "+MyNun1);
      Console.WriteLine("double: "+MyNum2);
      Console.WriteLine("int2: "+MyNun3);
      Console.Read();
    }
  }
}