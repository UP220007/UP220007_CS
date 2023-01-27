using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace casting
{
  class Program
  {
    static void Mymehod(){
      Console.WriteLine("I just got executed!");
    }
    static void Main(string[]args){
      Mymehod();
      Mymehod();
      Mymehod();
      Console.Read();
    }
  }
}