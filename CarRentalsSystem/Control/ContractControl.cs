using CarRentalsSystem.Database;
using CarRentalsSystem.WindowsForm;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalsSystem.Control
{
    public partial class ContractControl : UserControl
    {
        private DataTable _contractsTable;
        private DataTable _policiesTable;
        private bool _gridInitialized = false;

        public ContractControl()
        {
            InitializeComponent();

            this.Load += ContractControl_Load;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
        }

        // ============================
        //  LOAD
        // ============================
        private void ContractControl_Load(object sender, EventArgs e)
        {
            LoadPolicies();
            LoadContracts();
            InitializeGridColumns();
            BindContracts();
            ConfigureGridStyle();
        }

        private void LoadPolicies()
        {
            _policiesTable = dbQuery.GetRentalPolicies();
        }

        private void LoadContracts()
        {
            _contractsTable = dbQuery.GetContracts();
        }

        // ============================
        //  GRID SETUP
        // ============================
        private void InitializeGridColumns()
        {
            if (_gridInitialized)
                return;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            // helper to add read-only text columns
            void AddTextColumn(string name, string header, string dataProperty)
            {
                var col = new DataGridViewTextBoxColumn
                {
                    Name = name,
                    HeaderText = header,
                    DataPropertyName = dataProperty,
                    ReadOnly = true
                };
                dataGridView1.Columns.Add(col);
            }

            AddTextColumn("ContractID", "Contract ID", "contractID");
            AddTextColumn("CustomerID", "Customer ID", "customerID");
            AddTextColumn("CustomerName", "Customer Name", "CustomerName");
            AddTextColumn("BookingDate", "Booking Date", "bookingDate");
            AddTextColumn("ExpectedDate", "Expected Return Date", "expectedReturnDate");
            AddTextColumn("ActualDate", "Actual Return Date", "actualReturnDate");

            // Policy combo column (ONLY editable column)
            var policyCol = new DataGridViewComboBoxColumn
            {
                Name = "Policy",
                HeaderText = "Policy",
                DataPropertyName = "policyID",   // value stored in contracts table

                DataSource = _policiesTable,
                DisplayMember = "policyName",    // what user sees
                ValueMember = "rentalpolicyID",        // actual value in DataTable

                DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton,
                FlatStyle = FlatStyle.Flat,
                ReadOnly = false
            };
            dataGridView1.Columns.Add(policyCol);

            // User column – read-only
            AddTextColumn("User", "User", "User");

            _gridInitialized = true;
        }

        private void BindContracts()
        {
            dataGridView1.DataSource = _contractsTable;
        }

        private void ConfigureGridStyle()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = false; // important – column-level ReadOnly controls editing

            // center headers
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // header style
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 80, 160);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            // alternating row color
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
        }

        // ============================
        //  ADD CONTRACT BUTTON
        // ============================
        private void button1_Click(object sender, EventArgs e)
        {
            using (var dlg = new frmAddContract())
            {
                var result = dlg.ShowDialog();

                // If frmAddContract sets DialogResult = OK on success:
                if (result == DialogResult.OK)
                {
                    ReloadContracts();
                }
                // If not using DialogResult, you can just always:
                // ReloadContracts();
            }
        }

        private void ReloadContracts()
        {
            LoadContracts();
            BindContracts();
        }

        // ============================
        //  SAVE EDITS (Policy only)
        // ============================
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var column = dataGridView1.Columns[e.ColumnIndex];
            if (column.Name != "Policy") return; // only respond to Policy edits

            var row = dataGridView1.Rows[e.RowIndex];

            try
            {
                int contractId = Convert.ToInt32(row.Cells["ContractID"].Value);
                object policyValue = row.Cells["Policy"].Value;

                if (policyValue == null || policyValue == DBNull.Value)
                {
                    MessageBox.Show("Policy cannot be empty.", "Validation",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ReloadContracts(); // revert
                    return;
                }

                int newPolicyId = Convert.ToInt32(policyValue);

                bool ok = dbQuery.UpdateContractPolicy(contractId, newPolicyId);

                if (!ok)
                {
                    MessageBox.Show("Failed to update policy.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ReloadContracts(); // revert UI
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating policy: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReloadContracts();
            }
        }

        private void assignbutton_Click(object sender, EventArgs e)
        {
            //frmAssignVehicle frmAssignVehicle = new frmAssignVehicle();
            //frmAssignVehicle.ShowDialog();

        }
    }
}
