using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalsSystem.WindowsForm
{
    public class Vehicle :IModule
    {
        public void module(frmMainDashboard frmMainDashboard)
        {

            frmMainDashboard.label1.Text = "Vehicle";
            

        }
        private Panel panel;

        public Vehicle(Panel panel)
        {
            this.panel = panel;
            // Initialize the Vehicle module controls
        }

        public void Initialize()
        {
            // Initialize the Vehicle module controls
            // ...
        }

        public void Show()
        {
            // Show the Vehicle module controls
            panel.Show();
        }

        public void Hide()
        {
            // Hide the Vehicle module controls
            panel.Hide();
        }
    }
}
