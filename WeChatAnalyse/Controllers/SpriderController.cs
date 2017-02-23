using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeChatAnalyse.Models;

namespace WeChatAnalyse.Controllers
{
    public class SpriderController : Controller
    {
        WeChartContex context = new WeChartContex();
        //
        // GET: /Sprider/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetFridendInformation()
        {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://wx.qq.com/cgi-bin/mmwebwx-bin/webwxgetcontact?r=1480564845349&seq=0&skey=@crypt_20089e09_d38ecc170f273d2db91833e793677276");
            request.Method = "get";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:49.0) Gecko/20100101 Firefox/49.0";
            request.Referer = "https://wx.qq.com/";
           
            request.Headers.Add("Cookie", "pgv_pvi=1499432960; pt2gguin=o1694675518; RK=aptzZsSyPP; ptcz=b74e1fb9d8ae59f25d51418c79b5352528aa033b0a4b849017965cf95107a9f1; wxuin=2922609112; webwxuvid=f7235d1630200f2f1f67b21cc9dfa26090cf59625838b4f781cf2ca9755bcd75d940fb7af2627b5506b3ff88f433f4b7; webwx_auth_ticket=CIsBENXploILGoABvGbBitQi5uGvukaHSAXbE98Uka4Ojs7KP/nDotPnr8FHV4d38NEni+OLWB3bGx1pstKrZH4kkErrYAlgT9aeRrZ09QM2URG2D1w4CmQukiqTNyg0JZygzlcZg+xJRU2lh0qLR06DRRxBChePL524b3FtR50H/7+TYqRZATgllbc=; mm_lang=zh_CN; MM_WX_NOTIFY_STATE=1; MM_WX_SOUND_STATE=1; pgv_si=s7972417536; wxsid=tjF6UrJ2RcvNH76H; wxloadtime=1480564533_expired; webwx_data_ticket=gSfR9g9aXZPGpInCl5dt6JCr; wxpluginkey=1480551842");
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                 Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                Respone responsefronserver = JsonHelper.DeserializeToObject<Respone>(responseFromServer);
                foreach (var item in responsefronserver.MemberList)
                {
                    if (item.VerifyFlag == 0) context.Fridens.Add(item);
                }
                if (context.SaveChanges() > 0)
                {
                    return Content("ok");
                }
            }
            return Content("fail");
        }
  
    }
}