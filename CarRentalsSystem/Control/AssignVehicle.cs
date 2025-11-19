using CarRentalsSystem.WindowsForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalsSystem.Control
{
    public partial class AssignVehicle : UserControl
    {
        public AssignVehicle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAssignVehicleAdd frmAssignVehicleAdd = new frmAssignVehicleAdd();
            frmAssignVehicleAdd.ShowDialog();
        }

        private void AssignVehicle_Load(object sender, EventArgs e)
        {

        }
    }
}
