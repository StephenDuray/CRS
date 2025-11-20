using CarRentalsSystem.Database;
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
    public partial class DashboardControl : UserControl
    {
        public DashboardControl()
        {
            InitializeComponent();
            this.AutoScroll = true;
            this.Load += DashboardControl_Load;
        }

        private void DashboardControl_Load(object sender, EventArgs e)
        {
          //  
           // this.AutoScrollMinSize = new Size(
             //   0,
             //   dataGridView1.Bottom + 20  // 20px extra padding
          //  );

            LoadDashboardStats();
        }
        private void LoadDashboardStats()
        {
            try
            {
                // Total Cars
                int totalCars = dbQuery.GetTotalVehicles();
                label8.Text = totalCars.ToString();

                // Total Customers
                int totalCustomers = dbQuery.GetTotalCustomers();
                label7.Text = totalCustomers.ToString();

                // Available Rentals (Vehicles NOT rented)
                int availableCars = dbQuery.GetAvailableVehicles();
                label2.Text = availableCars.ToString();

                // Rented Vehicles (Active Rentals)
                int rentedCars = dbQuery.GetRentedVehicles();
                label6.Text = rentedCars.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load dashboard stats:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


      
        //Total Cars
        private void label8_Click(object sender, EventArgs e)
        {
            
        }
        //Total Customer
        private void label7_Click(object sender, EventArgs e)
        {

        }
        //Available Rentals
        private void label6_Click(object sender, EventArgs e)
        {

        }
        //Available Cars
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
