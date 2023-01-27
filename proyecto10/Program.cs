using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace casting
{
  class Program
  {
    static void Mymethod (string country = "norwey"){
      Console.WriteLine(country);
    }
    static void Main(string[]args){
      Mymethod("swden");
      Mymethod("india");
      Mymethod();
      Mymethod("USA");
      Console.Read();
    }
  }
}