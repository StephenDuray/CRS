namespace CarRentalsSystem.WindowsForm
{
    partial class frmAddContract
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.CustomerIDBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.PolicyBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.actual = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.bookdate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.expected = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.addPictureButton = new Guna.UI2.WinForms.Guna2GradientButton();
            this.button1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.CustomerNameBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.UserBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(164, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 32);
            this.label2.TabIndex = 45;
            this.label2.Text = "Add Contract";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BorderRadius = 10;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(440, 14);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 39);
            this.guna2ControlBox1.TabIndex = 47;
            // 
            // CustomerIDBox
            // 
            this.CustomerIDBox.BorderRadius = 5;
            this.CustomerIDBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CustomerIDBox.DefaultText = "";
            this.CustomerIDBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.CustomerIDBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.CustomerIDBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CustomerIDBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CustomerIDBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CustomerIDBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CustomerIDBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CustomerIDBox.Location = new System.Drawing.Point(27, 93);
            this.CustomerIDBox.Name = "CustomerIDBox";
            this.CustomerIDBox.PlaceholderText = "Customer ID";
            this.CustomerIDBox.SelectedText = "";
            this.CustomerIDBox.Size = new System.Drawing.Size(214, 36);
            this.CustomerIDBox.TabIndex = 48;
            this.CustomerIDBox.TextChanged += new System.EventHandler(this.guna2TextBox2_TextChanged);
            // 
            // PolicyBox
            // 
            this.PolicyBox.BackColor = System.Drawing.Color.Transparent;
            this.PolicyBox.BorderRadius = 5;
            this.PolicyBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.PolicyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PolicyBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PolicyBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PolicyBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.PolicyBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.PolicyBox.ItemHeight = 30;
            this.PolicyBox.Items.AddRange(new object[] {
            "Policy ID"});
            this.PolicyBox.Location = new System.Drawing.Point(27, 153);
            this.PolicyBox.Name = "PolicyBox";
            this.PolicyBox.Size = new System.Drawing.Size(214, 36);
            this.PolicyBox.StartIndex = 0;
            this.PolicyBox.TabIndex = 50;
            this.PolicyBox.SelectedIndexChanged += new System.EventHandler(this.guna2ComboBox1_SelectedIndexChanged);
            // 
            // actual
            // 
            this.actual.BorderRadius = 5;
            this.actual.Checked = true;
            this.actual.FillColor = System.Drawing.Color.White;
            this.actual.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.actual.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.actual.Location = new System.Drawing.Point(27, 319);
            this.actual.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.actual.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.actual.Name = "actual";
            this.actual.Size = new System.Drawing.Size(214, 36);
            this.actual.TabIndex = 51;
            this.actual.Value = new System.DateTime(2025, 11, 15, 12, 42, 6, 346);
            this.actual.ValueChanged += new System.EventHandler(this.guna2DateTimePicker1_ValueChanged);
            // 
            // bookdate
            // 
            this.bookdate.BorderRadius = 5;
            this.bookdate.Checked = true;
            this.bookdate.FillColor = System.Drawing.Color.White;
            this.bookdate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bookdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.bookdate.Location = new System.Drawing.Point(260, 237);
            this.bookdate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.bookdate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.bookdate.Name = "bookdate";
            this.bookdate.Size = new System.Drawing.Size(214, 36);
            this.bookdate.TabIndex = 52;
            this.bookdate.Value = new System.DateTime(2025, 11, 15, 12, 42, 6, 346);
            this.bookdate.ValueChanged += new System.EventHandler(this.guna2DateTimePicker2_ValueChanged);
            // 
            // expected
            // 
            this.expected.BorderRadius = 5;
            this.expected.Checked = true;
            this.expected.FillColor = System.Drawing.Color.White;
            this.expected.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.expected.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.expected.Location = new System.Drawing.Point(27, 237);
            this.expected.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.expected.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.expected.Name = "expected";
            this.expected.Size = new System.Drawing.Size(220, 36);
            this.expected.TabIndex = 53;
            this.expected.Value = new System.DateTime(2025, 11, 15, 12, 42, 6, 346);
            this.expected.ValueChanged += new System.EventHandler(this.guna2DateTimePicker3_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(257, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 54;
            this.label1.Text = "Booking Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(24, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 17);
            this.label3.TabIndex = 55;
            this.label3.Text = "Expected Return Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(24, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 17);
            this.label4.TabIndex = 56;
            this.label4.Text = "Actual Return Date (optional)";
            // 
            // addPictureButton
            // 
            this.addPictureButton.Animated = true;
            this.addPictureButton.BackColor = System.Drawing.Color.Transparent;
            this.addPictureButton.BorderRadius = 5;
            this.addPictureButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addPictureButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addPictureButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addPictureButton.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addPictureButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addPictureButton.FillColor = System.Drawing.Color.White;
            this.addPictureButton.FillColor2 = System.Drawing.Color.White;
            this.addPictureButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.addPictureButton.ForeColor = System.Drawing.Color.Black;
            this.addPictureButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(58)))), ((int)(((byte)(130)))));
            this.addPictureButton.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(58)))), ((int)(((byte)(130)))));
            this.addPictureButton.HoverState.ForeColor = System.Drawing.Color.White;
            this.addPictureButton.Location = new System.Drawing.Point(260, 384);
            this.addPictureButton.Margin = new System.Windows.Forms.Padding(2);
            this.addPictureButton.Name = "addPictureButton";
            this.addPictureButton.Size = new System.Drawing.Size(92, 41);
            this.addPictureButton.TabIndex = 101;
            this.addPictureButton.Text = "Cancel";
            this.addPictureButton.Click += new System.EventHandler(this.addPictureButton_Click);
            // 
            // button1
            // 
            this.button1.Animated = true;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BorderRadius = 5;
            this.button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(12)))), ((int)(((byte)(28)))));
            this.button1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(12)))), ((int)(((byte)(28)))));
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(58)))), ((int)(((byte)(130)))));
            this.button1.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(58)))), ((int)(((byte)(130)))));
            this.button1.HoverState.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(364, 384);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 41);
            this.button1.TabIndex = 100;
            this.button1.Text = "Add";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CustomerNameBox
            // 
            this.CustomerNameBox.BorderRadius = 5;
            this.CustomerNameBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CustomerNameBox.DefaultText = "";
            this.CustomerNameBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.CustomerNameBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.CustomerNameBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CustomerNameBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.CustomerNameBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CustomerNameBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CustomerNameBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CustomerNameBox.Location = new System.Drawing.Point(260, 93);
            this.CustomerNameBox.Name = "CustomerNameBox";
            this.CustomerNameBox.PlaceholderText = "Customer Name";
            this.CustomerNameBox.SelectedText = "";
            this.CustomerNameBox.Size = new System.Drawing.Size(214, 36);
            this.CustomerNameBox.TabIndex = 102;
            this.CustomerNameBox.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged_1);
            // 
            // UserBox
            // 
            this.UserBox.BackColor = System.Drawing.Color.Transparent;
            this.UserBox.BorderRadius = 5;
            this.UserBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.UserBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UserBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.UserBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.UserBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.UserBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.UserBox.ItemHeight = 30;
            this.UserBox.Items.AddRange(new object[] {
            "Admin Name"});
            this.UserBox.Location = new System.Drawing.Point(260, 153);
            this.UserBox.Name = "UserBox";
            this.UserBox.Size = new System.Drawing.Size(214, 36);
            this.UserBox.StartIndex = 0;
            this.UserBox.TabIndex = 103;
            this.UserBox.SelectedIndexChanged += new System.EventHandler(this.guna2ComboBox2_SelectedIndexChanged);
            // 
            // frmAddContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(502, 448);
            this.Controls.Add(this.UserBox);
            this.Controls.Add(this.CustomerNameBox);
            this.Controls.Add(this.addPictureButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.expected);
            this.Controls.Add(this.bookdate);
            this.Controls.Add(this.actual);
            this.Controls.Add(this.PolicyBox);
            this.Controls.Add(this.CustomerIDBox);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddContract";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddContract";
            this.Load += new System.EventHandler(this.frmAddContract_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2TextBox CustomerIDBox;
        private Guna.UI2.WinForms.Guna2ComboBox PolicyBox;
        private Guna.UI2.WinForms.Guna2DateTimePicker actual;
        private Guna.UI2.WinForms.Guna2DateTimePicker bookdate;
        private Guna.UI2.WinForms.Guna2DateTimePicker expected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2GradientButton addPictureButton;
        private Guna.UI2.WinForms.Guna2GradientButton button1;
        private Guna.UI2.WinForms.Guna2TextBox CustomerNameBox;
        private Guna.UI2.WinForms.Guna2ComboBox UserBox;
    }
}