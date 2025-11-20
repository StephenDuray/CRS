using CarRentalsSystem.Database;
using CarRentalsSystem.WindowsForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CarRentalsSystem
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += LoginForm_KeyDown;
        }
        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

      
        private void frmLogin_Load(object sender, EventArgs e)
        {
            int radius = 80;

            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            this.Region = new Region(path);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (dbQuery.AuthenticateUser(username, password))
            {
                MessageBox.Show("Log in successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.None);

                // Create dashboard
                frmMainDashboard dashboard = new frmMainDashboard();

                // When dashboard is closed (e.g., user logs out), show login again
                dashboard.FormClosed += (s, args) => this.Show();

                // Hide login and show dashboard (non-modal)
                this.Hide();
                dashboard.Show();
            }
            else
            {
                MessageBox.Show("Incorrect username or password.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
   }

