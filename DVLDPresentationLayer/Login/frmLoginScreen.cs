using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBusinessLayer;
using DVLDPresentationLayer.Properties; // Ensure this is included

namespace DVLDPresentationLayer
{
    public partial class frmLoginScreen : Form
    {
        public frmLoginScreen()
        {
            InitializeComponent();
            LoadCredentials();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;
            bool rememberMe = RemembermeCheckBox.Checked;

            clsPerson person = new clsPerson();
            if (person.ValidateUser(username, password))
            {
                if (rememberMe)
                {
                    Settings.Default.Username = username;
                    Settings.Default.Password = password; // Insecure, consider encrypting
                    Settings.Default.RememberMe = true;
                }
                else
                {
                    Settings.Default.Username = string.Empty;
                    Settings.Default.Password = string.Empty;
                    Settings.Default.RememberMe = false;
                }
                Settings.Default.Save();

                // Open the ManagePeople form if the user is valid
                Main MainForm = new Main();
                MainForm.Show();
                this.Hide(); // Optional: hide the login form
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCredentials()
        {
            if (Settings.Default.RememberMe)
            {
                UsernameTextBox.Text = Settings.Default.Username;
                PasswordTextBox.Text = Settings.Default.Password;
                RemembermeCheckBox.Checked = true;
            }
            else
            {
                UsernameTextBox.Text = string.Empty;
                PasswordTextBox.Text = string.Empty;
                RemembermeCheckBox.Checked = false;
            }
        }
    }
}
