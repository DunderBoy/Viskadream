using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;

namespace Viskadream.Droid
{
	[Activity (Label = "Viskadream.Droid", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/viskadreamTheme")]
	public class MainActivity : ActionBarActivity
	{
        private SupportToolbar mToolbar;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
            
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            SetSupportActionBar(mToolbar);
		}
	}
}


