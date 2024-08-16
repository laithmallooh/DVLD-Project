using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static DVLDBusinessLayer.clsPerson;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net;

namespace DVLDPresentationLayer
{
    public partial class AddPerson : Form
    {

        private clsPerson person; // Declare person at class level
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;


        public bool ImageRemoved { get; private set; }
        public bool ImageUpdated { get; private set; }
        public string SelectedImagePath { get; private set; }

        // Methods to update the state based on user actions
        private void RemoveImage()
        {
            // Logic to remove image
            ImageRemoved = true;
            SelectedImagePath = ""; // Clear image path
        }

        private void UpdateImage(string imagePath)
        {
            // Logic to update image
            ImageUpdated = true;
            SelectedImagePath = imagePath; // Set selected image path
        }





        private bool isImageSelected = false;
        private string selectedImagePath = null;
        private Dictionary<string, int> countryIds = new Dictionary<string, int>();
        private string imageDirectory = "C:\\DVLD Images";

        public string FirstName;
        public string SecondName;
        public string ThirdName;
        public string LastName;
        public string NationalNumber;
        public int GenderInput;
        public DateTime DateOfBirthInput;
        public string AddressInput;
        public string CountryInput;
        public string PhoneInput;
        public string EmailInput;
        public string ImageInput;
        public int NationalityCountryID;


        private string selectedImageLocation = null;

  

        // Constructors 

        // Constructor for adding a new person
        public AddPerson()
        {

            person = new clsPerson(); // Initialize person object here

            InitializeComponent();
            PopulateCountryList();
            EnsureDirectoryExists();
            SetupEventHandlers();
            SetDefaultValues();

            // Set default country to Jordan
            comboBox1.SelectedIndex = Array.IndexOf(comboBox1.Items.Cast<string>().ToArray(), "Jordan");

            setImage.Visible = true; // Ensure "Set Image" label is visible on form load
            removeImageLabel.Visible = false; // Hide remove image label initially



            // Set default image to Male

            pictureBox1.Image = Properties.Resources.male;

            // Set default gender to Male
            Male.Checked = true;
            Female.Checked = false;

            // Enable gender selection
            Male.Enabled = true;
            Female.Enabled = true;

        }

        // Constructor for editing an existing person
        public AddPerson(clsPerson person) : this()
        {
            if (person != null)
            {
                TitleLabel.Text = "Edit Person";
                Mode = enMode.Update;

                this.person = person;
                LoadPersonData();
            }
        }

        // logger class 
        public static class Logger
        {
            private static readonly string logFilePath = "log.txt"; // Specify your log file path

            public static void Log(string message)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(logFilePath, true))
                    {
                        writer.WriteLine($"{DateTime.Now} - {message}");
                    }
                }
                catch (Exception ex)
                {
                    // Handle logging errors here
                    Console.WriteLine($"Error logging message: {ex.Message}");
                }
            }
        }

        private void SetDefaultValues()
        {


            // Set default gender to Male
            pictureBox1.Image = Properties.Resources.male;
            GenderInput = 1; // Set GenderInput to 1 for Male


            // Calculate the maximum date 18 years ago from today
            DateTime maxDate = DateTime.Today.AddYears(-18);

            // Set DateOfBirthPicker properties
            DateOfBirthPicker.MaxDate = maxDate;
            DateOfBirthPicker.Value = maxDate; // Set default value to maxDate (18 years ago)
            DateOfBirthInput = maxDate; // Set the default value for DateOfBirthInput
            ClearForm();
        }

        private void SetupEventHandlers()
        {
            // Ensure the event handler is only subscribed once
            setImage.LinkClicked -= setImage_LinkClicked; // Unsubscribe to avoid duplicate
            setImage.LinkClicked += setImage_LinkClicked; // Subscribe the event handler

            FirstNameBox.Validating += TextBox_Validating;
            SecondNameBox.Validating += TextBox_Validating;
            ThirdNameBox.Validating += TextBox_Validating;
            LastNameBox.Validating += TextBox_Validating;
            NationalNoBox.Validating += NationalNoBox_Validating;
            DateOfBirthLabel.Validating += TextBox_Validating;
            AddressBox.Validating += TextBox_Validating;
            PhoneBox.Validating += PhoneBox_Validating;
            PhoneBox.KeyPress += PhoneBox_KeyPress;
            EmailBox.Validating += EmailBox_Validating;

            removeImageLabel.LinkClicked += removeImageLabel_LinkClicked;

            DateOfBirthPicker.ValueChanged += DateOfBirthPicker_ValueChanged;


            DateTime maxDate = DateTime.Today.AddYears(-18);
            DateOfBirthPicker.MaxDate = maxDate;
            DateOfBirthPicker.MinDate = DateTime.Today.AddYears(-100); // Set the minimum date to 100 years ago if needed
            DateOfBirthPicker.Value = maxDate; // Set default value to maxDate (18 years ago)

            Male.CheckedChanged += Male_CheckedChanged;
            Female.CheckedChanged += Female_CheckedChanged;

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged_1;
        }




        private void DateOfBirthPicker_ValueChanged(object sender, EventArgs e)
        {
            DateOfBirthInput = DateOfBirthPicker.Value;
        }




        // Method to load existing person data into form fields
        private void LoadPersonData()
        {

            PersonIDLabel.Text = person.PersonID.ToString();   
            FirstNameBox.Text = person.FirstName;
            SecondNameBox.Text = person.SecondName;
            ThirdNameBox.Text = person.ThirdName;
            LastNameBox.Text = person.LastName;
            NationalNoBox.Text = person.NationalNo;
            //DateOfBirthPicker.Value = person.DateOfBirth;
            DateOfBirthInput = person.DateOfBirth; // Ensure DateOfBirthInput is updated
            AddressBox.Text = person.Address;
            comboBox1.SelectedItem = person.NationalityCountryID;
            PhoneBox.Text = person.Phone;
            EmailBox.Text = person.Email;
            selectedImagePath = person.ImagePath;

            // Load the image if available
            if (!string.IsNullOrEmpty(person.ImagePath) && File.Exists(person.ImagePath))
            {
                pictureBox1.Image = Image.FromFile(person.ImagePath);
                isImageSelected = true;
                removeImageLabel.Visible = true;
                setImage.Visible = false;
            }

            // Set gender
            if (person.Gendor == 1) // Assuming 1 for Male and 2 for Female based on your current logic
            {
                Male.Checked = true;
            }
            else if (person.Gendor == 2)
            {
                Female.Checked = true;
            }

            // Enable gender selection regardless of image state
            Male.Enabled = true;
            Female.Enabled = true;

            // Load the nationality (country)
            if (person.NationalityCountryID > 0)
            {
                // Find the corresponding country name using countryIds dictionary
                string selectedCountry = countryIds.FirstOrDefault(x => x.Value == person.NationalityCountryID).Key;

                // Select the country in comboBox1
                if (!string.IsNullOrEmpty(selectedCountry))
                {
                    int selectedIndex = comboBox1.Items.IndexOf(selectedCountry);
                    if (selectedIndex >= 0)
                    {
                        comboBox1.SelectedIndex = selectedIndex;
                    }
                }
            }



        }



        private void ClearForm()
        {

            // Clear all form fields
            FirstNameBox.Text = "";
            SecondNameBox.Text = "";
            ThirdNameBox.Text = "";
            LastNameBox.Text = "";
            NationalNoBox.Text = "";

            // Set DateOfBirthPicker to a default date within the valid range
            DateOfBirthPicker.Value = DateOfBirthPicker.MaxDate;

            AddressBox.Text = "";
            comboBox1.SelectedIndex = -1;
            PhoneBox.Text = "";
            EmailBox.Text = "";
            pictureBox1.Image = Properties.Resources.male; // Default image
            isImageSelected = false;
            selectedImagePath = null;
            removeImageLabel.Visible = false; // Hide remove image link label
            setImage.Visible = true; // Show set image link label
            Male.Checked = true; // Default gender selection
            Female.Checked = false;
            Male.Enabled = true; // Enable gender selection
            Female.Enabled = true;
        }
        private void PopulateForm(clsPerson person)
        {
            // Populate form fields with existing person data
            FirstNameBox.Text = person.FirstName;
            SecondNameBox.Text = person.SecondName;
            ThirdNameBox.Text = person.ThirdName;
            LastNameBox.Text = person.LastName;
            NationalNoBox.Text = person.NationalNo;
            DateOfBirthPicker.Value = person.DateOfBirth;
            AddressBox.Text = person.Address;
            comboBox1.SelectedItem = person.NationalityCountryID; // Assuming you have a method to map ID to country name
            PhoneBox.Text = person.Phone;
            EmailBox.Text = person.Email;
            selectedImagePath = person.ImagePath;

            // Load the image if available
            if (!string.IsNullOrEmpty(person.ImagePath) && File.Exists(person.ImagePath))
            {
                pictureBox1.Image = Image.FromFile(person.ImagePath);
                isImageSelected = true;
                removeImageLabel.Visible = true;
                setImage.Visible = false;
            }

            // Set gender
            if (person.Gendor == 1)
            {
                Male.Checked = true;
            }
            else if (person.Gendor == 2)
            {
                Female.Checked = true;
            }

            // Disable gender selection if an image is selected
            Male.Enabled = !isImageSelected;
            Female.Enabled = !isImageSelected;
        }

        private void EnsureDirectoryExists()
        {
            try
            {
                if (!Directory.Exists(imageDirectory))
                {
                    Directory.CreateDirectory(imageDirectory);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating directory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private void label1_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCountry = comboBox1.SelectedItem.ToString();
            MessageBox.Show("You selected: " + selectedCountry);
        }


        private void PopulateCountryList()
        {
            // Manually assign IDs to each country
            countryIds["Jordan"] = 1;
            countryIds["Egypt"] = 2;
            countryIds["Saudi Arabia"] = 3;
            countryIds["United Arab Emirates"] = 4;
            countryIds["Lebanon"] = 5;
            countryIds["Syria"] = 6;
            countryIds["Iraq"] = 7;
            countryIds["Kuwait"] = 8;
            countryIds["Qatar"] = 9;
            countryIds["Bahrain"] = 10;
            countryIds["Oman"] = 11;
            countryIds["Yemen"] = 12;
            countryIds["Libya"] = 13;
            countryIds["Sudan"] = 14;
            countryIds["Morocco"] = 15;
            countryIds["Algeria"] = 16;
            countryIds["Tunisia"] = 17;
            countryIds["Palestine"] = 18;
            countryIds["Mauritania"] = 19;
            countryIds["Somalia"] = 20;
            countryIds["Djibouti"] = 21;
            countryIds["Comoros"] = 22;

            // Populate comboBox1 with country names
            comboBox1.Items.AddRange(countryIds.Keys.ToArray());
        }



        private void groupBox1_Enter(object sender, EventArgs e) { }

        private void Male_CheckedChanged(object sender, EventArgs e)
        {
            if (Male.Checked)
            {
                pictureBox1.Image = Properties.Resources.male;
                GenderInput = 1; // Set GenderInput to 1 for Male
            }
        }

        private void Female_CheckedChanged(object sender, EventArgs e)
        {
            if (Female.Checked)
            {
                pictureBox1.Image = Properties.Resources.female;
                GenderInput = 2; // Set GenderInput to 2 for Female
            }
        }


        private void label5_Click(object sender, EventArgs e) { }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IsNullOrWhiteSpace(object sender, EventArgs e)
        {
          
        }

        private bool ValidateEmail(TextBox textBox, string errorMessage)
        {
            string email = textBox.Text;
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, emailPattern))
            {
                errorProvider1.SetError(textBox, errorMessage);
                return false;
            }
            else
            {
                errorProvider1.SetError(textBox, "");
                return true;
            }
        }

        private bool ValidatePhoneNumber(TextBox textBox, string errorMessage)
        {
            string phone = textBox.Text;
            string phonePattern = @"^\d{10}$"; // Example pattern for a 10-digit phone number
            if (string.IsNullOrWhiteSpace(phone) || !Regex.IsMatch(phone, phonePattern))
            {
                errorProvider1.SetError(textBox, errorMessage);
                return false;
            }
            else
            {
                errorProvider1.SetError(textBox, "");
                return true;
            }
        }

        private bool ValidateTextBox(TextBox textBox, string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProvider1.SetError(textBox, errorMessage);
                return false;
            }
            else
            {
                errorProvider1.SetError(textBox, "");
                return true;
            }
        }

        // Enhance ValidateForm method to ensure comprehensive validation
        private bool ValidateForm()
        {
            bool isValid = true;
            isValid &= ValidateTextBox(FirstNameBox, "First Name is required.");
            isValid &= ValidateTextBox(SecondNameBox, "Second Name is required.");
            isValid &= ValidateTextBox(ThirdNameBox, "Third Name is required.");
            isValid &= ValidateTextBox(LastNameBox, "Last Name is required.");
            isValid &= ValidateTextBox(NationalNoBox, "National Number is required.");
            isValid &= ValidateTextBox(AddressBox, "Address is required.");
            isValid &= ValidatePhoneNumber(PhoneBox, "Phone Number is required.");
            isValid &= ValidateEmail(EmailBox, "Invalid email format.");
            return isValid;
        }


        // Save button click event handler
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {

                // Validate DateOfBirthPicker here before saving
                DateTime minDate = DateTime.Today.AddYears(-18);
                if (DateOfBirthPicker.Value > minDate)
                {
                    MessageBox.Show("Date of Birth must be at least 18 years ago.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Exit method if validation fails
                }



                SavePerson();
            }
            else
            {
                MessageBox.Show("Please fill in all required fields with valid data.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void SavePerson()
        {
            try
            {
                if (person == null)
                {
                    person = new clsPerson();
                }

                // Assign values from form controls to person object
                person.FirstName = FirstNameBox.Text.Trim();
                person.SecondName = SecondNameBox.Text.Trim();
                person.ThirdName = ThirdNameBox.Text.Trim();
                person.LastName = LastNameBox.Text.Trim();
                person.NationalNo = NationalNoBox.Text.Trim();
                person.Gendor = GenderInput; // Assign GenderInput based on selected radio button
                person.DateOfBirth = DateOfBirthPicker.Value;
                person.Address = AddressBox.Text.Trim();
                person.NationalityCountryID = NationalityCountryID;
                person.Phone = PhoneBox.Text.Trim();
                person.Email = EmailBox.Text.Trim();


                // Check if the person already has an image and if a new image has been selected
                if (!string.IsNullOrEmpty(person.ImagePath) && selectedImagePath != person.ImagePath)
                {
                    // Delete the old image
                    if (File.Exists(person.ImagePath))
                    {
                        File.Delete(person.ImagePath);
                    }
                }

                // Set the image path
                if (!string.IsNullOrEmpty(selectedImagePath))
                {
                    person.ImagePath = selectedImagePath;
                }
                else
                {
                    person.ImagePath = Path.Combine(imageDirectory, "male.jpg");
                }

                // Save person object
                bool success = person.Save();

                if (success)
                {
                    MessageBox.Show("Person saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;

                    this.Close(); // Close the form after successful save
                }
                else
                {
                    MessageBox.Show("Failed to save person. Please check your input and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save person. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Log($"Error in SavePerson method: {ex.Message}");
            }
        }





        private int GetCountryID(string country)
        {
            return 10;
        }

        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    errorProvider1.SetError(textBox, $"{textBox.Name.Replace("Box", "")} is required.");
                }
                else
                {
                    errorProvider1.SetError(textBox, "");
                }
            }
        }
        private void FirstNameBox_TextChanged(object sender, EventArgs e) { }

        private void EmailBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                string email = textBox.Text;
                if (!IsValidEmail(email))
                {
                    e.Cancel = true;
                    textBox.Select(0, textBox.Text.Length);
                    errorProvider1.SetError(textBox, "Invalid email format.");
                }
                else
                {
                    errorProvider1.SetError(textBox, "");
                }
            }
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            DateTimePicker dateTimePicker = sender as DateTimePicker;
            if (dateTimePicker != null)
            {
                if (dateTimePicker.Value > dateTimePicker.MaxDate)
                {
                    dateTimePicker.Value = dateTimePicker.MaxDate;
                }

                DateOfBirthInput = dateTimePicker.Value;
            }
        }

        private void NationalNoBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                string nationalNumber = textBox.Text;
                if (string.IsNullOrWhiteSpace(nationalNumber))
                {
                    errorProvider1.SetError(textBox, "National Number is required.");
                    e.Cancel = true;
                }
                else
                {
                    if (clsPerson.NationalNumberExists(nationalNumber))
                    {
                        e.Cancel = true;
                        textBox.Select(0, textBox.Text.Length);
                        errorProvider1.SetError(textBox, "National Number already exists in the database.");
                    }
                    else
                    {
                        errorProvider1.SetError(textBox, "");
                    }
                }
            }
        }

        private void NationalNoBox_TextChanged(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void groupBox1_Enter_1(object sender, EventArgs e) { }

        private void PhoneBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                string phone = textBox.Text;
                if (phone.Length != 10 || !phone.All(char.IsDigit))
                {
                    errorProvider1.SetError(textBox, "Phone Number must be 10 numeric characters.");
                }
                else
                {
                    errorProvider1.SetError(textBox, "");
                }
            }
        }

        private void PhoneBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            try
            {
                if (comboBox1.SelectedItem != null)
                {
                    string selectedCountry = comboBox1.SelectedItem.ToString();
                    MessageBox.Show("Selected country: " + selectedCountry);
                    // Proceed with logic using selectedCountry

                    int countryId = countryIds[selectedCountry];
                    // Save the country unique id in NationalityCountryID
                    NationalityCountryID = countryId;
                }
                else
                {
                    MessageBox.Show("No country selected. Please select a country from the list.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
        private void setImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";

            if (person != null)
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        selectedImagePath = dialog.FileName;
                        string fileExtension = Path.GetExtension(selectedImagePath);
                        string guidFileName = Guid.NewGuid().ToString() + fileExtension; // Generate GUID-based filename with original extension
                        string destinationPath = Path.Combine(imageDirectory, guidFileName);

                        // Copy the image to the destination directory
                        File.Copy(selectedImagePath, destinationPath, true);

                        // Set the picture box image
                        pictureBox1.Image = Image.FromFile(destinationPath);
                        isImageSelected = true;

                        // Update UI elements
                        removeImageLabel.Visible = true; // Show remove image label
                        setImage.Visible = true; // Ensure "Set Image" label is visible

                        // Update the selected image path to the new location
                        selectedImagePath = destinationPath;

                        // Enable gender controls
                        Male.Enabled = true;
                        Female.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Person object is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void removeImageLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (person != null && !string.IsNullOrEmpty(selectedImagePath))
            {
                try
                {
                    // Remove the image file if it exists
                    if (File.Exists(selectedImagePath))
                    {
                        pictureBox1.Image.Dispose(); // Dispose of current image
                        File.Delete(selectedImagePath);
                    }

                    // Clear the picture box image
                    pictureBox1.Image = null;
                    isImageSelected = false;

                    // Update UI elements
                    removeImageLabel.Visible = false; // Hide remove image label
                    setImage.Visible = true; // Ensure "Set Image" label is visible

                    // Enable gender controls
                    Male.Enabled = true;
                    Female.Enabled = true;

                    // Clear the selected image path
                    selectedImagePath = string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error removing image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No image to remove or person object is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void FirstNameBox_TextChanged_1(object sender, EventArgs e)
        {

        }
    }

}
