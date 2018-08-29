using PagedList;
using schedule.com.Controllers.Base;
using schedule.data.erps.his;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace schedule.com.Controllers.BHXH
{
    public class BHXHController : BaseController
    {
        // GET: BHXH
        public ActionResult Index(int page = 1, int pagesize = 20)
        {
            SetPageInfo(page, pagesize);
            using (HIS_BENHNHAN benhnhan = new HIS_BENHNHAN())
            {
                var data = benhnhan.GetFilter().ToPagedList(page, pagesize);
                return View(data);
            }
        }
        public void Message(string key)
        {
            Response.ContentType = "text/event-stream";
            var obj = BHXH.process.FirstOrDefault(p1 => p1.Key == key);
            var p = obj.Value;
            int percent = 0;
            while (percent < 100)
            {
                BHXH.process.TryGetValue(key, out percent);
                Response.Write(string.Format("data: {0}\n\n",  percent));
                Response.Flush();
                System.Threading.Thread.Sleep(100);
            }
            BHXH.process.Remove(key);
            Response.Close();
        }
        [HttpPost]
        public JsonResult xulydulieu(List<int> data)
        {
            BHXH model = new BHXH();
            string key = Guid.NewGuid().ToString();
            model.Processing(key, data).GetAwaiter();
            return Json(new { processId = key, data = data }, JsonRequestBehavior.AllowGet);
        }
    }
    public class BHXH
    {
        public static Dictionary<string, int> process = new Dictionary<string, int>();
        public async Task Processing(string key, List<int> array)
        {
            await Task.Run(() => {
                process.Add(key, 0);
                for (int i = 0; i < array.Count; i++)
                {
                    //process
                    int percent = Convert.ToInt32((i + 1) / Convert.ToDecimal(array.Count) * 100);
                    process[key] = percent;
                    int p = process[key];
                    System.Threading.Thread.Sleep(100);
                }
            });

        }
    }
}