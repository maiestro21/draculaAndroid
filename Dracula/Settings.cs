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

namespace Dracula
{
    //[Table("Settings")]
    public class Settings
    {
        public string CNP { get; set; }
        public string identificator { get; set; }
        public override string ToString()
        {
            return string.Format("[Settings: CNP={0}, identificator={1}]", CNP, identificator);
        }
    }
}