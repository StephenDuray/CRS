using CarRentalsSystem.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalsSystem.WindowsForm
{
    public partial class frmReturn : Form
    {
        private ReturnControl _returnControl;   

        public frmReturn()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;
        }


        int borderRadius = 25;
        int borderSize = 2;
        Color borderColor = Color.FromArgb(0, 45, 139);

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(borderColor, borderSize))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                int d = borderRadius * 2;

                path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                path.CloseFigure();

                this.Region = new Region(path);
                pen.Alignment = PenAlignment.Inset;
                e.Graphics.DrawPath(pen, path);
            }
        }

        private void frmReturn_Load(object sender, EventArgs e)
        {
            int radius = 40;

            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            this.Region = new Region(path);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (_returnControl == null)
            {
                _returnControl = new ReturnControl();
                _returnControl.Dock = DockStyle.Fill;   
                panel1.Controls.Clear();              
                panel1.Controls.Add(_returnControl);  
            }

            _returnControl.BringToFront();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
