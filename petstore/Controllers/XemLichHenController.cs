using petstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace petstore.Controllers
{
    public class XemLichHenController : Controller
    {
        // GET: XemLichHen
        MyDataDataContext data = new MyDataDataContext();

       
        public ActionResult Index()
        {
            var all_danhmuc = from dv in data.DichVus
                              join kh in data.KhachHangs on dv.makh equals kh.makh
                              where kh.tendangnhap == Session["Username"]
                              select dv;

            return View(all_danhmuc);
        }


        public ActionResult HuyDichVu(int id)
        {
            var D_sach = data.DichVus.First(m => m.iddichvu == id);
            return View(D_sach);
        }
        [HttpPost]
        public ActionResult HuyDichVu(int id, FormCollection collection)
        {
            try
            {
                var D_danhmuc2 = data.DichVus.Where(m => m.iddichvu == id).First();

                if (D_danhmuc2.trangthai == "đang chờ")
                {

                    data.DichVus.DeleteOnSubmit(D_danhmuc2);
                    data.SubmitChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["thongbao1"] = "<script>alert('Đã tiếp nhận thông tin khách hàng không được xóa');</script>";

                    return RedirectToAction("Index");
                }
            }
            catch (Exception e) { return View("Error" + e); }


        }
    }
}