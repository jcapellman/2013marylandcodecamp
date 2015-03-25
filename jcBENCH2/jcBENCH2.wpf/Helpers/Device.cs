using System;
using Microsoft.Win32;

namespace jcBENCH2.wpf.Helpers {
    public class Device : jcBENCH2.library.Interfaces.IDevice {
        public string Manufacturer {
            get {
                var RegKey = Registry.LocalMachine;

                RegKey = RegKey.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0");

                if (RegKey == null) {
                    return "Unknown";
                }

                switch (RegKey.GetValue("VendorIdentifier").ToString()) {
                    case "AuthenticAMD":
                        return "AMD";
                    case "GenuineIntel":
                        return "Intel";
                    default:
                        return "Unknown";
                }
            }
        }

        public string CPUName {
            get {
                return System.Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");
            }
        }

        public int CPUCount {
            get {
                return Environment.ProcessorCount;
            }
        }

        public string CPUArchitecture {
            get {
                return System.Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
            }
        }

        public string CPUSpeed {
            get {
                var RegKey = Registry.LocalMachine;
                
                RegKey = RegKey.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0");
                
                return String.Format("{0} mhz", RegKey.GetValue("~MHz"));
            }
        }
    }
}
