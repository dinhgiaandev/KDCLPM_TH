using System;
using System.Collections.Generic;

#nullable disable

namespace TestAPI.Models
{
    public partial class DonHang
    {
        public DonHang()
        {
            Ctdhs = new HashSet<Ctdh>();
        }

        public int MaDh { get; set; }
        public int? MaNv { get; set; }
        public DateTime? NgayTao { get; set; }

        public virtual NhanVien MaNvNavigation { get; set; }
        public virtual ICollection<Ctdh> Ctdhs { get; set; }
    }
}
