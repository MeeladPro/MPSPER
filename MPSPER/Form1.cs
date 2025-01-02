using System;
using System.Drawing;
using System.Windows.Forms;

namespace MPSPER
{
    public partial class Form1 : Form
    {
        private Form2 drawingForm;
        private Color currentColor = Color.Black;
        private int penSize = 5;

        public Form1()
        {
            InitializeComponent();
            btnStop.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (drawingForm == null || drawingForm.IsDisposed)
            {
                drawingForm = new Form2(currentColor, penSize);
                drawingForm.Show();
            }
            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (drawingForm != null && !drawingForm.IsDisposed)
            {
                drawingForm.Close();
            }
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            drawingForm?.Clear();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                currentColor = colorDialog.Color;
                btnColor.BackColor = currentColor;
                drawingForm?.UpdateColor(currentColor);
            }
        }

        private void trackBarSize_Scroll(object sender, EventArgs e)
        {
            penSize = trackBarSize.Value;
            drawingForm?.UpdatePenSize(penSize);
        }
    }
}
