using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using DVLDDataAccessLayer;

namespace DVLDBusinessLayer
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }
        public enMode Mode { get; set; }




        public clsPerson()
        {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gendor = 1;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.ImagePath = "";
            this.Mode = enMode.AddNew;
        }

        private clsPerson(int personID, string nationalNo, string firstName, string secondName,
            string thirdName, string lastName, string email, string phone, string address, DateTime dateOfBirth, int gendor, string imagePath, int nationalityCountryID)
        {
            this.PersonID = personID;
            this.NationalNo = nationalNo;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Gendor = gendor;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.NationalityCountryID = nationalityCountryID;
            this.ImagePath = imagePath;
            this.Mode = enMode.Update;
        }

        private bool _UpdatePerson()
        {
            // Call the data access layer to update the person in the database
            return clsPeopleData.UpdatePerson(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.Email, this.Phone,
                                    this.Address, this.DateOfBirth, this.Gendor, this.ImagePath, this.NationalityCountryID);
        }

        private bool _AddNewPerson()
        {
            // Call the data access layer to add a new person to the database
            this.PersonID = clsPeopleData.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.Email, this.Phone,
                                this.Address, this.DateOfBirth, this.Gendor, this.ImagePath, this.NationalityCountryID);

            return (this.PersonID != -1); // Return true if person was successfully added
        }


        public static bool DeletePerson(int PersonID)
        {
            MessageBox.Show(" clsPerson.DeletePerson(personId); business layer ");
            return clsPeopleData.DeletePerson(PersonID);
        }

        public static bool NationalNumberExists(string nationalNumber)
        {
            return clsPeopleData.NationalNumberExists(nationalNumber);
        }

            
        public static clsPerson Find(int PersonID)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int Gendor = 0, NationalityCountryID = -1;

            MessageBox.Show("Finding person with ID: " + PersonID);

            if (clsPeopleData.GetPersonInfoByID(PersonID, ref NationalNo, ref FirstName, ref SecondName,
            ref ThirdName, ref LastName, ref Email, ref Phone, ref Address, ref DateOfBirth, ref Gendor, ref ImagePath, ref NationalityCountryID))
            {
                MessageBox.Show("Person found: " + FirstName + " " + LastName);
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, Email, Phone, Address, DateOfBirth, Gendor, ImagePath, NationalityCountryID);
            }
            else
            {
                MessageBox.Show("Person with ID " + PersonID + " not found.");
                return null;
            }
        }


        public static clsPerson FindByNationalNo(string NationalNo)
        {
            int PersonID = -1;
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int Gendor = 0, NationalityCountryID = -1;

            MessageBox.Show("Finding person with NationalNo: " + NationalNo);

            if (clsPeopleData.GetPersonInfoByNationalNo(NationalNo, ref PersonID, ref FirstName, ref SecondName, ref ThirdName,
            ref LastName, ref Email, ref Phone, ref Address, ref DateOfBirth, ref Gendor, ref ImagePath, ref NationalityCountryID))
            {
                MessageBox.Show("Person found: " + FirstName + " " + LastName);
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, Email, Phone, Address, DateOfBirth, Gendor, ImagePath, NationalityCountryID);
            }
            else
            {
                MessageBox.Show("Person with NationalNo " + NationalNo + " not found.");
                return null;
            }
        }



        public bool Save()
        {

            MessageBox.Show("Mode : " + Mode + " in save function in person class");

            switch (Mode)
            {
                case enMode.AddNew:
                    // Logic to add new person record

                    return _AddNewPerson();

                case enMode.Update:
                    // Logic to update existing person record
                    return _UpdatePerson();

                default:
                    return false; // Handle unsupported modes or errors
            }

        }



            private int GetCountryID(string countryName)
        {
            // Dummy implementation for now
            // Replace with actual logic to get country ID
            return 1;
        }
    

 
        public static DataTable GetAllPeople()
        {
            return clsPeopleData.GetAllPeople();
        }


        private clsPeopleData dataAccess = new clsPeopleData();

        public bool ValidateUser(string username, string password)
        {
            return dataAccess.ValidateUser(username, password);
        }



         

    }
}
