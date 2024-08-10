using DVLDBusinessLayer;
using System;
using System.Windows.Forms;

namespace DVLDPresentationLayer
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        private bool isPersonFound = false; // State variable to track if a person is found
        private clsPerson selectedPerson; // Track the selected person object
        public event EventHandler PersonSelectedChanged;

        // Property indicating if a person is found
        public bool IsPersonFound => isPersonFound;


        private int? _selectedPersonId;
        public int? SelectedPersonId
        {
            get => _selectedPersonId;
            set
            {
                if (_selectedPersonId != value)
                {
                    _selectedPersonId = value;
                    OnPersonSelectedChanged();
                    MessageBox.Show($"SelectedPersonId updated to: {value}");
                }
            }
        }

        public void CheckState()
        {
            MessageBox.Show($"Current state: SelectedPersonId = {SelectedPersonId}", "State Check");
        }


        protected virtual void OnPersonSelectedChanged()
        {
            PersonSelectedChanged?.Invoke(this, EventArgs.Empty);
        }


        // Method to update person details in UI
        private void UpdatePersonDetails()
        {
            if (_selectedPersonId.HasValue)
            {
                clsPerson person = clsPerson.Find(_selectedPersonId.Value);
                if (person != null)
                {
                    // Update UI with person details
                    MessageBox.Show($"Displaying details for: {person.FirstName} {person.LastName}");
                    // Implement UI update logic here
                }
                else
                {
                    MessageBox.Show("Person not found.");
                }
            }
        }



        // Reference to panel1 where person details will be shown
        public Panel personDetailsPanel;

        // Default constructor
        public ctrlPersonCardWithFilter(Panel panel)
        {
            InitializeComponent();
            personDetailsPanel = panel; // Assign the passed panel
            InitializeDefaultPersonCard();
            dgvPersons.Visible = false;
            dgvPersons.SelectionChanged += dgvPersons_SelectionChanged;

        }


        // Default constructor (optional, if needed elsewhere)
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
            dgvPersons.Visible = false;

        }

        private void OnPersonSelected(int personId)
        {
            SelectedPersonId = personId;
            DisplayPersonData(personId);
            MessageBox.Show($"Person selected: {SelectedPersonId}", "Debug");
            // Other logic related to person selection
        }



        public void SelectPerson(int personId)
        {
            SelectedPersonId = personId;
            PersonSelectedChanged?.Invoke(this, EventArgs.Empty);
            DisplayPersonData(personId);
            MessageBox.Show($"Person selected with ID: {SelectedPersonId}");
        }


        public void UpdateSelectedPerson(int personId)
        {
            MessageBox.Show($"UpdateSelectedPerson called with ID: {personId}", "Update");
            SelectedPersonId = personId;
            DisplayPersonData(personId);
            OnPersonSelectedChanged(); // This will notify the parent form
        }

   



        // Method to display person data
        public void DisplayPersonData(int personId)
        {
            // Debugging check
            if (personDetailsPanel == null)
            {
                MessageBox.Show("personDetailsPanel is not initialized.");
                return;
            }

            clsPerson person = clsPerson.Find(personId);
            if (person != null)
            {
                personDetailsPanel.Controls.Clear();
                ctrlPersonCard personCard = new ctrlPersonCard(person)
                {
                    Dock = DockStyle.Fill
                };
                personDetailsPanel.Controls.Add(personCard);
            }
            else
            {
                MessageBox.Show("Person not found.");
            }
        }

        







        private void SetupDataGridView()
        {
            dgvPersons.Columns.Add("PersonID", "Person ID");
            dgvPersons.Columns.Add("Name", "Name");
            // Ensure dgvPersons is populated with data
            // Example: dgvPersons.DataSource = GetPersonsData();
        }


        // Disable only the search controls (e.g., ComboBox, TextBox, and PictureBox)
        public void DisableSearchControls()
        {
            // Disable search controls and other related UI elements
            FindByComboBox.Enabled = false;
            textInput.Enabled = false;
            pictureBox1.Enabled = false; // Assuming pictureBox1 is the button to trigger the search
        }


        // Enable the search controls (optional)
        public void EnableSearchControls()
        {
            FindByComboBox.Enabled = true;
            textInput.Enabled = true;
            pictureBox1.Enabled = true;
        }
        // Method to load and display data based on PersonID from DataGridView
        public void LoadPersonById(int personId)
        {
            try
            {
                clsPerson person = clsPerson.Find(personId);
                if (person != null)
                {
                    panel1.Controls.Clear();
                    ctrlPersonCard ctrlPersonCard = new ctrlPersonCard(person)
                    {
                        Dock = DockStyle.Fill
                    };
                    panel1.Controls.Add(ctrlPersonCard);

                    selectedPerson = person;
                    isPersonFound = true;
                    SomePersonSelectionMethod(person.PersonID);
                    OnPersonSelectedChanged(); // Trigger event
                }
                else
                {
                    MessageBox.Show("Person not found.");
                    selectedPerson = null;
                    isPersonFound = false;
                    OnPersonSelectedChanged();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving person data: " + ex.Message);
                selectedPerson = null;
                isPersonFound = false;
                OnPersonSelectedChanged();
            }
        }

        private void SomePersonSelectionMethod(int personId)
        {
            SharedData.SelectedPersonId = personId;
            // Trigger any necessary events or updates
        }


        private void dgvPersons_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPersons.SelectedRows.Count > 0)
            {
                int personId = (int)dgvPersons.SelectedRows[0].Cells["PersonID"].Value;
                SelectedPersonId = personId;
                UpdateSelectedPerson(personId);
            }
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

        // Call this method after updating `isPersonFound` in pictureBox1_Click
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string selectedFilter = FindByComboBox.SelectedItem?.ToString();
            string filterValue = textInput.Text;

            clsPerson person = null;

            if (person != null)
            {
                MessageBox.Show($"Person found with ID: {person.PersonID}", "Search");
                SelectedPersonId = person.PersonID;

                UpdateSelectedPerson(person.PersonID);
            }




            if (!string.IsNullOrEmpty(filterValue))
                {
                    try
                    {

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
                            panel1.Controls.Clear();
                            ctrlPersonCard ctrlPersonCard = new ctrlPersonCard(person)
                            {
                                Dock = DockStyle.Fill
                            };
                            panel1.Controls.Add(ctrlPersonCard);

                            selectedPerson = person; // Set the selected person
                            isPersonFound = true;
                            UpdateSelectedPerson(person.PersonID);
                            OnPersonSelectedChanged(); // Trigger event
                            MessageBox.Show("Person found. Event triggered."); // Debug
                        }
                        else
                        {
                            MessageBox.Show("Person not found.");
                            selectedPerson = null;
                            isPersonFound = false;
                            OnPersonSelectedChanged();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error retrieving person data: " + ex.Message);
                        selectedPerson = null;
                        isPersonFound = false;
                        OnPersonSelectedChanged();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a value to search.");
                    selectedPerson = null;
                    isPersonFound = false;
                    OnPersonSelectedChanged();
                }

            
        
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

        private void textInput_TextChanged(object sender, EventArgs e)
       {

        }

        private void dgvPersons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
