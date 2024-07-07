namespace DVLDPresentationLayer
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
            
        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagePeople ManagePeople = new ManagePeople();
            ManagePeople.Show();
        }
         
        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginScreen LoginScreen = new LoginScreen();    
            LoginScreen.Show(); 

        }
    }
}
