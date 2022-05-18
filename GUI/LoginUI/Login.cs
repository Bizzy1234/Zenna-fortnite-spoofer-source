using Fusion;
using spoofer.pro.Backend.Spoofer;
using spoofer.pro.GUI.Notification;
using System;
using System.Windows.Forms;

namespace spoofer.pro.GUI.LoginUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private static FusionApp App = new FusionApp("62144976912");
        BoxMessage box = new BoxMessage();
        private void Login_Load(object sender, EventArgs e)
        {

        }
        private async void siticoneButton2_Click(object sender, EventArgs e)
        {
            var loginResponse = await App.Login(tbUsername.Text, tbPassword.Text, "", true, false);
            if (loginResponse.Error == false)
            {
                this.Hide();
                MainForm form = new MainForm();
                form.Show();
            }
            else
            {
          
                BoxMessage.title = "Error"; BoxMessage.message = loginResponse.Message;
                box.ShowDialog();
                BoxMessage.Clear();
            }
        }

        private async void siticoneButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register form = new Register();
            form.Show();
        }

   

        private async void label6_Click(object sender, EventArgs e)
        {
            this.Refresh();
            BoxMessage.title = "Terms Of Service";
            BoxMessage.message = " - No Sharing Client Download \n - No Reversing Attempts \n - No Sharing Logins \n - We are not responsible for bans in the game \n - Disputing a payment cause you to be banned \n\n Regards Reflex Team";
            box.Refresh();
            box.ShowDialog();
            BoxMessage.Clear();

            this.Refresh();
        }

        private async void label3_Click_1(object sender, EventArgs e)
        {
            this.Refresh();
            BoxMessage.title = "Reset Password?";
            BoxMessage.message = " We do not do client password resets. \n Contact an admin to reset your password. \n @discord.gg/JHassFZzNV";
            box.Refresh();
            box.ShowDialog();
            BoxMessage.Clear();
            this.Refresh();
        }
    }
}
