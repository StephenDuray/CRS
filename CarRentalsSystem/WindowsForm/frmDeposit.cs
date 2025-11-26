using CarRentalsSystem.Database;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CarRentalsSystem.WindowsForm
{
    public partial class frmDeposit : Form
    {
        private DataTable _paymentsTable;        // paymentID + contractID + customerName
        private int? _selectedContractId = null; // we’ll use this to calc deposit

        public frmDeposit()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;
        }


        int borderRadius = 25;
        int borderSize = 2;
        Color borderColor = Color.FromArgb(0, 45, 139);

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(borderColor, borderSize))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                int d = borderRadius * 2;

                path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                path.CloseFigure();

                this.Region = new Region(path);
                pen.Alignment = PenAlignment.Inset;
                e.Graphics.DrawPath(pen, path);
            }
        }



        private void frmDeposit_Load(object sender, EventArgs e)
        {
            LoadPaymentIdsIntoCombo();

            int radius = 40;

            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            this.Region = new Region(path);
        }

        private void LoadPaymentIdsIntoCombo()
        {
            _paymentsTable = dbQuery.GetPaymentIdsWithCustomerName();

            guna2ComboBox1.DataSource = _paymentsTable;
            guna2ComboBox1.DisplayMember = "paymentID";   // shown
            guna2ComboBox1.ValueMember = "paymentID";   // actual value

            guna2ComboBox1.SelectedIndex = -1;
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedIndex < 0)
            {
                guna2TextBox2.Text = string.Empty; // customer name
                guna2TextBox1.Text = string.Empty; // deposit amount
                _selectedContractId = null;
                return;
            }

            var rowView = guna2ComboBox1.SelectedItem as DataRowView;
            if (rowView != null)
            {
                // Show customer name
                guna2TextBox2.Text = rowView["customerName"].ToString();

                // Grab contractID from the same row
                _selectedContractId = Convert.ToInt32(rowView["contractID"]);

                // Auto-calc deposit for Full to Full contracts
                decimal deposit = dbQuery.CalculateDepositForFullToFull(_selectedContractId.Value);

                if (deposit > 0)
                {
                    guna2TextBox1.Text = deposit.ToString("0.00");
                }
                else
                {
                    // Not Full to Full or no rule -> leave blank (or set 0)
                    guna2TextBox1.Text = string.Empty;
                    // Optionally:
                    // MessageBox.Show("No automatic deposit rule for this contract.", "Info");
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Validate selections
            if (guna2ComboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a Payment ID.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(guna2TextBox1.Text))
            {
                MessageBox.Show("Deposit amount is empty.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (guna2ComboBox2.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a deposit status.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(guna2TextBox1.Text, out decimal amount))
            {
                MessageBox.Show("Invalid deposit amount.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int paymentId = Convert.ToInt32(guna2ComboBox1.SelectedValue);
            string status = guna2ComboBox2.SelectedItem.ToString();

            // TODO: if you add damageFee & notes controls, read them here
            decimal damageFee = 0m;
            string notes = "";

            try
            {
                int newDepositId = dbQuery.AddDeposit(paymentId, amount, status, damageFee, notes);

                MessageBox.Show($"Deposit saved successfully.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear form
                guna2ComboBox1.SelectedIndex = -1;
                guna2ComboBox2.SelectedIndex = -1;
                guna2TextBox1.Text = string.Empty;
                guna2TextBox2.Text = string.Empty;
                _selectedContractId = null;
            }
            catch (Exception )
            {
                MessageBox.Show("Error saving deposit: ","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // other handlers (unchanged)
        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e) { }
        private void guna2TextBox2_TextChanged(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
    }
}
