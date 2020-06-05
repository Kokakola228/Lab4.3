using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        Point center;//Центр вращения
        RectangleF ellipse = new RectangleF(0, 0, 100, 40);//Эллипс
        RectangleF ellipse2 = new RectangleF(100, 100, 50, 20);
        float radius = 100f;//Радиус вращения

        public Form1()
        {
            InitializeComponent();
            Paint += Form1_Paint;
            center = new Point(ClientRectangle.Width / 2, ClientRectangle.Height / 2);
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Yellow, ellipse);
            e.Graphics.FillEllipse(Brushes.Green, ellipse2);

            e.Graphics.DrawEllipse(Pens.Black, ellipse);
            e.Graphics.DrawEllipse(Pens.Black, ellipse2);

            e.Graphics.DrawLine(Pens.Red, center, new PointF(ellipse.X + ellipse.Width / 2, ellipse.Y + ellipse.Height / 2));
            e.Graphics.DrawLine(Pens.Red, center, new PointF(ellipse2.X + ellipse2.Width / 2, ellipse2.Y + ellipse2.Height / 2));
        }

        float angle;
        
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            ellipse.Location = new PointF(center.X + radius * (float)Math.Cos(angle) - ellipse.Width / 2,
                                                        center.Y + radius * (float)Math.Sin(angle) - ellipse.Height / 2);
            ellipse2.Location = new PointF(center.X - radius * (float)Math.Cos(angle) - ellipse2.Width / 2 ,
                                                        center.Y - radius * (float)Math.Sin(angle) - ellipse2.Height / 2);
            Refresh();
            angle += (float)(Math.PI / 10f);
        }
    }


}
