using CarRentalsSystem.Database;
using CarRentalsSystem.WindowsForm;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalsSystem.Control
{
    public partial class AssignVehicle : UserControl
    {
        public AssignVehicle()
        {
            InitializeComponent();
        }

        private void AssignVehicle_Load(object sender, EventArgs e)
        {
            LoadRentalsToGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAssignVehicleAdd frmAssignVehicleAdd = new frmAssignVehicleAdd();
            frmAssignVehicleAdd.ShowDialog();

            // Refresh grid after assigning a vehicle
            LoadRentalsToGrid();
        }

        // 🔹 Load rentals into grid
        private void LoadRentalsToGrid()
        {
            try
            {
                DataTable dt = dbQuery.GetCurrentRentals();   // the method we made before

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = dt;

                ConfigureGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading rentals:\n" + ex.Message,
                                "Assign Vehicle", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔹 Apply styling + header text (like your sample)
        private void ConfigureGrid()
        {
            if (dataGridView1.Columns.Count == 0)
                return;

            // Auto-size columns & rows
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;

            // Center header text
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Header style
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 80, 160);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // Alternating row colors
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);

            // 🔹 Rename headers based on GetCurrentRentals() columns
            if (dataGridView1.Columns.Contains("CustomerName"))
                dataGridView1.Columns["CustomerName"].HeaderText = "Customer Name";

            if (dataGridView1.Columns.Contains("ContractID"))
                dataGridView1.Columns["ContractID"].HeaderText = "Contract ID";

            if (dataGridView1.Columns.Contains("Brand"))
                dataGridView1.Columns["Brand"].HeaderText = "Brand";

            if (dataGridView1.Columns.Contains("Model"))
                dataGridView1.Columns["Model"].HeaderText = "Model Type";

            if (dataGridView1.Columns.Contains("PlateNo"))
                dataGridView1.Columns["PlateNo"].HeaderText = "Plate Number";

            if (dataGridView1.Columns.Contains("BookingDate"))
                dataGridView1.Columns["BookingDate"].HeaderText = "Booking Date";

           
        }
    }
}
