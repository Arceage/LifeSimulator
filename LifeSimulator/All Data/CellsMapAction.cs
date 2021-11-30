using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeSimulator;

namespace LifeSimulator.All_Data
{
    static class CellsMapAction
    {
        static public bool[,] CellsArray { get; set; }
        static public int RowsFields { get; set; }
        static public int ColFields { get; set; }

        /// <summary>
        /// this method checks for free and occupied cells
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        static public int CheckNeighbor(int x , int y)
        {
            int count = 0;


            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int col = (x + i + ColFields) % ColFields;
                    int row = (y + j + RowsFields) % RowsFields;

                    bool checkbjij = CellsArray[col, row];
                    bool checkharevan = col == x && row == y;
                    if (checkbjij && !checkharevan)
                    {
                        count++;
                    }
                }
            }

            return count;
        }


    }
}
