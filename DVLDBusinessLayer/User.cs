using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsUser
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public enMode Mode { get; set; }


        public clsUser()
        {

            this.UserID = -1;
            this.PersonID = -1;
            this.FullName = "";
            this.UserName = "";
            this.Password = "";
            this.IsActive = false ;
            this.Mode = enMode.AddNew;
        }

        private clsUser(int UserID, string PersonID, string FullName, string UserName ,string Password, bool IsActive)
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.FullName = "";
            this.UserName = "";
            this.Password = "";
            this.IsActive = false;
            this.Mode = enMode.Update;
        }



        private bool _UpdatePerson()
        {
            // Call the data access layer to update the person in the database
            return clsUsersData.UpdateUser(this.UserID, this.PersonID, this.FullName, this.UserName, this.Password, this.IsActive );
        }

        private bool _AddNewPerson()
        {
            // Call the data access layer to add a new person to the database
            this.UserID = clsUsersData.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);

            return (this.UserID != -1); // Return true if person was successfully added
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


        public static clsUser Find(int UserID)
        {
            string FullName = "", UserName = "", Password = "" , PersonID ="";
            bool IsActive = false;

            MessageBox.Show("Finding person with ID: " + PersonID);

            if (clsUsersData.GetUserInfoByID(UserID , PersonID, ref FullName, ref UserName, ref Password ,ref IsActive ))
            {
                MessageBox.Show("Person found: " + FullName);
                return new clsUser(UserID, PersonID, FullName, UserName, Password, IsActive);
            }
            else
            {
                MessageBox.Show("Person with ID " + PersonID + " not found.");
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





        public static DataTable GetAllUsers()
        {
            return clsUsersData.GetAllUsers();
        }













    }
}
