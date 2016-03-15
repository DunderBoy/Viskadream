using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Widget;
using Android.Net;

namespace Viskadream.Droid {
    public class Fragment2 : Fragment {
        private VideoView mPlayer;
        private Uri mUrl;
        private Button mPlayerPause;

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

            return view;
        }

        private void MPlayerPause_Touch(object sender, View.TouchEventArgs e) {
            if (mPlayer.IsPlaying)
                mPlayer.Pause();
            else
                mPlayer.Start();
        }
    }
}