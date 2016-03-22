using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace Viskadream.Droid {
    class MatchListAdapter : BaseAdapter<Match> {
        private Context mContext;
        private int mLayout;
        private List<Match> mMatches;

        //Object Variables
        //private TextView mMatchName;
        //private TextView mScore1;
        //private TextView mScore2;
        //private TextView mDivider;

        public MatchListAdapter(Context context, int layout, List<Match> match) {
            mContext = context;
            mLayout = layout;
            mMatches = match;
        }

        public override Match this[int position] {
            get { return mMatches[position]; }
        }

        public override int Count {
            get { return mMatches.Count(); }
        }

        public override long GetItemId(int position) {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent) {
            View row = convertView;

            if (row == null)
                row = LayoutInflater.From(mContext).Inflate(mLayout, parent, false);

            //Colors
            var Gray = Android.Graphics.Color.Gray;
            //References to textviews in layout
            var relMatchLayout = row.FindViewById<LinearLayout>(Resource.Id.relMatchLayout);
            var mMatchName = row.FindViewById<TextView>(Resource.Id.txtMatchName);
            var mScore1 = row.FindViewById<TextView>(Resource.Id.txtScore1);
            var mScore2 = row.FindViewById<TextView>(Resource.Id.txtScore2);
            var mDivider = row.FindViewById<TextView>(Resource.Id.txtScoreDivider);
            //Reference score in match
            int score1 = mMatches[position].score1;
            int score2 = mMatches[position].score2;

            //Place text in all TextViews.
            mMatchName.Text = mMatches[position].Name;
            mScore1.Text = mMatches[position].score1.ToString();
            mScore2.Text = mMatches[position].score2.ToString();

            //Set scoredivider debending of score ratio.
            if (score1 > score2)
                mDivider.Text = ">";
            else if (score1 < 2)
                mDivider.Text = "<";
            else
                mDivider.Text = "=";

            //If matchNr is odd change background color!
            if (mMatches[position].matchNr % 2 != 0)
                relMatchLayout.SetBackgroundColor(Gray);

            return row;
        }
    }
}