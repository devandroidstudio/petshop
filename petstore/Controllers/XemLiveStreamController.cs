using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using petstore.Models;
namespace petstore.Controllers
{
    public class XemLiveStreamController : Controller
    {
        // GET: XemLiveStream

        public ActionResult Index()
        {
            MyDataDataContext data = new MyDataDataContext();
            var D_sach = data.LiveStreams.OrderByDescending(a => a.idLiveStream).ToList();
            return View(D_sach);
        }
    }
}