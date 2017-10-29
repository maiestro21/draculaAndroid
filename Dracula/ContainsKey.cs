using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Preferences;

namespace Dracula
{
    public class ContainsKey
    {
        public static void store_cnp(String cnp)
        {
            //store
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
            var prefEditor = prefs.Edit();
            prefEditor.PutString("cnp", cnp);
            prefEditor.Commit();
            prefEditor.Apply();
        }

        public static String retrive_cnp()
        {
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
            String str = prefs.GetString("cnp", "");
            return str;
        }
    }
}