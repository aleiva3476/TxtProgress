using Alp3476;
using System;
using System.Diagnostics;

namespace DemoProgressBar
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();

            Console.WindowWidth = 100;

            Stopwatch sw = new Stopwatch();

            sw.Start();
            for (int i = 1; i <= 5; i++)
            {
                int numPasos = r.Next(20, 50);
                string titulo = $"Proceso nº {i}";

                TxtProgress.Start(titulo, numPasos);
                for (int j = 0; j < numPasos; j++)
                {
                    TxtProgress.Step();
                    System.Threading.Thread.Sleep(50);
                }
                TxtProgress.End();
            }

            sw.Stop();

            Console.WriteLine($"\r\nTiempo total: {sw.Elapsed}");

            Console.ReadKey();
        }
    }
}
