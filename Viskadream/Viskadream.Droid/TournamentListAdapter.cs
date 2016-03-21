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
            row.FindViewById<TextView>(Resource.Id.txtScore1).Text = mTournaments[position].score1.ToString();
            row.FindViewById<TextView>(Resource.Id.txtScore2).Text = mTournaments[position].score2.ToString();

            return row;
        }

    }
}