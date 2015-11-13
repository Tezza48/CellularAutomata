using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomata
{
    class Cell
    {
        private int state;

        public Cell()
        {
        }
        public Cell(int state)
        {
            State = state;
        }

        public int State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }
    }
}
