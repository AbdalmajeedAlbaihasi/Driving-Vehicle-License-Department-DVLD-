
namespace DVLD_Desktop_Net8.User
{
    public partial class fmShowUserDetails : Form
    {
        //members
        private readonly int _userID;


        //constructors
        public fmShowUserDetails()
        {
            InitializeComponent();
        }

        public fmShowUserDetails(int userID)
        {
            InitializeComponent();
            _userID = userID;
        }




        //event handeler
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fmShowUserDetails_Load(object sender, EventArgs e)
        {
            ucShowUserDetails1.loadUserDetailsByUserID(_userID);
        }




        //empty
        private void ucShowUserDetails1_Load(object sender, EventArgs e)
        {

        }
    }
}
