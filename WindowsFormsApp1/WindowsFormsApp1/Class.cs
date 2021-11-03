using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace ZunLoginAPI
{
    public class Class
    {
        internal class Constants
        {
            public static string Token { get; set; }

            public static string Date { get; set; }

            public static string APIENCRYPTKEY { get; set; }

            public static string APIENCRYPTSALT { get; set; }

            public static bool Breached = false;

            public static string Key = null;

            public static string IV = null;

            public static bool Initialized = false;

            public static Random random = new Random();

            public static string RandomString(int length)
            {
                return new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", length).Select(s => s[random.Next(s.Length)]).ToArray());
            }

            public static string HWID()
            {
                return WindowsIdentity.GetCurrent().User.Value;
            }
        }
        public static void Login(string Token)
        {
            try
            {
                if (Token == "ImBest")
                {
                    NameValueCollection Info = new NameValueCollection
                    {
                        ["token"] = Constants.Token,
                        ["session_id"] = Constants.IV,
                        ["api_id"] = Constants.APIENCRYPTSALT,
                        ["api_key"] = Constants.APIENCRYPTKEY,
                        ["hwid"] = Constants.HWID()
                    };

                    MessageBox.Show("Logged in");
                    Main main = new Main();
                    main.Show();
                    Form1 form = new Form1();
                    form.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect Token, Please Go To Our Discord For the Key: Discord invite here");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public static void Welcome(string WelcomeLabel)
        {
            NameValueCollection Welc = new NameValueCollection
            {
                ["token"] = Constants.Token,
                ["WelcomeLabel"] = Constants.IV,
            };
            WelcomeLabel = "Hello And Welcome!";
        }

        public static void exitApp()
        {
            NameValueCollection ExitThread = new NameValueCollection
            {
                ["token"] = Constants.Token,
                ["Disabling"] = Constants.IV,
            };
            Environment.Exit(0);
        }
    }
}