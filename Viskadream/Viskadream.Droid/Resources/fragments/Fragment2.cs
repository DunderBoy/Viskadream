using Android.OS;
using Android.Views;
using Android.Support.V4.App;

namespace Viskadream.Droid {
    public class Fragment2 : Fragment {
        public override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
            View view = inflater.Inflate(Resource.Layout.Fragment2, container, false);

            return view;
        }
    }
}