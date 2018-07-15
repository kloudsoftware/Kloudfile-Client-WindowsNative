using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kloudfile_Client
{
    public partial class ScreenShotForm : Form
    {
        private Point MouseDownLocation;

        public ScreenShotForm()
        {
            this.DoubleBuffered = true;
        }

        Rectangle rec = new Rectangle(0, 0, 0, 0);

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Black, rec);
        }

        Tuple<int, int> _startPos = null;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _startPos = new Tuple<int, int>(e.X, e.X);
            rec = new Rectangle(e.X, e.Y, 0, 0);
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            rec.Width = e.X - rec.X;
            rec.Height = e.Y - rec.Y;
            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                this.Close();
            }

            MainWindow.setBounds(rec);

            this.Close();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            this.Close();
        }
    }
}