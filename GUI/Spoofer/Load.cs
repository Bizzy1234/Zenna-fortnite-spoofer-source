using Microsoft.Win32;
using spoofer.pro.Backend.History;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spoofer.pro.GUI.Spoofer
{
    public partial class Load : Form
    {
        public Load()
        {
            InitializeComponent();
        }
        // Structure contain information about low-level keyboard input event 
        [StructLayout(LayoutKind.Sequential)]
        private struct KBDLLHOOKSTRUCT
        {
            public Keys key;
            public int scanCode;
            public int flags;
            public int time;
            public IntPtr extra;
        }
        //System level functions to be used for hook and unhook keyboard input  
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int id, LowLevelKeyboardProc callback, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hook);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hook, int nCode, IntPtr wp, IntPtr lp);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string name);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern short GetAsyncKeyState(Keys key);
        //Declaring Global objects     
        private IntPtr ptrHook;
        private LowLevelKeyboardProc objKeyboardProcess;

        private IntPtr captureKey(int nCode, IntPtr wp, IntPtr lp)
        {
            if (nCode >= 0)
            {
                KBDLLHOOKSTRUCT objKeyInfo = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lp, typeof(KBDLLHOOKSTRUCT));

                // Disabling Windows keys 

                if (objKeyInfo.key == Keys.RWin || objKeyInfo.key == Keys.LWin || objKeyInfo.key == Keys.Tab && HasAltModifier(objKeyInfo.flags) || objKeyInfo.key == Keys.Escape && (ModifierKeys & Keys.Control) == Keys.Control)
                {
                    return (IntPtr)1; // if 0 is returned then All the above keys will be enabled
                }
            }
            return CallNextHookEx(ptrHook, nCode, wp, lp);
        }

        bool HasAltModifier(int flags)
        {
            return (flags & 0x20) == 0x20;
        }

        [DllImport("user32.dll")]
        private static extern bool BlockInput(bool block);

        public async static void FreezeMouse()
        {
            BlockInput(true);
        }
        public async static void ThawMouse()
        {
            BlockInput(false);
        }

        public async void SetTaskManager(bool enable)
        {
            RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            if (enable && objRegistryKey.GetValue("DisableTaskMgr") != null)
                objRegistryKey.DeleteValue("DisableTaskMgr");
            else
                objRegistryKey.SetValue("DisableTaskMgr", "1");
            objRegistryKey.Close();
        }
        History history = new History();
        private async void Load_Load(object sender, EventArgs e)
        {
            try
            {
                SetTaskManager(false);
                //
                FreezeMouse();
                //
                ProcessModule objCurrentModule = Process.GetCurrentProcess().MainModule;
                objKeyboardProcess = new LowLevelKeyboardProc(captureKey);
                ptrHook = SetWindowsHookEx(13, objKeyboardProcess, GetModuleHandle(objCurrentModule.ModuleName), 0);
                //
                Cursor.Hide();
                //
                AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
                //
                this.Size = Screen.PrimaryScreen.Bounds.Size;

                siticoneShadowPanel1.Location = new Point(
    this.ClientSize.Width / 2 - siticoneShadowPanel1.Size.Width / 2,
    this.ClientSize.Height / 2 - siticoneShadowPanel1.Size.Height / 2);
                siticoneShadowPanel1.Anchor = AnchorStyles.None;
                //
                this.TopMost = true;
                string sysName = (Backend.Spoofer.Spoof.FileDir + "\\SystemLoop.sys");
                string exeName = (Backend.Spoofer.Spoof.FileDir + "\\SystemFile.exe");


                await Task.Delay(1000);

                Logs.AppendText("• Downloading Spoofer Files");

                await Task.Delay(1000);

                Logs.AppendText("\n• Spoofing Diskdrive");
                //
                try
                {
                    Backend.Spoofer.Spoof spoof = new Backend.Spoofer.Spoof();
                    spoof.Start();
                    await history.AddSucessCount();
                }
                catch
                {
                    await history.AddFailCount();
                    File.Delete(sysName);
                    File.Delete(exeName);
                    SetTaskManager(true);
                    await Task.Delay(2000);
                    Process.GetCurrentProcess().Kill();

                }


                File.Delete(sysName);
                File.Delete(exeName);

                await Task.Delay(1000);

                Logs.AppendText("\n• Spoofing GPU");

                await Task.Delay(1000);

                Logs.AppendText("\n• Spoofing CPU");

                await Task.Delay(1000);

                Logs.AppendText("\n• Spoofing Mac Address");

                await Task.Delay(1000);

                Logs.AppendText("\n• Cleaning Up Files");

                await Task.Delay(1000);

                Logs.AppendText("\n\n\nFinished!");

                SetTaskManager(true);
                await Task.Delay(2000);
                Process.GetCurrentProcess().Kill();
            }
            catch(Exception ex)
            {
                SetTaskManager(true);
                Clipboard.SetText(ex.ToString());
                await Task.Delay(2000);
                Process.GetCurrentProcess().Kill();
            }
        }

        static void OnProcessExit(object sender, EventArgs e)
        {
        }
        private void siticoneShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Load_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
