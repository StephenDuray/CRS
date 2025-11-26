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
        private AssignVehicle assignVehicle;
        private ReturnControl returnControl;
        private ReportsControl reportsControl;

        public frmMainDashboard()
        {
            InitializeComponent();        
            panel1.Paint += panel1_Paint;          
            button6.Hide();
            textBox1.Hide();
            label2.Hide();

           
            dashboardControl = new DashboardControl();
        }

       
        private void frmMainDashboard_Load(object sender, EventArgs e)
        {
          
            ShowDashboard();

           
            timer1.Interval = 1000;
            timer1.Start();
        }

      

        private void ShowDashboard()
        {
            panel2.Controls.Clear();

            
            if (dashboardControl.Parent != null)
                dashboardControl.Parent.Controls.Remove(dashboardControl);

            dashboardControl.Dock = DockStyle.Fill;
            panel2.Controls.Add(dashboardControl);

            var view = Factory.CreateView("Car Rental Dashboard", panel2);
            view.module(this);

            label1.Text = "Car Rental Dashboard";
           
        }

        private void ShowCustomers()
        {

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
          
            panel2.Controls.Clear();

            contractsControl = new ContractControl
            {
                Dock = DockStyle.Fill
            };
            panel2.Controls.Add(contractsControl);

            label1.Text = "Booking";
        }

       
        private void button1_Click_1(object sender, EventArgs e)
        {
            ShowDashboard();
        }

      
        private void button2_Click_1(object sender, EventArgs e)
        {
            ShowCustomers();
        }

       
        private void button7_Click_1(object sender, EventArgs e)
        {
            ShowVehicles();
        }

       
        private void button8_Click_1(object sender, EventArgs e)
        {
            ShowContracts();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Color color1 = Color.FromArgb(3, 15, 40);   
            Color color2 = Color.FromArgb(15, 60, 150); 

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

        private void label3_Click(object sender, EventArgs e)
        {
        }

      
        private void label5_Click(object sender, EventArgs e)
        {
        }

      

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString("hh:mm:ss tt").ToUpper();       
            label5.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");     
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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            using (var frm = new frmReturn())  
            {
                frm.ShowDialog();
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();

            reportsControl = new ReportsControl()
            {
                Dock = DockStyle.Fill
            };
            panel2.Controls.Add(reportsControl);

            label1.Text = "Reports";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            frmDeposit frmDeposit = new frmDeposit();
            frmDeposit.ShowDialog();
        }
    }
}

