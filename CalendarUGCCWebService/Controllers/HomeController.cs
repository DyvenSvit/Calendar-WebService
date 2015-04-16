using CalendarUGCCWebService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CalendarUGCCWebService.Models.Pray;
using MongoDB.Driver;

namespace CalendarUGCCWebService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            //var day = new Day();
            //var year = new Year(2015);

            //var pray = new Pray();
            var praytype = new PrayType();
            //string json = JsonConvert.SerializeObject(pray, Formatting.Indented,
                            //new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            //var tmp = new Vechirnya();

            return View();
        }
    }
}
