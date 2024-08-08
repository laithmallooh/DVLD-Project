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
        private ctrlPersonCard personCard; // Declare at the class level

        private clsUser _user;
        private ctrlUserCard userCard; // Add this line


        public ChangePassword(clsPerson person , clsUser user)
        {
            InitializeComponent();
            this._person = person;

            this._user = user; // Store the user object

            // Debugging messages
            MessageBox.Show($"PersonID: {person.PersonID}, Name: {person.FirstName} in ChangePassword constructor");
            MessageBox.Show($"UserID: {user.UserID}, Username: {user.UserName} in ChangePassword constructor");

            // InitializePersonCard();
            // Initialize the existing ctrlPersonCard control with person data
            LoadPersonData();
            LoadUserData();
          //  InitializeUserCard(); // Add this line


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

        }

        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {

        }
    }
}
