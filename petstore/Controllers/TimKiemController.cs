using System;
using petstore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace petstore.Controllers
{
    public class TimKiemController : Controller
    {
        // GET: Student
        MyDataDataContext data = new MyDataDataContext();

        [HttpGet]
        public ActionResult TimKiem(int? page, string search)
        {
            if (page == null) page = 1;
            var lstSP = data.SanPhams.Where(n => n.tensp.Contains(search));
            int pageSize = 5;
            int pageNum = page ?? 1;


            ViewBag.Search = search;

            return View(lstSP.ToPagedList(pageNum, pageSize));
        }

        public ActionResult KQ(int? page, string search, string searchby)
        {
            if (page == null) page = 1;

            int pageSize = 5;
            int pageNum = page ?? 1;

            if (searchby == "giakm")
            {
                var tblProduct = data.SanPhams.Where(n => n.giakhuyenmai.ToString().Contains(search));
                ViewBag.Search = search;
                ViewBag.Searchby = searchby;
                return View(tblProduct.ToPagedList(pageNum, pageSize));
            }
            else if (searchby == "danhmuc")
            {
                var tblProduct = data.SanPhams.Where(n => n.idDanhmuc.ToString().Contains(search));
                ViewBag.Search = search;
                ViewBag.Searchby = searchby;
                return View(tblProduct.ToPagedList(pageNum, pageSize));
            }
            else
            {
                var tblProduct = data.SanPhams.Where(n => n.tensp.Contains(search));
                ViewBag.Search = search;
                ViewBag.Searchby = searchby;
                return View(tblProduct.ToPagedList(pageNum, pageSize));

            }

        }

    }
}