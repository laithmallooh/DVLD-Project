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
        public bool IsActive { get; set; }
        public enMode Mode { get; set; }




        public clsUser()
        {

            this.UserID = -1;
            this.PersonID = -1;
            this.FullName = "";
            this.UserName = "";
            this.IsActive = false ;
            this.Mode = enMode.AddNew;
        }

        private clsUser(int personID, string nationalNo, string firstName, string secondName,
            string thirdName, string lastName, string email, string phone, string address, DateTime dateOfBirth, int gendor, string imagePath, int nationalityCountryID)
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.FullName = "";
            this.UserName = "";
            this.IsActive = false;        
            this.Mode = enMode.Update;
        }



        


        public static DataTable GetAllUsers()
        {
            return clsUsersData.GetAllUsers();
        }













    }
}
