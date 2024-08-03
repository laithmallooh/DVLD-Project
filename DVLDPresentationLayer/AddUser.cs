using DVLDBusinessLayer;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLDPresentationLayer
{
    public partial class AddUser : Form
    {
        private ErrorProvider errorProvider1;
        private clsUser currentUser;

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

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

        // Constructor for editing an existing person
        public AddUser(clsUser user) : this()
        {
            if (user != null)
            {
                label4.Text = "Edit User";
                Mode = enMode.Update;

                this.currentUser = user;
                LoadUserData();

                // Disable search controls
                DisableSearchControls();
            }
        }

        // Method to disable search controls
        private void DisableSearchControls()
        {
            ctrlPersonCardWithFilter1.Enabled = false; // Assuming ctrlPersonCardWithFilter1 is the search control
            NextButton.Enabled = false; // Disable next button if it navigates the tabs
        }

        // Method to load existing person data into form fields
        private void LoadUserData()
        {
            UserNameInput.Text = currentUser.UserName;
            PasswordInput.Text = currentUser.Password;
            IsActiveCheckBox.Checked = currentUser.IsActive;
        }

        private void UpdateNextButtonState()
        {
            bool personSelected = ctrlPersonCardWithFilter1.IsPersonSelected;
            bool personFound = ctrlPersonCardWithFilter1.IsPersonFound;

            MessageBox.Show($"UpdateNextButtonState: Person Selected = {personSelected}, Person Found = {personFound}");

            NextButton.Enabled = personFound;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count > 1)
            {
                tabControl1.SelectedIndex = 1;
            }
        }

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
            else if (passwordsMatch)
            {
                errorProvider1.SetError(PasswordInput, "");
                PasswordInput.BackColor = Color.White;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                SaveUser();
            }
            else
            {
                MessageBox.Show("Please fill in all required fields with valid data.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SaveUser()
        {
            MessageBox.Show("Saving user. Username: " + UserNameInput.Text);

            int? selectedPersonId = ctrlPersonCardWithFilter1.SelectedPersonId;

            if (selectedPersonId.HasValue)
            {
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

                            UserIDLabel.Text = $"{currentUser.UserID}";

                            // Optional: ClearForm(); // If you want to clear the form after saving
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
            UserNameInput.Clear();
            PasswordInput.Clear();
            IsActiveCheckBox.Checked = false;

            currentUser = new clsUser(); // Reset to a new user
        }
    }
}
