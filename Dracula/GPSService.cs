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
using Android.Locations;
using Android.Util;

namespace Dracula
{
    [Service]
    class GPSService : Android.App.Service, ILocationListener
    {
        LocationManager locMgr;

        string tag = "MainActivity";
        string latitude;
        string longitude;
        string provider;
        bool locSent = false;

        public override StartCommandResult OnStartCommand(Android.Content.Intent intent, StartCommandFlags flags, int startId)
        {
            locMgr = GetSystemService(Context.LocationService) as LocationManager;

            if (locMgr.AllProviders.Contains(LocationManager.NetworkProvider)
                && locMgr.IsProviderEnabled(LocationManager.NetworkProvider))
            {
                locMgr.RequestLocationUpdates(LocationManager.NetworkProvider, 2000, 1, this);
            }
            else
            {
                StopSelf();
            }

            return StartCommandResult.NotSticky;
        }

        public void OnLocationChanged(Android.Locations.Location location)
        {
            Log.Debug(tag, "Location changed");

            latitude = location.Latitude.ToString();
            longitude = location.Longitude.ToString();
            provider = location.Provider.ToString();
            if (locSent == false)
            {
                API apiCall = new API();
               
                apiCall.SendLocation(latitude,longitude);
                locSent = true;
            }

            StopSelf();
        }

        public void OnProviderDisabled(string provider)
        {
            Log.Debug(tag, provider + " disabled by user");
        }

        public void OnProviderEnabled(string provider)
        {
            Log.Debug(tag, provider + " enabled by user");
        }

        public void OnStatusChanged(string provider, Availability status, Bundle extras)
        {
            Log.Debug(tag, provider + " availability has changed to " + status.ToString());
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
    }
}