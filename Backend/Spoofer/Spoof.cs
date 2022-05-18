using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using spoofer.pro.Properties;

namespace spoofer.pro.Backend.Spoofer
{
    internal class Spoof
    {
        private string GeneratedDir;
        public static string FileDir;

        private string key1;
        private string key2;
        History.History history = new History.History();

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
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
        public async void Start()
        {
            try
            {
                string path = Path.GetPathRoot(Environment.SystemDirectory);
                var files = new DirectoryInfo($@"{path}ProgramData").GetDirectories();
                int index = new Random().Next(0, files.Length);
                GeneratedDir = files[index].FullName;
                FileDir = GeneratedDir;
                //
                string exeName = (FileDir + "\\SystemFile.exe");

                using (FileStream fsDst = new FileStream(exeName, FileMode.CreateNew, FileAccess.Write))
                {
                    byte[] bytes = Resources.GetMapper();

                    fsDst.Write(bytes, 0, bytes.Length);
                }
                //

                string sysName = (FileDir + "\\SystemLoop.sys");

                using (FileStream fsDst = new FileStream(sysName, FileMode.CreateNew, FileAccess.Write))
                {
                    byte[] bytes = Resources.GetDriver();

                    fsDst.Write(bytes, 0, bytes.Length);

                    Process process = new Process();
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.Verb = "runas";
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process = Process.Start(exeName, sysName);
                    Thread.Sleep(3000);

             
                }
            }
            catch
            {
                await history.FailedSpoofCount();
                SetTaskManager(true);
                string exeName = (FileDir + "\\SystemFile.exe");
                string sysName = (FileDir + "\\SystemLoop.sys");
                File.Delete(exeName);
                File.Delete(sysName);
                Process.GetCurrentProcess().Kill();
            }
        }
        static string Encrypt(string text)
        {
            try
            {
                string textToEncrypt = text;
                string ToReturn = "";
                string publickey = "12345678";
                string secretkey = "87654321";
                byte[] secretkeyByte = { };
                secretkeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    ToReturn = Convert.ToBase64String(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        static string Decrypt(string text, string key1, string key2)
        {
            try
            {
                string textToDecrypt = text;
                string ToReturn = "";
                string publickey = "12345678";
                string secretkey = "87654321";
                byte[] privatekeyByte = { };
                privatekeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = new byte[textToDecrypt.Replace(" ", "+").Length];
                inputbyteArray = Convert.FromBase64String(textToDecrypt.Replace(" ", "+"));
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    Encoding encoding = Encoding.UTF8;
                    ToReturn = encoding.GetString(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ae)
            {
                throw new Exception(ae.Message, ae.InnerException);
            }
        }
    }
}
