using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordRPC;
using DiscordRPC.Events;
using spoofer.pro.GUI.Notification;

namespace spoofer.pro.Backend.DiscordRPC
{
    internal class DiscordRPC
    {

        public static bool started;
        public async static void Init(bool check, bool stop)
        {
            if(stop != true) { return; };
            if (check)
            {
                Start();
                started = true;
            }
            else
            {
                Stop();
            }
        }
        public static DiscordRpcClient client = new DiscordRpcClient("");
        public async static void Start()
        {
            client.Initialize();
            client.SetPresence(new RichPresence()
            {
                Details = "pasted",
                State = "blah blah",
             
            });
        }
        public async static void Stop()
        {
            client.ClearPresence();
        }
    }
}
