using System;
using System.Drawing;
using System.Windows.Forms;

namespace MPSPER
{
    public partial class Form2 : Form
    {
        private Bitmap drawingBitmap;
        private Graphics drawingGraphics;
        private bool isDrawing = false;
        private Point lastPoint;
        private Color currentColor;
        private int penSize;

        public Form2(Color initialColor, int initialPenSize)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            this.BackColor = Color.White;
            this.TransparencyKey = Color.White;
            this.Cursor = Cursors.Cross;

            currentColor = initialColor;
            penSize = initialPenSize;

            drawingBitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            drawingGraphics = Graphics.FromImage(drawingBitmap);
            drawingGraphics.Clear(Color.Transparent);

            this.Paint += Form2_Paint;
            this.MouseDown += Form2_MouseDown;
            this.MouseMove += Form2_MouseMove;
            this.MouseUp += Form2_MouseUp;
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(drawingBitmap, Point.Empty);
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            lastPoint = e.Location;
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                using (var pen = new Pen(currentColor, penSize))
                {
                    drawingGraphics.DrawLine(pen, lastPoint, e.Location);
                }
                lastPoint = e.Location;
                this.Invalidate();
            }
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }

        public void Clear()
        {
            drawingGraphics.Clear(Color.Transparent);
            this.Invalidate();
        }

        public void UpdateColor(Color newColor)
        {
            currentColor = newColor;
        }

        public void UpdatePenSize(int newSize)
        {
            penSize = newSize;
        }
    }
}
