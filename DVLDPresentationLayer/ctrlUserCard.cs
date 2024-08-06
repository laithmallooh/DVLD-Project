using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDPresentationLayer
{
    public partial class ctrlUserCard : UserControl
    {

        private clsUser _user; // Declare person at class level

        public ctrlUserCard()
        {
            InitializeComponent();
        }



        public void Initialize(clsUser user)
        {
            this._user = user;
            LoadUserData(); // Load the data
        }


        public void LoadUserData()
        {
            if (_user != null)
            {
                UserIDOutput.Text = _user.UserID.ToString();
                UserNameOutPut.Text = _user.UserName;
                IsActiveOutput.Text = _user.IsActive ? "Active" : "Inactive";

                // Debugging messages
                MessageBox.Show($"UserIDOutput: {UserIDOutput.Text}");
                MessageBox.Show($"UserNameOutPut: {UserNameOutPut.Text}");
                MessageBox.Show($"IsActiveOutput: {IsActiveOutput.Text}");

            }
            else
            {
                MessageBox.Show("User data is null.");
            }

        }



        private void ctrlUserCard_Load(object sender, EventArgs e)
        {

        }
    }
}
