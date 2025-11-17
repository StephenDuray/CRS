// Factory.cs  (namespace CarRentalsSystem.WindowsForm)
using CarRentalsSystem.Control;
using CarRentalsSystem.Database;
using CarRentalsSystem.Factory;
using System;
using System.Windows.Forms;

namespace CarRentalsSystem.WindowsForm
{
    public class Factory
    {
        public static IModule CreateView(string moduleType, Panel panel)
        {
            if (moduleType == null) throw new ArgumentNullException(nameof(moduleType));
            var key = moduleType.Trim();  // tolerate "Customer " etc.

            if (string.Equals(key, "Panel", StringComparison.OrdinalIgnoreCase))
            {
                return new PanelModule(panel);
            }
            else if (string.Equals(key, "Car Rental Dashboard", StringComparison.OrdinalIgnoreCase))
            {
                panel.Controls.Clear();
                var uc = new DashboardControl();      // ✅ UserControl, not Dashboard
                uc.Dock = DockStyle.Fill;
                panel.Controls.Add(uc);
                
                
                return new PanelModule(panel);        // whatever IModule you use for headers
            }
            else if (string.Equals(key, "Customer", StringComparison.OrdinalIgnoreCase))
            {
                panel.Controls.Clear();
                var uc = new CustomerControl();       // ✅ a UserControl
                uc.Dock = DockStyle.Fill;
                panel.Controls.Add(uc);

                return new Customer(panel);


            }
            else if (string.Equals(key, "Vehicle", StringComparison.OrdinalIgnoreCase))
            {
                panel.Controls.Clear();
                var uc = new VehicleControl();
                uc.Dock = DockStyle.Fill;
                panel.Controls.Add(uc);


                return new Vehicle(panel);
            }
            else if (string.Equals(key, "Contracts", StringComparison.OrdinalIgnoreCase))
            {
                return new Contracts(panel);
            }

            throw new ArgumentException($"Unknown moduleType: '{moduleType}'", nameof(moduleType));
        }
    }
}
