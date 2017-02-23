using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeChatAnalyse.Models;

namespace WeChatAnalyse.Controllers
{
    public class DataAnalyseController : Controller
    {
        WeChartContex DataBase = new WeChartContex();
        //
        // GET: /DataAnalyse/
        
        public ActionResult AnalyseForSex()
        {
     
            int ManCount = DataBase.Fridens.Where(f => f.Sex == 1).Count();
            int WoManCount = DataBase.Fridens.Where(f => f.Sex == 2).Count();
            int OthersCount = DataBase.Fridens.Where(f => f.Sex == 0).Count();
            ViewData["man"] = ManCount;
            ViewData["woman"] = WoManCount;
            ViewData["other"] = OthersCount;
            return View();
        }
        public ActionResult AnalyseforProvince()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Province()
        {
            string sql = "select province as name, count(*) as value from Friends group by province";
          List<Province> list=  DataBase.Database.SqlQuery<Province>(sql).ToList();
          return Json(list);
        }
	}
}