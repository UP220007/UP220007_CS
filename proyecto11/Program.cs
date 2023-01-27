using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace casting
{
  class Program
  {
    static int PlusMetodInt(int x, int y){
      return x+y;
    } 
    static double PlusMetodDouble(double x, double y){
      return x+y;
    }
    static void Main(string[]args){
      int MyNun1 = PlusMetodInt(8,5);
      double MyNum2 = PlusMetodDouble(4.3,6.26);
      Console.WriteLine("int: "+MyNun1);
      Console.WriteLine("double: "+ MyNum2);
      Console.Read();
    }
  }
}