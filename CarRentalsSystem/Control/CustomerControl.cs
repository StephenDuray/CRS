using CarRentalsSystem.WindowsForm;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalsSystem.Database   // keep this as-is so the designer doesn't break
{
    public partial class CustomerControl : UserControl
    {
        public CustomerControl()
        {
            InitializeComponent();

            // Load data when the control is first shown
            this.Load += CustomerControl_Load;
        }

        // ============================
        //  INITIAL LOAD
        // ============================
        private void CustomerControl_Load(object sender, EventArgs e)
        {
            LoadCustomers();   // load all records on startup
        }

        // Load all (or filtered) customers into the grid
        private void LoadCustomers(string keyword = "")
        {
            // keyword == ""  → your SearchCustomers will just return all
            DataTable dt = dbQuery.SearchCustomers(keyword);
            dataGridView1.DataSource = dt;

            ConfigureGrid();
        }

        // ============================
        //  GRID APPEARANCE & HEADERS
        // ============================
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

            // Optional: nicer header style
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 80, 160);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // Optional: alternating row colors
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);

            // Rename headers safely (only if column exists)
            if (dataGridView1.Columns.Contains("name"))
                dataGridView1.Columns["name"].HeaderText = "Customer Name";

            if (dataGridView1.Columns.Contains("dob"))
                dataGridView1.Columns["dob"].HeaderText = "Date of Birth";

            if (dataGridView1.Columns.Contains("gender"))
                dataGridView1.Columns["gender"].HeaderText = "Gender";

            if (dataGridView1.Columns.Contains("address"))
                dataGridView1.Columns["address"].HeaderText = "Complete Address";

            if (dataGridView1.Columns.Contains("licenseNo"))
                dataGridView1.Columns["licenseNo"].HeaderText = "License Number";
        }

       
        private void button1_Click_1(object sender, EventArgs e)
        {
            using (var addCustomerForm = new frmAdd())
            {
                // If you ever set DialogResult = OK in frmAdd, you can check it here
                addCustomerForm.ShowDialog();
            }

            // After closing frmAdd, refresh the customer list
            LoadCustomers(guna2TextBox1.Text.Trim());
        }

        // ============================
        //  LIVE SEARCH
        // ============================
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = guna2TextBox1.Text.Trim();
            LoadCustomers(keyword);   // reload grid with filter
        }

        private void CustomerControl_Load_1(object sender, EventArgs e)
        {

        }
    }
}
