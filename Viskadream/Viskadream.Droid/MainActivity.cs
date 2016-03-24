using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportFragment = Android.Support.V4.App.Fragment;

namespace Viskadream.Droid {
    [Activity(Label = "Viskadream.Droid", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/viskadreamTheme")]
    public class MainActivity : AppCompatActivity {
        //Toolbar
        private SupportToolbar mToolbar;
        //Drawer
        private MyActionBarDrawerToggle mDrawerToggle;
        private DrawerLayout mDrawerLayout;
        private ListView mLeftDrawer;
        //Drawer Item List
        private ArrayAdapter mLeftAdapter;
        private List<string> mLeftDataSet;
        //Fragments
        private SupportFragment mCurrentFragment;
        private Fragment1 mFragment1;
        private Fragment2 mFragment2;
        private Fragment3 mFragment3;

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            mLeftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);

            mFragment1 = new Fragment1();
            mFragment2 = new Fragment2();
            mFragment3 = new Fragment3();

            //Set the toolbar to function as the old actionbar
            SetSupportActionBar(mToolbar);

            //Open first fragment
            var trans = SupportFragmentManager.BeginTransaction();
            trans.Add(Resource.Id.fragmentContainer, mFragment1);
            trans.Commit();

            mCurrentFragment = mFragment1;
            //--

            //Adds Three Items to a list
            mLeftDataSet = new List<string>();
            mLeftDataSet.Add("Tournaments");
            mLeftDataSet.Add("Stream");
            mLeftDataSet.Add("Twitter");
            //Adding the list to an array
            mLeftAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, mLeftDataSet);
            //Adding the array to the left drawer content.
            mLeftDrawer.Adapter = mLeftAdapter;

            mLeftDrawer.ItemClick += MLeftDrawer_ItemClick;

            mDrawerToggle = new MyActionBarDrawerToggle(
                this,                               //Host Activity
                mDrawerLayout,                      //DrawerLayout
                Resource.String.openDrawer,         //Opened Message
                Resource.String.closeDrawer         //Closed Message
            );

            mDrawerLayout.SetDrawerListener(mDrawerToggle);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            mDrawerToggle.SyncState();


            if (bundle != null)
                if (bundle.GetString("DrawerState") == "Opened")
                    SupportActionBar.SetTitle(Resource.String.openDrawer);
                else
                    SupportActionBar.SetTitle(Resource.String.closeDrawer);
            else
                SupportActionBar.SetTitle(Resource.String.closeDrawer);
        }

        private void MLeftDrawer_ItemClick(object sender, AdapterView.ItemClickEventArgs e) {
            //When list item in drawer is pressed, check Item Id and do stuff.
            switch (e.Id) {

                //Replaces the fragment to another based on item id.
                case 0:
                    ReplaceFragment(mFragment1);
                    mDrawerLayout.CloseDrawer(mLeftDrawer);
                    return;

                case 1:
                    ReplaceFragment(mFragment2);
                    mDrawerLayout.CloseDrawer(mLeftDrawer);
                    return;

                case 2:
                    ReplaceFragment(mFragment3);
                    mDrawerLayout.CloseDrawer(mLeftDrawer);
                    return;

            }
        }

        public void ReplaceFragment(SupportFragment fragment) {
            if (fragment.IsVisible)
                return;

            var trans = SupportFragmentManager.BeginTransaction();

            trans.AddToBackStack(null);
            trans.Replace(Resource.Id.fragmentContainer, fragment);
            trans.Commit();

            mCurrentFragment = fragment;
        }

        public override bool OnOptionsItemSelected(IMenuItem item) {
            mDrawerToggle.OnOptionsItemSelected(item);
            return base.OnOptionsItemSelected(item);
        }

        public override bool OnCreateOptionsMenu(IMenu menu) {
            MenuInflater.Inflate(Resource.Menu.action_menu, menu);
            return base.OnCreateOptionsMenu(menu);
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