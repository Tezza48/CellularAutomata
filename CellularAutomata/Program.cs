using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomata
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            Grid grid = new Grid();

            Console.BackgroundColor = ConsoleColor.DarkCyan;

            while (isRunning)
            {
                Console.Clear();
                grid.Write();
                grid.Tick();
                Console.ReadKey();
            }
        }
    }
}
