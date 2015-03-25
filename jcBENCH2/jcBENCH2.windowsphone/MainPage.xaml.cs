using System;
using System.Windows;
using Microsoft.Phone.Controls;

namespace jcBENCH2.windowsphone {
    public partial class MainPage : PhoneApplicationPage {
        private jcBENCH2.library.ViewModels.MainModel<Helpers.Device> ViewModel {
            get {
                return (jcBENCH2.library.ViewModels.MainModel<Helpers.Device>) DataContext;
            }
        }

        public MainPage() {
            InitializeComponent();

            DataContext = new jcBENCH2.library.ViewModels.MainModel<Helpers.Device>();

            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            switch (e.PropertyName) {
                case "BENCHMARK_COMPLETED":
                    MessageBox.Show("Benchmark Complete");

                    break;
            }
        }

        private void BtnRun_OnClick(object sender, EventArgs e) {
           ViewModel.RunBenchmark();
        }
    }
}