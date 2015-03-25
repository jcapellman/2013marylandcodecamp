namespace jcBENCH2.windowsphone.Helpers {
    public class Device : jcBENCH2.library.Interfaces.IDevice {
        private readonly jcWPLIBRARY.Info.Device _device;

        public Device() {
            _device = new jcWPLIBRARY.Info.Device();    
        }

        public string Manufacturer {
            get {
                return _device.Manufacturer;
            }
        }

        public string CPUName {
            get {
                return _device.CPUName;
            }
        }

        public int CPUCount {
            get {
                return 2;
            }
        }

        public string CPUArchitecture {
            get {
                return "ARM";
            }
        }

        public string Name {
            get {
                return _device.Name;
            }
        }

        public string GPUName {
            get {
                return _device.GPUName;
            }
        }

        public string TotalMemory {
            get {
                return _device.TotalMemory;
            }
        }

        public string Firmware {
            get {
                return _device.Firmware;
            }
        }

        public string HardwareVersion {
            get {
                return _device.HardwareVersion;
            }
        }
    }
}