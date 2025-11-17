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

            // ❌ we no longer need to force 5-per-row using SizeChanged
            // this.flowLayoutPanel1.SizeChanged += flowLayoutPanel1_SizeChanged;
        }

        private void VehicleControl_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.WrapContents = true;

            // ❌ REMOVE THESE — they break the layout
            // int cardSpace = (190 + 20);
            // flowLayoutPanel1.MaximumSize = new Size(cardSpace * 5 + 20, 9999);
            // flowLayoutPanel1.MinimumSize = new Size(cardSpace * 5 + 20, 0);

            // ✔ FIX: Just anchor the flow panel
            flowLayoutPanel1.Dock = DockStyle.None;
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            LoadVehicleCards();
        }

        // ❌ No need to force a fixed width any more – remove or leave empty
        private void flowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            // Intentionally left blank
        }

        // Load all vehicles and create one "card" per car
        private void LoadVehicleCards()
        {
            flowLayoutPanel1.Controls.Clear();

            // now loads ALL vehicles, not just available ones
            DataTable dt = dbQuery.GetAllVehiclesForGallery();

            foreach (DataRow row in dt.Rows)
            {
                Panel card = CreateVehicleCard(row);
                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private Panel CreateVehicleCard(DataRow row)
        {
            string brand = row["brand"]?.ToString();
            string model = row["model"]?.ToString();

            // === OUTER CARD ===
            var card = new Panel
            {
                Width = 280,    // ⭐ slightly wider for nicer spacing
                Height = 340,
                Margin = new Padding(40),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Tag = row["vehicleID"]
            };

            // === IMAGE BOX (square, like your design) ===
            var pic = new PictureBox
            {
                Dock = DockStyle.Top,
                Height = 275,   // ⭐ image ~260x260 inside card
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

            // === CAR NAME ===
            var lblTitle = new Label
            {
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Height = 30,
                Text = $"{brand} {model}"
            };

            // stack: title above image or image above title?
            // if you want title on TOP (like your screenshot), add in this order:
            card.Controls.Add(pic);
            card.Controls.Add(lblTitle);

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
        }

        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
    }
}
