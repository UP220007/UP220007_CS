using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace casting
{
  class Program
  {
    
    static void Main(string[]args){
      int c=1;
      int activador_aleatorio=1;
      int esatado=0;
      Random x = new Random();
      int aleatorio=0;
      while (c==1)
      {
        if (activador_aleatorio==1)
        {
          aleatorio=x.Next(1,4);
          esatado=0;
          activador_aleatorio=0;
        }
        string salida="  ";
        Console.WriteLine("Juguewmos a adibinar el numero");
        while (esatado==0)
        {
          Console.WriteLine("En que numero del uno al 3 cre3es que estoy pensando ?");
          int jugador = Convert.ToInt32(Console.ReadLine());
          if (jugador==aleatorio)
          {
            Console.WriteLine("omedeto has ganado");
            esatado=1;
          }else if (jugador!=aleatorio)
          {
            Console.WriteLine("oh no que mal perdiste ");
            if(jugador<aleatorio){
              Console.WriteLine("el numero que estaba pensando era mayor ");
            }
            if(jugador>aleatorio){
              Console.WriteLine("el numero que estaba pensando era menor ");
            }
          }
        }
        Console.WriteLine("Deseas volver a jugar ?");
        salida =Console.ReadLine();
        if ( salida.ToLower() =="si")
        {
          c=1;
          activador_aleatorio=1;
          Console.WriteLine("a jugar");
        }else if ( salida.ToLower() =="no")
        {
          c=0;
          esatado=0;
          activador_aleatorio=1;
          Console.WriteLine("adios");
        }
      }
      Console.Read();
    }
  }
}