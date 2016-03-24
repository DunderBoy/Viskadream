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
        //Web Communication
        private WebClient mClient;
        private Uri mUrl;
        //
        private BaseAdapter<Tournament> mAdapter;
        private List<Tournament> mTournaments;

        //Override
        //private BaseAdapter<Match> mAdapter;
        //private List<Match> mMatch;

        public override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
            View view = inflater.Inflate(Resource.Layout.Fragment1, container, false);
            mContent = view.FindViewById<ListView>(Resource.Id.frg1Content);

            //Creating a webclient
            mClient = new WebClient();
            mUrl = new Uri("http://android-sql-dunderboy.c9users.io/GetTournaments.php");
            //mUrl = new Uri("http://android-sql-dunderboy.c9users.io/override.php");

            //Communication to php
            mClient.DownloadDataAsync(mUrl);
            mClient.DownloadDataCompleted += MClient_DownloadDataCompleted;

            return view;
        }

        private void MClient_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e) {
            Activity.RunOnUiThread(() => {
                string json = Encoding.UTF8.GetString(e.Result);
                mTournaments = JsonConvert.DeserializeObject<List<Tournament>>(json);
                mAdapter = new TournamentListAdapter(Activity, Resource.Layout.tournament_row, mTournaments);
                //mMatch = JsonConvert.DeserializeObject<List<Match>>(json);
                //mAdapter = new MatchListAdapter(Activity, Resource.Layout.match_row, mMatch);
                mContent.Adapter = mAdapter;
            });
        }
    }
}