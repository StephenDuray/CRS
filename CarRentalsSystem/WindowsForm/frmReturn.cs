using CarRentalsSystem.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalsSystem.WindowsForm
{
    public partial class frmReturn : Form
    {
        private ReturnControl _returnControl;   // your usercontrol instance

        public frmReturn()
        {
            InitializeComponent();
        }

        private void frmReturn_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (_returnControl == null)
            {
                _returnControl = new ReturnControl();
                _returnControl.Dock = DockStyle.Fill;   // make it fill the panel

                panel1.Controls.Clear();               // remove anything already in the panel
                panel1.Controls.Add(_returnControl);   // attach usercontrol to the panel
            }

            _returnControl.BringToFront();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
