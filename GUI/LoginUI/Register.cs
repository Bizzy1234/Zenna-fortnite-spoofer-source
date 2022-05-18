using Fusion;
using spoofer.pro.GUI.Notification;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spoofer.pro.GUI.LoginUI
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        BoxMessage box = new BoxMessage();
        private static FusionApp App = new FusionApp("62144976912");
        private async void siticoneButton2_Click(object sender, EventArgs e)
        {
            var registerResponse = await App.Register(tbUsername.Text, tbPassword.Text, tbToken.Text);
            if (registerResponse.Error == false)
            {
     
                BoxMessage.title = "Success"; BoxMessage.message = registerResponse.Message;
                box.ShowDialog();
                BoxMessage.Clear();
            }
            else
            {
              
                BoxMessage.title = "Error"; BoxMessage.message = registerResponse.Message;
                box.ShowDialog();
                BoxMessage.Clear();
            }
        }

        private async void siticoneButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login form = new Login();
            form.Show();
        }

        private async void label3_Click(object sender, EventArgs e)
        {
           
            BoxMessage.title = "Terms Of Service";
            BoxMessage.message = " - No Sharing Client Download \n - No Reversing Attempts \n - No Sharing Logins \n - We are not responsible for bans in the game \n - Disputing a payment cause you to be banned \n\n Regards Reflex Team";
            box.ShowDialog();
            BoxMessage.Clear();
        }
    }
}
