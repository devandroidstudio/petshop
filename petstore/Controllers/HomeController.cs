using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using petstore.Models;

namespace petstore.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection, DichVu dv)
        {
            MyDataDataContext data = new MyDataDataContext();
            var ten = collection["hoten"];
            var email = collection["email"];
            var sdt = collection["sdt"];
            var diachi = collection["diachi"];
            var loaidv = collection["loaidv"];
            var ngaydat = DateTime.Parse(collection["ngaydat"]);

            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            else
            {
                if (string.IsNullOrEmpty(ten))
                {
                    ViewData["Error"] = "Du lieu khong duoc de trong!";
                }
                else
                {

                    var tendn = Session["Username"];
                    var E_sach2 = data.KhachHangs.FirstOrDefault(m => m.tendangnhap == tendn);

                    if (E_sach2 != null)
                    {
                        dv.makh = E_sach2.makh;
                    }

                    dv.hoten = ten;
                    dv.email = email;
                    dv.sdt = sdt;
                    dv.diachi = diachi;
                    dv.trangthai = "đang chờ";
                    dv.tendichvu = loaidv;
                    dv.ngaydat = ngaydat;
                    data.DichVus.InsertOnSubmit(dv);
                    data.SubmitChanges();


                    return RedirectToAction("Index");
                }
            }


            return this.Index();
        }


    }
}