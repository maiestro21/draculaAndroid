using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Globalization;
using System.Net;

namespace Dracula
{
    class API
    {
        public string APIurl = "http://89.43.62.59/api";
        public int timer = 300000;
        public string CNP;
       
        public API()
        {
            if (ContainsKey.retrive_cnp().Length == 0)
                CNP = ContainsKey.retrive_cnp();
        }

        public bool LogIn(string cnp)
        {
            WebClient wc = new WebClient();
            string messageApi = wc.DownloadString(APIurl + "/is_user_auth.php?cnp=" + cnp);

            if (int.Parse(messageApi) == 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SendLocation(string lat, string lon)
        {

            CNP = ContainsKey.retrive_cnp();

            WebClient wc = new WebClient();
            string messageApi = wc.DownloadString(APIurl + "/send_location.php?cnp=" + CNP + "&lat="+lat +"&long=" + lon);

            if (int.Parse(messageApi) == 100)
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