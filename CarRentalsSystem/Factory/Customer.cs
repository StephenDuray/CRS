using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalsSystem.WindowsForm
{
    public class Customer : IModule
    {
        private Panel panel;

        public Customer(Panel panel)
        {
            this.panel = panel;
            // Initialize the Customer module
        }
        public void Initialize()
        {
            // Initialize the Customer module controls
            // ...
        }

        public void Show()
        {
            // Show the Customer module controls
            panel.Show();
        }

        public void Hide()
        {
            // Hide the Customer module controls
            panel.Hide();
        }
        public void module(frmMainDashboard frmMainDashboard)
        {
            frmMainDashboard.label1.Text = "Customer Management";
        }
    }
}
