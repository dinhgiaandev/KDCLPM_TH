using System;
using System.Collections.Generic;

#nullable disable

namespace TestAPI.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            DonHangs = new HashSet<DonHang>();
            TaiKhoans = new HashSet<TaiKhoan>();
        }

        public int MaNv { get; set; }
        public string TenNv { get; set; }
        public short? Quyen { get; set; }

        public virtual ICollection<DonHang> DonHangs { get; set; }
        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
    }
}
