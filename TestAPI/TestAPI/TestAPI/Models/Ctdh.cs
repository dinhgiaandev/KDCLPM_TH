using System;
using System.Collections.Generic;

#nullable disable

namespace TestAPI.Models
{
    public partial class Ctdh
    {
        public int MaSp { get; set; }
        public int MaDh { get; set; }
        public int? Sl { get; set; }
        public decimal? GiaBan { get; set; }
        public double? GiamGia { get; set; }

        public virtual DonHang MaDhNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
