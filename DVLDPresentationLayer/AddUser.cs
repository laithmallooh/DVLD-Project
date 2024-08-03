using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLDPresentationLayer.AddPerson;


namespace DVLDPresentationLayer
{
    public partial class AddUser : Form
    {

        private ErrorProvider errorProvider1;
        private clsUser currentUser;

        public AddUser()
        {
            InitializeComponent();
            currentUser = new clsUser();

            errorProvider1 = new ErrorProvider();

            // Set PasswordChar for password fields
            PasswordInput.PasswordChar = '*';
            ConfirmPasswordInput.PasswordChar = '*';

            // Connect events
            UserNameInput.TextChanged += UserNameInput_TextChanged;
            PasswordInput.TextChanged += PasswordInput_TextChanged;
            ConfirmPasswordInput.TextChanged += ConfirmPasswordInput_TextChanged;
            SaveButton.Click += SaveButton_Click;
            NextButton.Click += NextButton_Click;

            // Subscribe to the PersonSelectedChanged event
            ctrlPersonCardWithFilter1.PersonSelectedChanged += ctrlPersonCardWithFilter1_PersonSelectedChanged;

            // Initialize button state
            UpdateNextButtonState();
        }



        private void ctrlPersonCardWithFilter1_Load(object sender, EventArgs e)
        {
            // Code for control load event, if needed
        }



        private void UpdateNextButtonState()
        {
            bool personSelected = ctrlPersonCardWithFilter1.IsPersonSelected;
            bool personFound = ctrlPersonCardWithFilter1.IsPersonFound;

            MessageBox.Show($"UpdateNextButtonState: Person Selected = {personSelected}, Person Found = {personFound}");

            // Enable or disable the Next button based on both conditions
            //NextButton.Enabled = personSelected && personFound;
            NextButton.Enabled =  personFound;

        }



        private void NextButton_Click(object sender, EventArgs e)
        {
            // Ensure the TabControl has at least 2 tabs
            if (tabControl1.TabPages.Count > 1)
            {
                // Switch to the second tab (index 1)
                tabControl1.SelectedIndex = 1;
            }
        }

        // Event handler for when person selection changes
        private void ctrlPersonCardWithFilter1_PersonSelectedChanged(object sender, EventArgs e)
        {
            UpdateNextButtonState();
            MessageBox.Show("Person selection changed."); // Debugging message
        }


        private bool IsPersonSelected
        {
            get
            {
                return ctrlPersonCardWithFilter1.IsPersonSelected;
            }
        }





        private void label1_Click(object sender, EventArgs e)
        {
            // Code for label1 click event, if needed
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
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
            bool passwordsMatch = PasswordInput.Text == ConfirmPasswordInput.Text;
            bool passwordLengthValid = PasswordInput.Text.Length >= 4;

            if (!passwordsMatch)
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

            if (!passwordLengthValid)
            {
                errorProvider1.SetError(PasswordInput, "Password must be at least 4 characters long.");
                PasswordInput.BackColor = Color.LightCoral;
            }
            else if (passwordsMatch) // Clear error if both checks pass
            {
                errorProvider1.SetError(PasswordInput, "");
                PasswordInput.BackColor = Color.White;
            }
        }




        // Save button click event handler
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                // Ensure all necessary fields are validated before saving
                SaveUser();
            }
            else
            {
                MessageBox.Show("Please fill in all required fields with valid data.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //this.Close();
        }

        private void SaveUser()
        {
            MessageBox.Show("Saving user. Username: " + UserNameInput.Text);

            // Get the selected person ID from ctrlPersonCardWithFilter
            int? selectedPersonId = ctrlPersonCardWithFilter1.SelectedPersonId;

            if (selectedPersonId.HasValue)
            {
                // Use the selected person ID
                currentUser.UserName = UserNameInput.Text;
                currentUser.Password = PasswordInput.Text;
                currentUser.IsActive = IsActiveCheckBox.Checked;
                currentUser.PersonID = selectedPersonId.Value;

                if (ValidateInput())
                {
                    try
                    {
                        bool result = currentUser.Save();
                        MessageBox.Show("Save result: " + result);

                        if (result)
                        {
                            MessageBox.Show("User saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Display user ID in UserIDLabel
                            UserIDLabel.Text = $"{currentUser.UserID}";

                           // ClearForm();
                        }
                        else
                        {
                            MessageBox.Show("Failed to save the user. Please check your input and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No person selected. Please select a person before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private bool ValidateInput()
        {
            bool isValid = true;

            MessageBox.Show("Validating input. Username: " + UserNameInput.Text);

            if (string.IsNullOrWhiteSpace(UserNameInput.Text))
            {
                MessageBox.Show("Username is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(PasswordInput.Text))
            {
                MessageBox.Show("Password is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isValid = false;
            }

            if (PasswordInput.Text.Length < 4)
            {
                MessageBox.Show("Password must be at least 4 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isValid = false;
            }

            return isValid;
        }








        private void ClearForm()
        {
            // txtPersonID.Clear();
            // txtFullName.Clear();
            UserNameInput.Clear();
            PasswordInput.Clear();
            IsActiveCheckBox.Checked = false;

            currentUser = new clsUser(); // Reset to a new user
        }




        private void LoginInfo_Click(object sender, EventArgs e)
        {
            // Code for login info click event, if needed
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Code for textBox2 text change event, if needed
        }

     


        private void SaveButton_Click_1(object sender, EventArgs e)
        {

        }

       
    }
}
