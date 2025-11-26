using CarRentalsSystem.Database;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalsSystem.Control
{
    public partial class ReportsControl : UserControl
    {
        public ReportsControl()
        {
            InitializeComponent();
            this.Load += ReportsControl_Load1;
        }

        private void ReportsControl_Load1(object sender, EventArgs e)
        {
            LoadReports();
        }

        private void ReportsControl_Load(object sender, EventArgs e)
        {
            // You can leave this empty or remove the event hookup in Designer
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // If you don't want it to reload on every paint, you can remove this call.
            // For now I'll leave it as you had it:
            // LoadReports();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadReports()
        {
            try
            {
                DataTable dt = dbQuery.GetReturnReports();

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = dt;

                ConfigureGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading reports:\n" + ex.Message,
                                "Reports", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔹 Apply styling + header text (like your ConfigureGrid example)
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

            // 🔹 Let header wrap and auto-size its height
            dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // Center header text
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Header style
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 80, 160);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // Alternating row colors
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);

            // 🔹 Rename headers based on GetReturnReports() columns
            if (dataGridView1.Columns.Contains("CustomerName"))
                dataGridView1.Columns["CustomerName"].HeaderText = "Customer Name";

            if (dataGridView1.Columns.Contains("ContractID"))
                dataGridView1.Columns["ContractID"].HeaderText = "Contract ID";

            if (dataGridView1.Columns.Contains("PolicyName"))
                dataGridView1.Columns["PolicyName"].HeaderText = "Policy Type";

            if (dataGridView1.Columns.Contains("BookingDate"))
                dataGridView1.Columns["BookingDate"].HeaderText = "Booking Date";

            if (dataGridView1.Columns.Contains("ReturnDate"))
                dataGridView1.Columns["ReturnDate"].HeaderText = "Return Date";

            if (dataGridView1.Columns.Contains("Brand"))
                dataGridView1.Columns["Brand"].HeaderText = "Brand";

            if (dataGridView1.Columns.Contains("ModelType"))
                dataGridView1.Columns["ModelType"].HeaderText = "Model Type";

            if (dataGridView1.Columns.Contains("OriginalDepositAmount"))
                dataGridView1.Columns["OriginalDepositAmount"].HeaderText = "Deposit (Original)";

            if (dataGridView1.Columns.Contains("DepositRemainingOrRefund"))
                dataGridView1.Columns["DepositRemainingOrRefund"].HeaderText = "Deposit (Refund/Remaining)";

            if (dataGridView1.Columns.Contains("LateCharges"))
                dataGridView1.Columns["LateCharges"].HeaderText = "Late Charges";

            if (dataGridView1.Columns.Contains("DamageFee"))
                dataGridView1.Columns["DamageFee"].HeaderText = "Damage Fee";

            if (dataGridView1.Columns.Contains("DepositStatus"))
                dataGridView1.Columns["DepositStatus"].HeaderText = "Deposit Status";
        }

    }
}
