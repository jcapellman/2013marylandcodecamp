using System.Collections.Generic;
using System.ServiceModel;

using TopResultItem = jcBENCH2.wcf.Objects.TopResultItem;

namespace jcBENCH2.wcf {
    [ServiceContract]
    public interface IResultService {
        [OperationContract]
        List<TopResultItem> GetTopResults(int numberResults = 10);

        [OperationContract]
        bool SubmitResult(Objects.SubmitResultItem resultItem);
    }
}