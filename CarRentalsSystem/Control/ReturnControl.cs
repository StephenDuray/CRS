using CarRentalsSystem.Database;
using Guna.UI2.WinForms;
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
    public partial class ReturnControl : UserControl
    {
        private bool _isBindingContracts = false;
        private DateTime? _expectedReturnDate = null;
        private decimal _dailyRate = 0m;

        public ReturnControl()
        {
            InitializeComponent();
        }

        private void ReturnControl_Load(object sender, EventArgs e)
        {
            _isBindingContracts = true;

            DataTable contracts = dbQuery.GetAllContractIds();
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
            DepositIDBox.Text = "";
            DepositamountBox.Text = "";
            statusBox.SelectedIndex = -1;
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isBindingContracts || ContractIDBox.SelectedIndex < 0)
                return;

            if (ContractIDBox.SelectedValue == null)
            {
                ClearReturnFields();
                return;
            }

            int contractId = Convert.ToInt32(ContractIDBox.SelectedValue);

            DataRow info = dbQuery.GetContractReturnInfo(contractId);
            if (info == null)
            {
                ClearReturnFields();
                return;
            }

         
            NameBox.Text = info["CustomerName"]?.ToString() ?? string.Empty;
            BrandBox.Text = info["Brand"]?.ToString() ?? string.Empty;
            ModelBox.Text = info["Model"]?.ToString() ?? string.Empty;

            
            if (info["DepositID"] != DBNull.Value)
                DepositIDBox.Text = info["DepositID"].ToString();
            else
                DepositIDBox.Text = "";

            // Deposit amount
            if (info["DepositAmount"] != DBNull.Value)
            {
                decimal amt = Convert.ToDecimal(info["DepositAmount"]);
                DepositamountBox.Text = amt.ToString("0.00");
            }
            else
            {
                DepositamountBox.Text = "0.00";
            }

            // Deposit status -> status combobox
            if (info.Table.Columns.Contains("DepositStatus") && info["DepositStatus"] != DBNull.Value)
            {
                string status = info["DepositStatus"].ToString();

                // If status not yet in items, add it
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
            if (info["ExpectedReturnDate"] != DBNull.Value)
                _expectedReturnDate = Convert.ToDateTime(info["ExpectedReturnDate"]);
            else
                _expectedReturnDate = null;

            if (info["DailyRate"] != DBNull.Value)
                _dailyRate = Convert.ToDecimal(info["DailyRate"]);
            else
                _dailyRate = 0m;


            amountBox.Text = "";
        }
    

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
        }
        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (!_expectedReturnDate.HasValue || _dailyRate <= 0)
            {
       
                amountBox.Text = "";
                return;
            }

            DateTime expected = _expectedReturnDate.Value.Date;
            DateTime actual = guna2DateTimePicker1.Value.Date;

            if (actual <= expected)
            {
  
                amountBox.Text = "0.00";
                return;
            }

            int extraDays = (actual - expected).Days;     // 1 day, 2 days, ...

            decimal charges = _dailyRate * extraDays;

            
            amountBox.Text = charges.ToString("0.00");
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
