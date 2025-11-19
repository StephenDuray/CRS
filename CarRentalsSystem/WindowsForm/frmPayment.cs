using CarRentalsSystem.Database;
using CarRentalsSystem.Factory;
using Guna.UI2.WinForms;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalsSystem.WindowsForm
{
    public partial class frmPayment : Form
    {
        public frmPayment()
        {
            InitializeComponent();
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            LoadContract();

            // numeric only for textbox2
            guna2TextBox2.KeyPress += NumberKeyPress;

            // react when contractID changes
            guna2ComboBox1.SelectedIndexChanged += guna2ComboBox1_SelectedIndexChanged;

            // start hidden until we know it's full-to-full
           
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void LoadContract()
        {
            DataTable dt = dbQuery.GetContracts();
            guna2ComboBox1.DataSource = dt;
            guna2ComboBox1.DisplayMember = "contractID";   // what user sees
            guna2ComboBox1.ValueMember = "contractID";     // real ID
            guna2ComboBox1.SelectedIndex = -1;
        }

        private void NumberKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Allow only ONE decimal point
            var txt = sender as Guna2TextBox;
            if (e.KeyChar == '.' && txt != null && txt.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        // ===== CHECK CONTRACT WHEN USER SELECTS IT =====
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            guna2TextBox2.Clear();

            if (guna2ComboBox1.SelectedIndex < 0 || guna2ComboBox1.SelectedValue == null)
                return;

            if (!int.TryParse(guna2ComboBox1.SelectedValue.ToString(), out int contractId))
                return;

            // 🔒 First: check if this contract is already paid
            if (dbQuery.ContractHasPayment(contractId))
            {
                // contract already has a payment → do NOT show total, block editing
                guna2TextBox2.ReadOnly = true;
                // optional: show an info message once
                MessageBox.Show("This contract is already paid. No new payment can be recorded.",
                                "Already Paid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Not yet paid → allow editing and auto-fill total if Full-to-Full
            guna2TextBox2.ReadOnly = false;

            double total = dbQuery.GetFullToFullTotal(contractId);   // this already supports multiple vehicles

            if (total > 0)
            {
                guna2TextBox2.Text = total.ToString("0.00");
            }
            else
            {
                // Not Full-to-Full (or no rented vehicles) → user can type manually
                guna2TextBox2.Clear();
            }
        }


        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            // no logic needed here anymore
        }

        private void ResetField()
        {
            guna2ComboBox1.SelectedIndex = -1;
            guna2ComboBox2.SelectedIndex = -1;
            guna2TextBox2.Clear();
          
        }

        private void FulltoFullTotal()
        {
            // no longer needed, handled in combo SelectedIndexChanged
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedIndex < 0 || guna2ComboBox1.SelectedValue == null)
            {
                MessageBox.Show("Please select a Contract ID first.",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(guna2ComboBox1.SelectedValue.ToString(), out int contractId))
            {
                MessageBox.Show("Invalid Contract ID.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 🔒 STOP if already paid
            if (dbQuery.ContractHasPayment(contractId))
            {
                MessageBox.Show("This contract already has a recorded payment. You cannot add another one.",
                                "Already Paid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check amount from textbox2
            if (!double.TryParse(guna2TextBox2.Text.Trim(), out double amount))
            {
                MessageBox.Show("Invalid or missing total amount.",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Example: payment method from comboBox2 (or however you store it)
            if (guna2ComboBox2.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a payment method.",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string method = guna2ComboBox2.SelectedItem.ToString();

            DateTime paymentDate = guna2DateTimePicker1.Value;

            bool ok = dbQuery.AddPayment(contractId, amount, paymentDate, method);

            if (ok)
            {
                MessageBox.Show("Payment recorded successfully!",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ResetField();   // this should just clear controls, not hide textbox2
                frmDeposit frmDeposit = new frmDeposit();
                frmDeposit.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save payment.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
