using System;
using System.Collections.Generic;
using System.Text;
using Android.App;
using Android.Views;
using Android.Widget;

namespace jcBENCH2.android.Modules {
     class TopResultListingAdapter : BaseAdapter {
        readonly Activity _context;

        public List<jcBENCH2.library.jcBENCHResultServiceReference.TopResultItem> items;

        public TopResultListingAdapter(Activity context, List<jcBENCH2.library.jcBENCHResultServiceReference.TopResultItem> items) : base() {
            _context = context;

            this.items = items;
        }

        public override int Count {
            get { return items.Count; }
        }

        public override Java.Lang.Object GetItem(int position) {
            return position;
        }

        public override long GetItemId(int position) {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent) {
            var item = items[position];

            var view = (convertView ??
                _context.LayoutInflater.Inflate(
                    Resource.Layout.TopResultItem,
                    parent,
                    false));

            var tvDate = view.FindViewById(Resource.Id.tvDateOfBenchmark) as TextView;
            var tvScore = view.FindViewById(Resource.Id.tvScore) as TextView;
            var tvDevice = view.FindViewById(Resource.Id.tvDeviceName) as TextView;

            tvDevice.Text = item.DeviceName;
            tvScore.Text = item.Score.ToString();
            tvDate.Text = item.DateOfBenchmark.ToString();

            view.Clickable = false;
            view.Focusable = false;
            
            return view;
        }

    }
}
