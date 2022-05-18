using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spoofer.pro.Backend.History
{
    internal class History
    {
        public async Task <string> SucessfulSpoofCount()
        {
            return await Fusion.FusionApp.GetUserVar("SucessfulSpoofCount");
        }
        public async Task AddSucessCount()
        {
            string current = await Fusion.FusionApp.GetUserVar("SucessfulSpoofCount");

            int currentint = Convert.ToInt32(current);
            currentint++;

            string currentstring = currentint.ToString();

            await Fusion.FusionApp.SetUserVar("SucessfulSpoofCount", currentstring);
        }
        //
        public async Task<string> FailedSpoofCount()
        {
            return await Fusion.FusionApp.GetUserVar("FailedSpoofCount");
        }
        public async Task StartHistory()
        {
            await Fusion.FusionApp.SetUserVar("SucessfulSpoofCount", "0");
            await Fusion.FusionApp.SetUserVar("FailedSpoofCount", "0");
        }

        public async Task AddFailCount()
        {
            string current = await Fusion.FusionApp.GetUserVar("FailedSpoofCount");
            int currentint = Convert.ToInt32(current);
            currentint++;

            string currentstring = currentint.ToString();

            await Fusion.FusionApp.SetUserVar("FailedSpoofCount", currentstring);
        }
        //
        public async Task <int> TotalSpoofCount()
        {
            string Failed = await Fusion.FusionApp.GetUserVar("FailedSpoofCount");
            string Sucessful = await Fusion.FusionApp.GetUserVar("SucessfulSpoofCount");

            int Sucessfulv2 = Convert.ToInt32(Failed);
            int Failedv2 = Convert.ToInt32(Sucessful);

            return Sucessfulv2 + Failedv2;
        }
    }
}
