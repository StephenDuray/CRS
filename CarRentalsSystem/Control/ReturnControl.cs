using CarRentalsSystem.Database;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalsSystem.Control
{
    public partial class ReturnControl : UserControl
    {
        private bool _isBindingContracts = false;
        private DateTime? _expectedReturnDate = null;
        private decimal _dailyRate = 0m;
        private decimal _originalDepositAmount = 0m;

        // starting odometer value for this contract
        private int _meterStart = 0;

        // vehicle associated with the contract
        private int _vehicleId = 0;

        // helper flags/values
        private bool _changingMeterEndText = false;
        private decimal _amountToPay = 0m;

        public ReturnControl()
        {
            InitializeComponent();
        }

        private void ReturnControl_Load(object sender, EventArgs e)
        {
            _isBindingContracts = true;

            DataTable contracts = dbQuery.GetAllContractIds();

            // Remove contracts that are already returned/closed
            for (int i = contracts.Rows.Count - 1; i >= 0; i--)
            {
                DataRow row = contracts.Rows[i];

                if (!int.TryParse(row["contractID"].ToString(), out int contractId))
                {
                    contracts.Rows.RemoveAt(i);
                    continue;
                }

                if (dbQuery.ContractAlreadyReturned(contractId))
                {
                    contracts.Rows.RemoveAt(i);
                }
            }

            ContractIDBox.DataSource = contracts;
            ContractIDBox.DisplayMember = "contractID";
            ContractIDBox.ValueMember = "contractID";
            ContractIDBox.SelectedIndex = -1;

            _isBindingContracts = false;

            ClearReturnFields();
        }

        private void ClearReturnFields()
        {
            NameBox.Text = "";
            BrandBox.Text = "";
            ModelBox.Text = "";
            MeterEndBox.Text = "";

            DepositIDBox.Text = "";
            DepositamountBox.Text = "0.00";
            extraChargesBox.Text = "";
            amountBox.Text = "";
            customertoPay.Text = "";
            PaymentBox.Text = "";
            noteBox.Text = "";

            _originalDepositAmount = 0m;
            _expectedReturnDate = null;
            _dailyRate = 0m;

            _meterStart = 0;
            _vehicleId = 0;

            // clear parts list
            checkedListBox1.DataSource = null;
            checkedListBox1.Items.Clear();
        }

        /// <summary>
        /// Load all parts assigned to a vehicle into the CheckedListBox.
        /// Assumes dbQuery.GetVehicleParts(int vehicleId) exists and returns (partsID, partName).
        /// </summary>
        private DataTable _partsTable;
        private void LoadVehicleParts(int vehicleId)
        {
            checkedListBox1.DataSource = null;
            checkedListBox1.Items.Clear();
            _partsTable = null;

            if (vehicleId <= 0)
                return;

            _partsTable = dbQuery.GetVehicleParts(vehicleId);
            if (_partsTable == null || _partsTable.Rows.Count == 0)
                return;

            // bind the table so each item knows its partsID
            checkedListBox1.DataSource = _partsTable;
            checkedListBox1.DisplayMember = "partName";
            checkedListBox1.ValueMember = "partsID";

            // assume everything is present at first
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, true);
        }


        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ignore events while we are binding data
            if (_isBindingContracts)
                return;

            // no selection → clear
            if (ContractIDBox.SelectedIndex < 0 || ContractIDBox.SelectedValue == null)
            {
                ClearReturnFields();
                return;
            }

            // make sure we can parse the contractID
            if (!int.TryParse(ContractIDBox.SelectedValue.ToString(), out int contractId))
            {
                ClearReturnFields();
                return;
            }

            // optional: only allow contracts that have at least one assigned vehicle
            if (!dbQuery.ContractHasAssignedVehicle(contractId))
            {
                ClearReturnFields();
                return;
            }

            // get all info we need for the return screen
            DataRow info = dbQuery.GetContractReturnInfo(contractId);
            if (info == null)
            {
                ClearReturnFields();
                return;
            }

            // ---------- fill customer & vehicle ----------
            NameBox.Text = info["CustomerName"]?.ToString() ?? string.Empty;
            BrandBox.Text = info["Brand"]?.ToString() ?? string.Empty;
            ModelBox.Text = info["Model"]?.ToString() ?? string.Empty;

            // vehicleID for this contract (ensure your SQL returns VehicleID)
            if (info.Table.Columns.Contains("VehicleID") && info["VehicleID"] != DBNull.Value)
                _vehicleId = Convert.ToInt32(info["VehicleID"]);
            else
                _vehicleId = 0;

            // starting meter (ensure your SQL returns OdometerStart if you use this)
            if (info.Table.Columns.Contains("OdometerStart") && info["OdometerStart"] != DBNull.Value)
                _meterStart = Convert.ToInt32(info["OdometerStart"]);
            else
                _meterStart = 0;

            // ---------- deposit info ----------
            if (info["DepositID"] != DBNull.Value)
                DepositIDBox.Text = info["DepositID"].ToString();
            else
                DepositIDBox.Text = string.Empty;

            if (info["DepositAmount"] != DBNull.Value)
            {
                _originalDepositAmount = Convert.ToDecimal(info["DepositAmount"]);
                DepositamountBox.Text = _originalDepositAmount.ToString("0.00");
            }
            else
            {
                _originalDepositAmount = 0m;
                DepositamountBox.Text = "0.00";
            }

            // deposit status → statusBox
            if (info.Table.Columns.Contains("DepositStatus") && info["DepositStatus"] != DBNull.Value)
            {
                string status = info["DepositStatus"].ToString();
                int idx = statusBox.Items.IndexOf(status);
                if (idx < 0)
                {
                    statusBox.Items.Add(status);
                    idx = statusBox.Items.IndexOf(status);
                }
                statusBox.SelectedIndex = idx;
            }
            else
            {
                statusBox.SelectedIndex = -1;
            }

            // ---------- expected return & daily rate ----------
            if (info.Table.Columns.Contains("ExpectedReturnDate") && info["ExpectedReturnDate"] != DBNull.Value)
                _expectedReturnDate = Convert.ToDateTime(info["ExpectedReturnDate"]);
            else
                _expectedReturnDate = null;

            if (info.Table.Columns.Contains("DailyRate") && info["DailyRate"] != DBNull.Value)
                _dailyRate = Convert.ToDecimal(info["DailyRate"]);
            else
                _dailyRate = 0m;

            if (_expectedReturnDate.HasValue)
                guna2DateTimePicker1.Value = _expectedReturnDate.Value;

            // clear per-return inputs
            extraChargesBox.Text = string.Empty;
            amountBox.Text = string.Empty;
            customertoPay.Text = string.Empty;
            PaymentBox.Text = string.Empty;
            noteBox.Text = string.Empty;

            // load parts for this vehicle into the CheckedListBox
            LoadVehicleParts(_vehicleId);

            // start with refund = full deposit (no charges yet)
            RecalculateCustomerToPay();
        }
        private void guna2TextBox2_TextChanged_1(object sender, EventArgs e)
        { 
        }
        private void RecalculateCustomerToPay()
        {
            decimal deposit = 0m;
            decimal charges = 0m;
            decimal damageFee = 0m;

            decimal.TryParse(DepositamountBox.Text, out deposit);
            decimal.TryParse(amountBox.Text, out charges);
            decimal.TryParse(extraChargesBox.Text, out damageFee);

            decimal totalCharges = charges + damageFee;

            // CASE 1: no charges
            if (totalCharges <= 0m)
            {
                label13.Text = "Refund to Customer :";
                label13.ForeColor = Color.Green;
                customertoPay.ForeColor = Color.Green;
                customertoPay.Text = deposit.ToString("0.00");
                return;
            }

            // CASE 2: charges <= deposit → refund remaining deposit
            if (totalCharges <= deposit)
            {
                decimal remainingDeposit = deposit - totalCharges;

                label13.Text = "Refund to Customer :";
                label13.ForeColor = Color.Green;
                customertoPay.ForeColor = Color.Green;
                customertoPay.Text = remainingDeposit.ToString("0.00");
                return;
            }

            // CASE 3: charges > deposit → customer pays extra
            decimal extraToPay = totalCharges - deposit;

            label13.Text = "Customer to Pay :";
            label13.ForeColor = Color.Red;
            customertoPay.ForeColor = Color.Red;
            customertoPay.Text = extraToPay.ToString("0.00");
        }

        // stubs you already had
        private void guna2TextBox1_TextChanged(object sender, EventArgs e) { }
        private void guna2TextBox2_TextChanged(object sender, EventArgs e) { }
        private void guna2TextBox3_TextChanged(object sender, EventArgs e) { }
        private void guna2TextBox5_TextChanged(object sender, EventArgs e) { }
        private void guna2TextBox6_TextChanged(object sender, EventArgs e) { }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // 1. Basic validation
            if (ContractIDBox.SelectedIndex < 0 || ContractIDBox.SelectedValue == null)
            {
                MessageBox.Show("Please select a contract ID first.",
                                "Return", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int contractId = Convert.ToInt32(ContractIDBox.SelectedValue);

            // Validate Mileage
            if (!int.TryParse(MeterEndBox.Text, out int meterEnd) || meterEnd < 0)
            {
                MessageBox.Show("Please enter a valid meter end / odometer value.",
                                "Return", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MeterEndBox.Focus();
                return;
            }

            if (meterEnd < _meterStart)
            {
                MessageBox.Show(
                    $"Meter End cannot be lower than the starting mileage ({_meterStart}).",
                    "Invalid Mileage",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                MeterEndBox.Focus();
                return;
            }

            // Deposit ID validation
            if (string.IsNullOrWhiteSpace(DepositIDBox.Text) ||
                !int.TryParse(DepositIDBox.Text, out int depositId))
            {
                MessageBox.Show("No deposit record found for this contract.",
                                "Return", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Parse late charges & damage
            decimal lateCharges = 0m;
            decimal damageFee = 0m;

            decimal.TryParse(amountBox.Text, out lateCharges);      // late fees
            decimal.TryParse(extraChargesBox.Text, out damageFee);  // damage fees

            // Deposit status
            string depositStatus = statusBox.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(depositStatus))
            {
                MessageBox.Show("Please select a deposit status.",
                                "Return", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Payment amount validation
            decimal amountCustomerMustPay = 0m;
            decimal.TryParse(customertoPay.Text, out amountCustomerMustPay);

            decimal actualPayment = 0m;
            decimal.TryParse(PaymentBox.Text, out actualPayment);

            if (label13.Text.Contains("Customer to Pay"))
            {
                if (actualPayment < amountCustomerMustPay)
                {
                    MessageBox.Show(
                        $"Payment is insufficient.\nCustomer must pay at least {amountCustomerMustPay:0.00}.",
                        "Insufficient Payment",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    PaymentBox.Focus();
                    return;
                }
            }

            string notes = noteBox.Text;
            string paymentMethod = string.IsNullOrWhiteSpace(PaymentBox.Text)
                                   ? null
                                   : PaymentBox.Text;

            DateTime actualReturnDate = guna2DateTimePicker1.Value.Date;

            try
            {
                bool ok = dbQuery.SaveReturn(
                    contractId: contractId,
                    odometerEnd: meterEnd,
                    actualReturnDate: actualReturnDate,
                    originalDepositAmount: _originalDepositAmount,
                    lateCharges: lateCharges,
                    damageFee: damageFee,
                    depositId: depositId,
                    depositStatus: depositStatus,
                    notes: notes,
                    extraPaymentMethod: paymentMethod
                );

                if (ok)
                {
                    // ✅ update parts statuses now
                    UpdatePartsStatusesOnSave();

                    MessageBox.Show("Return has been saved and contract closed.",
                                    "Return", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearReturnFields();
                }
                else
                {
                    MessageBox.Show("No changes were saved. Please check the data.",
                                    "Return", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving return:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e) { }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {
            RecalculateCustomerToPay();
        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {
            RecalculateCustomerToPay();
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (!_expectedReturnDate.HasValue || _dailyRate <= 0)
            {
                amountBox.Text = "0.00";
                RecalculateCustomerToPay();
                return;
            }

            DateTime expected = _expectedReturnDate.Value.Date;
            DateTime actual = guna2DateTimePicker1.Value.Date;

            if (actual < expected)
            {
                MessageBox.Show(
                    "Return date cannot be earlier than the expected return date.",
                    "Invalid Return Date",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                guna2DateTimePicker1.Value = expected;
                amountBox.Text = "0.00";
                RecalculateCustomerToPay();
                return;
            }

            if (actual == expected)
            {
                amountBox.Text = "0.00";
                RecalculateCustomerToPay();
                return;
            }

            int extraDays = (actual - expected).Days;
            decimal charges = _dailyRate * extraDays;

            amountBox.Text = charges.ToString("0.00");
            RecalculateCustomerToPay();
        }

        private void label11_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }

        // mileage numeric-only guard
        private void MeterEndBox_TextChanged(object sender, EventArgs e)
        {
            if (_changingMeterEndText) return;

            string text = MeterEndBox.Text.Trim();
            if (string.IsNullOrEmpty(text))
                return;

            if (!int.TryParse(text, out _))
            {
                _changingMeterEndText = true;
                MessageBox.Show("Please enter numbers only for Meter End.",
                                "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MeterEndBox.Text = "";
                _changingMeterEndText = false;
            }
        }

        private void customertoPay_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(customertoPay.Text, out decimal value))
                _amountToPay = value;
            else
                _amountToPay = 0m;
        }

        // optional textbox search handler, if you use a separate text box for contract ID
        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {
            // left empty on purpose or you can wire it to sync ContractIDBox if needed
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }



        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // If we don't know the vehicle, nothing to update
            if (_vehicleId <= 0)
                return;

            // Which part is being changed?
            string partName = checkedListBox1.Items[e.Index].ToString();

            // If it becomes unchecked → use status from partsStatusBox (Lost/Replaced/etc)
            if (e.NewValue == CheckState.Unchecked)
            {
                string selectedStatus = guna2ComboBox1.SelectedItem?.ToString();   // <-- use the NEW combo

                if (string.IsNullOrWhiteSpace(selectedStatus))
                {
                    MessageBox.Show(
                        "Please select a status for the part (Lost / Replaced / Damaged, etc.)",
                        "Part Status",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    // cancel uncheck → keep it checked
                    e.NewValue = CheckState.Checked;
                    return;
                }

                // Update DB: this part is Lost/Replaced/etc
                dbQuery.UpdatePartStatus(_vehicleId, partName, selectedStatus);
            }
            else if (e.NewValue == CheckState.Checked)
            {
                // When user checks it again → set back to OK
                dbQuery.UpdatePartStatus(_vehicleId, partName, "OK");
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e) 
        {
        
        }
        private void UpdatePartsStatusesOnSave()
        {
            if (_partsTable == null || _partsTable.Rows.Count == 0)
                return;

            // Status to use for all missing/unchecked parts
            string missingStatus = guna2ComboBox1.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(missingStatus))
                missingStatus = "Lost";   // default if nothing selected

            for (int i = 0; i < _partsTable.Rows.Count; i++)
            {
                DataRow row = _partsTable.Rows[i];
                int partsId = Convert.ToInt32(row["partsID"]);

                bool isPresent = checkedListBox1.GetItemChecked(i);

                string status = isPresent ? "OK" : missingStatus;

                dbQuery.UpdatePartStatusById(partsId, status);
            }
        }

    }
}
