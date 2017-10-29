using System;
using System.Net;
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
using System.Threading;
using System.Threading.Tasks;

namespace Dracula
{
    [Activity(Label = "Sanguinity", MainLauncher = true)]
    public class MainActivity : Activity
    {
        public object AccountStore { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Button buttonLogin = FindViewById<Button>(Resource.Id.button1);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Android.App.Application.Context.StartService(new Intent(Android.App.Application.Context, typeof(SanguinityService)));
            //StartActivity(typeof(SanguinityService));
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += delegate {
                string cnp = FindViewById<EditText>(Resource.Id.editText1).Text;
                API apicall = new API();

                DateTime date = DateTime.Now;
                if (apicall.LogIn(cnp) == true)
                {
                    // Handle User-NickName
                    if (ContainsKey.retrive_cnp().Length == 0)  // Property don't exists
                    {
                        ContainsKey.store_cnp(cnp);
                    } // Create it with "Empty"


                    Toast.MakeText(this, "Logat!", ToastLength.Long).Show();

                    Intent myIntent = new Intent(this, typeof(LoginActivity));
                    myIntent.PutExtra("cnp", cnp);
                    SetResult(Result.Ok, myIntent);
                    Finish();
                    StartActivity(typeof(LoginActivity));
                }
                else
                {
                    Toast.MakeText(this, "CNP neinregistrat!", ToastLength.Long).Show();
                }
            };
           
        }
    }
}

