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
    class Match {
        public string Name { get; set; }
        public int score1 { get; set; }
        public int score2 { get; set; }
        public int matchNr { get; set; }
    }
}