using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace casting
{
  class Program
  {
    static void Main(string[]args){
      int c=1;
      int filas=4;
      int columnas=7;
      int activador_aleatorio=1;
      int esatado=0;
      int n = 4;
      int m = 7;
      int game=0;
      int pairs=0;
      string [] coordinates1 = new string[2];
      string coordinates2;
      int[,] matrix = new int[n, m];
      int[] matrix2 = new int[n*m];
      string[,] valores_impresion = new string[n+1,m+1];
      string[,] impresionmatrix = new string[n, m];
      int mostrar_aleatorios=0;
      Random rand = new Random();

      int aleatorio=0;
      while (c==1)
      {
        string salida="  ";
        do
        {
          for (int i = 0; i < n; i++)
          {
            for (int j = 0; j < m; j++)
            {
            int num = rand.Next(1, n * m + 1);
            while (isDuplicate(matrix, num))
              {
                num = rand.Next(1, n * m + 1);
              }
              matrix[i, j] = num;
            }
          }
          for (int i = 0; i < n; i++)
          {
            for (int j = 0; j < m; j++)
            {
              impresionmatrix[i,j]="       ";
            }
          }
          for (int i = 0; i < (n+1); i++)
          {
            for (int j = 0; j < (m+1); j++)
            {
              if (i==0)
              {
                valores_impresion[i,j]="   "+j+"   ";
              }else if (j==0 && i>0)
              {
                valores_impresion[i,j]="   "+i+"   ";
              }else
              {
                valores_impresion[i,j]="       ";
              }
            }
          }
          game=2;
          pairs =0;
        } while (game==1);
        while (game==2)
        {
          do
          {
            for (int i = 0; i < 2; i++)
            {
              do{
                printmatrix(valores_impresion,n+1,m+1);
                Console.WriteLine("coordenadas del objetivo "+ (i+1)+" en formato\"(y,X)\"");
                coordinates1[i]=Console.ReadLine();
                if((verificar_coordenadas(coordinates1[i])==true)&&(verificar_limites(coordinates1[i],n,m)==true)&&(coordinates1[0]!=coordinates1[1]))
                {
                  if (numerico(matrix,coordinates1[i])>9)
                  {
                    valores_impresion[coordenadax(coordinates1[i])+1,coordenaday(coordinates1[i])+1]="  "+ numerico(matrix,coordinates1[i])+"   ";
                    printmatrix(valores_impresion,n+1,m+1);
                    Thread.Sleep(5000);
                  }else
                  {
                    valores_impresion[coordenadax(coordinates1[i])+1,coordenaday(coordinates1[i])+1]="   "+ numerico(matrix,coordinates1[i])+"   ";
                    printmatrix(valores_impresion,n+1,m+1);
                    Thread.Sleep(5000);
                  }
                }
              } while ((verificar_coordenadas(coordinates1[i])==false)||(verificar_limites(coordinates1[i],n,m)==false)||(coordinates1[0]==coordinates1[1]));
            }
            if (verificar(matrix,coordinates1[0],coordinates1[1])==true)
            {
              for (int i = 0; i < 2; i++)
              {
                if (pairs==0||pairs==1)
                {
                  matrix2[pairs]=numerico(matrix,coordinates1[i]);
                  pairs++;
                }else if (pairs>1)
                {
                  if (verificar_encontrados(matrix2,pairs,numerico(matrix,coordinates1[i]))==false)
                  {
                    matrix2[pairs]=numerico(matrix,coordinates1[i]);
                    pairs++;
                  }
                }
              }
            }else
            {
              for (int i = 0; i < 2; i++)
              {
                if (verificar_encontrados(matrix2,pairs,numerico(matrix,coordinates1[i]))==true)
                {
                  
                }else
                {
                  valores_impresion[coordenadax(coordinates1[i])+1,coordenaday(coordinates1[i])+1]="       ";
                }
              }
              printmatrix(valores_impresion,n+1,m+1);
            }
          } while (finish(pairs)==false);
          
          game=3;
        }
        while (game==3)
        {
          Console.Clear();
          Console.BackgroundColor=ConsoleColor.Black;
          Console.ForegroundColor=ConsoleColor.White;
          Console.WriteLine("                                                                                                                                                                  ");
          Console.WriteLine("                                                                                                                                                                  ");
          Console.ForegroundColor=ConsoleColor.Black;
          Console.BackgroundColor=ConsoleColor.Yellow;
          Console.WriteLine("                                                                                                                                                                  ");
          Console.WriteLine("                                                                                                                                                                  ");
          Console.WriteLine("                                                                                                                                                                  ");
          Console.WriteLine("        ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄            ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄   ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄   ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄             ");
          Console.WriteLine("       ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░▌          ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░▌ ▐░░░░░░░░░░░▌▐░░░░░░░░░░▌ ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌            ");
          Console.WriteLine("       ▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀▀▀ ▐░▌           ▀▀▀▀█░█▀▀▀▀ ▐░█▀▀▀▀▀▀▀▀▀  ▀▀▀▀█░█▀▀▀▀ ▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀▀▀             ");
          Console.WriteLine("       ▐░▌          ▐░▌          ▐░▌               ▐░▌     ▐░▌               ▐░▌     ▐░▌       ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌▐░▌          ▐░▌                      ");
          Console.WriteLine("       ▐░█▄▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄▄▄ ▐░▌               ▐░▌     ▐░▌               ▐░▌     ▐░▌       ▐░▌▐░█▄▄▄▄▄▄▄█░▌▐░▌       ▐░▌▐░█▄▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄▄▄             ");
          Console.WriteLine("       ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░▌               ▐░▌     ▐░▌               ▐░▌     ▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌            ");
          Console.WriteLine("       ▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀▀▀ ▐░▌               ▐░▌     ▐░▌               ▐░▌     ▐░▌       ▐░▌▐░█▀▀▀▀▀▀▀█░▌▐░▌       ▐░▌▐░█▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀█░▌            ");
          Console.WriteLine("       ▐░▌          ▐░▌          ▐░▌               ▐░▌     ▐░▌               ▐░▌     ▐░▌       ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌▐░▌                    ▐░▌            ");
          Console.WriteLine("       ▐░▌          ▐░█▄▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄▄▄  ▄▄▄▄█░█▄▄▄▄ ▐░█▄▄▄▄▄▄▄▄▄  ▄▄▄▄█░█▄▄▄▄ ▐░█▄▄▄▄▄▄▄█░▌▐░▌       ▐░▌▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄█░▌            ");
          Console.WriteLine("       ▐░▌          ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░▌ ▐░▌       ▐░▌▐░░░░░░░░░░▌ ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌            ");
          Console.WriteLine("        ▀            ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀   ▀         ▀  ▀▀▀▀▀▀▀▀▀▀   ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀             ");
          Console.WriteLine("                                                                                                                                                                  ");
          Console.WriteLine("        ▄         ▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄       ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄        ▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄   ▄▄▄▄▄▄▄▄▄▄▄                                  ");
          Console.WriteLine("       ▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░▌      ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░▌ ▐░░░░░░░░░░░▌                                 ");
          Console.WriteLine("       ▐░▌       ▐░▌▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀▀▀      ▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀█░▌▐░▌░▌     ▐░▌▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀█░▌                                 ");
          Console.WriteLine("       ▐░▌       ▐░▌▐░▌       ▐░▌▐░▌               ▐░▌          ▐░▌       ▐░▌▐░▌▐░▌    ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌                                 ");
          Console.WriteLine("       ▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄▄▄      ▐░▌ ▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄█░▌▐░▌ ▐░▌   ▐░▌▐░█▄▄▄▄▄▄▄█░▌▐░▌       ▐░▌▐░▌       ▐░▌                                 ");
          Console.WriteLine("       ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     ▐░▌▐░░░░░░░░▌▐░░░░░░░░░░░▌▐░▌  ▐░▌  ▐░▌▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░▌       ▐░▌                                 ");
          Console.WriteLine("       ▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀█░▌ ▀▀▀▀▀▀▀▀▀█░▌     ▐░▌ ▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀█░▌▐░▌   ▐░▌ ▐░▌▐░█▀▀▀▀▀▀▀█░▌▐░▌       ▐░▌▐░▌       ▐░▌                                 ");
          Console.WriteLine("       ▐░▌       ▐░▌▐░▌       ▐░▌          ▐░▌     ▐░▌       ▐░▌▐░▌       ▐░▌▐░▌    ▐░▌▐░▌▐░▌       ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌                                 ");
          Console.WriteLine("       ▐░▌       ▐░▌▐░▌       ▐░▌ ▄▄▄▄▄▄▄▄▄█░▌     ▐░█▄▄▄▄▄▄▄█░▌▐░▌       ▐░▌▐░▌     ▐░▐░▌▐░▌       ▐░▌▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌                                 ");
          Console.WriteLine("       ▐░▌       ▐░▌▐░▌       ▐░▌▐░░░░░░░░░░░▌     ▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░▌      ▐░░▌▐░▌       ▐░▌▐░░░░░░░░░░▌ ▐░░░░░░░░░░░▌                                 ");
          Console.WriteLine("        ▀         ▀  ▀         ▀  ▀▀▀▀▀▀▀▀▀▀▀       ▀▀▀▀▀▀▀▀▀▀▀  ▀         ▀  ▀        ▀▀  ▀         ▀  ▀▀▀▀▀▀▀▀▀▀   ▀▀▀▀▀▀▀▀▀▀▀                                  ");
          Console.WriteLine("                                                                                                                                                                  ");
          Console.WriteLine("                                                                                                                                                                  ");
          Console.WriteLine("                                                                                                                                                                  ");
          Console.BackgroundColor=ConsoleColor.Black;
          Console.ForegroundColor=ConsoleColor.White;
          Thread.Sleep(10000);
          game=0;
        }
        Console.Clear();
        Console.BackgroundColor=ConsoleColor.Black;
        Console.ForegroundColor=ConsoleColor.White;
        Console.WriteLine("                                                                                                                                                                    ");
        Console.WriteLine("                                                                                                                                                                    ");
        Console.BackgroundColor=ConsoleColor.DarkCyan;
        Console.ForegroundColor=ConsoleColor.Black;
        Console.WriteLine("                                                                                                                                                                    ");
        Console.WriteLine("                                                                                                                                                                    ");
        Console.WriteLine("        ________  _______   ________  _______   ________  ________           ___      ___ ________  ___       ___      ___ _______   ________                       ");
        Console.WriteLine("       | \\   ___  \\| \\  ___  \\ | \\   ____ \\| \\  ___  \\ | \\   __   \\| \\   ____ \\         | \\   \\    /  /| \\   __   \\| \\   \\     | \\   \\    /  /| \\  ___  \\ | \\   __   \\                      ");
        Console.WriteLine("        \\  \\   \\_| \\  \\  \\   __/| \\  \\   \\___| \\  \\   __/| \\  \\   \\| \\   \\  \\   \\___|_         \\  \\   \\  /  / |  \\   \\| \\   \\  \\   \\     \\  \\   \\  /  / |  \\   __/| \\  \\   \\| \\   \\                     ");
        Console.WriteLine("         \\  \\   \\  \\ \\  \\  \\   \\_|/_ \\  \\_____   \\  \\   \\_|/_ \\  \\   __   \\  \\_____   \\         \\  \\   \\/  / /  \\  \\   \\ \\ \\   \\  \\   \\     \\  \\   \\/  / /  \\  \\   \\_|/_ \\  \\   _  _ \\                    ");
        Console.WriteLine("          \\  \\   \\_ \\ \\  \\  \\   \\_| \\  \\|____| \\   \\  \\   \\_| \\  \\  \\   \\  \\   \\|____| \\   \\         \\  \\    / /    \\  \\   \\ \\ \\   \\  \\   \\____ \\  \\    / /    \\  \\   \\_| \\  \\  \\   \\ \\   \\|                   ");
        Console.WriteLine("           \\  \\_______ \\  \\_______ \\____ \\_ \\   \\  \\_______ \\  \\__ \\  \\__ \\____ \\_ \\   \\         \\  \\__/ /      \\  \\_______ \\  \\_______ \\  \\__/ /      \\  \\_______ \\  \\__ \\ \\ _ \\                   ");
        Console.WriteLine("            \\|_______| \\|_______| \\_________ \\|_______| \\|__| \\|__| \\_________ \\         \\|__|/        \\|_______| \\|_______| \\|__|/        \\|_______| \\|__| \\|__|                  ");
        Console.WriteLine("                               \\|_________|                   \\|_________|                                                                                            ");
        Console.WriteLine("                                                                                                                                                                    ");
        Console.WriteLine("                                                                                                                                                                    ");
        Console.WriteLine("                     ________             ___  ___  ___  ________  ________  ________  ________           ________  ___          ___ ________   ________            ");
        Console.WriteLine("                    | \\   __   \\           | \\   \\| \\   \\| \\   \\| \\   ____ \\| \\   __   \\| \\   __   \\| \\_____   \\         | \\   ____ \\| \\   \\        /  /| \\   ___   \\| \\   __   \\           ");
        Console.WriteLine("                     \\  \\   \\| \\   \\           \\  \\   \\  \\   \\ \\ \\   \\  \\   \\___| \\  \\   \\| \\   \\  \\   \\| \\   \\|____| \\   \\         \\  \\   \\___| \\  \\   \\      /  // \\  \\   \\ \\  \\   \\  \\   \\| \\   \\          ");
        Console.WriteLine("                      \\  \\   __   \\       __  \\  \\   \\  \\   \\ \\ \\   \\  \\   \\  __ \\  \\   __   \\  \\   _  _ \\     \\  \\__ \\         \\  \\_____   \\  \\   \\    /  //   \\  \\   \\ \\  \\   \\  \\   \\ \\ \\   \\         ");
        Console.WriteLine("                       \\  \\   \\  \\   \\     | \\   \\ \\_ \\   \\  \\   \\ \\ \\   \\  \\   \\| \\   \\  \\   \\  \\   \\  \\   \\ \\   \\|     \\|__|          \\|____| \\   \\  \\   \\  /  //     \\  \\   \\ \\  \\   \\  \\   \\ \\ \\   \\        ");
        Console.WriteLine("                        \\  \\__ \\  \\__ \\     \\  \\________ \\  \\_______ \\  \\_______ \\  \\__ \\  \\__ \\  \\__ \\ \\ _ \\        ___         ____ \\_ \\   \\  \\__ \\/_ //       \\  \\__ \\ \\  \\__ \\  \\_______ \\       ");
        Console.WriteLine("                         \\|__| \\|__|      \\|________| \\|_______| \\|_______| \\|__| \\|__| \\|__| \\|__|      | \\__ \\       | \\_________ \\|__|__|/         \\|__|  \\|__| \\|_______|       ");
        Console.WriteLine("                                                                                                 \\|__|        \\|_________|                                            ");
        Console.WriteLine("                                                                                                                                                                    ");
        Console.WriteLine("                                                                                                                                                                    ");
        Console.BackgroundColor=ConsoleColor.Black;
        Console.ForegroundColor=ConsoleColor.White;
        Thread.Sleep(5000);
        salida =Console.ReadLine();
        if ( salida.ToLower() =="si")
        {
          c=1;
          for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
              matrix[i, j] = 0;
            }
          game=1;
          mostrar_aleatorios=0;
        }
        for (int j = 0; j < (n*m); j++) {
              matrix2[j] = 0;
            }
          Console.Clear();
          Console.BackgroundColor=ConsoleColor.Black;
          Console.ForegroundColor=ConsoleColor.White;
          Console.WriteLine("                                                                                                                    ");
          Console.WriteLine("                                                                                                                    ");
          Console.ForegroundColor=ConsoleColor.Black;
          Console.BackgroundColor=ConsoleColor.Magenta;
          Console.WriteLine("                                                                                                                    ");
            Console.WriteLine("                                                                                                                    ");
            Console.WriteLine("                _                        _      _                  _              _                   _             ");
            Console.WriteLine("               / / \\                     / \\  \\   / \\_ \\               / \\  \\           / / \\                / \\  \\           ");
            Console.WriteLine("              / /   \\                     \\  \\  \\ / / /         _    /   \\  \\         / /   \\              /   \\  \\          ");
            Console.WriteLine("             / / / \\  \\                   / \\  \\_ \\ \\  \\  \\__      / \\_ \\ / / \\  \\_ \\       / / / \\  \\            / / \\  \\  \\         ");
            Console.WriteLine("            / / / \\  \\  \\                 / / \\/_/  \\  \\___ \\    / / // / / \\/_/      / / / \\  \\  \\          / / / \\  \\_ \\        ");
            Console.WriteLine("           / / /   \\  \\  \\       _       / / /      \\__  /   / / // / / ______   / / /   \\  \\  \\        / / /_/ / /        ");
            Console.WriteLine("          / / /___/ / \\  \\     / \\  \\    / / /      / / /   / / // / / / \\_____ \\ / / /___/ / \\  \\      / / /__ \\/ /         ");
            Console.WriteLine("         / / /_____/ / \\  \\     \\  \\_ \\  / / /      / / /   / / // / /   \\/____ // / /_____/ / \\  \\    / / /_____/          ");
            Console.WriteLine("        / /_________/ \\  \\  \\   / / /_/ / /      / / /___/ / // / /_____/ / // /_________/ \\  \\  \\  / / / \\  \\  \\            ");
            Console.WriteLine("       / / /_       __ \\  \\_ \\ / / /__ \\/ /      / / /____ \\/ // / /______ \\/ // / /_       __ \\  \\_ \\/ / /   \\  \\  \\           ");
            Console.WriteLine("        \\_ \\___ \\     /____/_/  \\/_______/        \\/_________/  \\/___________/  \\_ \\___ \\     /____/_/ \\/_/     \\_ \\/           ");
            Console.WriteLine("                                                                                                                    ");
            Console.WriteLine("                                                                                                                    ");
            Console.BackgroundColor=ConsoleColor.Black;
          Console.ForegroundColor=ConsoleColor.White;
        }else if ( salida.ToLower() =="no")
        {
          c=0;
          Console.Clear();
          Console.BackgroundColor=ConsoleColor.Black;
          Console.ForegroundColor=ConsoleColor.White;
          Console.WriteLine("                                                                                                                  ");
          Console.WriteLine("                                                                                                                  ");
          Console.BackgroundColor=ConsoleColor.Cyan;
          Console.ForegroundColor=ConsoleColor.Black;
          Console.WriteLine("                                                                                                                  ");
          Console.WriteLine("                                                                                                                  ");
          Console.WriteLine("        .----------------.  .----------------.  .----------------.  .----------------.  .----------------.        ");
          Console.WriteLine("       | .--------------. || .--------------. || .--------------. || .--------------. || .--------------. |       ");
          Console.WriteLine("       | |      __      | || |  ________    | || |     _____    | || |     ____     | || |    _______   | |       ");
          Console.WriteLine("       | |     /   \\     | || | |_   ___ `.  | || |    |_   _|   | || |   .'    `.   | || |   /  ___  |  | |       ");
          Console.WriteLine("       | |    / / \\  \\    | || |   | |   `.  \\ | || |      | |     | || |  /  .--.   \\  | || |  |  (__  \\_|  | |       ");
          Console.WriteLine("       | |   / ____  \\   | || |   | |    | | | || |      | |     | || |  | |    | |  | || |   '.___`-.   | |       ");
          Console.WriteLine("       | | _/ /     \\  \\_ | || |  _| |___.' / | || |     _| |_    | || |   \\  `--'  /  | || |  |` \\____) |  | |       ");
          Console.WriteLine("       | ||____|  |____|| || | |________.'  | || |    |_____|   | || |   `.____.'   | || |  |_______.'  | |       ");
          Console.WriteLine("       | |              | || |              | || |              | || |              | || |              | |       ");
          Console.WriteLine("       | '--------------' || '--------------' || '--------------' || '--------------' || '--------------' |       ");
          Console.WriteLine("        '----------------'  '----------------'  '----------------'  '----------------'  '----------------'        ");
          Console.WriteLine("                                                                                                                  ");
          Console.WriteLine("                                                                                                                  ");
          Console.BackgroundColor=ConsoleColor.Black;
          Console.ForegroundColor=ConsoleColor.White;
          Thread.Sleep(10000);
          Console.Clear();
        }
      }
      Console.Read();
    }
    static bool isDuplicate(int[,] matrix, int num)
    {
      for (int i = 0; i < matrix.GetLength(0); i++)
      {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
          if (matrix[i, j] == num)
          {
            return true;
          }
        }
      }
      return false;
    }
    static void printmatrix(int[,] matrix,int n, int m){
      Console.WriteLine("                                                                              ");
      Console.WriteLine(" ███▄ ▄███▓▓█████  ███▄ ▄███▓ ▒█████   ██▀███   ▄▄▄       ███▄ ▄███▓ ▄▄▄      ");
      Console.WriteLine("▓██▒▀█▀ ██▒▓█   ▀ ▓██▒▀█▀ ██▒▒██▒  ██▒▓██ ▒ ██▒▒████▄    ▓██▒▀█▀ ██▒▒████▄    ");
      Console.WriteLine("▓██    ▓██░▒███   ▓██    ▓██░▒██░  ██▒▓██ ░▄█ ▒▒██  ▀█▄  ▓██    ▓██░▒██  ▀█▄  ");
      Console.WriteLine("▒██    ▒██ ▒▓█  ▄ ▒██    ▒██ ▒██   ██░▒██▀▀█▄  ░██▄▄▄▄██ ▒██    ▒██ ░██▄▄▄▄██ ");
      Console.WriteLine("▒██▒   ░██▒░▒████▒▒██▒   ░██▒░ ████▓▒░░██▓ ▒██▒ ▓█   ▓██▒▒██▒   ░██▒ ▓█   ▓██▒");
      Console.WriteLine("░ ▒░   ░  ░░░ ▒░ ░░ ▒░   ░  ░░ ▒░▒░▒░ ░ ▒▓ ░▒▓░ ▒▒   ▓▒█░░ ▒░   ░  ░ ▒▒   ▓▒█░");
      Console.WriteLine("░  ░      ░ ░ ░  ░░  ░      ░  ░ ▒ ▒░   ░▒ ░ ▒░  ▒   ▒▒ ░░  ░      ░  ▒   ▒▒ ░");
      Console.WriteLine("░      ░      ░   ░      ░   ░ ░ ░ ▒    ░░   ░   ░   ▒   ░      ░     ░   ▒   ");
      Console.WriteLine("       ░      ░  ░       ░       ░ ░     ░           ░  ░       ░         ░  ░");
      Console.WriteLine("                                                                              ");
      for (int i = 0; i < n; i++)
      {
        for (int j = 0; j < m; j++)
        {
          Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
      }
    }
    static void printmatrix(string[,] matrix,int n, int m){
      Console.Clear();
      Console.BackgroundColor=ConsoleColor.Black;
      Console.ForegroundColor=ConsoleColor.White;
      Console.WriteLine("ENCUENTRA LA PAREJA DE NUMEROS QUE SUMADOS DEN COMO RESULTADO\"29\"");
      Console.ForegroundColor=ConsoleColor.Black;
      Console.BackgroundColor=ConsoleColor.Yellow;
      Console.WriteLine("                                                                                            ");
      Console.WriteLine("                                                                                            ");
      Console.WriteLine("        ███▄ ▄███▓▓█████  ███▄ ▄███▓ ▒█████   ██▀███   ▄▄▄       ███▄ ▄███▓ ▄▄▄             ");
      Console.WriteLine("       ▓██▒▀█▀ ██▒▓█   ▀ ▓██▒▀█▀ ██▒▒██▒  ██▒▓██ ▒ ██▒▒████▄    ▓██▒▀█▀ ██▒▒████▄           ");
      Console.WriteLine("       ▓██    ▓██░▒███   ▓██    ▓██░▒██░  ██▒▓██ ░▄█ ▒▒██  ▀█▄  ▓██    ▓██░▒██  ▀█▄         ");
      Console.WriteLine("       ▒██    ▒██ ▒▓█  ▄ ▒██    ▒██ ▒██   ██░▒██▀▀█▄  ░██▄▄▄▄██ ▒██    ▒██ ░██▄▄▄▄██        ");
      Console.WriteLine("       ▒██▒   ░██▒░▒████▒▒██▒   ░██▒░ ████▓▒░░██▓ ▒██▒ ▓█   ▓██▒▒██▒   ░██▒ ▓█   ▓██▒       ");
      Console.WriteLine("       ░ ▒░   ░  ░░░ ▒░ ░░ ▒░   ░  ░░ ▒░▒░▒░ ░ ▒▓ ░▒▓░ ▒▒   ▓▒█░░ ▒░   ░  ░ ▒▒   ▓▒█░       ");
      Console.WriteLine("       ░  ░      ░ ░ ░  ░░  ░      ░  ░ ▒ ▒░   ░▒ ░ ▒░  ▒   ▒▒ ░░  ░      ░  ▒   ▒▒ ░       ");
      Console.WriteLine("       ░      ░      ░   ░      ░   ░ ░ ░ ▒    ░░   ░   ░   ▒   ░      ░     ░   ▒          ");
      Console.WriteLine("              ░      ░  ░       ░       ░ ░     ░           ░  ░       ░         ░  ░       ");
      Console.WriteLine("                                                                                            ");
      Console.WriteLine("                                                                                            ");
      Console.BackgroundColor=ConsoleColor.Black;
      for (int i = 0; i < n; i++)
      {
        Console.BackgroundColor=ConsoleColor.Black;
        Console.Write("       ");
        for (int j = 0; j < m; j++)
        {
          if (i==0)
          {
            Console.BackgroundColor=ConsoleColor.Green;
            Console.Write("|"+matrix[i, j] + "|");
          }else if (j==0 && i>0)
          {
            Console.BackgroundColor=ConsoleColor.Green;
            Console.Write("|"+matrix[i, j] + "|");
          }else if(j!=0 && i>0 && matrix[i, j]!="       ")
          {
            Console.BackgroundColor=ConsoleColor.Blue;
            Console.Write("|"+matrix[i, j] + "|");
          }else if(j!=0 && i>0 && matrix[i, j]=="       ")
          {
            Console.BackgroundColor=ConsoleColor.White;
            Console.Write("|"+matrix[i, j] + "|");
          }
        }
        Console.WriteLine();
      }
      Console.BackgroundColor=ConsoleColor.Black;
      Console.ForegroundColor=ConsoleColor.White;
    }
    static bool verificar (int[,] matrix,string coordinates1,string coordinates2){
      int coodenada1 = (int)char.GetNumericValue(coordinates1[coordinates1.IndexOf(",")-1])-1;
      int coodenada2 = (int)char.GetNumericValue(coordinates1[coordinates1.IndexOf(",")+1])-1;
      int coodenada3 = (int)char.GetNumericValue(coordinates2[coordinates2.IndexOf(",")-1])-1;
      int coodenada4 = (int)char.GetNumericValue(coordinates2[coordinates2.IndexOf(",")+1])-1;
      if ((matrix[coodenada1,coodenada2] + matrix[coodenada3,coodenada4])==29)
      {
        return true;
      }else{
        return false;
      }
    }
    static bool finish(int pairs){
      if (pairs==28)
      {
        return true;
      }else
      {
        return false;
      }
    }
    static bool verificar_coordenadas(string coordinates1){
      if (coordinates1.Length<5||coordinates1.Length>5||string.IsNullOrEmpty(coordinates1)==true)
      {
        return false;
      }else
      {
        if (coordenadas_recorrer(coordinates1)==true)
        {
          if (verificador_repeticiones(coordinates1)==true)
          {
            if (verificar_formato(coordinates1) == false)
            {
              return false;
            } else
            {
              return true;
            } 
          }else
          {
            return false;
          }
        }else
        {
          return false;
        }
      }
    }
    static bool coordenadas_recorrer(string coordinates1){
      string input = "123,456(789)";
      bool valid = true;
      for (int i = 0; i < coordinates1.Length; i++)
      {
        char c = coordinates1[i];
        if (!(char.IsDigit(c) || c == ',' || c == '(' || c == ')'))
        {
          valid = false;
          break;
        }
      }
      if (valid)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    static bool verificar_formato(string coordenadas){
      char a= coordenadas[coordenadas.IndexOf(",")-1];
      char b= coordenadas[coordenadas.IndexOf(",")+1];
      char c= coordenadas[0];
      char d= coordenadas[4];
      if (char.IsDigit(a)&&char.IsDigit(b)&&c=='('&&d==')')
      {
        return true;
      }else
      {
        return false;
      }
    }
    static bool verificador_repeticiones(string coordenadas){
      int parentecis=0;
      int comas=0;
      int parentesis2=0;
      for (int i = 0; i < coordenadas.Length; i++)
      {
        if (coordenadas[i]=='(')
        {
          parentecis++;
        } else if(coordenadas[i]==')')
        {
          parentesis2++;
        }else if (coordenadas[i]==',')
        {
          comas++;
        }
      }
      if (parentecis==1&&parentesis2==1&&comas==1)
      {
        return true;
      }else
      {
        return false;
      }
    }
    static bool verificar_limites(string coordenadas, int limite, int limite2){
      int coodenada1 = (int)char.GetNumericValue(coordenadas[coordenadas.IndexOf(",")-1]);
      int coodenada2 = (int)char.GetNumericValue(coordenadas[coordenadas.IndexOf(",")+1]);
      if ((coodenada1<=limite)&&(coodenada1>0)&&(coodenada2>0)&&(coodenada2<=limite2))
      {
        return  true;
      }else
      {
        return false;
      }
    }
    static int numerico(int[,] matrix,string coordinates1){
      int coodenada1 = (int)char.GetNumericValue(coordinates1[coordinates1.IndexOf(",")-1])-1;
      int coodenada2 = (int)char.GetNumericValue(coordinates1[coordinates1.IndexOf(",")+1])-1;
      return matrix[coodenada1,coodenada2];
    }
    static int coordenadax(string coordenadas){
      int coodenada1 = (int)char.GetNumericValue(coordenadas[coordenadas.IndexOf(",")-1])-1;
      return coodenada1;
    }
    static int coordenaday(string coordenadas){
      int coodenada1 = (int)char.GetNumericValue(coordenadas[coordenadas.IndexOf(",")+1])-1;
      return coodenada1;
    }
    static bool verificar_encontrados(int[] encontrados,int pairs,int numero)
    {
      for (int i = 0; i < pairs; i++)
      {
        if (numero==encontrados[i])
        {
          return true;
        }
      }
      return false;
    }
  }
}