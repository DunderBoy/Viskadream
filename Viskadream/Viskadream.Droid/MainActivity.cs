using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Support.V4.Widget;

namespace Viskadream.Droid {
    [Activity(Label = "Viskadream.Droid", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/viskadreamTheme")]
    public class MainActivity : ActionBarActivity {
        private SupportToolbar mToolbar;
        private MyActionBarDrawerToggle mDrawerToggle;
        private DrawerLayout mDrawerLayout;
        private ListView mLeftDrawer;

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            mLeftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);

            SetSupportActionBar(mToolbar);

            mDrawerToggle = new MyActionBarDrawerToggle(
                this,                               //Host Activity
                mDrawerLayout,                      //DrawerLayout
                Resource.String.openDrawer,         //Opened Message
                Resource.String.closeDrawer         //Closed Message
            );

            mDrawerLayout.SetDrawerListener(mDrawerToggle);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            mDrawerToggle.SyncState();


            if (bundle != null)
                if (bundle.GetString("DrawerState") == "Opened")
                    SupportActionBar.SetTitle(Resource.String.openDrawer);
                else
                    SupportActionBar.SetTitle(Resource.String.closeDrawer);
            else
                SupportActionBar.SetTitle(Resource.String.closeDrawer);
        }

        public override bool OnOptionsItemSelected(IMenuItem item) {
            mDrawerToggle.OnOptionsItemSelected(item);
            return base.OnOptionsItemSelected(item);
        }

        protected override void OnSaveInstanceState(Bundle outState) {
            if (mDrawerLayout.IsDrawerOpen((int)GravityFlags.Left))
                outState.PutString("DrawerState", "Opened");
            else
                outState.PutString("DrawerState", "Closed");
            base.OnSaveInstanceState(outState);
        }

        protected override void OnPostCreate(Bundle savedInstanceState) {
            base.OnPostCreate(savedInstanceState);
            mDrawerToggle.SyncState();
        }
    }
}