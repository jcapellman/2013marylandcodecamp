using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace jcBENCH2.mvc.Controllers {
    public class HomeController : Controller {
        private async Task<List<jcBENCH2.library.jcBENCHResultServiceReference.TopResultItem>> getResults() {
            var ws = new jcBENCH2.library.jcBENCHResultServiceReference.ResultServiceClient();

            return await ws.GetTopResultsAsync(10);
        } 

        public async Task<ActionResult> Index() {
            var model = new Models.ResultModel();

            var ws = new jcBENCH2.library.jcBENCHResultServiceReference.ResultServiceClient();

            ws.GetTopResultsCompleted += (sender, evt) => {
                                             model.TopResultItems = evt.Result;
                                         };

            ws.GetTopResultsAsync(jcBENCH2.library.Common.Constants.NUM_ITEMS_TO_RETURN);
         
            return View(model);
        }
    }
}
