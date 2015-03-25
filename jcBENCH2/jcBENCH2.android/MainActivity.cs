using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using jcBENCH2.android.Helpers;
using jcBENCH2.library.ViewModels;

namespace jcBENCH2.android {
    [Activity(Label = "jcBENCH2", MainLauncher = true, Icon = "@drawable/Icon")]
    public class MainActivity : TabActivity {        
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            RequestedOrientation = ScreenOrientation.Portrait;

            SetContentView(Resource.Layout.Main);

            ViewModel.MainModel = new MainModel<Device>();
            ViewModel.MainModel.PropertyChanged += MainModel_PropertyChanged;
            var intent = new Intent(this, typeof(Modules.TopResultListingActivity));
            intent.AddFlags(ActivityFlags.NewTask);

            var spec = TabHost.NewTabSpec("topresults");

            spec.SetIndicator("Top Results");
            spec.SetContent(intent);

            TabHost.AddTab(spec);
            
            intent = new Intent(this, typeof(Modules.DeviceInfoActivity));
            intent.AddFlags(ActivityFlags.NewTask);

            spec = TabHost.NewTabSpec("deviceinfo");
            spec.SetIndicator("Device Info");
            spec.SetContent(intent);
            TabHost.AddTab(spec);
            
            TabHost.CurrentTab = 0;
        }

        #region Alert Dialog
        private void showBenchmarkComplete() {
            var adb = new AlertDialog.Builder(this);
            adb.SetPositiveButton("OK", delegate { });
            adb.SetMessage("Benchmark Complete");
            adb.Show();
        }
        #endregion

        void MainModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            switch (e.PropertyName) {
                case "BENCHMARK_COMPLETED":
                    RunOnUiThread(showBenchmarkComplete);
                    break;
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu) {
            menu.Add(0, 1, 1, "Run Benchmark");
            menu.Add(0, 2, 2, "About");            

            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item) {
            switch (item.TitleFormatted.ToString()) {
                case "Run Benchmark":
                    ViewModel.MainModel.RunBenchmark();
                    break;
            }

            return true;
        }
    }
}