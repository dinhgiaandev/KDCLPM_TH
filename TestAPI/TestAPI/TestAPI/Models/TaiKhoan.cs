using System;
using System.Collections.Generic;

#nullable disable

namespace TestAPI.Models
{
    public partial class TaiKhoan
    {
        public string TenDn { get; set; }
        public int? MaNv { get; set; }
        public string MatKhau { get; set; }

        public virtual NhanVien MaNvNavigation { get; set; }
    }
}
