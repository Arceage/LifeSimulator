using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeSimulator;
using System.Windows.Forms;
using LifeSimulator.All_Data;
using System.Drawing;


namespace LifeSimulator.All_Data
{
   static public class Gen 
    {
        
       static public int GenCunter { get; set; }



        /// <summary>
        /// this method will generate the next tingling sensation, by checking free and occupied cells
        /// </summary>
       static public void NextGen(Graphics graphics, PictureBox pictureBox1, int Allsize)
        {
            graphics.Clear(Color.Black);

            bool[,] NewCells = new bool[CellsMapAction.ColFields, CellsMapAction.RowsFields];

            for (int x = 0; x < CellsMapAction.ColFields; x++)
            {
                for (int y = 0; y < CellsMapAction.RowsFields; y++)
                {
                    int Neighbor = CellsMapAction.CheckNeighbor(x, y);
                    bool life = CellsMapAction.CellsArray[x, y];
                    if (!life && Neighbor == 3)
                    {
                        NewCells[x, y] = true;
                    }
                    else if (life && Neighbor < 2 || Neighbor > 3)
                    {
                        NewCells[x, y] = false;
                    }
                    else
                    {
                        NewCells[x, y] = CellsMapAction.CellsArray[x, y];
                    }

                    if (life)
                    {
                        graphics.FillRectangle(Brushes.Red, x * Allsize, y * Allsize, Allsize - 1, Allsize - 1);
                    }
                }
            }
            CellsMapAction.CellsArray = NewCells;
            pictureBox1.Refresh();
        }

    }
}
