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
        private ctrlPersonCardWithFilter personCardWithFilter;

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        private string selectedPersonId;


        public AddUser()
        {
            InitializeComponent();
            currentUser = new clsUser();
            errorProvider1 = new ErrorProvider();
            PasswordInput.PasswordChar = '*';
            ConfirmPasswordInput.PasswordChar = '*';
            UserNameInput.TextChanged += UserNameInput_TextChanged;
            PasswordInput.TextChanged += PasswordInput_TextChanged;
            ConfirmPasswordInput.TextChanged += ConfirmPasswordInput_TextChanged;
            SaveButton.Click += SaveButton_Click;
            NextButton.Click += NextButton_Click;

            // Initialize and set up DataGridView
            dataGridView1 = new DataGridView();
            dataGridView1.Dock = DockStyle.Fill; // Adjust as needed
            dataGridView1.CellClick += dataGridView1_CellClick;
            this.Controls.Add(dataGridView1);



            // Initialize ctrlPersonCardWithFilter
            personCardWithFilter = new ctrlPersonCardWithFilter(panel1);
            this.Controls.Add(personCardWithFilter);
            personCardWithFilter.PersonSelectedChanged += PersonCardWithFilter_PersonSelectedChanged;

            MessageBox.Show("AddUser constructor completed");



        }


        private void PersonCardWithFilter_PersonSelectedChanged(object sender, EventArgs e)
        {
            MessageBox.Show($"PersonSelectedChanged event triggered. SelectedPersonId: {personCardWithFilter.SelectedPersonId}", "Event Triggered");
            UpdateSaveButtonState();
        }

        private void UpdateSaveButtonState()
        {
            SaveButton.Enabled = personCardWithFilter.SelectedPersonId.HasValue;
        }


        private void AddUser_Load(object sender, EventArgs e)
        {
            if (Mode == enMode.Update)
            {
                LoadUserData();
            }
        }


        // Constructor for editing an existing person
        public AddUser(clsUser user, int personId) : this()
        {
            MessageBox.Show($"Initializing AddUser with PersonID: {personId}"); // Debug message
            if (user != null)
            {
                label4.Text = "Edit User";
                Mode = enMode.Update;
                currentUser = user;
                LoadUserData(personId);

                // Ensure the correct PersonID is set
                currentUser.PersonID = personId;
                MessageBox.Show($"Set currentUser.PersonID to: {currentUser.PersonID}"); // Debug message

                // Update the personCardWithFilter with the correct PersonID
                personCardWithFilter.SelectedPersonId = personId;
                MessageBox.Show($"Set personCardWithFilter.SelectedPersonId to: {personCardWithFilter.SelectedPersonId}"); // Debug message

                ctrlPersonCardWithFilter1.DisableSearchControls();
            }
            else
            {
                MessageBox.Show("User object is null.");
            }
        }

        private void SomeMethodToTestSelection()
        {
            // For testing purposes only
            personCardWithFilter.SelectedPersonId = 1026; // or any valid ID
            MessageBox.Show($"Manually set SelectedPersonId: {personCardWithFilter.SelectedPersonId}");
        }


        private void ctrlPersonCardWithFilter1_PersonSelectedChanged(object sender, EventArgs e)
        {
            if (personCardWithFilter.SelectedPersonId.HasValue)
            {
                MessageBox.Show($"Selected Person ID: {personCardWithFilter.SelectedPersonId.Value}"); // Debugging message
                personCardWithFilter.DisplayPersonData(personCardWithFilter.SelectedPersonId.Value);
            }
            else
            {
                MessageBox.Show("No person selected.");
            }
        }


        //private void ctrlPersonCardWithFilter1_PersonSelectedChanged(object sender, EventArgs e)
        //{
        //    UpdateNextButtonState();
        //    MessageBox.Show("Person selection changed."); // Debugging message
        //}




        // Method to load existing person data into form fields
        private void LoadUserData(int personId)
        {
            MessageBox.Show($"Loading user data for PersonID: {personId}");

            clsPerson person = clsPerson.Find(personId);
            if (person != null)
            {
                MessageBox.Show($"Person found: {person.FirstName} {person.LastName}");

                // Load data into form controls
                UserNameInput.Text = currentUser.UserName;
                PasswordInput.Text = currentUser.Password;
                ConfirmPasswordInput.Text = currentUser.Password;
                IsActiveCheckBox.Checked = currentUser.IsActive;

                // Update the personCardWithFilter
                personCardWithFilter.UpdateSelectedPerson(personId);

                // Optionally update the control showing person details
                panel1.Controls.Clear();
                ctrlPersonCard ctrlPersonCard = new ctrlPersonCard(person)
                {
                    Dock = DockStyle.Fill
                };
                panel1.Controls.Add(ctrlPersonCard);
            }
            else
            {
                MessageBox.Show("Person not found for given PersonID.");
            }
        }

        private void LoadUserData()
        {
            if (currentUser.PersonID != null) // Change this line
            {
                int personId = currentUser.PersonID;
                MessageBox.Show($"Loading user data for PersonID: {personId}");

                clsPerson person = clsPerson.Find(personId); // Change this line
                if (person != null)
                {
                    MessageBox.Show($"Person found: {person.FirstName} {person.LastName}");

                    // Load data into form controls
                    UserNameInput.Text = currentUser.UserName;
                    PasswordInput.Text = currentUser.Password;
                    IsActiveCheckBox.Checked = currentUser.IsActive;

                    // Optionally update the control showing person details
                    panel1.Controls.Clear();
                    ctrlPersonCard ctrlPersonCard = new ctrlPersonCard(person)
                    {
                        Dock = DockStyle.Fill
                    };
                    panel1.Controls.Add(ctrlPersonCard);
                }
                else
                {
                    MessageBox.Show("Person not found.");
                }
            }
            else
            {
                MessageBox.Show("Invalid user data. PersonID is missing.");
            }
        }



        // Method to disable search controls
        private void DisableSearchControls()
        {
            ctrlPersonCardWithFilter1.Enabled = false; // Assuming ctrlPersonCardWithFilter1 is the search control
            NextButton.Enabled = false; // Disable next button if it navigates the tabs
        }




        private void UpdateNextButtonState()
        {
            NextButton.Enabled = personCardWithFilter.SelectedPersonId.HasValue;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count > 1)
            {
                tabControl1.SelectedIndex = 1;
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


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedPersonId = row.Cells["PersonID"].Value.ToString();
                MessageBox.Show($"Selected Person ID: {selectedPersonId}"); // Debugging message

                // Ensure ctrlPersonCardWithFilter is updated with the selected person ID if necessary
                personCardWithFilter.SelectedPersonId = int.Parse(selectedPersonId); // Assuming SelectedPersonId is an int
            }
        }








        private void SaveButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Save button clicked. currentUser.PersonID: {currentUser.PersonID}, personCardWithFilter.SelectedPersonId: {personCardWithFilter.SelectedPersonId}");

            if (ValidateInput())
            {
                if (personCardWithFilter.SelectedPersonId.HasValue)
                {
                    // Ensure the PersonID matches between currentUser and personCardWithFilter
                    if (currentUser.PersonID != personCardWithFilter.SelectedPersonId.Value)
                    {
                        MessageBox.Show($"PersonID mismatch detected. Updating currentUser.PersonID from {currentUser.PersonID} to {personCardWithFilter.SelectedPersonId.Value}");
                        currentUser.PersonID = personCardWithFilter.SelectedPersonId.Value;
                    }
                    SaveUser();
                }
                else
                {
                    MessageBox.Show("No person selected. Please select a person before saving.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please fill in all required fields with valid data.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == PersonalInfo) // Adjust name as needed
            {
                // Re-trigger person selection if necessary
                if (personCardWithFilter.SelectedPersonId.HasValue)
                {
                    personCardWithFilter.UpdateSelectedPerson(personCardWithFilter.SelectedPersonId.Value);
                }
            }
        }


        // Add this method to check the state
        private void CheckControlState()
        {
            MessageBox.Show($"AddUser form state: personCardWithFilter.SelectedPersonId = {personCardWithFilter.SelectedPersonId}", "Form State Check");
            personCardWithFilter.CheckState();
        }

        private void SaveUser()
        {

            MessageBox.Show($"Saving user. PersonID: {currentUser.PersonID}, Username: {UserNameInput.Text}");


            // Final check to ensure PersonID is correct
            if (personCardWithFilter.SelectedPersonId.HasValue && currentUser.PersonID != personCardWithFilter.SelectedPersonId.Value)
            {
                MessageBox.Show($"Final PersonID check: Updating from {currentUser.PersonID} to {personCardWithFilter.SelectedPersonId.Value}");
                currentUser.PersonID = personCardWithFilter.SelectedPersonId.Value;
            }


            if (personCardWithFilter.SelectedPersonId.HasValue)
            {
                currentUser.UserName = UserNameInput.Text;
                currentUser.Password = PasswordInput.Text;
                currentUser.IsActive = IsActiveCheckBox.Checked;
                currentUser.PersonID = personCardWithFilter.SelectedPersonId.Value;

                try
                {
                    bool result = currentUser.Save();
                    if (result)
                    {
                        MessageBox.Show("User saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UserIDLabel.Text = $"{currentUser.UserID}";
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
            else
            {
                MessageBox.Show("No person selected. Please select a person before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void CheckState()
{
    MessageBox.Show($"Current SelectedPersonId: {personCardWithFilter.SelectedPersonId}", "State Check");
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

        private void BtnCheckState_Click(object sender, EventArgs e)
        {
            CheckControlState();
        }

    }
}
