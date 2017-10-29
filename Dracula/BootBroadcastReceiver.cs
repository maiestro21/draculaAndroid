﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Dracula
{
    [BroadcastReceiver]
    [IntentFilter(new[] { Intent.ActionBootCompleted })]
    class BootBroadcastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            if ((intent.Action != null) && (intent.Action == Intent.ActionBootCompleted))
            {

                Android.App.Application.Context.StartService(new Intent(Android.App.Application.Context, typeof(SanguinityService)));
                API callApi = new API();
                try
                {
                   ///
                }
                catch (Exception s)
                {

                }
            }

        }
    }
}