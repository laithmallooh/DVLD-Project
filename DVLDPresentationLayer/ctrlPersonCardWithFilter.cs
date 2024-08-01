﻿using DVLDBusinessLayer;
using System;
using System.Windows.Forms;

namespace DVLDPresentationLayer
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        private bool isPersonFound = false; // State variable to track if a person is found

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
            InitializeDefaultPersonCard();
        }

        private void InitializeDefaultPersonCard()
        {
            // Create an instance of ctrlPersonCard with default (empty) values
            ctrlPersonCard defaultPersonCard = new ctrlPersonCard()
            {
                Dock = DockStyle.Fill
            };

            // Add ctrlPersonCard to the panel1
            panel1.Controls.Add(defaultPersonCard);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string selectedFilter = FindByComboBox.SelectedItem?.ToString();
            string filterValue = textInput.Text;

            if (!string.IsNullOrEmpty(filterValue))
            {
                try
                {
                    clsPerson person = null;

                    if (selectedFilter == "PersonID" && int.TryParse(filterValue, out int personId))
                    {
                        person = clsPerson.Find(personId);
                    }
                    else if (selectedFilter == "NationalNo")
                    {
                        person = clsPerson.FindByNationalNo(filterValue);
                    }

                    if (person != null)
                    {
                        // Clear previous controls from panel1
                        panel1.Controls.Clear();

                        // Create an instance of ctrlPersonCard with the found person
                        ctrlPersonCard ctrlPersonCard = new ctrlPersonCard(person)
                        {
                            Dock = DockStyle.Fill
                        };

                        // Add ctrlPersonCard to the panel1
                        panel1.Controls.Add(ctrlPersonCard);

                        // Update the state to indicate a person is found
                        isPersonFound = true;
                    }
                    else
                    {
                        MessageBox.Show("Person not found.");
                        isPersonFound = false; // Update the state to indicate no person is found
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving person data: " + ex.Message);
                    isPersonFound = false; // Update the state to indicate no person is found
                }
            }
            else
            {
                MessageBox.Show("Please enter a value to search.");
                isPersonFound = false; // Update the state to indicate no person is found
            }
        }

        public bool IsPersonSelected
        {
            get { return isPersonFound; }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle ComboBox selection change if needed
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            // Initialize ComboBox with filter options
            FindByComboBox.Items.Add("PersonID");
            FindByComboBox.Items.Add("NationalNo");
        }

        private void Filter_Enter(object sender, EventArgs e)
        {

        }
    }
}
