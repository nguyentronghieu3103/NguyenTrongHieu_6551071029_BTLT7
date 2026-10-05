using System.Drawing;

namespace Bai3.Models
{
    public class PhongViewModel
    {
        public int MaPhong { get; set; }
        public Image? HinhAnh { get; set; }
        public string? TenHinhAnh { get; set; }
        public string SoPhong { get; set; } = string.Empty;
        public int? TangSo { get; set; }
        public string TenLoai { get; set; } = string.Empty;
        public decimal? GiaMoiDem { get; set; }
        public string TinhTrang { get; set; } = string.Empty;
        public int? MaLoai { get; set; }
    }
}
