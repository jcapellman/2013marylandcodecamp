using System;
using System.Collections.Generic;
using System.Text;

namespace jcBENCH2.android.Helpers {
    public class Device : jcBENCH2.library.Interfaces.IDevice {
        public string Manufacturer {
            get {
                return Android.OS.Build.Manufacturer;
            }
        }

        public string CPUName {
            get {
                return "Unknown Android CPU";
            }
        }

        public string Name {
            get {
                return Android.OS.Build.Hardware;
            }
        }

        public int CPUCount {
            get {
                return Java.Lang.Runtime.GetRuntime().AvailableProcessors();
            }
        }

        public string CPUArchitecture {
            get {
                return Android.OS.Build.CpuAbi;
            }
        }
    }
}
