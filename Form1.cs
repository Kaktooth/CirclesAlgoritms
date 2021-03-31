using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsGraphics2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            using (var g = Graphics.FromImage(pictureBox1.Image))
            {
                Brush b = Brushes.Black;
                float R = (float)Convert.ToDouble(textBox1.Text);
                float x = 0;
                float y = R;
                int X = Convert.ToInt32(textBox2.Text);
                int Y = Convert.ToInt32(textBox3.Text);
                float i = 2 * (1 - R);
                float limit = 0;

              
                float d = 0;
                float d2 = 0;
                while (y >= limit)
                {
                   
                    g.FillRectangle(b, (X + x), (Y + y), 1, 1);
                    g.FillRectangle(b, (X + x), (Y - y), 1, 1);
                    g.FillRectangle(b, (X - x), (Y + y), 1, 1);
                    g.FillRectangle(b, (X - x), (Y - y), 1, 1);

                    if (i < 0) {
                        d = (2 * i) + (2 * y) - 1;
                        if (d <= 0)
                        {
                            x = x + 1;
                            i = i + 2 * x + 1;
                            continue;
                        }
                        if (d > 0)
                        {
                            x = x + 1;
                            y = y - 1;
                            i = i + 2 * x - 2 * y + 2;
                            continue;
                        }
                    }
                    if (i > 0)
                    {
                        d2 = (2 * i) + (2 * x) - 1;
                        if (d2 <= 0)
                        {
                            x = x + 1;
                            y = y - 1;
                            i = i + (2 * x) - (2 * y) + 2;
                            continue;
                        }
                        if (d2 > 0)
                        {
                            y = y - 1;
                            i = i - (2 * y) - 1;
                            continue;
                        }
                    }
                    if (i == 0)
                    {
                        x = x + 1;
                        y = y - 1;
                        i = i + (2 * x) - (2 * y) + 2;
                        continue;
                    }
                }
               
                pictureBox1.Refresh();
            }
           

            stopwatch.Stop();
            label4.Text = stopwatch.Elapsed.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            using (var g = Graphics.FromImage(pictureBox2.Image))
            {
                Brush b = Brushes.Black;
                float R = (float)Convert.ToDouble(textBox1.Text);
                float x = 0;
                float y = R;
                int X = Convert.ToInt32(textBox2.Text);
                int Y = Convert.ToInt32(textBox3.Text);
                float d = 2 * (1 - R);

                double E = 0;

                while (y >= 0)
                {
                    g.FillRectangle(b, (X + x), (Y + y), 1, 1);
                    g.FillRectangle(b, (X + x), (Y - y), 1, 1);
                    g.FillRectangle(b, (X - x), (Y + y), 1, 1);
                    g.FillRectangle(b, (X - x), (Y - y), 1, 1);
                    E = 2 * (d + y) - 1;
                    
                    if (d < 0 && (int)E <= 0)
                    {

                        d += 2 * ++x + 1;
                        continue;
                    }
                    if (d > 0 && (int)E > 0)
                    {

                        d -= 2 * --y + 1;
                        continue;
                    }
                    d += 2 * (++x - --y);

                }
                pictureBox2.Refresh();
            }

            stopwatch.Stop();
            label5.Text = stopwatch.Elapsed.ToString();
        }
    }
}
