using petstore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace petstore.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult GetData()
        {
            var results = data.KhachHangs.ToList();
            return Json(new { Data = results, TotalItems = results.Count }, JsonRequestBehavior.AllowGet);
        }
    }
}
