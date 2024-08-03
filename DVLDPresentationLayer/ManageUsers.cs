using DVLDBusinessLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLDPresentationLayer
{
    public partial class ManageUsers : Form
    {
        private ContextMenuStrip contextMenuStrip;
        private ComboBox FindByfilter;
        private Control FilterControl;
        private Label FilterByLabel;
        private DataTable peopleDataTable;

        public ManageUsers()
        {
            InitializeComponent();
            InitializeFilterComponents();
            LoadData(); // Call the LoadData method when the form initializes
        }

        private void InitializeFilterComponents()
        {
            // Initialize ComboBox
            FindByfilter = new ComboBox
            {
                Location = new Point(110, 300), // Adjust the location as needed
                Size = new Size(120, 21)
            };
            FindByfilter.Items.AddRange(new string[] { "UserID", "PersonID", "FullName", "UserName", "IsActive" });
            FindByfilter.SelectedIndex = 0; // Set default selection
            FindByfilter.SelectedIndexChanged += FindByfilter_SelectedIndexChanged;
            this.Controls.Add(FindByfilter);

            // Initialize initial Filter Control (TextBox by default)
            FilterControl = new TextBox
            {
                Location = new Point(245, 300), // Adjust the location as needed
                Size = new Size(200, 21)
            };
            ((TextBox)FilterControl).KeyPress += FilterControl_KeyPress;
            this.Controls.Add(FilterControl);

            // Initialize Label
            FilterByLabel = new Label
            {
                Location = new Point(20, 300), // Adjust the location as needed
                Size = new Size(100, 21),
                Text = "Filter By"
            };
            this.Controls.Add(FilterByLabel);

            // Initialize other components and event handlers
            InitializeContextMenu();
        }


        private void InitializeContextMenu()
        {
            contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Items.Add("Show Details", null, ShowDetailsItem_Click);
            contextMenuStrip.Items.Add("Edit", null, EditMenuItem_Click);
            contextMenuStrip.Items.Add("Delete", null, DeleteMenuItem_Click);
            contextMenuStrip.Items.Add("Add Person", null, AddPersonItem_Click);

            usersDataGridView.ContextMenuStrip = contextMenuStrip;
            usersDataGridView.MouseDown += usersDataGridView_MouseDown;
        }

        private void FindByfilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = FindByfilter.SelectedItem.ToString();

            // Remove existing FilterControl and initialize new one based on selected filter
            this.Controls.Remove(FilterControl);

            if (selectedFilter == "IsActive")
            {
                // Initialize ComboBox for IsActive filter
                FilterControl = new ComboBox
                {
                    Location = new Point(245, 300), // Adjust the location as needed
                    Size = new Size(200, 21)
                };
                ((ComboBox)FilterControl).Items.AddRange(new string[] { "All", "Yes", "No" });
                ((ComboBox)FilterControl).SelectedIndex = 0; // Set default selection
                ((ComboBox)FilterControl).SelectedIndexChanged += IsActiveFilter_SelectedIndexChanged;
            }
            else
            {
                // Initialize TextBox for other filters
                FilterControl = new TextBox
                {
                    Location = new Point(245, 300), // Adjust the location as needed
                    Size = new Size(200, 21)
                };
                ((TextBox)FilterControl).TextChanged += FilterInput_TextChanged;

                // Add validation for TextBox based on column type
                if (selectedFilter == "UserName" || selectedFilter == "FullName")
                {
                    ((TextBox)FilterControl).KeyPress += (s, ev) => ValidateTextInput(ev);
                }
                else if (selectedFilter == "UserID" || selectedFilter == "PersonID")
                {
                    ((TextBox)FilterControl).KeyPress += (s, ev) => ValidateNumberInput(ev);
                }
            }

            this.Controls.Add(FilterControl);
        }


        private void ValidateTextInput(KeyPressEventArgs e)
        {
            // Allow control characters (e.g., backspace)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Allow letters and space
            if (char.IsLetter(e.KeyChar) || e.KeyChar == ' ')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void ValidateNumberInput(KeyPressEventArgs e)
        {
            // Allow control characters (e.g., backspace)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Allow digits
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }




        private void FilterInput_TextChanged(object sender, EventArgs e)
        {
            if (peopleDataTable != null)
            {
                DataView dv = peopleDataTable.DefaultView;
                string filterColumn = FindByfilter.SelectedItem.ToString();
                string filterValue = ((TextBox)FilterControl).Text;

                // Determine the type of the column to apply the correct filter
                var columnType = peopleDataTable.Columns[filterColumn].DataType;

                if (columnType == typeof(int))
                {
                    // Validate and filter numeric input for integer columns
                    int intValue;
                    if (int.TryParse(filterValue, out intValue))
                    {
                        dv.RowFilter = $"{filterColumn} = {intValue}";
                    }
                    else
                    {
                        dv.RowFilter = ""; // Clear filter if filterValue is not a valid integer
                    }
                }
                else
                {
                    // Use LIKE for other types of columns (e.g., string)
                    dv.RowFilter = $"{filterColumn} LIKE '%{filterValue}%'";
                }

                usersDataGridView.DataSource = dv;
            }
        }

        private void FilterControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            string filterColumn = FindByfilter.SelectedItem.ToString();
            var columnType = peopleDataTable.Columns[filterColumn].DataType;
            Console.WriteLine($"Column: {filterColumn}, Type: {columnType}");

            if (columnType == typeof(int))
            {
                // Allow only numeric input for integer columns
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else
            {
                // Allow alphanumeric input for other column types
                if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != ' ')
                {
                    e.Handled = true;
                }
            }
        }


        private void IsActiveFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (peopleDataTable != null)
            {
                DataView dv = peopleDataTable.DefaultView;
                string filterColumn = FindByfilter.SelectedItem.ToString();
                string filterValue = ((ComboBox)FilterControl).SelectedItem.ToString();

                if (filterValue == "Yes")
                {
                    dv.RowFilter = $"{filterColumn} = True";
                }
                else if (filterValue == "No")
                {
                    dv.RowFilter = $"{filterColumn} = False";
                }
                else
                {
                    dv.RowFilter = ""; // Clear filter to show all
                }

                usersDataGridView.DataSource = dv;
            }
        }

        private void ShowDetailsItem_Click(object sender, EventArgs e)
        {
            if (usersDataGridView.SelectedRows.Count > 0)
            {
                int selectedRowIndex = usersDataGridView.SelectedRows[0].Index;
                DataGridViewRow selectedRow = usersDataGridView.SelectedRows[0];
                object firstColumnValue = selectedRow.Cells[0].Value;

                if (firstColumnValue != null && int.TryParse(firstColumnValue.ToString(), out int personId))
                {
                    try
                    {
                        // Retrieve the person's data
                        clsPerson person = clsPerson.Find(personId);

                        if (person != null)
                        {
                            // Create a new Form to host the ctrlPersonCard
                            Form form = new Form
                            {
                                Text = "Person Details",
                                Size = new Size(1400, 600) // Adjust the size as needed
                            };

                            // Create an instance of ctrlPersonCard and set its Dock property
                            ctrlPersonCard ctrlPersonCard = new ctrlPersonCard(person)
                            {
                                Dock = DockStyle.Fill
                            };

                            // Add the ctrlPersonCard to the Form
                            form.Controls.Add(ctrlPersonCard);

                            // Show the form
                            form.Show();
                        }
                        else
                        {
                            MessageBox.Show("Person with ID " + personId + " not found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error retrieving person data: " + ex.Message);
                    }
                }
            }
        }

        private void AddPersonItem_Click(object sender, EventArgs e)
        {
            using (AddPerson addPerson = new AddPerson())
            {
                if (addPerson.ShowDialog() == DialogResult.OK)
                {
                    // Refresh data after closing AddPerson form
                    LoadData(); // Assuming LoadData() is a method that reloads your people data
                }
            }
        }

        private void EditMenuItem_Click(object sender, EventArgs e)
        {
            if (usersDataGridView.SelectedRows.Count > 0)
            {
                // Retrieve selected person's ID and data
                int selectedRowIndex = usersDataGridView.SelectedRows[0].Index;
                DataGridViewRow selectedRow = usersDataGridView.SelectedRows[0];
                object firstColumnValue = selectedRow.Cells[0].Value;

                if (firstColumnValue != null && int.TryParse(firstColumnValue.ToString(), out int personId))
                {
                    // Retrieve person's data from business layer
                    clsPerson person = clsPerson.Find(personId);

                    if (person != null)
                    {
                        // Set mode to Update
                        person.Mode = clsPerson.enMode.Update;

                        // Open AddPerson form with person data
                        AddPerson addPersonForm = new AddPerson(person);
                        addPersonForm.ShowDialog();

                        // Handle image operations based on AddPerson form state
                        if (addPersonForm.ImageRemoved)
                        {
                            // Remove person's image from file system
                            // RemovePersonImage(person.ImagePath);
                            person.ImagePath = ""; // Clear image path in person object
                        }
                        else if (addPersonForm.ImageUpdated)
                        {
                            // Save new selected image for person
                            // SavePersonImage(person, addPersonForm.SelectedImagePath);
                        }

                        // Refresh data after editing
                        LoadData(); // Example: Refresh data after editing
                    }
                    else
                    {
                        MessageBox.Show("Person with ID " + personId + " not found.");
                    }
                }
            }
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            if (usersDataGridView.SelectedRows.Count > 0)
            {
                int selectedRowIndex = usersDataGridView.SelectedRows[0].Index;
                DataGridViewRow selectedRow = usersDataGridView.SelectedRows[0];
                object firstColumnValue = selectedRow.Cells[0].Value;

                if (firstColumnValue != null && int.TryParse(firstColumnValue.ToString(), out int personId))
                {
                    // Retrieve person's data from business layer
                    clsPerson person = clsPerson.Find(personId);

                    if (person != null)
                    {
                        // Delete person from database or business layer
                        bool deleteResult = clsPerson.DeletePerson(personId);

                        if (deleteResult)
                        {
                            // Delete associated image file
                            // DeletePersonImage(person.ImagePath);

                            // Display success message
                            MessageBox.Show("Person and associated image deleted successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete person.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Person with ID " + personId + " not found.");
                    }
                }
                else
                {
                    MessageBox.Show("The first column value is not a valid integer.");
                }
            }
            else
            {
                MessageBox.Show("No row is selected.");
            }

            // Refresh data 
            LoadData();
        }

        private void usersDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = usersDataGridView.HitTest(e.X, e.Y);
                if (hitTestInfo.RowIndex >= 0)
                {
                    usersDataGridView.ClearSelection();
                    usersDataGridView.Rows[hitTestInfo.RowIndex].Selected = true;
                    contextMenuStrip.Show(usersDataGridView, new Point(e.X, e.Y));
                }
            }
        }

        private void LoadData()
        {
            try
            {
                peopleDataTable = clsUser.GetAllUsers(); // Load data into peopleDataTable

                if (peopleDataTable != null && peopleDataTable.Rows.Count > 0)
                {
                    // Set the DataSource of the DataGridView to the modified DataTable
                    usersDataGridView.DataSource = peopleDataTable;
                    label2.Text = peopleDataTable.Rows.Count.ToString();
                }
                else
                {
                    MessageBox.Show("No data found or loaded.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addPerson_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();

            // Attach the FormClosed event handler
            addUser.FormClosed += AddUser_FormClosed;

            addUser.Show();
        }

        // Event handler for AddUser form closure
        private void AddUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Refresh data when the AddUser form is closed
            LoadData();
        }

    }
}
