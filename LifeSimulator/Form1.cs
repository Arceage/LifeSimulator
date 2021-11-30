using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LifeSimulator.All_Data;

namespace LifeSimulator
{
   public partial class Form1 : Form
    {
        private Graphics graphics;
        private int ZoomCounter;
        public Form1()
        {
            InitializeComponent();
        }

        private void StartGame()
        {
            if (timer1.Enabled)
            {
                return;
            }
            Gen.GenCunter = 0;
            Text = $"Generation {Gen.GenCunter}" ;

            numResolution.Enabled = false;

            numDensity.Enabled = false;

            ZoomCounter = (int)numResolution.Value;

            CellsMapAction.ColFields = pictureBox1.Width / ZoomCounter;

            CellsMapAction.RowsFields = pictureBox1.Height / ZoomCounter;

            CellsMapAction.CellsArray = new bool[CellsMapAction.ColFields, CellsMapAction.RowsFields];

            Random random = new Random();

            for (int x = 0; x < CellsMapAction.ColFields; x++)
            {
                for (int y = 0; y < CellsMapAction.RowsFields; y++)
                {
                    CellsMapAction.CellsArray[x, y] = random.Next((int)numDensity.Value) == 0;
                }
            }

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            timer1.Start();
            
        }

        private void StopGame()
        {
            if (!timer1.Enabled)
            {
                return;
            }
            numResolution.Enabled = true;

            numDensity.Enabled = true;
            timer1.Stop();
            pictureBox1.Refresh();
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Gen.NextGen(graphics,pictureBox1,ZoomCounter);
            Text = $"Generation {Gen.GenCunter++}";
        }
        private void Bstart(object sender, EventArgs e)
        {
            StartGame();
           
        }
        private void Bstop(object sender, EventArgs e)
        {
            StopGame();
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!timer1.Enabled)
            {
                return;
            }
            if (e.Button == MouseButtons.Left)
            {
                int xcord = e.Location.X / ZoomCounter;
                int ycord = e.Location.Y / ZoomCounter;

                if (xcord > 0 && ycord > 0 && xcord < CellsMapAction.ColFields && ycord < CellsMapAction.RowsFields)
                    CellsMapAction.CellsArray[xcord, ycord] = true;
                
                
            }

            if (e.Button == MouseButtons.Right)
            {
                int xcord = e.Location.X / ZoomCounter;
                int ycord = e.Location.Y / ZoomCounter;

                if (xcord > 0 && ycord > 0 && xcord < CellsMapAction.ColFields && ycord < CellsMapAction.RowsFields)
                    CellsMapAction.CellsArray[xcord, ycord] = false;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Text = $"Generation {Gen.GenCunter}" ;
        }
    }
}
