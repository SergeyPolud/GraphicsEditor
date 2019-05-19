using System;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Point lastcoords = Point.Empty;
        bool isPressed;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            pBox.Paint += new PaintEventHandler(pbCanvas_Paint);
            pBox.MouseDown += new MouseEventHandler(pbCanvas_MouseDown);
            pBox.MouseMove += new MouseEventHandler(pbCanvas_MouseMove);
            pBox.MouseUp += new MouseEventHandler(pbCanvas_MouseUp);
        }
        bool allowedToPaint = new bool();
        
        private void button1_Click(object sender, EventArgs e)
        {
            allowedToPaint = false;
            pBox.Image = null;
            pBox.Invalidate();
        }


        private void pbCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            lastcoords = e.Location;
            isPressed = true;
           
        }
        
        private void pbCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if(isPressed)
            {
                if (lastcoords != null)
                {
                    if (pBox.Image == null)
                    {
                        Bitmap bitmap = new Bitmap(pBox.Width, pBox.Height);
                        pBox.Image = bitmap;
                    }
                    Graphics g = Graphics.FromImage(pBox.Image);
                    if (radioButton1.Checked)
                    {
                        data data = new data();
                        string hexBlue = "#FF0000FF";
                        data.penColor = Int32.Parse(hexBlue.Replace("#", ""), System.Globalization.NumberStyles.HexNumber);
                    }
                    Pen pen = new Pen(Color.FromArgb(data.penColor), 2);
                    g.DrawLine(pen, lastcoords, e.Location);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    pen.Dispose();
                    pBox.Invalidate();
                    lastcoords = e.Location;
                } 
            } 
        }

        private void pbCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            lastcoords = Point.Empty;
            isPressed = false;
        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            if(allowedToPaint)
            {
                Bitmap rectmap = new Bitmap(pBox.Width, pBox.Height);
                pBox.Image = rectmap;
                Graphics f = Graphics.FromImage(pBox.Image);
                Pen pen = new Pen(Color.Blue, 2);
                for (int i = 0; i <= pBox.Height; i += 15)
                {
                    f.DrawLine(pen, new Point(0, i), new Point(1000, i));
                }
                for (int i = 0; i <= pBox.Width; i += 15)
                {
                    f.DrawLine(pen, new Point(i, 0), new Point(i, 1000));
                }
                f.Dispose();
                pen.Dispose();
                pBox.Invalidate();
                allowedToPaint = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            allowedToPaint = true;
            pBox.Invalidate();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pBox.Invalidate();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pBox.Invalidate();
        }
    }
}
