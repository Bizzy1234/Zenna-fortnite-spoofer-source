using Protection;
using spoofer.pro.Backend.History;
using spoofer.pro.GUI.Notification;
using spoofer.pro.GUI.Pages.Settings;
using spoofer.pro.GUI.Spoofer;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace spoofer.pro
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
        }


        private async void pictureBox7_Click(object sender, EventArgs e)
        {
            Kimtoo.Backdrop.Show(new Settings(), this);
        }
        BoxMessage box = new BoxMessage();
        private async void materialButton1_Click(object sender, EventArgs e)
        {
            if (confirm == false)
            {
                BoxMessage.title = "Error"; BoxMessage.message = "Please confirm your configuration.";
                box.ShowDialog();
                return;
            }
            this.Hide();
            Load load = new Load(); load.Show();
        }

        private async void gunaGoogleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            DiskLbl.Text = gunaGoogleSwitch1.Checked.ToString();
        }

        private async void gunaGoogleSwitch2_CheckedChanged(object sender, EventArgs e)
        {
            CpuLbl.Text = gunaGoogleSwitch2.Checked.ToString();
        }

        private async void gunaGoogleSwitch3_CheckedChanged(object sender, EventArgs e)
        {

            GpuLabel.Text = gunaGoogleSwitch3.Checked.ToString();
        }
        public bool confirm = false;
        private async void materialButton3_Click(object sender, EventArgs e)
        {
            if (gunaGoogleSwitch1.Checked == false && gunaGoogleSwitch2.Checked == false && gunaGoogleSwitch3.Checked == false)
            {
                confirm = false;
                materialButton3.Text = "Confirm";
                BoxMessage.title = "Error"; BoxMessage.message = "Spoofing method is empty.";
                box.ShowDialog();
                return;
            }
            if (confirm == false) { confirm = true; materialButton3.Text = "CONFIRMED"; }
            else if (materialButton3.Text == "CONFIRMED") { confirm = false; materialButton3.Text = "Confirm"; }

        }
        History history = new History();
        private async void MainForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            ClientCheck.Start();


            try
            {
                failedSpooflbl.Text = await history.FailedSpoofCount();
                totalSpoofslbl.Text = Convert.ToString(await history.TotalSpoofCount());
                successLbl.Text = await history.SucessfulSpoofCount();
                if (failedSpooflbl.Text == "N/A") { failedSpooflbl.Text = "0"; }
                if (totalSpoofslbl.Text == "N/A") { failedSpooflbl.Text = "0"; }
                if (successLbl.Text == "N/A") { failedSpooflbl.Text = "0"; }
            }
            catch(System.FormatException)
            {
                await history.StartHistory();
                failedSpooflbl.Text = await history.FailedSpoofCount();
                totalSpoofslbl.Text = Convert.ToString(await history.TotalSpoofCount());
                successLbl.Text = await history.SucessfulSpoofCount();
                if (failedSpooflbl.Text == "N/A") { failedSpooflbl.Text = "0"; }
                if (totalSpoofslbl.Text == "N/A") { failedSpooflbl.Text = "0"; }
                if (successLbl.Text == "N/A") { failedSpooflbl.Text = "0"; }
            }
           
        }

        private async void materialButton2_Click(object sender, EventArgs e)
        {
            failedSpooflbl.Text = await history.FailedSpoofCount();
            totalSpoofslbl.Text = Convert.ToString(await history.TotalSpoofCount());
            successLbl.Text = await history.SucessfulSpoofCount();
            if (failedSpooflbl.Text == "N/A") { failedSpooflbl.Text = "0"; }
            if (totalSpoofslbl.Text == "N/A") { failedSpooflbl.Text = "0"; }
            if (successLbl.Text == "N/A") { failedSpooflbl.Text = "0"; }
        }
    }
}

