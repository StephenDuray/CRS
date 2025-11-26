using CarRentalsSystem;
using CarRentalsSystem.Database;
using CarRentalsSystem.Factory;
using Guna.UI2.WinForms;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
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
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = System.Drawing.Color.White;
        }

        int borderRadius = 25;
        int borderSize = 2;
        System.Drawing.Color borderColor = System.Drawing.Color.FromArgb(0, 45, 139);

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

        private void frmPayment_Load(object sender, EventArgs e)
        {
            int radius = 40;

            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            this.Region = new Region(path);

            LoadContract();

         
            guna2TextBox2.KeyPress += NumberKeyPress;

           
            guna2ComboBox1.SelectedIndexChanged += guna2ComboBox1_SelectedIndexChanged;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void LoadContract()
        {
            DataTable dt = dbQuery.GetContracts();
            guna2ComboBox1.DataSource = dt;
            guna2ComboBox1.DisplayMember = "contractID";  
            guna2ComboBox1.ValueMember = "contractID";    
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

          
            var txt = sender as Guna2TextBox;
            if (e.KeyChar == '.' && txt != null && txt.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

      
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            guna2TextBox2.Clear();

            if (guna2ComboBox1.SelectedIndex < 0 || guna2ComboBox1.SelectedValue == null)
                return;

            if (!int.TryParse(guna2ComboBox1.SelectedValue.ToString(), out int contractId))
                return;

          
            if (dbQuery.ContractHasPayment(contractId))
            {
                guna2TextBox2.ReadOnly = true;
                MessageBox.Show("This contract is already paid. No new payment can be recorded.",
                                "Already Paid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

           
            guna2TextBox2.ReadOnly = false;

            double total = dbQuery.GetFullToFullTotal(contractId);  

            if (total > 0)
            {
                guna2TextBox2.Text = total.ToString("0.00");
            }
            else
            {
                guna2TextBox2.Clear();
            }
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ResetField()
        {
            guna2ComboBox1.SelectedIndex = -1;
            guna2ComboBox2.SelectedIndex = -1;
            guna2TextBox2.Clear();
        }

        private void FulltoFullTotal()
        {
            
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

            
            if (dbQuery.ContractHasPayment(contractId))
            {
                MessageBox.Show("This contract already has a recorded payment. You cannot add another one.",
                                "Already Paid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (!double.TryParse(guna2TextBox2.Text.Trim(), out double amount))
            {
                MessageBox.Show("Invalid or missing total amount.",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
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
                
                try
                {
                    GenerateContractPdf(contractId, amount, method);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Payment saved but failed to generate contract PDF:\n" + ex.Message,
                                    "PDF Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                MessageBox.Show("Payment recorded successfully!",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ResetField();
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

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

      
        private void GenerateContractPdf(int contractId, double amount, string paymentMethod)
        {
            
            DataTable contracts = dbQuery.GetContracts();
            DataRow row = contracts.AsEnumerable()
                                   .FirstOrDefault(r => Convert.ToInt32(r["contractID"]) == contractId);

            if (row == null)
                return;

            string policyName = row["PolicyName"]?.ToString() ?? "";

           
            bool isFullToFull = policyName.IndexOf("full", StringComparison.OrdinalIgnoreCase) >= 0;
            if (!isFullToFull)
                return;

            string customerName = row["CustomerName"]?.ToString() ?? "";
            string customerIdText = row["customerID"]?.ToString() ?? "";

            DateTime bookingDate = Convert.ToDateTime(row["bookingDate"]);
            DateTime expectedReturn = Convert.ToDateTime(row["expectedReturnDate"]);
            int daysRented = (expectedReturn.Date - bookingDate.Date).Days + 1;

          
            decimal securityDeposit = dbQuery.CalculateDepositForFullToFull(contractId);

            decimal totalRentalAmount = (decimal)amount;
            decimal totalDue = totalRentalAmount + securityDeposit;

           
            string address = row["Address"]?.ToString() ?? ""; ;
            string phone = "";
            string employeeName = "";
            string employeeId = "";

           
            var vehicles = new List<VehicleLine>();
           
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(folder, $"Contract_{contractId}.pdf");

            var pdf = new GeneratePDFContract.pdf_Contract();
            pdf.GenerateContract(
                filePath: filePath,
                //contractId: contractId,
                customerName: customerName,
                customerIdText: customerIdText,
                address: address,
                phone: phone,
                policyName: policyName,
                bookingDate: bookingDate,
                expectedReturnDate: expectedReturn,
                daysRented: daysRented,
                totalRentalAmount: totalRentalAmount,
                securityDeposit: securityDeposit,
                paymentMethod: paymentMethod,
                totalDue: totalDue,
                employeeName: employeeName,
                employeeId: employeeId,
                vehicles: vehicles

            );

            MessageBox.Show($"Contract PDF generated:\n{filePath}",
                            "Contract", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
