using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Bai2.Models;

namespace Bai2
{
    public partial class Form1 : Form
    {
        // Chuỗi kết nối đến SQL Server (Tùy chỉnh nếu tên Server hoặc DB của bạn khác)
        private const string ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=QuanLyPhongGym;Integrated Security=True;TrustServerCertificate=True";

        private int? _selectedMaHv = null;

        public Form1()
        {
            InitializeComponent();
        }

        private QuanLyPhongGymContext GetContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<QuanLyPhongGymContext>();
            optionsBuilder.UseSqlServer(ConnectionString);
            return new QuanLyPhongGymContext(optionsBuilder.Options);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            ResetInputs();
            cboTimKiemHang.SelectedIndex = 0; // "-- Tất cả --"
            await LoadDataAsync();
        }

        private async Task LoadDataAsync(string keyword = "", string hangLoc = "")
        {
            try
            {
                using var context = GetContext();
                var query = context.HoiViens.AsQueryable();

                // 4. Tìm kiếm kết hợp 2 điều kiện: Họ tên VÀ Hạng thành viên (LINQ &&)
                bool hasKeyword = !string.IsNullOrWhiteSpace(keyword);
                bool hasHang = !string.IsNullOrWhiteSpace(hangLoc) && hangLoc != "-- Tất cả --";

                if (hasKeyword && hasHang)
                {
                    query = query.Where(hv => hv.HoTen.Contains(keyword) && hv.HangThanhVien == hangLoc);
                }
                else if (hasKeyword)
                {
                    query = query.Where(hv => hv.HoTen.Contains(keyword));
                }
                else if (hasHang)
                {
                    query = query.Where(hv => hv.HangThanhVien == hangLoc);
                }

                var list = await query.OrderByDescending(hv => hv.MaHv)
                    .Select(hv => new
                    {
                        hv.MaHv,
                        hv.HoTen,
                        GioiTinh = hv.GioiTinh == true ? "Nam" : "Nữ",
                        NgaySinh = hv.NgaySinh.HasValue ? hv.NgaySinh.Value.ToString("dd/MM/yyyy") : "",
                        hv.Sdt,
                        hv.HangThanhVien,
                        TrangThai = hv.TrangThai == true ? "Đang hoạt động" : "Tạm ngưng",
                        hv.Email,
                        hv.NgayDangKy
                    })
                    .ToListAsync();

                dgvHoiVien.DataSource = list;

                // Cấu hình tiêu đề cột hiển thị
                if (dgvHoiVien.Columns.Count > 0)
                {
                    if (dgvHoiVien.Columns["MaHv"] != null) dgvHoiVien.Columns["MaHv"]!.HeaderText = "Mã HV";
                    if (dgvHoiVien.Columns["HoTen"] != null) dgvHoiVien.Columns["HoTen"]!.HeaderText = "Họ tên";
                    if (dgvHoiVien.Columns["GioiTinh"] != null) dgvHoiVien.Columns["GioiTinh"]!.HeaderText = "Giới tính";
                    if (dgvHoiVien.Columns["NgaySinh"] != null) dgvHoiVien.Columns["NgaySinh"]!.HeaderText = "Ngày sinh";
                    if (dgvHoiVien.Columns["Sdt"] != null) dgvHoiVien.Columns["Sdt"]!.HeaderText = "SĐT";
                    if (dgvHoiVien.Columns["HangThanhVien"] != null) dgvHoiVien.Columns["HangThanhVien"]!.HeaderText = "Hạng thành viên";
                    if (dgvHoiVien.Columns["TrangThai"] != null) dgvHoiVien.Columns["TrangThai"]!.HeaderText = "Trạng thái";

                    if (dgvHoiVien.Columns["Email"] != null) dgvHoiVien.Columns["Email"]!.HeaderText = "Email";
                    if (dgvHoiVien.Columns["NgayDangKy"] != null)
                    {
                        dgvHoiVien.Columns["NgayDangKy"]!.HeaderText = "Ngày đăng ký";
                        dgvHoiVien.Columns["NgayDangKy"]!.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            // Kiểm tra Họ tên
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên hội viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            // Kiểm tra SĐT: chỉ chứa chữ số và đủ 9-11 ký tự
            string sdt = txtSdt.Text.Trim();
            if (string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSdt.Focus();
                return false;
            }
            if (!Regex.IsMatch(sdt, @"^[0-9]{9,11}$"))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa chữ số và có độ dài từ 9 đến 11 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSdt.Focus();
                return false;
            }

            // Kiểm tra Email: phải chứa ký tự '@'
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Vui lòng nhập email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            if (!email.Contains('@'))
            {
                MessageBox.Show("Email không hợp lệ, email phải chứa ký tự '@'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // Kiểm tra Tuổi: tính từ NgaySinh đến hiện tại phải từ 15 tuổi trở lên
            DateTime ngaySinh = dtpNgaySinh.Value.Date;
            DateTime hienTai = DateTime.Today;
            int tuoi = hienTai.Year - ngaySinh.Year;
            if (ngaySinh.Date > hienTai.AddYears(-tuoi)) tuoi--;

            if (tuoi < 15)
            {
                MessageBox.Show($"Hội viên phải từ 15 tuổi trở lên mới được đăng ký! (Hiện tại: {tuoi} tuổi)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Focus();
                return false;
            }

            // Kiểm tra Hạng thành viên
            if (cboHangThanhVien.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn hạng thành viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboHangThanhVien.Focus();
                return false;
            }

            return true;
        }

        private void ResetInputs()
        {
            _selectedMaHv = null;
            txtHoTen.Clear();
            txtSdt.Clear();
            txtEmail.Clear();
            dtpNgaySinh.Value = DateTime.Today.AddYears(-20); // Mặc định 20 tuổi
            cboHangThanhVien.SelectedIndex = 0; // Basic
            chkTrangThai.Checked = true;
            radNam.Checked = true;
            radNu.Checked = false;

            dgvHoiVien.ClearSelection();
            txtHoTen.Focus();
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                using var context = GetContext();
                var hoiVien = new HoiVien
                {
                    HoTen = txtHoTen.Text.Trim(),
                    GioiTinh = radNam.Checked,
                    NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value),
                    Sdt = txtSdt.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    HangThanhVien = cboHangThanhVien.SelectedItem?.ToString(),
                    NgayDangKy = DateTime.Now,
                    TrangThai = chkTrangThai.Checked
                };

                context.HoiViens.Add(hoiVien);
                await context.SaveChangesAsync();

                MessageBox.Show("Thêm mới hội viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetInputs();
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Thêm hội viên thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedMaHv == null)
            {
                MessageBox.Show("Vui lòng chọn hội viên cần sửa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            try
            {
                using var context = GetContext();
                var hoiVien = await context.HoiViens.FindAsync(_selectedMaHv.Value);
                if (hoiVien == null)
                {
                    MessageBox.Show("Không tìm thấy hội viên cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                hoiVien.HoTen = txtHoTen.Text.Trim();
                hoiVien.GioiTinh = radNam.Checked;
                hoiVien.NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value);
                hoiVien.Sdt = txtSdt.Text.Trim();
                hoiVien.Email = txtEmail.Text.Trim();
                hoiVien.HangThanhVien = cboHangThanhVien.SelectedItem?.ToString();
                hoiVien.TrangThai = chkTrangThai.Checked;

                await context.SaveChangesAsync();

                MessageBox.Show("Cập nhật thông tin hội viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetInputs();
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cập nhật thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedMaHv == null)
            {
                MessageBox.Show("Vui lòng chọn hội viên cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 6. Hiển thị xác nhận YesNo khi xóa
            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa hội viên '{txtHoTen.Text}' (Mã: {_selectedMaHv}) không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using var context = GetContext();
                var hoiVien = await context.HoiViens.FindAsync(_selectedMaHv.Value);
                if (hoiVien != null)
                {
                    context.HoiViens.Remove(hoiVien);
                    await context.SaveChangesAsync();
                    MessageBox.Show("Xóa hội viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetInputs();
                    await LoadDataAsync();
                }
                else
                {
                    MessageBox.Show("Hội viên không tồn tại hoặc đã bị xóa trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xóa hội viên thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetInputs();
            txtTimKiemHoTen.Clear();
            cboTimKiemHang.SelectedIndex = 0;
            _ = LoadDataAsync();
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemHoTen.Text.Trim();
            string hangLoc = cboTimKiemHang.SelectedItem?.ToString() ?? "";
            await LoadDataAsync(keyword, hangLoc);
        }

        // 3. Tích chọn dòng trên DataGridView -> đổ dữ liệu lên toàn bộ control
        private void dgvHoiVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvHoiVien.Rows.Count) return;

            var row = dgvHoiVien.Rows[e.RowIndex];
            if (row.Cells["MaHv"].Value == null) return;

            _selectedMaHv = Convert.ToInt32(row.Cells["MaHv"].Value);
            txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? "";
            txtSdt.Text = row.Cells["Sdt"].Value?.ToString() ?? "";
            txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";

            // Đổ giới tính lên RadioButton
            string gioiTinh = row.Cells["GioiTinh"].Value?.ToString() ?? "";
            if (gioiTinh == "Nam")
            {
                radNam.Checked = true;
                radNu.Checked = false;
            }
            else
            {
                radNam.Checked = false;
                radNu.Checked = true;
            }

            // Đổ ngày sinh lên DateTimePicker
            string ngaySinhStr = row.Cells["NgaySinh"].Value?.ToString() ?? "";
            if (DateTime.TryParseExact(ngaySinhStr, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime ns))
            {
                dtpNgaySinh.Value = ns;
            }
            else if (DateTime.TryParse(ngaySinhStr, out DateTime ns2))
            {
                dtpNgaySinh.Value = ns2;
            }

            // Đổ Hạng thành viên lên ComboBox
            string hang = row.Cells["HangThanhVien"].Value?.ToString() ?? "";
            cboHangThanhVien.SelectedItem = hang;

            // Đổ trạng thái lên CheckBox
            string trangThai = row.Cells["TrangThai"].Value?.ToString() ?? "";
            chkTrangThai.Checked = (trangThai == "Đang hoạt động");
        }
    }
}
