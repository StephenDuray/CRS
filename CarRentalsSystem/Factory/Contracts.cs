using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalsSystem.WindowsForm
{
    public class Contracts : IModule
    {
        public void module(frmMainDashboard frmMainDashboard)
        {
            frmMainDashboard.label1.Text = "Contracts";
            
        }
        private Panel panel;

        public Contracts(Panel panel)
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
