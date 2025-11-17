using CarRentalsSystem.Database;
using CarRentalsSystem.WindowsForm;
using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Guna.UI2.WinForms;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CarRentalsSystem
{
    public partial class frmAdd : Form
    {
        
        private FormMode _mode;
        public frmAdd() : this(FormMode.Customer) { }
        public frmAdd(FormMode mode)
        {
            InitializeComponent();
           // _mode = mode;
           // ConfigureFor(mode);
            

        }

        private void ConfigureFor(FormMode mode)
        {
            
            SetAllControlsVisible(this.Controls, false);

            
            if (this.Controls.Contains(NameLabel))
            {
                NameLabel.Visible = true;
                NameLabel.Text = (mode == FormMode.Customer) ? "Name " : " ";

                if (mode == FormMode.Customer)
                {
                    label2.Visible = false;

                    NamebOx.Visible = false;

                    dobLabel.Visible = true; dateTimePicker1.Visible = true;

                    genderLabel.Visible = true; radioButton1.Visible = true; radioButton2.Visible = true;

                    addresslabel.Visible = true; addressBox.Visible = true;

                    

                    PhoneNoLabel.Visible = true; PhoneNoBox.Visible = true;

                    EmailLabel.Visible = true; EmailBox.Visible = true;

                    licenseLabel.Visible = true; LicenseBox.Visible = true;

                    secondaryPhoneNo.Visible = true; 
                    secondaryLabel.Visible = true;
                    addPictureButton.Visible = true;

                    //PhoneNoBox.Text = requriedplaceholder;
                    //secondaryPhoneNo.Text = optionalplaceholder;
                    //EmailBox.Text = optionalplaceholder;
                    
                   
                    button1.Visible = true; // OK button
                    // attach digit-only handler for phone and license fields to avoid non-digit input
                    PhoneNoBox.KeyPress -= DigitsOnly_KeyPress;
                    secondaryPhoneNo.KeyPress -= DigitsOnly_KeyPress;
                    // attach letter-only handler for name if desired
                    NamebOx.KeyPress -= LetterOnly_KeyPress; NamebOx.KeyPress += LetterOnly_KeyPress;
                    EmailBox.KeyPress -= LetterOnly_KeyPress; EmailBox.KeyPress += LetterOnly_KeyPress;
                }
                //Vehicle
                else 
                {
                }
            }
        }

        private void PhoneNoBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            throw new NotImplementedException();
        }


        // frmAdd.cs
        private void SetAllControlsVisible(System.Windows.Forms.Control.ControlCollection controls, bool visible)
        {
            foreach (System.Windows.Forms.Control c in controls)
            {
                c.Visible = visible;
                if (c.HasChildren) SetAllControlsVisible(c.Controls, visible);
            }
        }


       // public FormMode Mode => _mode;

      
        private void LetterOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            char c = e.KeyChar;
            if (!(char.IsLetter(c) || c == ' ' || c == '-' || c == '\''))
            {
                e.Handled = true;
            }
        }

        // Prevent non-digit input (for phone/license fields)
        private void DigitsOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // basic email regex
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch
            {
                return false;
            }
        }

        private void frmAdd_Load(object sender, EventArgs e)
        {
           
            int radius = 40;

            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            this.Region = new Region(path);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // ============================
                //   READ USER INPUT
                // ============================
                string name = NamebOx.Text.Trim();
                DateTime dob = dateTimePicker1.Value.Date;
                string gender = radioButton1.Checked ? "Male" :
                                      (radioButton2.Checked ? "Female" : "");
                string address = addressBox.Text.Trim();
                string licenseNo = LicenseBox.Text.Trim();
                string primaryPhone = PhoneNoBox.Text.Trim();
                string secondaryPhone = secondaryPhoneNo.Text.Trim();
                string email = EmailBox.Text.Trim();

                // ============================
                //   BASIC REQUIRED FIELDS
                // ============================

                if (string.IsNullOrWhiteSpace(name) ||
                    string.IsNullOrWhiteSpace(address) ||
                    string.IsNullOrWhiteSpace(primaryPhone))
                {
                    MessageBox.Show("Please fill in all required fields (Name, Address, Primary Phone).",
                                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(licenseNo))
                {
                    MessageBox.Show("License number is required.",
                                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ============================
                //   LICENSE DUPLICATE CHECK
                // ============================

                if (dbQuery.LicenseExists(licenseNo))
                {
                    MessageBox.Show("A customer with this License No. already exists.",
                                    "Duplicate License", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ============================
                //   AGE VALIDATION (>= 18)
                // ============================

                int age = DateTime.Now.Year - dob.Year;
                if (dob > DateTime.Now.AddYears(-age)) age--;

                if (age < 18)
                {
                    MessageBox.Show("Customer must be at least 18 years old.",
                                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ============================
                //   PHONE VALIDATION
                // ============================
                // keep only digits
                string primaryDigits = new string(primaryPhone.Where(char.IsDigit).ToArray());

                if (primaryDigits.Length != 11)
                {
                    MessageBox.Show("Primary phone must contain exactly 11 digits.",
                                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string secondaryDigits = null;
                if (!string.IsNullOrWhiteSpace(secondaryPhone))
                {
                    secondaryDigits = new string(secondaryPhone.Where(char.IsDigit).ToArray());

                    if (secondaryDigits.Length != 11)
                    {
                        MessageBox.Show("Secondary phone must contain exactly 11 digits if provided.",
                                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (primaryDigits == secondaryDigits)
                    {
                        MessageBox.Show("Primary and secondary phone numbers cannot be the same.",
                                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // ============================
                //   EMAIL VALIDATION
                // ============================

                if (!string.IsNullOrWhiteSpace(email) && !IsValidEmail(email))
                {
                    MessageBox.Show("Please enter a valid email address.",
                                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ============================
                //   INSERT INTO DATABASE
                // ============================

                int newCustomerId = dbQuery.AddCustomer(name, dob, gender, address, licenseNo);

                if (newCustomerId <= 0)
                {
                    MessageBox.Show("Failed to add customer.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // primary contact
                bool primaryContactAdded =
                    dbQuery.AddContact(primaryDigits,
                                       string.IsNullOrWhiteSpace(email) ? null : email,
                                       newCustomerId);

                // secondary contact (optional)
                bool secondaryContactAdded = true;
                if (!string.IsNullOrWhiteSpace(secondaryDigits))
                {
                    secondaryContactAdded = dbQuery.AddContact(secondaryDigits, null, newCustomerId);
                }

                // ============================
                //   RESULT MESSAGES
                // ============================

                if (!primaryContactAdded)
                {
                    MessageBox.Show("Customer saved but adding primary contact failed.",
                                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!secondaryContactAdded)
                {
                    MessageBox.Show("Customer and primary contact added, "
                                    + "but adding secondary contact failed.",
                                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Customer and contact(s) added successfully.",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // ============================
                //   CLEAR FIELDS
                // ============================
                NamebOx.Clear();
                addressBox.Clear();
                LicenseBox.Clear();
                PhoneNoBox.Clear();
                secondaryPhoneNo.Clear();
                EmailBox.Clear();
                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addPictureButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


