using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace generatePaint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            
            InitializeComponent();
            
        }
        Pen[] colors = new Pen[] { Pens.Red,Pens.DarkBlue,Pens.Violet,Pens.Purple,Pens.MediumPurple};
        private void Draw(object sender, PaintEventArgs e)
        {
            Graphics letsDraw = e.Graphics;
            int randomX, randomY, shift,colorIndex;
            for (int counter = 0; counter<10 ; counter++)
            {
                Realm(out randomX, out randomY, out shift, out colorIndex);
                DrawSircle(letsDraw, colors[colorIndex], randomX, randomY, shift);
            }
        }
        private void DrawSircle(Graphics lines , Pen color , int xFirst , int yFirst , int shift)
        {
            lines.DrawLine(color, xFirst,  yFirst, xFirst+shift, yFirst);
            lines.DrawLine(color, xFirst, yFirst, xFirst, yFirst+shift);
            lines.DrawLine(color, xFirst+shift, yFirst+shift, xFirst+shift, yFirst);
            lines.DrawLine(color, xFirst+shift, yFirst+shift, xFirst, yFirst+shift);
        }
        private void Realm(out int x,out int y,out int shift,out int colorIndex)
        {
            Random random = new Random();
            shift = random.Next(1,canvas.Width);
            while (shift>canvas.Width-1 | shift>canvas.Height-1)
            {
                shift = random.Next(1,canvas.Width);
            }
            x = random.Next(10,canvas.Width-shift);
            y = random.Next(10,canvas.Width-shift);
            colorIndex=random.Next(0,colors.Length);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void canvas_Click(object sender, EventArgs e)
        {

        }
    }
    class GenerateCoordinates
    {
        public int XCoordinate,YCordinate,Shift;
        public GenerateCoordinates(int x , int y,int shift)
        {
            //без this может не работать
            XCoordinate = x;
            YCordinate = y;
            Shift = shift;
        }
    }

}
