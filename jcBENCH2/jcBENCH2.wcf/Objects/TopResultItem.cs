using System;
using System.Runtime.Serialization;

namespace jcBENCH2.wcf.Objects {
    [DataContract]
    public class TopResultItem {
        [DataMember]
        public string DeviceName { get; set; }

        [DataMember]
        public int Score { get; set; }

        [DataMember]
        public DateTime DateOfBenchmark { get; set; }
 
        public TopResultItem() { }

        public TopResultItem(string deviceName, int score, DateTime dateOfBenchmark) {
            DeviceName = deviceName;
            Score = score;
            DateOfBenchmark = dateOfBenchmark;
        }
    }
}
