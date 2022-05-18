using Microsoft.Win32;
using spoofer.pro.GUI.Notification;
using System;
using System.Windows.Forms;

namespace spoofer.pro.GUI.Pages.Settings
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }
        Timer t1 = new Timer();
        void fadeIn(object sender, EventArgs e)
        {
            if (Opacity >= 1)
                t1.Stop();
            else
                Opacity += 0.05;
        }
        private async void siticoneControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void Settings_Load(object sender, EventArgs e)
        {
            Opacity = 0;
            t1.Interval = 10;
            t1.Tick += new EventHandler(fadeIn);
            t1.Start();




            if (Properties.Settings.Default.discordRPC != true)
            {
                spoofer.pro.Backend.DiscordRPC.DiscordRPC.Init(gunaGoogleSwitch2.Checked, false);
            }
            else { gunaGoogleSwitch2.Checked = Properties.Settings.Default.discordRPC; }

            if (Properties.Settings.Default.autoUpdate != true)
            {
            }
            else { gunaGoogleSwitch1.Checked = Properties.Settings.Default.autoUpdate; }

            if (Properties.Settings.Default.apponStart != true)
            {
            }
            else
            {
                chkStartUp.Checked = Properties.Settings.Default.apponStart;
            }
        }
   
        private async void UpdateApp()
        {
            if (await Fusion.FusionApp.GetAppVar("version") != "1.0")
            {
                BoxMessage.message = "Update is needed please download the update. \n Download: @discord.gg/spoofer.";
                BoxMessage.title = "Error";
                box.ShowDialog();
            }
            else
            {
                BoxMessage.message = "Application is currently up to date.";
                BoxMessage.title = "Update Check";
                box.ShowDialog();
            }
        }
        private async void AppOnStart(bool type)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
       ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (type)
                rk.SetValue("Spoofer.Pro", Application.ExecutablePath);
            else
                rk.DeleteValue("Spoofer.Pro", false);
        }

        private async void gunaGoogleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaGoogleSwitch1.Checked != true)
            {
            } else { UpdateApp(); }
        
        }
        public static BoxMessage box = new BoxMessage();
        private async void gunaGoogleSwitch2_CheckedChanged(object sender, EventArgs e)
        {
            if(gunaGoogleSwitch2.Checked != false)
            {
                if (spoofer.pro.Backend.DiscordRPC.DiscordRPC.started)
                {
                    gunaGoogleSwitch2.Checked = false;
                    BoxMessage.message = "DiscordRPC has already been started.";
                    BoxMessage.title = "Error";
                    box.ShowDialog();
                    return;
                }
                else
                {
                    spoofer.pro.Backend.DiscordRPC.DiscordRPC.Init(gunaGoogleSwitch2.Checked, true);
                }
            } else { spoofer.pro.Backend.DiscordRPC.DiscordRPC.Stop(); }

        }

        private async void materialButton3_Click(object sender, EventArgs e)
        {
            if (gunaGoogleSwitch2.Checked) { Properties.Settings.Default.discordRPC = true; Properties.Settings.Default.Save(); }
            if (gunaGoogleSwitch1.Checked) { Properties.Settings.Default.autoUpdate = true; Properties.Settings.Default.Save(); }
            if (chkStartUp.Checked) { Properties.Settings.Default.apponStart = true; Properties.Settings.Default.Save(); }
        }

        private async void chkStartUp_CheckedChanged(object sender, EventArgs e)
        {
            AppOnStart(gunaGoogleSwitch1.Checked);
        }

        private async void materialButton1_Click(object sender, EventArgs e)
        {
            gunaGoogleSwitch2.Checked = false;
            gunaGoogleSwitch1.Checked = false;
            chkStartUp.Checked = false;
            Properties.Settings.Default.discordRPC = false;
            Properties.Settings.Default.autoUpdate = false;
            Properties.Settings.Default.apponStart = false;
            Properties.Settings.Default.Save();
        }
    }
}