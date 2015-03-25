using System;
using System.Collections.Generic;
using System.Text;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using jcBENCH2.android.Helpers;

namespace jcBENCH2.android.Modules {
    [Activity]
    public class DeviceInfoActivity : Activity {
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            RequestedOrientation = ScreenOrientation.Portrait;

            SetContentView(Resource.Layout.DeviceInfo);

            var device = new Device();

            var manufacturer = FindViewById<TextView>(Resource.Id.tvManufacturer);
            manufacturer.Text = device.Manufacturer;

            var modelName = FindViewById<TextView>(Resource.Id.tvModelName);
            modelName.Text = device.Name;

            var cpuArchitectureName = FindViewById<TextView>(Resource.Id.tvCPUArchitectureName);
            cpuArchitectureName.Text = device.CPUArchitecture;

            var cpuCount = FindViewById<TextView>(Resource.Id.tvCPUCount);
            cpuCount.Text = device.CPUCount.ToString();
        }
    }
}