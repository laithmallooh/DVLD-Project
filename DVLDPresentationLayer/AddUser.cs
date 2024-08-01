using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDPresentationLayer
{
    public partial class AddUser : Form
    {

        private ErrorProvider errorProvider1;

        public AddUser()
        {
            InitializeComponent();
            errorProvider1 = new ErrorProvider();

            // Connect events
            UserNameInput.TextChanged += UserNameInput_TextChanged;
            PasswordInput.TextChanged += PasswordInput_TextChanged;
            ConfirmPasswordInput.TextChanged += ConfirmPasswordInput_TextChanged;
            SaveButton.Click += SaveButton_Click;
            NextButton.Click += NextButton_Click;
        }





        private void label1_Click(object sender, EventArgs e)
        {
            // Code for label1 click event, if needed
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlPersonCardWithFilter1_Load(object sender, EventArgs e)
        {
            // Code for control load event, if needed
        }

        private void UserNameInput_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UserNameInput.Text))
            {
                errorProvider1.SetError(UserNameInput, "Username cannot be blank.");
                UserNameInput.BackColor = Color.LightCoral;
            }
            else
            {
                errorProvider1.SetError(UserNameInput, "");
                UserNameInput.BackColor = Color.White;
            }
        }

        private void PasswordInput_TextChanged(object sender, EventArgs e)
        {
            ValidatePasswords();
        }

        private void ConfirmPasswordInput_TextChanged(object sender, EventArgs e)
        {
            ValidatePasswords();
        }

        private void ValidatePasswords()
        {
            if (PasswordInput.Text != ConfirmPasswordInput.Text)
            {
                errorProvider1.SetError(PasswordInput, "Passwords do not match.");
                errorProvider1.SetError(ConfirmPasswordInput, "Passwords do not match.");
                PasswordInput.BackColor = Color.LightCoral;
                ConfirmPasswordInput.BackColor = Color.LightCoral;
            }
            else
            {
                errorProvider1.SetError(PasswordInput, "");
                errorProvider1.SetError(ConfirmPasswordInput, "");
                PasswordInput.BackColor = Color.White;
                ConfirmPasswordInput.BackColor = Color.White;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Clear existing errors
            errorProvider1.Clear();

            // Validate inputs
            if (string.IsNullOrWhiteSpace(UserNameInput.Text))
            {
                errorProvider1.SetError(UserNameInput, "Username cannot be blank.");
                return;
            }

            if (PasswordInput.Text != ConfirmPasswordInput.Text)
            {
                errorProvider1.SetError(PasswordInput, "Passwords do not match.");
                errorProvider1.SetError(ConfirmPasswordInput, "Passwords do not match.");
                return;
            }

            // Ensure the TabControl has at least 2 tabs
            if (tabControl1.TabPages.Count > 1)
            {
                // Switch to the second tab (index 1)
                tabControl1.SelectedIndex = 1;
            }
        }



        private void LoginInfo_Click(object sender, EventArgs e)
        {
            // Code for login info click event, if needed
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Code for textBox2 text change event, if needed
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            // Check if a person is selected in ctrlPersonCardWithFilter
            if (!ctrlPersonCardWithFilter1.IsPersonSelected)
            {
                MessageBox.Show("Please find a person before proceeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ensure the TabControl has at least 2 tabs
            if (tabControl1.TabPages.Count > 1)
            {
                // Switch to the second tab (index 1)
                tabControl1.SelectedIndex = 1;
            }
        }
    }
}
