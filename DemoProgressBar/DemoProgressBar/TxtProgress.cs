using System;
using System.Diagnostics;

namespace Alp3476
{
    class TxtProgress
    {
        const int LEN_TITLE = 20;
        const int TOTAL_BLOCKS = 30;

        private static string title;
        private static int numSteps = 0;
        private static int current = 0;
        private static Stopwatch sw = new Stopwatch();

        public static void Start(string title, int numSteps)
        {
            TxtProgress.title = title;
            TxtProgress.numSteps = numSteps;
            if (TxtProgress.title.Length > LEN_TITLE)
            {
                TxtProgress.title = TxtProgress.title.Substring(0, LEN_TITLE);
            }
            current = 0;

            sw.Reset();
            sw.Start();

            Console.CursorVisible = false;
        }

        public static void Step()
        {
            ++current;
            decimal percent = Math.Ceiling(numSteps == 0 ? 100 : current * 100M / (decimal)numSteps);
            int numBlocks = (int)(TOTAL_BLOCKS * percent / 100M);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\r{title,-LEN_TITLE} ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"{percent,6:N0}%  ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(new string('\x2588', numBlocks));
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(new string('\x2591', TOTAL_BLOCKS - numBlocks));
        }

        public static void End()
        {
            sw.Stop();

            /* Force repainting with 100 % */
            current = numSteps - 1;
            Step();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" OK ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("(");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(sw.Elapsed);

            Console.ResetColor();
            Console.WriteLine($") {numSteps,6:N0} reg.");

            Console.CursorVisible = true;
        }
    }
}
