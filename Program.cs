using System;

namespace tablero{
    class program{
        static void datos(){
            int [,]Relleno={{20,10,30,12,24}};
        }
        static int tableWidth =73;
        static void Main(string[]args){
            Console.Clear();
            PrintLine();
            PrintRow(" ","1","2","3","4","5","6","7"," ");

            PrintLine();
            PrintRow("1"," "," "," "," "," "," "," ");

            PrintLine();
            PrintRow("2"," "," "," "," "," "," "," ");

            PrintLine();
            PrintRow("3"," "," "," "," "," "," "," ");

            PrintLine();
            PrintRow("4"," "," "," "," "," "," "," ");

            PrintLine();
            Console.ReadLine();

        }
        static void PrintLine(){
            Console.WriteLine(new string('-',tableWidth));
        }
        static void PrintRow(params string[]colums){
            int width =(tableWidth-colums.Length)/colums.Length;
            string row ="|";
            foreach (string column in colums)
            {
                row+=aligncenter(column,width)+"|";
            }
            Console.WriteLine(row);
        }
        static string aligncenter(string txt, int width){
            txt = txt.Length> width ? txt.Substring(0,width-3)+ ". . .":txt;
            if(string.IsNullOrEmpty(txt)){
                return new string(' ',width);
            }
            else{
                return txt.PadRight(width-(width-txt.Length/2)).PadLeft(width);
            }
        }
        
    }
}
