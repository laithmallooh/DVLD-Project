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

namespace DVLDPresentationLayer
{




    public partial class ChangePassword : Form
    {

        private clsPerson _person;
        private clsUser _user;
        private ctrlPersonCard personCard;
        private ctrlUserCard userCard;
        private ErrorProvider errorProvider;
        private System.Windows.Forms.Timer typingTimer; // Use full namespace for Timer
        private const int TypingDelay = 500; // Delay in milliseconds


        public ChangePassword(clsPerson person, clsUser user)
        {
            InitializeComponent();
            this._person = person;
            this._user = user;

            // Initialize the ErrorProvider for displaying errors
            errorProvider = new ErrorProvider();

            // Initialize the Timer
            typingTimer = new System.Windows.Forms.Timer(); // Use full namespace for Timer
            typingTimer.Interval = TypingDelay;
            typingTimer.Tick += TypingTimer_Tick;

            // Attach the TextChanged event handler to CurrentPasswordInput
            CurrentPasswordInput.TextChanged += CurrentPasswordInput_TextChanged;

            // Attach event handlers for NewPasswordInput and ConfirmPasswordInput
            NewPasswordInput.TextChanged += NewPasswordInput_TextChanged;
            ConfirmPasswordInput.TextChanged += ConfirmPasswordInput_TextChanged;


            // Initialize controls with data
            LoadPersonData();
            LoadUserData();
        }

        private void NewPasswordInput_TextChanged(object sender, EventArgs e)
        {
            // Check if the new password matches the confirm password
            ValidateNewPassword();
        }

        private void ConfirmPasswordInput_TextChanged(object sender, EventArgs e)
        {
            // Check if the confirm password matches the new password
            ValidateNewPassword();
        }


        private void ValidateNewPassword()
        {
            if (NewPasswordInput.Text != ConfirmPasswordInput.Text)
            {
                errorProvider.SetError(ConfirmPasswordInput, "Passwords do not match.");
            }
            else
            {
                errorProvider.SetError(ConfirmPasswordInput, "");
            }
        }


        private void ValidateCurrentPassword()
        {
            // Retrieve the stored password for the user
            string storedPassword = FindPassword(_user);

            // Check if the entered password matches the stored password
            if (storedPassword != null && CurrentPasswordInput.Text != storedPassword)
            {
                // Display an error message next to the CurrentPasswordInput
                errorProvider.SetError(CurrentPasswordInput, "The current password is incorrect.");
            }
            else
            {
                // Clear the error if the password matches
                errorProvider.SetError(CurrentPasswordInput, "");
            }
        }


        private void CurrentPasswordInput_TextChanged(object sender, EventArgs e)
        {
            // Restart the timer whenever the text changes
            typingTimer.Stop();
            typingTimer.Start();
        }

        private void TypingTimer_Tick(object sender, EventArgs e)
        {
            // Stop the timer and validate the password when the delay period elapses
            typingTimer.Stop();
            ValidateCurrentPassword();
        }



        public string FindPassword(clsUser user)
        {
            clsUser selectedUser = clsUser.Find(user.UserID);

            return selectedUser?.Password;
        }





        private void LoadPersonData()
        {
            if (_person != null && ctrlPersonCard != null)
            {
                ctrlPersonCard.Initialize(_person);
            }
            else
            {
                MessageBox.Show("No person data to load or ctrlPersonCard is null.");
            }
        }


        private void LoadUserData()
        {
            if (_user != null && ctrlUserCard != null)
            {
                ctrlUserCard.Initialize(_user);
            }
            else
            {
                MessageBox.Show("No person data to load or ctrlPersonCard is null.");
            }
        }
        private void InitializeUserCard()
        {
            if (_user != null)
            {
                MessageBox.Show($"Initializing ctrlUserCard with user data: {_user.UserName}");

                if (ctrlUserCard == null)
                {
                    ctrlUserCard = new ctrlUserCard();
                    this.Controls.Add(ctrlUserCard);
                }

                MessageBox.Show($"Before LoadUserData: UserIDOutput.Text ");
                ctrlUserCard.LoadUserData();
                MessageBox.Show($"After LoadUserData: UserIDOutput.Text = ");



            }
            else
            {
                MessageBox.Show("User data is null.");
            }
        }



        private void ChangePassword_Load(object sender, EventArgs e)
        {
            // Optionally re-load data here if needed
            LoadPersonData();
            InitializeUserCard(); // Add this line

        }





        private void InitializePersonCard()
        {
            personCard = new ctrlPersonCard(_person)
            {
                Dock = DockStyle.Fill
            };

            // Debug: Check if personCard is added
            MessageBox.Show("Adding ctrlPersonCard to the ChangePassword form.");

            this.Controls.Add(personCard);
        }






        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Validate the password fields
            if (ValidatePasswordFields())
            {
                // Log for debugging: Show userID and new password
                Console.WriteLine($"Updating password for UserID: {_user.UserID}, New Password: {NewPasswordInput.Text}");

                // Update the password if there are no validation errors
                _user.Password = NewPasswordInput.Text; // Ensure new password is assigned
                if (_user._UpdatePassword())
                {
                    MessageBox.Show("Password updated successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to update the password. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Please fix the errors in the password fields.");
            }
        }

        private bool ValidatePasswordFields()
        {
            bool isValid = true;

            // Validate current password
            ValidateCurrentPassword();
            if (errorProvider.GetError(CurrentPasswordInput) != "")
            {
                isValid = false;
            }

            // Validate new password
            ValidateNewPassword();
            if (errorProvider.GetError(ConfirmPasswordInput) != "")
            {
                isValid = false;
            }

            return isValid;
        }


        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
