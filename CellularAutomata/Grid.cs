using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomata
{
    class Grid
    {
        private Cell[,] cells;
        private int width = 12;
        private int height = 12;
        private int[,] cellsValues = new int[,] {
            {1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        };

        public Grid ()
        {
            cells = new Cell[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    cells[x, y] = new Cell(cellsValues[x, y]);
                }
            }
            Console.WriteLine("Grid Constructor");
        }

        public void Randomise (out Cell[,] cells)
        {
            cells = new Cell[0,0];
        }

        public void Tick ()
        {
            Cell[,] newCells = new Cell[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    newCells[x, y] = new Cell();
                }
            }
                    int neighbourCount;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    neighbourCount = 0;
                    for (int i = -1; i < 3; i++)
                    {
                        for (int j = -1; j < 3; j++)
                        {
                            try
                            {
                                if (cells[x + i, y + j].State == 1 && (i + j) == 0)
                                    neighbourCount++;
                            }
                            catch
                            {

                            }
                        }
                    }
                    if (cells[x, y].State == 1)
                    {
                        if (neighbourCount < 2)// die
                            newCells[x, y].State = 0;
                        else if (neighbourCount > 3)// die
                            newCells[x, y].State = 0;
                        else if (neighbourCount == 2 || neighbourCount == 3)// live
                            newCells[x, y].State = 1;
                    } else
                    {
                    if (neighbourCount == 3)// live
                        newCells[x, y].State = 1;
                    }

                }
            }
            cells = (Cell[,])newCells.Clone();
        }

        public void Write()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (cells[x, y].State == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(".");
                    }
                    else if (cells[x, y].State == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("#");
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
