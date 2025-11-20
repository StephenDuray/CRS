namespace CarRentalsSystem.WindowsForm
{
    partial class frmAddVehicle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddVehicle));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.addPictureButton = new Guna.UI2.WinForms.Guna2GradientButton();
            this.button1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.label1 = new System.Windows.Forms.Label();
            this.StatusBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.DailyRateBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.MileageBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.comboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.ColorBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.BrandBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.ModelBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.plateNolabel = new System.Windows.Forms.Label();
            this.platenoBox = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.CustomIconSize = 15F;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(612, 15);
            this.guna2ControlBox1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(60, 36);
            this.guna2ControlBox1.TabIndex = 100;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(253, 39);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(76, 62);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 84;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(213, 137);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 23);
            this.label4.TabIndex = 83;
            this.label4.Text = "PNG,JPG up to 5MB";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(175, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 25);
            this.label3.TabIndex = 82;
            this.label3.Text = "Click or Drag Image Here";
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
            this.addPictureButton.Location = new System.Drawing.Point(352, 777);
            this.addPictureButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addPictureButton.Name = "addPictureButton";
            this.addPictureButton.Size = new System.Drawing.Size(123, 50);
            this.addPictureButton.TabIndex = 99;
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
            this.button1.Location = new System.Drawing.Point(491, 777);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 50);
            this.button1.TabIndex = 98;
            this.button1.Text = "Add";
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(43, 482);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 28);
            this.label1.TabIndex = 97;
            this.label1.Text = "Upload Vehicle Image";
            // 
            // StatusBox
            // 
            this.StatusBox.BackColor = System.Drawing.Color.Transparent;
            this.StatusBox.BorderRadius = 5;
            this.StatusBox.BorderThickness = 2;
            this.StatusBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.StatusBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StatusBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.StatusBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.StatusBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.StatusBox.ForeColor = System.Drawing.Color.Gray;
            this.StatusBox.ItemHeight = 30;
            this.StatusBox.Items.AddRange(new object[] {
            "Available",
            "Rented",
            "Maintenance"});
            this.StatusBox.Location = new System.Drawing.Point(48, 416);
            this.StatusBox.Margin = new System.Windows.Forms.Padding(4);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(283, 36);
            this.StatusBox.StartIndex = 0;
            this.StatusBox.TabIndex = 96;
            // 
            // DailyRateBox
            // 
            this.DailyRateBox.BackColor = System.Drawing.Color.Transparent;
            this.DailyRateBox.BorderColor = System.Drawing.Color.Gray;
            this.DailyRateBox.BorderRadius = 5;
            this.DailyRateBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.DailyRateBox.DefaultText = "";
            this.DailyRateBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.DailyRateBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.DailyRateBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.DailyRateBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.DailyRateBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.DailyRateBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DailyRateBox.ForeColor = System.Drawing.Color.Black;
            this.DailyRateBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.DailyRateBox.HoverState.ForeColor = System.Drawing.Color.Black;
            this.DailyRateBox.Location = new System.Drawing.Point(356, 324);
            this.DailyRateBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DailyRateBox.Name = "DailyRateBox";
            this.DailyRateBox.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.DailyRateBox.PlaceholderText = "Enter a daily rate";
            this.DailyRateBox.SelectedText = "";
            this.DailyRateBox.Size = new System.Drawing.Size(284, 44);
            this.DailyRateBox.TabIndex = 95;
            // 
            // MileageBox
            // 
            this.MileageBox.BackColor = System.Drawing.Color.Transparent;
            this.MileageBox.BorderColor = System.Drawing.Color.Gray;
            this.MileageBox.BorderRadius = 5;
            this.MileageBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.MileageBox.DefaultText = "";
            this.MileageBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.MileageBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.MileageBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.MileageBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.MileageBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.MileageBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MileageBox.ForeColor = System.Drawing.Color.Black;
            this.MileageBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.MileageBox.HoverState.ForeColor = System.Drawing.Color.Black;
            this.MileageBox.Location = new System.Drawing.Point(48, 324);
            this.MileageBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MileageBox.Name = "MileageBox";
            this.MileageBox.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.MileageBox.PlaceholderText = "Enter a mileage";
            this.MileageBox.SelectedText = "";
            this.MileageBox.Size = new System.Drawing.Size(284, 44);
            this.MileageBox.TabIndex = 94;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.Transparent;
            this.comboBox1.BorderColor = System.Drawing.Color.Gray;
            this.comboBox1.BorderRadius = 5;
            this.comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBox1.ForeColor = System.Drawing.Color.Gray;
            this.comboBox1.ItemHeight = 30;
            this.comboBox1.Items.AddRange(new object[] {
            "SUV",
            "Hatchback",
            "Convertible",
            "Crossover",
            "Sedan",
            "Minivan",
            "\t"});
            this.comboBox1.Location = new System.Drawing.Point(356, 231);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(283, 36);
            this.comboBox1.StartIndex = 0;
            this.comboBox1.TabIndex = 93;
            // 
            // ColorBox
            // 
            this.ColorBox.BackColor = System.Drawing.Color.Transparent;
            this.ColorBox.BorderColor = System.Drawing.Color.Gray;
            this.ColorBox.BorderRadius = 5;
            this.ColorBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ColorBox.DefaultText = "";
            this.ColorBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.ColorBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.ColorBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ColorBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ColorBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ColorBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ColorBox.ForeColor = System.Drawing.Color.Black;
            this.ColorBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ColorBox.HoverState.ForeColor = System.Drawing.Color.Black;
            this.ColorBox.Location = new System.Drawing.Point(48, 231);
            this.ColorBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ColorBox.Name = "ColorBox";
            this.ColorBox.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.ColorBox.PlaceholderText = "Enter a color";
            this.ColorBox.SelectedText = "";
            this.ColorBox.Size = new System.Drawing.Size(284, 44);
            this.ColorBox.TabIndex = 92;
            // 
            // BrandBox
            // 
            this.BrandBox.BackColor = System.Drawing.Color.Transparent;
            this.BrandBox.BorderColor = System.Drawing.Color.Gray;
            this.BrandBox.BorderRadius = 5;
            this.BrandBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.BrandBox.DefaultText = "";
            this.BrandBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.BrandBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.BrandBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.BrandBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.BrandBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.BrandBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BrandBox.ForeColor = System.Drawing.Color.Black;
            this.BrandBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.BrandBox.HoverState.ForeColor = System.Drawing.Color.Black;
            this.BrandBox.Location = new System.Drawing.Point(48, 143);
            this.BrandBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BrandBox.Name = "BrandBox";
            this.BrandBox.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.BrandBox.PlaceholderText = "Enter a brand";
            this.BrandBox.SelectedText = "";
            this.BrandBox.Size = new System.Drawing.Size(284, 44);
            this.BrandBox.TabIndex = 91;
            // 
            // ModelBox
            // 
            this.ModelBox.BackColor = System.Drawing.Color.Transparent;
            this.ModelBox.BorderColor = System.Drawing.Color.Gray;
            this.ModelBox.BorderRadius = 5;
            this.ModelBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ModelBox.DefaultText = "";
            this.ModelBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.ModelBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.ModelBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ModelBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ModelBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ModelBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ModelBox.ForeColor = System.Drawing.Color.Black;
            this.ModelBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ModelBox.HoverState.ForeColor = System.Drawing.Color.Black;
            this.ModelBox.Location = new System.Drawing.Point(356, 143);
            this.ModelBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ModelBox.Name = "ModelBox";
            this.ModelBox.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.ModelBox.PlaceholderText = "Enter a model";
            this.ModelBox.SelectedText = "";
            this.ModelBox.Size = new System.Drawing.Size(284, 44);
            this.ModelBox.TabIndex = 90;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(198, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 41);
            this.label2.TabIndex = 89;
            this.label2.Text = "Add New Vehicle";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(43, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 28);
            this.label9.TabIndex = 81;
            this.label9.Text = "Brand";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(351, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 28);
            this.label10.TabIndex = 82;
            this.label10.Text = "Model";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Navy;
            this.label14.Location = new System.Drawing.Point(351, 288);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(119, 28);
            this.label14.TabIndex = 86;
            this.label14.Text = "DailyRate(₱)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(351, 194);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 28);
            this.label11.TabIndex = 83;
            this.label11.Text = "Cartype";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Navy;
            this.label15.Location = new System.Drawing.Point(43, 288);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(186, 28);
            this.label15.TabIndex = 87;
            this.label15.Text = "CurrentMileage(km)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label12.ForeColor = System.Drawing.Color.Navy;
            this.label12.Location = new System.Drawing.Point(43, 380);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 28);
            this.label12.TabIndex = 84;
            this.label12.Text = "Status";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label13.ForeColor = System.Drawing.Color.Navy;
            this.label13.Location = new System.Drawing.Point(43, 196);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 28);
            this.label13.TabIndex = 85;
            this.label13.Text = "Color";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Gray;
            this.guna2Panel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.guna2Panel1.BorderThickness = 2;
            this.guna2Panel1.Controls.Add(this.pictureBox2);
            this.guna2Panel1.Controls.Add(this.label4);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Location = new System.Drawing.Point(48, 524);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(592, 224);
            this.guna2Panel1.TabIndex = 88;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // plateNolabel
            // 
            this.plateNolabel.AutoSize = true;
            this.plateNolabel.BackColor = System.Drawing.Color.Transparent;
            this.plateNolabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plateNolabel.ForeColor = System.Drawing.Color.Navy;
            this.plateNolabel.Location = new System.Drawing.Point(351, 380);
            this.plateNolabel.Name = "plateNolabel";
            this.plateNolabel.Size = new System.Drawing.Size(91, 28);
            this.plateNolabel.TabIndex = 101;
            this.plateNolabel.Text = "Plate No.";
            // 
            // platenoBox
            // 
            this.platenoBox.BackColor = System.Drawing.Color.Transparent;
            this.platenoBox.BorderColor = System.Drawing.Color.Gray;
            this.platenoBox.BorderRadius = 5;
            this.platenoBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.platenoBox.DefaultText = "";
            this.platenoBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.platenoBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.platenoBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.platenoBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.platenoBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.platenoBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.platenoBox.ForeColor = System.Drawing.Color.Black;
            this.platenoBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.platenoBox.HoverState.ForeColor = System.Drawing.Color.Black;
            this.platenoBox.Location = new System.Drawing.Point(356, 416);
            this.platenoBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.platenoBox.Name = "platenoBox";
            this.platenoBox.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.platenoBox.PlaceholderText = "Enter a daily rate";
            this.platenoBox.SelectedText = "";
            this.platenoBox.Size = new System.Drawing.Size(284, 44);
            this.platenoBox.TabIndex = 102;
            // 
            // frmAddVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(683, 860);
            this.Controls.Add(this.platenoBox);
            this.Controls.Add(this.plateNolabel);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.addPictureButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StatusBox);
            this.Controls.Add(this.DailyRateBox);
            this.Controls.Add(this.MileageBox);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.ColorBox);
            this.Controls.Add(this.BrandBox);
            this.Controls.Add(this.ModelBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmAddVehicle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddVehicle";
            this.Load += new System.EventHandler(this.frmAddVehicle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2GradientButton addPictureButton;
        private Guna.UI2.WinForms.Guna2GradientButton button1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox StatusBox;
        private Guna.UI2.WinForms.Guna2TextBox DailyRateBox;
        private Guna.UI2.WinForms.Guna2TextBox MileageBox;
        private Guna.UI2.WinForms.Guna2ComboBox comboBox1;
        private Guna.UI2.WinForms.Guna2TextBox ColorBox;
        private Guna.UI2.WinForms.Guna2TextBox BrandBox;
        private Guna.UI2.WinForms.Guna2TextBox ModelBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label plateNolabel;
        private Guna.UI2.WinForms.Guna2TextBox platenoBox;
    }
}