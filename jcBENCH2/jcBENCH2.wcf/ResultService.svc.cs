using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using jcBENCH2.wcf.Objects;
using TopResultItem = jcBENCH2.wcf.Objects.TopResultItem;

namespace jcBENCH2.wcf {
    public class ResultService : IResultService {
        public List<TopResultItem> GetTopResults(int numberResults = 10) {
            using (var jEntities = new jcBENCH2.datalayer.Entities.CodeCamp_jcBenchEntities()) {
                return jEntities.getTopResults(numberResults).Select(a => new TopResultItem(deviceName: a.DeviceName, score: a.Score, dateOfBenchmark: a.Created)).ToList();
            }
        }

        public bool SubmitResult(SubmitResultItem resultItem) {
            try {
                using (var jEntities = new jcBENCH2.datalayer.Entities.CodeCamp_jcBenchEntities()) {
                    var newResult = jEntities.BenchmarkResults.Create();

                    newResult.Active = true;
                    newResult.Created = resultItem.TimeOfBenchmark;
                    newResult.Modified = DateTime.Now;
                    newResult.DeviceName = resultItem.DeviceName;
                    newResult.Score = resultItem.Score;

                    jEntities.BenchmarkResults.Add(newResult);
                    jEntities.SaveChanges();

                    return true;
                }
            } catch (Exception ex) {
                // Notify someone here

                return false;
            }
        }
    }
}