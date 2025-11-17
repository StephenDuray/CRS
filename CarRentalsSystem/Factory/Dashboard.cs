using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalsSystem.WindowsForm
{
    public class Dashboard : IModule
    {
        public void module(frmMainDashboard frmMainDashboard)
        {
            frmMainDashboard.label1.Text = "Car Rental Dashboard";
            
        }
        public void Initialize()
        {
            // Initialize the Dashboard module controls
            // ...
        }

        public void Show()
        {
            // Show the Dashboard module controls
            // ...
            
        }

        public void Hide()
        {
            // Hide the Dashboard module controls
            // ...
        }
    }
}
