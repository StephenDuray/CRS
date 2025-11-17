using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRentalsSystem.Database;

namespace CarRentalsSystem.Control
{
    public partial class AddVehicleControl : UserControl
    {
       
        public AddVehicleControl()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            openFileDialog.Title = "Select Image";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                MessageBox.Show("No image selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        public AddVehicleControl(frmAdd parent)
        {
            InitializeComponent();
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Color leftColor = Color.FromArgb(2, 12, 32);    // dark navy blue
            Color rightColor = Color.FromArgb(8, 45, 120);  // lighter blue

            // Create a linear gradient brush for the background
            using (System.Drawing.Drawing2D.LinearGradientBrush brush =
                new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle, leftColor, rightColor, 0f))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            //string brand = BrandBox.Text.Trim();
            //string model = ModelBox.Text.Trim();
            //// This line caused the NullReferenceException if nothing was selected
            //string cartype = comboBox1.SelectedItem?.ToString() ?? string.Empty; // Safely get selected item

            //string status = StatusBox.SelectedText.Trim();
            //string color = ColorBox.Text.Trim();
            //string mileageText = MileageBox.Text.Trim();
            //string dailyRateText = DailyRateBox.Text.Trim();

            //// Add validation for cartype
            //if (string.IsNullOrWhiteSpace(brand) || string.IsNullOrWhiteSpace(model) || string.IsNullOrWhiteSpace(cartype))
            //{
            //    MessageBox.Show("Please fill in at least brand, model, and select a car type.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (!double.TryParse(dailyRateText, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out double dailyRate))
            //{
            //    MessageBox.Show("Please enter a valid daily rate (numeric).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (!int.TryParse(mileageText, out int currentMileage))
            //{
            //    MessageBox.Show("Please enter a valid current mileage (integer).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //bool added = Database.dbConnection.AddVehicle(brand, model, cartype, status, color, dailyRate, currentMileage);
            //if (added)
            //{
            //    MessageBox.Show("Vehicle added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    BrandBox.Clear();
            //    ModelBox.Clear();
            //    comboBox1.SelectedIndex = -1;
            //    StatusBox.Clear();
            //    ColorBox.Clear();
            //    DailyRateBox.Clear();
            //    MileageBox.Clear();
            //    pictureBox1.Image = null;
            //}
            //else
            //{
            //    MessageBox.Show("Failed to add vehicle.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //string brand = BrandBox.Text.Trim();
            //string model = ModelBox.Text.Trim();
            //string cartype = comboBox1.SelectedItem != null ? comboBox1.SelectedItem.ToString() : string.Empty;

            //string status = StatusBox.SelectedText.Trim();
            //string color = ColorBox.Text.Trim();
            //string mileageText = MileageBox.Text.Trim();
            //string dailyRateText = DailyRateBox.Text.Trim();

            //// Add validation for cartype
            //if (string.IsNullOrWhiteSpace(brand) || string.IsNullOrWhiteSpace(model) || string.IsNullOrWhiteSpace(cartype))
            //{
            //    MessageBox.Show("Please fill in at least brand, model, and select a car type.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (!double.TryParse(dailyRateText, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out double dailyRate))
            //{
            //    MessageBox.Show("Please enter a valid daily rate (numeric).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (!int.TryParse(mileageText, out int currentMileage))
            //{
            //    MessageBox.Show("Please enter a valid current mileage (integer).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //bool added = dbQuery.AddVehicle(brand, model, cartype, status, color, dailyRate, currentMileage);
            //if (added)
            //{
            //    MessageBox.Show("Vehicle added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    BrandBox.Clear();
            //    ModelBox.Clear();
            //    comboBox1.SelectedIndex = -1;
            //    StatusBox.Clear();
            //    ColorBox.Clear();
            //    DailyRateBox.Clear();
            //    MileageBox.Clear();
            //    pictureBox1.Image = null;
            //}
            //else
            //{
            //    MessageBox.Show("Failed to add vehicle.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }
//        private byte[] ImageToByteArray(Image image)
//{
//    using (MemoryStream ms = new MemoryStream())
//    {
//        image.Save(ms, image.RawFormat);
//        return ms.ToArray();
//    }
//}

        private void PhoneNoBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            throw new NotImplementedException();
        }

        // frmAdd.cs
        private void DigitsOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void LetterOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            char c = e.KeyChar;
            if (!(char.IsLetter(c) || c == ' ' || c == '-' || c == '\''))
            {
                e.Handled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }

}