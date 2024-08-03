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


        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
            InitializeDefaultPersonCard();

            // Hide the DataGridView if you don't want it visible

            dgvPersons.Visible = false;


        }

        // Property indicating if a person is found
        public bool IsPersonFound => isPersonFound;

        // Property indicating if a person is selected
        public bool IsPersonSelected => selectedPerson != null;

        // Property to get the selected person's ID
        public int? SelectedPersonId => selectedPerson?.PersonID;




        // This method should be called when a person is found or not found
        private void OnPersonSelectedChanged()
        {
            bool personSelected = IsPersonSelected;
            bool personFound = IsPersonFound;

            // Debugging messages
            MessageBox.Show($"OnPersonSelectedChanged: Person Selected = {personSelected}, Person Found = {personFound}");

            PersonSelectedChanged?.Invoke(this, EventArgs.Empty);
        }





        private void SetupDataGridView()
        {
            dgvPersons.Columns.Add("PersonID", "Person ID");
            dgvPersons.Columns.Add("Name", "Name");
            // Ensure dgvPersons is populated with data
            // Example: dgvPersons.DataSource = GetPersonsData();
        }


        // Property to check if a person is selected





        private void dgvPersons_SelectionChanged(object sender, EventArgs e)
        {
            MessageBox.Show("DataGridView selection changed."); // Debugging message
            OnPersonSelectedChanged();
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
                        panel1.Controls.Clear();
                        ctrlPersonCard ctrlPersonCard = new ctrlPersonCard(person)
                        {
                            Dock = DockStyle.Fill
                        };
                        panel1.Controls.Add(ctrlPersonCard);

                        selectedPerson = person; // Set the selected person
                        isPersonFound = true;
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
