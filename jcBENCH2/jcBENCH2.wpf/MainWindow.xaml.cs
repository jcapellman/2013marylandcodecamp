using System;
using System.Windows;

namespace jcBENCH2.wpf {
    public partial class MainWindow : MahApps.Metro.Controls.MetroWindow {
        private jcBENCH2.library.ViewModels.MainModel<Helpers.Device> ViewModel {
            get {
                return (jcBENCH2.library.ViewModels.MainModel<Helpers.Device>)DataContext;
            }
        }

        public MainWindow() {
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

        private void BtnRun_OnClick(object sender, RoutedEventArgs e) {
            ViewModel.RunBenchmark();
        }
    }
}