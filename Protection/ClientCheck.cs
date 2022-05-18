using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using Fusion;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protection
{
    internal class ClientCheck
    {

        public async static void IfLoggedInCheck()
        {
            while (true)
            {
                if (LoggedIn())
                {
                    Process.GetCurrentProcess().Kill();
                }
                else { }
            }
        }
        public async static void Start()
        {
            Thread CheckProcessThread = new Thread(IfLoggedInCheck);
            CheckProcessThread.Start();
        }

        public static bool LoggedIn()
        {
            if (string.IsNullOrWhiteSpace(User.UserId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
