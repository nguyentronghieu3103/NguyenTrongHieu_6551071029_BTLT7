using System;

namespace Bai4.Models
{
    public class LichKhamViewModel
    {
        public int MaLich { get; set; }
        public string TenBenhNhan { get; set; } = string.Empty;
        public string Sdt { get; set; } = string.Empty;
        public string NgayKham { get; set; } = string.Empty;
        public string GioKham { get; set; } = string.Empty;
        public string BacSi { get; set; } = string.Empty;
        public string ChuyenKhoa { get; set; } = string.Empty;
        public string TrangThai { get; set; } = string.Empty;

        // Lưu thông tin gốc để khi click dòng có thể đổ ngược vào controls
        public DateOnly? NgayKhamRaw { get; set; }
        public TimeOnly? GioKhamRaw { get; set; }
        public int? MaBs { get; set; }
    }
}
