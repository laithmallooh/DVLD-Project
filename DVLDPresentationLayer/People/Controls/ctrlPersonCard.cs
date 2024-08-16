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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLDPresentationLayer
{
    public partial class ctrlPersonCard : UserControl
    {
        private clsPerson _person; // Declare person at class level

        public ctrlPersonCard()
        {
            InitializeComponent();
            SetDefaultValues();
        }

        public ctrlPersonCard(clsPerson person)
        {
            InitializeComponent();
            Initialize(person);
        }

        public void Initialize(clsPerson person)
        {
            this._person = person;
            LoadPersonData(); // Load the data
        }
        private void LoadPersonData()
        {

            // Debug: Check each field
            MessageBox.Show($"Loading data for PersonID: {_person.PersonID} in LoadPersonData function");

            if (_person != null)
            {
                // Assuming you have labels or textboxes to display the data
                PersonIDLabel.Text = _person.PersonID.ToString();
                NameLabel.Text = $"{_person.FirstName} {_person.SecondName} {_person.ThirdName} {_person.LastName}";
                NationalNoLabel.Text = _person.NationalNo;
                DateOfBirthLabel.Text = _person.DateOfBirth.ToShortDateString(); // Display date without time
                AddressLabel.Text = _person.Address;
                GenderLabel.Text = ShowGender(_person);
                PhoneLabel.Text = _person.Phone;
                EmailLabel.Text = _person.Email;
                CountryLabel.Text = ShowCountry(_person);

                // Load the image if ImagePath is valid
                if (!string.IsNullOrEmpty(_person.ImagePath))
                {
                    try
                    {
                        pictureBox1.Image = Image.FromFile(_person.ImagePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to load image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    pictureBox1.Image = null; // or set a default image
                }
            }
            else
            {
                MessageBox.Show("No person data to load.");
            }
        }


        private void SetDefaultValues()
        {
            // Set default or placeholder values
            PersonIDLabel.Text = "N/A";
            NameLabel.Text = "N/A";
            NationalNoLabel.Text = "N/A";
            DateOfBirthLabel.Text = "N/A";
            AddressLabel.Text = "N/A";
            GenderLabel.Text = "N/A";
            PhoneLabel.Text = "N/A";
            EmailLabel.Text = "N/A";
            CountryLabel.Text = "N/A";
            pictureBox1.Image = null; // Or set a default image
        }



       

        private String ShowCountry(clsPerson person)
        {

            switch (person.NationalityCountryID)
            {
                case 1:
                    return "Jordan";
                case 2:
                    return "Egypt";
                case 3:
                    return "Saudi Arabia";
                case 4:
                    return "United Arab Emirates";
                case 5:
                    return "Lebanon";
                case 6:
                    return "Syria";
                case 7:
                    return "Iraq";
                case 8:
                    return "Kuwait";
                case 9:
                    return "Qatar";
                case 10:
                    return "Bahrain";
                case 11:
                    return "Oman";
                case 12:
                    return "Yemen";
                case 13:
                    return "Libya";
                case 14:
                    return "Sudan";
                case 15:
                    return "Morocco";
                case 16:
                    return "Algeria";
                case 17:
                    return "Tunisia";
                case 18:
                    return "Palestine";
                case 19:
                    return "Mauritania";
                case 20:
                    return "Somalia";
                case 21:
                    return "Djibouti";
                case 22:
                    return "Comoros";
                default: 
                    return "Unknown";

            }


            return "";

        }

        private String ShowGender(clsPerson person)
        {

            switch (person.Gendor)
            {
                case 1:
                    return "Male";
                case 2:
                    return "Female";
                default: 
                    return "Unknown";


            }


            return "";

        }
        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void PersonIDLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
