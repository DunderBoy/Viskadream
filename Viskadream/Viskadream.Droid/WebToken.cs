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

namespace Viskadream.Droid {
    class WebToken {
        public string token { get; set; }
        public string sig { get; set; }
        public bool mobile_restricted { get; set; }

        private string getToken() {
            return token;
        }

        private string getSig() {
            return sig;
        }

        private bool getMobile_Restricted() {
            return mobile_restricted;
        }
    }
}