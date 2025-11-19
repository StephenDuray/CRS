using CarRentalsSystem.Control;
using CarRentalsSystem.Database;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CarRentalsSystem.WindowsForm
{
    public partial class frmMainDashboard : Form
    {
        private readonly DashboardControl dashboardControl;
        private CustomerControl customerControl;
        private AddVehicleControl addVehicleControl;
        private ContractControl contractsControl;
        private AssignVehicle assignVehicle; // <- your contracts usercontrol

        public frmMainDashboard()
        {
            InitializeComponent();

            // Gradient background for panel1
            panel1.Paint += panel1_Paint;

            // Hide these by default
            button6.Hide();
            textBox1.Hide();
            label2.Hide();

            // Create dashboard once and reuse it
            dashboardControl = new DashboardControl();
        }

        // === FORM LOAD =======================================================

        private void frmMainDashboard_Load(object sender, EventArgs e)
        {
            // Show dashboard by default
            ShowDashboard();

            // === START CLOCK / DATE TIMER ===
            // timer1 is assumed to be added via Designer
            timer1.Interval = 1000; // 1 second
            timer1.Start();
        }

        // === VIEW SWITCH HELPERS ============================================

        private void ShowDashboard()
        {
            panel2.Controls.Clear();

            // Ensure control is not attached elsewhere
            if (dashboardControl.Parent != null)
                dashboardControl.Parent.Controls.Remove(dashboardControl);

            dashboardControl.Dock = DockStyle.Fill;
            panel2.Controls.Add(dashboardControl);

            var view = Factory.CreateView("Car Rental Dashboard", panel2);
            view.module(this);

            label1.Text = "Car Rental Dashboard";
            label4.Text = string.Empty;
        }

        private void ShowCustomers()
        {
            label4.Text = "Manage customers and their rental activity.";

            panel2.Controls.Clear();

            customerControl = new CustomerControl
            {
                Dock = DockStyle.Fill
            };
            panel2.Controls.Add(customerControl);

            var view = Factory.CreateView("Customer", panel2);
            view.module(this);
        }
        public void showAssignVehicle()
        {
            label4.Text = "Manage your rental";

            panel2.Controls.Clear();
            assignVehicle = new AssignVehicle
            {
                Dock = DockStyle.Fill
            };
            panel2.Controls.Add(assignVehicle);
            label1.Text = "Rental";
        }
        private void ShowVehicles()
        {
            label4.Text = "Manage your fleet, monitor availability, and keep track of vehicle performance";

            panel2.Controls.Clear();

            addVehicleControl = new AddVehicleControl
            {
                Dock = DockStyle.Fill
            };
            panel2.Controls.Add(addVehicleControl);

            var view = Factory.CreateView("Vehicle", panel2);
            view.module(this);
        }

        private void ShowContracts()
        {
            label4.Text = "Manage contracts and rental records.";

            panel2.Controls.Clear();

            contractsControl = new ContractControl
            {
                Dock = DockStyle.Fill
            };
            panel2.Controls.Add(contractsControl);

            label1.Text = "Contracts";
        }

        // === BUTTON CLICK HANDLERS ==========================================

        // Dashboard button
        private void button1_Click_1(object sender, EventArgs e)
        {
            ShowDashboard();
        }

        // Customer button
        private void button2_Click_1(object sender, EventArgs e)
        {
            ShowCustomers();
        }

        // Vehicle button
        private void button7_Click_1(object sender, EventArgs e)
        {
            ShowVehicles();
        }

        // Contracts button
        private void button8_Click_1(object sender, EventArgs e)
        {
            ShowContracts();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Reserved for "Add" dialog logic if you want later
        }

        // === VISUALS / PAINT =================================================

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Color color1 = Color.FromArgb(3, 15, 40);   // dark navy
            Color color2 = Color.FromArgb(15, 60, 150); // deep blue

            using (LinearGradientBrush brush = new LinearGradientBrush(
                panel1.ClientRectangle,
                color1,
                color2,
                LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, panel1.ClientRectangle);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        // Time label (no logic needed here)
        private void label3_Click(object sender, EventArgs e)
        {
        }

        // Date label (no logic needed here)
        private void label5_Click(object sender, EventArgs e)
        {
        }

        // === TIMER TICK: UPDATE TIME & DATE ==================================

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString("hh:mm tt");                 // Time
            label5.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");      // Date
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin login = new frmLogin();
            login.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            showAssignVehicle();
        }

        private void paymentDepoButton_Click(object sender, EventArgs e)
        {
            frmPayment frmPayment = new frmPayment();
            frmPayment.ShowDialog();
        }
    }
}
