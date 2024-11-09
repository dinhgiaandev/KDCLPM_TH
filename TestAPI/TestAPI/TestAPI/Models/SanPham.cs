using System;
using System.Collections.Generic;

#nullable disable

namespace TestAPI.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            Ctdhs = new HashSet<Ctdh>();
        }

        public int MaSp { get; set; }
        public string TenSp { get; set; }
        public int? Sl { get; set; }
        public decimal? GiaMua { get; set; }

        public virtual ICollection<Ctdh> Ctdhs { get; set; }
    }
}
