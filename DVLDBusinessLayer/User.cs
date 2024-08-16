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
        private clsPeopleData dataAccess = new clsPeopleData();
        public clsUser()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.FullName = "";
            this.UserName = "";
            this.Password = "";
            this.IsActive = false;
            this.Mode = enMode.AddNew;
        }

        private clsUser(int UserID, int PersonID, string FullName, string UserName, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.FullName = FullName;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            this.Mode = enMode.Update;
        }
        private bool _UpdateUser()
        {
            // Call the data access layer to update the person in the database
            return clsUsersData.UpdateUser(this.UserID, this.FullName, this.UserName, this.Password, this.IsActive );
        }
        public bool _UpdatePassword()
        {
            // Ensure this.Password is set correctly
            MessageBox.Show($"Attempting to update password for UserID: {this.UserID}");
            return clsUsersData.UpdatePassword(this.UserID, this.Password);
        }
        private bool _AddNewUser()
        {
            // Call the data access layer to add a new person to the database
            this.UserID = clsUsersData.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);
            return (this.PersonID != -1); // Return true if person was successfully added

        }
        public static bool DeleteUser(int UserID)
        {
            MessageBox.Show(" clsUser.DeleteUser(UserId); business layer ");
            return clsUsersData.DeleteUser(UserID);
        }
        public static bool NationalNumberExists(string nationalNumber)
        {
            return clsPeopleData.NationalNumberExists(nationalNumber);
        }
        public static clsUser Find(int UserID)
        {
            int PersonID = -1;
            string FullName = "", UserName = "", Password = "";
            bool IsActive = false;

            MessageBox.Show("Finding user with ID: " + UserID);

            if (clsUsersData.GetUserInfoByID(UserID, ref FullName, ref UserName, ref Password, ref IsActive))
            {
                MessageBox.Show("User found: " + FullName);
                return new clsUser(UserID, PersonID, FullName, UserName, Password, IsActive);
            }
            else
            {
                MessageBox.Show("User not found.");
                return null;
            }
        }
        public bool Save()
        {
            MessageBox.Show("Save method called. Mode: " + Mode);

            switch (Mode)
            {
                case enMode.AddNew:
                    return _AddNewUser();

                case enMode.Update:
                    return _UpdateUser();

                default:
                    MessageBox.Show("Invalid mode.");
                    return false;
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
