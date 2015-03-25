using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace jcBENCH2.wcf.Objects {
    [DataContract]
    public class SubmitResultItem {
        [DataMember]
        public string DeviceName { get; set; }

        [DataMember]
        public int Score { get; set; }

        [DataMember]
        public DateTime TimeOfBenchmark { get; set; }

        public SubmitResultItem(string deviceName, int score, DateTime timeOfBenchmark) {
            DeviceName = deviceName;
            Score = score;
            TimeOfBenchmark = timeOfBenchmark;
        }
    }
}