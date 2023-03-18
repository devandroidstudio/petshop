using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace petstore.Models
{
    public class HomeModel
    {
        public List<SanPham> ListProduct { get; set; }
        public List<DanhMuc> ListCategory { get; set; }
    }
}