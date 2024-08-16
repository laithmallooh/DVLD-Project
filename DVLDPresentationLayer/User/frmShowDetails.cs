using DVLDBusinessLayer;
using System;
using System.Windows.Forms;

namespace DVLDPresentationLayer
{
    public partial class frmShowDetails : Form
    {
        private clsPerson _person;
        private clsUser _user;

        public frmShowDetails()
        {
            InitializeComponent();
        }

        public void UpdateData(clsPerson person, clsUser user)
        {
            this._person = person;
            this._user = user;

            LoadPersonData();
            LoadUserData();
        }

        private void LoadPersonData()
        {
            if (_person != null && personCard != null)
            {
                personCard.Initialize(_person);
            }
            else
            {
                MessageBox.Show("No person data to load or personCard is null.");
            }
        }

        private void LoadUserData()
        {
            if (_user != null && userCard != null)
            {
                userCard.Initialize(_user);
            }
            else
            {
                MessageBox.Show("No user data to load or userCard is null.");
            }
        }
    }
}
