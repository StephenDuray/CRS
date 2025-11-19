using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CarRentalsSystem.Database;

namespace CarRentalsSystem.WindowsForm
{
    public partial class frmAssignVehicleAdd : Form
    {
        private DataTable _contractsTable;
        private bool _isBindingContracts = false;   // used to ignore events while loading
        private int? _selectedVehicleId = null;
        private Panel _selectedCardPanel = null;
        private bool _isMileagePolicy = false;


        public frmAssignVehicleAdd()
        {
            InitializeComponent();
            this.Load += frmAssignVehicleAdd_Load;
        }

        // ============ FORM LOAD ============

        private void frmAssignVehicleAdd_Load(object sender, EventArgs e)
        {
            LoadContractsIntoCombo();
            LoadVehicleGallery();

            // On first load, hide mileage-related controls until a contract is chosen
            SetMileageControlsVisible(false);
        }

        // Load contracts from DB into combo box
        private void LoadContractsIntoCombo()
        {
            _isBindingContracts = true;

            DataTable contracts = dbQuery.GetContracts();
            guna2ComboBox1.DataSource = contracts;
            guna2ComboBox1.DisplayMember = "contractID";   // what user sees
            guna2ComboBox1.ValueMember = "contractID";     // what we use in SelectedValue

            guna2ComboBox1.SelectedIndex = -1;

            guna2TextBox1.Clear();  // customer name
            guna2TextBox2.Clear();  // policy name

            _isBindingContracts = false;
        }

        private void LoadVehicleGallery()
        {
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.Controls.Clear();

            DataTable dt = dbQuery.GetAvailableVehiclesForGallery();

            foreach (DataRow row in dt.Rows)
            {
                Panel card = CreateVehicleCard(row);
                flowLayoutPanel1.Controls.Add(card);
            }

            flowLayoutPanel1.ResumeLayout();
        }

        private Panel CreateVehicleCard(DataRow row)
        {
            int vehicleId = Convert.ToInt32(row["vehicleID"]);
            string brand = row["brand"]?.ToString();
            string model = row["model"]?.ToString();
            string vehicleType = row["vehicleType"]?.ToString();
            string color = row["color"]?.ToString();
            string status = row["status"]?.ToString();
            string rateText = row["dailyRate"]?.ToString();

            // 👇 NEW: read currentMileage
            int currentMileage = 0;
            if (row.Table.Columns.Contains("currentMileage") && row["currentMileage"] != DBNull.Value)
                currentMileage = Convert.ToInt32(row["currentMileage"]);

            // === outer card panel ===
            var card = new Panel
            {
                Width = 245,
                Height = 235,
                Margin = new Padding(15),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
            };

            // 👇 NEW: store id & mileage on the panel
            card.Name = vehicleId.ToString();   // for vehicleID
            card.Tag = currentMileage;         // for currentMileage

            // === picture box ===
            var pic = new PictureBox
            {
                Dock = DockStyle.Top,
                Height = 140,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.LightGray
            };

            // load image if present
            if (row["vehicleImage"] != DBNull.Value)
            {
                byte[] bytes = (byte[])row["vehicleImage"];
                using (var ms = new System.IO.MemoryStream(bytes))
                {
                    pic.Image = Image.FromStream(ms);
                }
            }

            // === labels ===
            var lblTitle = new Label
            {
                Dock = DockStyle.Top,
                Height = 22,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Text = $"{brand} {model}"
            };

            var lblType = new Label
            {
                Dock = DockStyle.Top,
                Height = 18,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12F, FontStyle.Regular),
                Text = $"{vehicleType} • {color}"
            };

            var lblRate = new Label
            {
                Dock = DockStyle.Top,
                Height = 18,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12F, FontStyle.Regular),
                ForeColor = Color.FromArgb(0, 120, 215),
                Text = $"₱ {rateText} / day"
            };

            var lblStatus = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 20,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12F, FontStyle.Italic),
                ForeColor = Color.Green,
                Text = status
            };

            card.Controls.Add(lblStatus);
            card.Controls.Add(lblRate);
            card.Controls.Add(lblType);
            card.Controls.Add(lblTitle);
            card.Controls.Add(pic);

            // click anywhere in the card to select
            card.Click += VehicleCard_Click;
            pic.Click += VehicleCard_Click;
            lblTitle.Click += VehicleCard_Click;
            lblType.Click += VehicleCard_Click;
            lblRate.Click += VehicleCard_Click;
            lblStatus.Click += VehicleCard_Click;

            return card;
        }


        private void VehicleCard_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Control ctrl = sender as System.Windows.Forms.Control;
            if (ctrl == null) return;

            Panel card = FindCardPanel(ctrl);
            if (card == null) return;

            // remove highlight
            if (_selectedCardPanel != null)
                _selectedCardPanel.BackColor = Color.White;

            // highlight
            card.BackColor = Color.FromArgb(230, 240, 255);
            _selectedCardPanel = card;

            // 👇 vehicleID taken from Name
            if (int.TryParse(card.Name, out int vid))
                _selectedVehicleId = vid;

            // 👇 auto-fill odometer start (currentMileage) from Tag
            if (card.Tag != null)
            {
                // even if the box is hidden for full-to-full, setting Text is fine
                odometerStarBox.Text = card.Tag.ToString();
            }
        }


        private Panel FindCardPanel(System.Windows.Forms.Control ctrl)
        {
            while (ctrl != null && !(ctrl is Panel && ctrl.Tag != null))
            {
                ctrl = ctrl.Parent;
            }
            return ctrl as Panel;
        }

        // ============ POLICY-BASED UI HELPERS ============

        private void SetMileageControlsVisible(bool visible)
        {
            // labels + textboxes for mileage
            odometerStart.Visible = visible;
            odometerStarBox.Visible = visible;
            mileageAllowance.Visible = visible;
            mileageAllowanceBox.Visible = visible;
        }

        private void ApplyPolicyUI(string policyName)
        {
            //if (string.IsNullOrWhiteSpace(policyName))
            //{
            //    SetMileageControlsVisible(false);
            //    return;
            //}

            //// Simple detection:
            //// If policy name contains "full" => treat as Full-to-Full (no mileage limits)
            //// Otherwise treat as mileage-based policy.
            //bool isFullToFull =
            //    policyName.IndexOf("full", StringComparison.OrdinalIgnoreCase) >= 0;

            //bool isMileagePolicy = !isFullToFull;

            //SetMileageControlsVisible(isMileagePolicy);
            if (string.IsNullOrWhiteSpace(policyName))
            {
                _isMileagePolicy = false;
                SetMileageControlsVisible(false);
                return;
            }

            // Example: "Full to full" → treat as full-to-full
            bool isFullToFull =
                policyName.IndexOf("full", StringComparison.OrdinalIgnoreCase) >= 0;

            _isMileagePolicy = !isFullToFull;

            SetMileageControlsVisible(_isMileagePolicy);
        }

        // ============ EVENTS ============

        // When user picks a contract ID
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isBindingContracts ||
                guna2ComboBox1.SelectedIndex < 0 ||
                guna2ComboBox1.SelectedValue == null)
            {
                guna2TextBox1.Clear();
                guna2TextBox2.Clear();
                SetMileageControlsVisible(false);
                return;
            }

            if (!int.TryParse(guna2ComboBox1.SelectedValue.ToString(), out int contractId))
            {
                guna2TextBox1.Clear();
                guna2TextBox2.Clear();
                SetMileageControlsVisible(false);
                return;
            }

            DataRow row = dbQuery.GetContractBasicInfo(contractId);

            if (row == null)
            {
                guna2TextBox1.Clear();
                guna2TextBox2.Clear();
                SetMileageControlsVisible(false);
                return;
            }

            // fill customer & policy
            guna2TextBox1.Text = row["CustomerName"].ToString();
            string policyName = row["PolicyName"].ToString();
            guna2TextBox2.Text = policyName;

            // apply visibility based on policy
            ApplyPolicyUI(policyName);
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            // no extra logic needed here for now
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            // no extra logic needed here for now
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void assignvehiclebutton_Click(object sender, EventArgs e)
        {
            // 1. Validate contract selection
            if (guna2ComboBox1.SelectedIndex < 0 || guna2ComboBox1.SelectedValue == null)
            {
                MessageBox.Show("Please select a contract ID first.",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(guna2ComboBox1.SelectedValue.ToString(), out int contractId))
            {
                MessageBox.Show("Invalid contract ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Validate vehicle selection
            if (_selectedVehicleId == null)
            {
                MessageBox.Show("Please select a vehicle from the gallery.",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int vehicleId = _selectedVehicleId.Value;

            // 🔥 3. CHECK FOR DUPLICATE BEFORE INSERT
            if (dbQuery.RentedVehicleExists(contractId, vehicleId))
            {
                MessageBox.Show("This vehicle is already assigned to this contract.",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Values depending on policy
            int? odometerStart = null;
            int? mileageAllowance = null;

            if (_isMileagePolicy)
            {
                if (!int.TryParse(odometerStarBox.Text.Trim(), out int odoVal))
                {
                    MessageBox.Show("Please enter a valid starting odometer.",
                                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(mileageAllowanceBox.Text.Trim(), out int allowanceVal))
                {
                    MessageBox.Show("Please enter a valid mileage allowance.",
                                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                odometerStart = odoVal;
                mileageAllowance = allowanceVal;
            }

            // 5. DB INSERT
            // 5. DB INSERT
            bool ok = dbQuery.AddRentedVehicle(
                contractId,
                vehicleId,
                odometerStart,
                mileageAllowance
            );

            if (ok)
            {
                // 🔥 set vehicle status to 'Rented'
                bool statusOk = dbQuery.UpdateVehicleStatus(vehicleId, "Rented");
                if (!statusOk)
                {
                    MessageBox.Show("Vehicle assigned, but failed to update vehicle status.",
                                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                MessageBox.Show("Vehicle successfully assigned to contract.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmPayment frmPayment = new frmPayment();
                frmPayment.ShowDialog();
                this.Close();

                // (these clears are technically not needed after Close(), but ok to leave)
                guna2ComboBox1.SelectedIndex = -1;
                guna2TextBox1.Clear();
                guna2TextBox2.Clear();
                odometerStarBox.Clear();
                mileageAllowanceBox.Clear();
                SetMileageControlsVisible(false);
                _isMileagePolicy = false;

                if (_selectedCardPanel != null)
                {
                    _selectedCardPanel.BackColor = Color.White;
                    _selectedCardPanel = null;
                }

                _selectedVehicleId = null;
            }
        }
    }
}
