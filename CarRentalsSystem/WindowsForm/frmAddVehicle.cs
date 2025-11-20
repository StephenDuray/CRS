using CarRentalsSystem.Database;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CarRentalsSystem.WindowsForm
{
    public partial class frmAddVehicle : Form
    {
        // will hold the image bytes to send to DB
        private byte[] _vehicleImageBytes;

        public frmAddVehicle()
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



        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        //=============================
        //   LOAD FORM (Rounded CornERS)
        //=============================
        private void frmAddVehicle_Load(object sender, EventArgs e)
        {
            int radius = 50;

            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            this.Region = new Region(path);
        }

        //=============================
        //   IMAGE UPLOAD SYSTEM
        //=============================

        // helper: convert Image -> byte[]
        private byte[] ImageToByteArray(Image image)
        {
            if (image == null) return null;

            // 1. Resize to a maximum size (e.g., 800x600)
            const int maxWidth = 800;
            const int maxHeight = 600;

            double ratioX = (double)maxWidth / image.Width;
            double ratioY = (double)maxHeight / image.Height;
            double ratio = Math.Min(ratioX, ratioY);

            int newWidth = (int)(image.Width * ratio);
            int newHeight = (int)(image.Height * ratio);

            using (var resized = new Bitmap(newWidth, newHeight))
            {
                using (var g = Graphics.FromImage(resized))
                {
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    g.DrawImage(image, 0, 0, newWidth, newHeight);
                }

                using (var ms = new MemoryStream())
                {
                    // 2. Save as JPEG with quality 70 (compressed)
                    ImageCodecInfo jpegCodec = ImageCodecInfo
                        .GetImageEncoders()
                        .First(c => c.FormatID == ImageFormat.Jpeg.Guid);

                    var encoder = System.Drawing.Imaging.Encoder.Quality;
                    var encParams = new EncoderParameters(1);
                    encParams.Param[0] = new EncoderParameter(encoder, 70L); // 70% quality

                    resized.Save(ms, jpegCodec, encParams);
                    return ms.ToArray();
                }
            }
        }

        // Load image into PANEL (fills whole dashed rectangle)
        private void LoadVehicleImageToPanel(Panel targetPanel)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                dialog.Title = "Select Vehicle Image";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Image img = Image.FromFile(dialog.FileName);

                        // Show image in panel
                        targetPanel.BackgroundImage = img;
                        targetPanel.BackgroundImageLayout = ImageLayout.Stretch;

                        // store image bytes for DB
                        _vehicleImageBytes = ImageToByteArray(img);

                        // Hide placeholder UI
                        pictureBox2.Hide();
                        label3.Hide();
                        label4.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message,
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No image selected.", "Warning",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // Clicking the preview PictureBox opens the dialog
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // guna2Panel1 = your big dashed panel
            LoadVehicleImageToPanel(guna2Panel1);
        }

        //=============================
        //  INPUT VALIDATION HELPERS
        //=============================

        private void DigitsOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void LetterOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;

            char c = e.KeyChar;
            if (!(char.IsLetter(c) || c == ' ' || c == '-' || c == '\''))
                e.Handled = true;
        }

        //=============================
        //  ADD VEHICLE BUTTON
        //=============================

        private void button1_Click(object sender, EventArgs e)
        {
            string brand = BrandBox.Text.Trim();
            string model = ModelBox.Text.Trim();
            string vehicleType = comboBox1.SelectedItem != null ? comboBox1.SelectedItem.ToString(): string.Empty;
            string plateNo = platenoBox.Text.Trim();

            // better to use Text or SelectedItem instead of SelectedText
            string status = StatusBox.SelectedItem != null
                                ? StatusBox.SelectedItem.ToString()
                                : StatusBox.Text.Trim();

            string color = ColorBox.Text.Trim();
            string mileageText = MileageBox.Text.Trim();
            string dailyRateText = DailyRateBox.Text.Trim();

            // Validation
            if (string.IsNullOrWhiteSpace(brand) ||
                string.IsNullOrWhiteSpace(model) ||
                string.IsNullOrWhiteSpace(vehicleType))
            {
                MessageBox.Show("Please fill in at least brand, model, and car type.",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(dailyRateText,
                                 System.Globalization.NumberStyles.AllowDecimalPoint,
                                 System.Globalization.CultureInfo.InvariantCulture,
                                 out double dailyRate))
            {
                MessageBox.Show("Enter a valid daily rate.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(mileageText, out int currentMileage))
            {
                MessageBox.Show("Enter a valid mileage.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Optionally require an image:
            // if (_vehicleImageBytes == null)
            // {
            //     MessageBox.Show("Please upload a vehicle image.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //     return;
            // }

            // Insert into DB (now includes image)
            bool added = dbQuery.AddVehicle(
                 brand,
                 model,
                 vehicleType,
                 status,
                 color,              // 5th = color
                 dailyRate,          // 6th = dailyRate
                 currentMileage,     // 7th = currentMileage
                 _vehicleImageBytes, // 8th = vehicleImage
                 plateNo             // 9th = plateNo
             );


            if (added)
            {
                MessageBox.Show("Vehicle added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                BrandBox.Clear();
                ModelBox.Clear();
                comboBox1.SelectedIndex = -1;
                StatusBox.SelectedIndex = -1;
                ColorBox.Clear();
                DailyRateBox.Clear();
                MileageBox.Clear();
                platenoBox.Clear();

                guna2Panel1.BackgroundImage = null;
                _vehicleImageBytes = null;

                pictureBox2.Show();
                label3.Show();
                label4.Show();
            }
            else
            {
                MessageBox.Show("Failed to add vehicle.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // In case designer is wired to button1_Click_1, forward it:
        private void button1_Click_1(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void addPictureButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
