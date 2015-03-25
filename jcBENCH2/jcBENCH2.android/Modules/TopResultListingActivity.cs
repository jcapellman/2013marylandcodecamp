using System;
using System.Collections.Generic;
using System.Text;
using Android.App;
using Android.Widget;
using jcBENCH2.android.Helpers;
using jcBENCH2.library.ViewModels;

namespace jcBENCH2.android.Modules {
    [Activity]
    public class TopResultListingActivity : Activity {
        TopResultListingAdapter _listAdapter;
        private bool _initialLoad = true;
        protected override void OnResume() {
            base.OnResume();

            SetContentView(Resource.Layout.TopResultListing);

            ViewModel.MainModel.PropertyChanged += MainModel_PropertyChanged;

            ViewModel.MainModel.GetTopResults();
        }

        void MainModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            switch (e.PropertyName) {
                case "TopResultsList":
                    RunOnUiThread(LoadData);
                    break;
            }
        }

        public void LoadData() {
            SetContentView(Resource.Layout.TopResultListing);

            var lstView = FindViewById(Resource.Id.lvTopResultListing) as ListView;

            _listAdapter = new TopResultListingAdapter(this, ViewModel.MainModel.TopResultsList);

            lstView.Adapter = _listAdapter;
            lstView.EmptyView = FindViewById<TextView>(Resource.Id.tvTopResultListingEmpty);
        }
    }
}
