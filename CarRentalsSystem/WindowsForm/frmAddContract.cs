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

namespace CarRentalsSystem.WindowsForm
{
    public partial class frmAddContract : Form
    {
        public frmAddContract()
        {
            InitializeComponent();
            this.Shown += frmAddContract_Shown;

            expected.ValueChanged += expected_ValueChanged;
            actual.ValueChanged += actual_ValueChanged;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmAddContract_Load(object sender, EventArgs e)
        {
            LoadPoliciesIntoCombo();
            LoadUsersIntoCombo();

           
            actual.Format = DateTimePickerFormat.Custom;
            actual.Checked = false;

           
            expected.Format = DateTimePickerFormat.Custom;
            expected.Checked = false;
        }
       
        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            bool isUpdating = false;
            if (isUpdating) return;

            if (int.TryParse(CustomerIDBox.Text.Trim(), out int customerId))
            {
                isUpdating = true;
                CustomerNameBox.Text = dbQuery.GetCustomerNameById(customerId);
                isUpdating = false;
            }
            else
            {
                isUpdating = true;
                CustomerNameBox.Text = "";
                isUpdating = false;
            }
        }
        private void LoadPoliciesIntoCombo()
        {
            DataTable dt = dbQuery.GetRentalPolicies();

            PolicyBox.DataSource = dt;
            PolicyBox.DisplayMember = "policyName";  // shown to user
            PolicyBox.ValueMember = "rentalpolicyID";      // real ID
            PolicyBox.SelectedIndex = -1;            // nothing selected initially
        }

        private void LoadUsersIntoCombo()
        {
            DataTable dt = dbQuery.GetUsers();

            UserBox.DataSource = dt;
            UserBox.DisplayMember = "name";   // what user sees
            UserBox.ValueMember = "userID";       // real ID
            UserBox.SelectedIndex = -1;
        }


        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {
            bool isUpdating = false;
            if (isUpdating) return;

            string name = CustomerNameBox.Text.Trim();

            if (name.Length == 0)
            {
                isUpdating = true;
                CustomerIDBox.Text = "";
                isUpdating = false;
                return;
            }

            int id = dbQuery.GetCustomerIdByName(name);

            isUpdating = true;
            CustomerIDBox.Text = (id != -1) ? id.ToString() : "";
            isUpdating = false;
        }
        private void frmAddContract_Shown(object sender, EventArgs e)
        {
            // Booking date: visible, today
            bookdate.Value = DateTime.Now;
            bookdate.Format = DateTimePickerFormat.Custom;
            bookdate.CustomFormat = "dd/MM/yyyy";

            // Expected: start blank
            expected.Value = DateTime.Now;        // internal value, not shown
            expected.Format = DateTimePickerFormat.Custom;
            expected.CustomFormat = " ";                 // <-- looks empty

            // Actual: start blank
            actual.Value = DateTime.Now;
            actual.Format = DateTimePickerFormat.Custom;
            actual.CustomFormat = " ";
        }
        // Expected return
        private void expected_ValueChanged(object sender, EventArgs e)
        {
            // As soon as user chooses a date, show it
            expected.Format = DateTimePickerFormat.Custom;
            expected.CustomFormat = "dd/MM/yyyy";
        }

        private void actual_ValueChanged(object sender, EventArgs e)
        {
            actual.Format = DateTimePickerFormat.Custom;
            actual.CustomFormat = "dd/MM/yyyy";
        }


        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int customerID;
            int userID;
            int policyID;

            // Validate ID fields
            if (!int.TryParse(CustomerIDBox.Text, out customerID))
            {
                MessageBox.Show("Invalid Customer ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(UserBox.SelectedValue?.ToString(), out userID))
            {
                MessageBox.Show("Please select a user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(PolicyBox.SelectedValue?.ToString(), out policyID))
            {
                MessageBox.Show("Please select a rental policy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Dates
            DateTime bookingDate = bookdate.Value.Date;

            // Expected must NOT be empty
            if (expected.CustomFormat == " ")
            {
                MessageBox.Show("Please select an expected return date.",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime expectedReturnDate = expected.Value.Date;

            if (expectedReturnDate < bookingDate)
            {
                MessageBox.Show("Expected return date cannot be earlier than the booking date.",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Actual optional
            DateTime? actualReturnDate = null;
            if (actual.CustomFormat != " ")
            {
                DateTime actualDateVal = actual.Value.Date;
                if (actualDateVal < bookingDate)
                {
                    MessageBox.Show("Actual return date cannot be earlier than the booking date.",
                                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                actualReturnDate = actualDateVal;
            }

            // Save to DB
            bool success = dbQuery.AddContract(customerID, userID, policyID,
                                               bookingDate, expectedReturnDate,
                                               actualReturnDate);

            if (success)
            {
                MessageBox.Show("Contract added successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 👇 This is what enables auto-refresh for the caller
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to add contract.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addPictureButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
