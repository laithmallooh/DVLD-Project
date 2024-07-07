using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBusinessLayer;
using DVLDDataAccessLayer;

namespace DVLDPresentationLayer
{
    public partial class ManagePeople : Form
    {
        private ContextMenuStrip contextMenuStrip;

        private ComboBox FindByfilter;
        private TextBox FilterInput;
        private Label FilterByLabel;

        private DataTable peopleDataTable;


        public ManagePeople()
        {
            InitializeComponent();
            InitializeFilterControls(); // Initialize filter controls

            InitializeContextMenu();
            LoadData(); // Call the LoadData method when the form initializes
        }

        private void InitializeContextMenu()
        {
            contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Items.Add("Show Details", null, ShowDetailsItem_Click);
            contextMenuStrip.Items.Add("Edit", null, EditMenuItem_Click);
            contextMenuStrip.Items.Add("Delete", null, DeleteMenuItem_Click);
            contextMenuStrip.Items.Add("Add Person", null, AddPersonItem_Click);


            dataGridView1.ContextMenuStrip = contextMenuStrip;
            dataGridView1.MouseDown += DataGridView1_MouseDown;
        }

        private void InitializeFilterControls()
        {
            // Initialize Label
            FilterByLabel = new Label
            {
                Text = "Filter by:",
                Location = new Point(10, 320),
                AutoSize = true
            };
            this.Controls.Add(FilterByLabel);

            // Initialize ComboBox
            FindByfilter = new ComboBox
            {
                Location = new Point(FilterByLabel.Right + 10, FilterByLabel.Top),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 150
            };
            FindByfilter.Items.AddRange(new string[]
            {
                "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName", "LastName",
                "DateOfBirth", "Gendor", "Address", "Phone", "Email", "Country"
            });
            FindByfilter.SelectedIndexChanged += ComboBoxFilter_SelectedIndexChanged;
            this.Controls.Add(FindByfilter);

            // Initialize TextBox
            FilterInput = new TextBox
            {
                Location = new Point(FindByfilter.Right + 10, FindByfilter.Top),
                Width = 150,
                Visible = false
            };
            FilterInput.TextChanged += TextBoxFilter_TextChanged; // Ensure this event handler is added
            this.Controls.Add(FilterInput);
        }

        private void ComboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterInput.Visible = true;
        }

        private void TextBoxFilter_TextChanged(object sender, EventArgs e)
        {
            if (FindByfilter.SelectedItem != null)
            {
                FilterData(FindByfilter.SelectedItem.ToString(), FilterInput.Text);
            }
        }


        private string ShowCountry(int countryId)
        {
            switch (countryId)
            {
                case 1: return "Jordan";
                case 2: return "Egypt";
                case 3: return "Saudi Arabia";
                case 4: return "United Arab Emirates";
                case 5: return "Lebanon";
                case 6: return "Syria";
                case 7: return "Iraq";
                case 8: return "Kuwait";
                case 9: return "Qatar";
                case 10: return "Bahrain";
                case 11: return "Oman";
                case 12: return "Yemen";
                case 13: return "Libya";
                case 14: return "Sudan";
                case 15: return "Morocco";
                case 16: return "Algeria";
                case 17: return "Tunisia";
                case 18: return "Palestine";
                case 19: return "Mauritania";
                case 20: return "Somalia";
                case 21: return "Djibouti";
                case 22: return "Comoros";
                default: return "";
            }
        }

        private void FilterData(string filterBy, string filterValue)
        {
            if (peopleDataTable == null)
            {
                // No data loaded, return
                return;
            }

            DataView dv = new DataView(peopleDataTable);

            if (!string.IsNullOrEmpty(filterValue))
            {
                DataColumn column = peopleDataTable.Columns[filterBy];

                if (filterBy.Equals("PersonID", StringComparison.OrdinalIgnoreCase))
                {
                    // Validate input to ensure it's numeric
                    if (!string.IsNullOrEmpty(filterValue) && !filterValue.All(char.IsDigit))
                    {
                        MessageBox.Show("Please enter numeric values only for Person ID filter.");
                        FilterInput.Text = ""; // Clear invalid input
                        return;
                    }
                }



                if (filterBy == "Country")
                {
                    // Filter by country names
                    List<int> matchingCountryIds = new List<int>();

                    // Iterate over rows to find matching country names
                    foreach (DataRow row in peopleDataTable.Rows)
                    {
                        int countryId = Convert.ToInt32(row["NationalityCountryID"]);
                        string countryName = ShowCountry(countryId);

                        if (countryName.IndexOf(filterValue, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            matchingCountryIds.Add(countryId);
                        }
                    }

                    if (matchingCountryIds.Count > 0)
                    {
                        dv.RowFilter = $"NationalityCountryID IN ({string.Join(",", matchingCountryIds)})";
                    }
                    else
                    {
                        dv.RowFilter = "1 = 0"; // No match
                    }
                }
                else if (column.DataType == typeof(string))
                {
                    dv.RowFilter = $"{filterBy} LIKE '%{filterValue}%'";
                }
                else if (column.DataType == typeof(int) || column.DataType == typeof(long) || column.DataType == typeof(short) ||
                         column.DataType == typeof(byte) || column.DataType == typeof(decimal) || column.DataType == typeof(double) ||
                         column.DataType == typeof(float))
                {
                    if (int.TryParse(filterValue, out int numericValue))
                    {
                        dv.RowFilter = $"{filterBy} = {numericValue}";
                    }
                    else
                    {
                        dv.RowFilter = "1 = 0"; // No match if the input is not a valid number
                    }
                }
                else if (column.DataType == typeof(DateTime))
                {
                    if (DateTime.TryParse(filterValue, out DateTime dateValue))
                    {
                        dv.RowFilter = $"{filterBy} = #{dateValue.ToString("MM/dd/yyyy")}#";
                    }
                    else
                    {
                        dv.RowFilter = "1 = 0"; // No match if the input is not a valid date
                    }
                }
                else if (column.DataType == typeof(bool))
                {
                    if (bool.TryParse(filterValue, out bool boolValue))
                    {
                        dv.RowFilter = $"{filterBy} = {boolValue}";
                    }
                    else
                    {
                        dv.RowFilter = "1 = 0"; // No match if the input is not a valid boolean
                    }
                }
                else
                {
                    dv.RowFilter = "1 = 0"; // No match for unsupported data types
                }
            }
            else
            {
                dv.RowFilter = string.Empty; // Clear the filter if the input is empty
            }

            dataGridView1.DataSource = dv;
        }






        private void DataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = dataGridView1.HitTest(e.X, e.Y);
                if (hitTestInfo.RowIndex >= 0)
                {

                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[hitTestInfo.RowIndex].Selected = true;
                    contextMenuStrip.Show(dataGridView1, new Point(e.X, e.Y));
                }
            }
        }



        private void ShowDetailsItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
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
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Retrieve selected person's ID and data
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
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
                            RemovePersonImage(person.ImagePath);
                            person.ImagePath = ""; // Clear image path in person object
                        }
                        else if (addPersonForm.ImageUpdated)
                        {
                            // Save new selected image for person
                            SavePersonImage(person, addPersonForm.SelectedImagePath);
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


        private void RemovePersonImage(string imagePath)
        {
            try
            {
                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting image: " + ex.Message);
            }
        }

        private void SavePersonImage(clsPerson person, string imagePath)
        {
            try
            {
                // Save selected image to destination directory
                string fileName = Path.GetFileName(imagePath);
                string destinationPath = Path.Combine("C:\\DVLD Images", fileName);
                File.Copy(imagePath, destinationPath, true);

                // Update person's image path
                person.ImagePath = destinationPath;

                // Update person in database or business layer if needed
                // Example: clsPerson.Update(person);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving image: " + ex.Message);
            }
        }






        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
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
                            DeletePersonImage(person.ImagePath);

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


        private bool IsFileAccessible(string filePath)
        {
            try
            {
                using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    fileStream.Close();
                }
                return true; // File is accessible
            }
            catch (IOException)
            {
                return false; // File is inaccessible (locked)
            }
            catch (Exception)
            {
                return false; // Other exceptions
            }
        }


        private void DeletePersonImage(string imagePath)
        {
            const int maxAttempts = 5;  // Maximum number of attempts to delete the file
            const int retryDelayMs = 1000;  // Delay between retry attempts in milliseconds (adjust as needed)

            int attempts = 0;
            bool fileDeleted = false;

            while (attempts < maxAttempts && !fileDeleted)
            {
                try
                {
                    if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                    {
                        // Ensure the file is not in use before deleting
                        bool fileInUse = IsFileInUse(imagePath);

                        if (!fileInUse)
                        {
                            // Delete the file
                            File.Delete(imagePath);
                            fileDeleted = true;
                            MessageBox.Show("Image deleted: " + imagePath);
                        }
                        else
                        {
                            // File is in use, wait and retry after delay
                            attempts++;
                            System.Threading.Thread.Sleep(retryDelayMs);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Image file not found or path is empty.");
                        break;
                    }
                }
                catch (IOException ex)
                {
                    // Handle specific exception when the file is locked or in use
                    MessageBox.Show($"Error deleting image: {ex.Message}");
                    attempts++;  // Increment attempts even on error to retry
                    System.Threading.Thread.Sleep(retryDelayMs);  // Retry after delay
                }
                catch (Exception ex)
                {
                    // Handle general exceptions
                    MessageBox.Show($"Error deleting image: {ex.Message}");
                    break;
                }
            }

            if (!fileDeleted)
            {
                MessageBox.Show($"Unable to delete image file after {maxAttempts} attempts.");
            }
        }
        private bool IsFileInUse(string filePath)
        {
            try
            {
                using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    // If we can open it, it's not in use by another process
                    fileStream.Close();
                }
                return false;
            }
            catch (IOException)
            {
                // File is in use
                return true;
            }
            catch (Exception)
            {
                // Other exceptions
                return true;
            }
        }




        private void FindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void LoadData()
        {
            try
            {
                peopleDataTable = clsPerson.GetAllPeople(); // Load data into peopleDataTable

                if (peopleDataTable != null && peopleDataTable.Rows.Count > 0)
                {
                    // Add a new column for the country name
                    if (!peopleDataTable.Columns.Contains("Country"))
                    {
                        peopleDataTable.Columns.Add("Country", typeof(string));
                    }

                    // Populate the new column with country names based on the NationalityCountryID
                    foreach (DataRow row in peopleDataTable.Rows)
                    {
                        int countryId = Convert.ToInt32(row["NationalityCountryID"]);
                        row["Country"] = ShowCountry(countryId);
                    }

                    // Hide NationalityCountryID column
                    if (dataGridView1.Columns.Contains("NationalityCountryID"))
                    {
                        dataGridView1.Columns["NationalityCountryID"].Visible = false;
                    }

                    // Set the DataSource of the DataGridView to the modified DataTable
                    dataGridView1.DataSource = peopleDataTable;
                    label4.Text = peopleDataTable.Rows.Count.ToString();
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




        private void addPerson_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
