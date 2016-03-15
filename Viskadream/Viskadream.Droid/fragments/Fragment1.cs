using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Newtonsoft.Json;

namespace Viskadream.Droid {
    public class Fragment1 : Fragment {

        //Global Variables
        private ListView mContent;
        private ArrayAdapter mItemsAdapter;
        private List<string> mItemList;
        //Web Communication
        private WebClient mClient;
        private Uri mUrl;

        public override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
            View view = inflater.Inflate(Resource.Layout.Fragment1, container, false);

            mContent = view.FindViewById<ListView>(Resource.Id.frg1Content);

            //Creating a webclient
            mClient = new WebClient();
            mUrl = new Uri("http://android-sql-dunderboy.c9users.io/getUsers.php");

            //Communication to php
            mClient.DownloadDataAsync(mUrl);
            mClient.DownloadDataCompleted += MClient_DownloadDataCompleted;

            return view;
        }

        private void MClient_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e) {
            Activity.RunOnUiThread(() => {
                //Encode the web response
                string json = Encoding.UTF8.GetString(e.Result);
                //Placing the responded json into a mItemList
                mItemList = JsonConvert.DeserializeObject<List<string>>(json);
                

                mItemsAdapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleListItem1, mItemList);
                mContent.Adapter = mItemsAdapter;

            });
        }
    }
}