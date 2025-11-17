using CarRentalsSystem.WindowsForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalsSystem.Factory
{
    public  class PanelModule : IModule
    {
        private Panel _panel;

        public PanelModule(Panel panel)
        {
            _panel = panel;
        }

        public void module(frmMainDashboard frmMainDashboard)
        {
            // Implement the logic for displaying the UI module in the given panel
            // You can add controls, set properties, etc. to the panel here
        }

       
    }
}
