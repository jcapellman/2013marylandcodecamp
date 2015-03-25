using System;
using System.Collections.Generic;
using System.ComponentModel;

using jcBENCH2.library.jcBENCHResultServiceReference;

namespace jcBENCH2.library.ViewModels {
    public class MainModel<T> : INotifyPropertyChanged where T : Interfaces.IDevice, new() {
        public List<jcBENCH2.library.jcBENCHResultServiceReference.TopResultItem> TopResultsList { get; set; }

        public T DeviceInfo { get; private set; }

        public MainModel() {
            DeviceInfo = new T();
            GetTopResults();
        }

        #region Get Top Results
        public void GetTopResults() {
            var ws = new jcBENCH2.library.jcBENCHResultServiceReference.ResultServiceClient();

            ws.GetTopResultsCompleted += ws_GetTopResultsCompleted;

            ws.GetTopResultsAsync(jcBENCH2.library.Common.Constants.NUM_ITEMS_TO_RETURN);
        }

        void ws_GetTopResultsCompleted(object sender, GetTopResultsCompletedEventArgs e) {
 	        TopResultsList = e.Result;

            NotifyPropertyChanged("TopResultsList");
        }
        #endregion

        #region Benchmark Run | Submit
        public void RunBenchmark() {
            var benchmark = new Benchmark();

            var score = benchmark.Run();

            submitResult(DeviceInfo.CPUName, score);
        }

        private void submitResult(string deviceName, int score) {
            var ws = new jcBENCH2.library.jcBENCHResultServiceReference.ResultServiceClient();

            ws.SubmitResultCompleted += ws_SubmitResultCompleted;
            ws.SubmitResultAsync(new SubmitResultItem { DeviceName = deviceName, Score = score, TimeOfBenchmark = DateTime.Now });            
        }

        private void ws_SubmitResultCompleted(object sender, SubmitResultCompletedEventArgs e) {
            GetTopResults();

            NotifyPropertyChanged("BENCHMARK_COMPLETED");
        }
        #endregion

        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}