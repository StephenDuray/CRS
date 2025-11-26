using CarRentalsSystem.Database;
using CarRentalsSystem.WindowsForm;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CarRentalsSystem.Control
{
    public partial class VehicleControl : UserControl
    {
        public VehicleControl()
        {
            InitializeComponent();
            this.Load += VehicleControl_Load;
        }

        private void VehicleControl_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.WrapContents = true;

            flowLayoutPanel1.Dock = DockStyle.None;
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            RefreshVehicles();   // load on first time
        }

        // 👉 Call this anytime you want to reload vehicles & statuses
        public void RefreshVehicles()
        {
            LoadVehicleCards();
        }

        private void flowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            // Intentionally left blank
        }

        // Load all vehicles and create one "card" per car
        private void LoadVehicleCards()
        {
            flowLayoutPanel1.Controls.Clear();

            DataTable dt = dbQuery.GetAllVehiclesForGallery();

            foreach (DataRow row in dt.Rows)
            {
                Panel card = CreateVehicleCard(row);
                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private Panel CreateVehicleCard(DataRow row)
        {
            // read data safely
            string brand = row["brand"]?.ToString();
            string model = row["model"]?.ToString();
            string vehicleType = row.Table.Columns.Contains("vehicleType") ? row["vehicleType"]?.ToString() : "";
            string plateNo = row.Table.Columns.Contains("plateNo") ? row["plateNo"]?.ToString() : "";
            string color = row.Table.Columns.Contains("color") ? row["color"]?.ToString() : "";
            string status = row.Table.Columns.Contains("status") ? row["status"]?.ToString() : "";

            decimal dailyRate = 0m;
            if (row.Table.Columns.Contains("dailyRate") && row["dailyRate"] != DBNull.Value)
                dailyRate = Convert.ToDecimal(row["dailyRate"]);

            // === OUTER CARD ===
            var card = new Panel
            {
                Width = 280,
                Height = 360,
                Margin = new Padding(40),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Tag = row["vehicleID"]
            };

            // === IMAGE BOX ===
            var pic = new PictureBox
            {
                Dock = DockStyle.Top,
                Height = 210,   // leave more room for text
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.LightGray
            };

            if (row["vehicleImage"] != DBNull.Value)
            {
                byte[] bytes = (byte[])row["vehicleImage"];
                using (var ms = new MemoryStream(bytes))
                {
                    pic.Image = Image.FromStream(ms);
                }
            }

            // === INFO PANEL (bottom part of the card) ===
            var infoPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(6)
            };

            // Title: Brand + Model
            var lblTitle = new Label
            {
                AutoSize = false,
                Dock = DockStyle.Top,
                Height = 24,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Text = $"{brand} {model}"
            };

            // Line: Type • Color
            var lblTypeColor = new Label
            {
                AutoSize = false,
                Dock = DockStyle.Top,
                Height = 20,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                ForeColor = Color.DimGray,
                Text = $"{vehicleType} • {color}"
            };

            // Line: Plate
            var lblPlate = new Label
            {
                AutoSize = false,
                Dock = DockStyle.Top,
                Height = 20,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                Text = string.IsNullOrWhiteSpace(plateNo) ? "Plate: (N/A)" : $"Plate: {plateNo}"
            };

            // Line: Rate
            var lblRate = new Label
            {
                AutoSize = false,
                Dock = DockStyle.Top,
                Height = 20,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                ForeColor = Color.FromArgb(0, 120, 215),
                Text = dailyRate > 0m ? $"₱ {dailyRate:0.00} / day" : "₱ 0.00 / day"
            };

            // Status line at the bottom
            var lblStatus = new Label
            {
                AutoSize = false,
                Dock = DockStyle.Bottom,
                Height = 20,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Text = string.IsNullOrWhiteSpace(status) ? "Unknown" : status
            };

            // status color (Available / Rented / etc.)
            if (status.Equals("Available", StringComparison.OrdinalIgnoreCase))
                lblStatus.ForeColor = Color.Green;
            else if (status.Equals("Rented", StringComparison.OrdinalIgnoreCase))
                lblStatus.ForeColor = Color.Red;
            else
                lblStatus.ForeColor = Color.DarkOrange;

            // add info controls (order matters)
            infoPanel.Controls.Add(lblRate);
            infoPanel.Controls.Add(lblPlate);
            infoPanel.Controls.Add(lblTypeColor);
            infoPanel.Controls.Add(lblTitle);
            infoPanel.Controls.Add(lblStatus); // Dock.Bottom keeps it at bottom

            // add to card
            card.Controls.Add(infoPanel);
            card.Controls.Add(pic);

            return card;
        }

        // ADD VEHICLE BUTTON
        private void button1_Click(object sender, EventArgs e)
        {
            using (var frmAddVehicle = new frmAddVehicle())
            {
                var owner = this.FindForm();
                frmAddVehicle.ShowDialog(owner);
            }

            // reload cards after adding a vehicle
            RefreshVehicles();
        }

        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
    }
}
