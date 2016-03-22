using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace Viskadream.Droid {
    class TournamentListAdapter : BaseAdapter<Tournament> {
        private Context mContext;
        private int mLayout;
        private List<Tournament> mTournaments;

        public TournamentListAdapter(Context context, int layout, List<Tournament> tournament) {
            mContext = context;
            mLayout = layout;
            mTournaments = tournament;
        }

        public override Tournament this[int position] {
            get { return mTournaments[position]; }
        }

        public override int Count {
            get { return mTournaments.Count; }
        }

        public override long GetItemId(int position) {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent) {
            View row = convertView;

            if (row == null)
                row = LayoutInflater.From(mContext).Inflate(mLayout, parent, false);

            row.FindViewById<TextView>(Resource.Id.txtName).Text = mTournaments[position].Name;

            return row;
        }
    }
}