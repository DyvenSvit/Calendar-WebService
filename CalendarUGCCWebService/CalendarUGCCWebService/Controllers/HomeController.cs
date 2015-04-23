using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CalendarUGCCWebService.Models.Calendar;
using CalendarUGCCWebService.Models.Pray;

namespace CalendarUGCCWebService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            //var day = new Day(new DateTime(2016,05,01), true);
            var year = new Year(2016,true);

            //var pray = new Pray();
            //var pray = new Pray(day);
            //string json = JsonConvert.SerializeObject(pray, Formatting.Indented,
                            //new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            //var tmp = new Vechirnya();
            //var ttt =  MongoDb.GetEntityList<PrayType>();

            //var r = PrayTypes.List;


            return View();
        }
    }
}
