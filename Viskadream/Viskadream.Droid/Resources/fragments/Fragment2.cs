using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Widget;
using Android.Net;
using System.Net;
using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
//using System;

namespace Viskadream.Droid {
    public class Fragment2 : Fragment {
        private Button mPlayerPause;
        private VideoView mPlayer;
        private Android.Net.Uri mUrl;
        private WebClient mClient;
        private System.Uri mWebUrl;
        private List<WebToken> mAccessToken;

        public override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
            View view = inflater.Inflate(Resource.Layout.Fragment2, container, false);
            mPlayerPause = view.FindViewById<Button>(Resource.Id.btnPlayerPause);
            mPlayerPause.Touch += MPlayerPause_Touch;
            mPlayer = view.FindViewById<VideoView>(Resource.Id.TwitchPlayer);
            mUrl = Android.Net.Uri.Parse("http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4");
            mPlayer.SetVideoURI(mUrl);
            mPlayer.Start();

            //getTwitchToken();

            //Get Twitch Token
            //mClient = new WebClient();
            //mWebUrl = new System.Uri("http://api.twitch.tv/api/channels/viskadream/access_token");


            return view;
        }

        private string getTwitchToken() {
            string res = "string";

            mClient = new WebClient();
            mWebUrl = new System.Uri("http://api.twitch.tv/api/channels/viskadream/access_token");
            mClient.DownloadDataAsync(mWebUrl);
            mClient.DownloadDataCompleted += MClient_DownloadDataCompleted;

            return res;

        }

        private void MClient_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e) {
            Activity.RunOnUiThread(() => {
                string json = Encoding.UTF8.GetString(e.Result);
                //Desterialze "json" into a JsonArray

                //TODO
                //Get Access token
                Console.WriteLine(mAccessToken); 
            });
        }

        private void MPlayerPause_Touch(object sender, View.TouchEventArgs e) {
            if (mPlayer.IsPlaying)
                mPlayer.Pause();
            else
                mPlayer.Start();
        }
    }
}