using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace casting
{
  class Program
  {
    static void Main(string[]args){
      string[]cars={"volvo","bmw","ford","mazda"};
      cars[0]="opel";
      Console.WriteLine(cars[0]);
    Console.Read();
    }
  }
}