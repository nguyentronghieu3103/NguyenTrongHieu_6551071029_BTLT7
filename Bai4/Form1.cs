using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Bai4.Models;

namespace Bai4
{
    public partial class Form1 : Form
    {
        private int? _selectedMaLich = null;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // Thiết lập giá trị mặc định cho DateTimePicker tìm kiếm
            dtpTuNgay.Value = DateTime.Today.AddDays(-30);
            dtpDenNgay.Value = DateTime.Today.AddDays(30);

            // Nạp trạng thái khám
            if (cboTrangThai.Items.Count > 0)
            {
                cboTrangThai.SelectedIndex = 0; // "Chờ khám"
            }

            // Nạp danh sách bác sĩ vào ComboBox
            await LoadBacSiCombosAsync();

            // Nạp dữ liệu lịch khám lên DataGridView
            await LoadDanhSachLichKhamAsync();

            ResetInputs();
        }

        /// <summary>
        /// Nạp dữ liệu Bác sĩ cho ComboBox ở Form chính và ComboBox Lọc tìm kiếm
        /// </summary>
        private async Task LoadBacSiCombosAsync()
        {
            try
            {
                using var context = new AnKhangClinicContext();
                var bacSiList = await context.BacSis
                    .OrderBy(b => b.HoTen)
                    .Select(b => new BacSiComboItem
                    {
                        MaBs = b.MaBs,
                        DisplayText = $"BS. {b.HoTen} - {b.ChuyenKhoa}"
                    })
                    .ToListAsync();

                // 1. Nạp cho ComboBox chọn Bác sĩ để đặt lịch
                cboBacSi.DataSource = new List<BacSiComboItem>(bacSiList);
                cboBacSi.DisplayMember = "DisplayText";
                cboBacSi.ValueMember = "MaBs";
                if (bacSiList.Count > 0)
                {
                    cboBacSi.SelectedIndex = 0;
                }

                // 2. Nạp cho ComboBox lọc tìm kiếm (thêm mục "-- Tất cả bác sĩ --")
                var filterList = new List<BacSiComboItem>
                {
                    new BacSiComboItem { MaBs = 0, DisplayText = "-- Tất cả bác sĩ --" }
                };
                filterList.AddRange(bacSiList);

                cboLocBacSi.DataSource = filterList;
                cboLocBacSi.DisplayMember = "DisplayText";
                cboLocBacSi.ValueMember = "MaBs";
                cboLocBacSi.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách bác sĩ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tải danh sách lịch khám sử dụng LINQ Include để JOIN lấy thông tin bác sĩ,
        /// kết hợp lọc theo khoảng ngày (>=, <=) và bác sĩ (==)
        /// </summary>
        private async Task LoadDanhSachLichKhamAsync()
        {
            try
            {
                using var context = new AnKhangClinicContext();

                // 4. LINQ Include(x => x.MaBsNavigation) để lấy kèm dữ liệu bảng BacSi trong cùng 1 câu truy vấn
                var query = context.LichKhams
                    .Include(x => x.MaBsNavigation)
                    .AsQueryable();

                // 6. Tìm kiếm kết hợp: Lọc theo khoảng Ngày khám (Từ ngày - Đến ngày)
                DateOnly tuNgay = DateOnly.FromDateTime(dtpTuNgay.Value.Date);
                DateOnly denNgay = DateOnly.FromDateTime(dtpDenNgay.Value.Date);

                // LINQ Where với nhiều điều kiện so sánh ngày tháng (>=, <=)
                query = query.Where(x => x.NgayKham >= tuNgay && x.NgayKham <= denNgay);

                // Kết hợp điều kiện bằng (==) khi người dùng chọn lọc theo bác sĩ cụ thể
                if (cboLocBacSi.SelectedValue is int maBsLoc && maBsLoc > 0)
                {
                    query = query.Where(x => x.MaBs == maBsLoc);
                }

                var listRaw = await query
                    .OrderBy(x => x.NgayKham)
                    .ThenBy(x => x.GioKham)
                    .ToListAsync();

                // Projection sang ViewModel hiển thị trên DataGridView, chống NullReferenceException
                var viewList = listRaw.Select(x => new LichKhamViewModel
                {
                    MaLich = x.MaLich,
                    TenBenhNhan = x.TenBenhNhan ?? string.Empty,
                    Sdt = x.Sdt ?? string.Empty,
                    NgayKham = x.NgayKham.HasValue ? x.NgayKham.Value.ToString("dd/MM/yyyy") : string.Empty,
                    GioKham = x.GioKham.HasValue ? x.GioKham.Value.ToString("HH:mm") : string.Empty,
                    BacSi = x.MaBsNavigation != null ? $"BS. {x.MaBsNavigation.HoTen} - {x.MaBsNavigation.ChuyenKhoa}" : string.Empty,
                    ChuyenKhoa = x.MaBsNavigation?.ChuyenKhoa ?? string.Empty,
                    TrangThai = x.TrangThai ?? string.Empty,
                    NgayKhamRaw = x.NgayKham,
                    GioKhamRaw = x.GioKham,
                    MaBs = x.MaBs
                }).ToList();

                dgvLichKham.DataSource = viewList;

                // Cấu hình tiêu đề và ẩn các cột dữ liệu raw không cần hiển thị
                if (dgvLichKham.Columns["MaLich"] is { } colMaLich)
                    colMaLich.HeaderText = "Mã lịch";
                if (dgvLichKham.Columns["TenBenhNhan"] is { } colTenBenhNhan)
                    colTenBenhNhan.HeaderText = "Tên bệnh nhân";
                if (dgvLichKham.Columns["Sdt"] is { } colSdt)
                    colSdt.HeaderText = "SĐT";
                if (dgvLichKham.Columns["NgayKham"] is { } colNgayKham)
                    colNgayKham.HeaderText = "Ngày khám";
                if (dgvLichKham.Columns["GioKham"] is { } colGioKham)
                    colGioKham.HeaderText = "Giờ khám";
                if (dgvLichKham.Columns["BacSi"] is { } colBacSi)
                    colBacSi.HeaderText = "Bác sĩ";
                if (dgvLichKham.Columns["ChuyenKhoa"] is { } colChuyenKhoa)
                    colChuyenKhoa.HeaderText = "Chuyên khoa";
                if (dgvLichKham.Columns["TrangThai"] is { } colTrangThai)
                    colTrangThai.HeaderText = "Trạng thái";

                // Ẩn các cột thô
                if (dgvLichKham.Columns["NgayKhamRaw"] is { } colNgayKhamRaw)
                    colNgayKhamRaw.Visible = false;
                if (dgvLichKham.Columns["GioKhamRaw"] is { } colGioKhamRaw)
                    colGioKhamRaw.Visible = false;
                if (dgvLichKham.Columns["MaBs"] is { } colMaBs)
                    colMaBs.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách lịch khám: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetInputs()
        {
            _selectedMaLich = null;
            txtTenBenhNhan.Clear();
            txtSdt.Clear();
            dtpNgayKham.Value = DateTime.Today;
            dtpGioKham.Value = DateTime.Today.AddHours(8); // mặc định 08:00 AM
            if (cboBacSi.Items.Count > 0)
            {
                cboBacSi.SelectedIndex = 0;
            }
            if (cboTrangThai.Items.Count > 0)
            {
                cboTrangThai.SelectedIndex = 0; // "Chờ khám"
            }
            dgvLichKham.ClearSelection();
            txtTenBenhNhan.Focus();
        }

        /// <summary>
        /// 5. CRUD: Tích chọn dòng trên DataGridView để hiển thị dữ liệu chi tiết lên các ô nhập
        /// </summary>
        private void dgvLichKham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvLichKham.Rows.Count) return;

            if (dgvLichKham.Rows[e.RowIndex].DataBoundItem is LichKhamViewModel item)
            {
                _selectedMaLich = item.MaLich;
                txtTenBenhNhan.Text = item.TenBenhNhan;
                txtSdt.Text = item.Sdt;

                if (item.NgayKhamRaw.HasValue)
                {
                    dtpNgayKham.Value = item.NgayKhamRaw.Value.ToDateTime(TimeOnly.MinValue);
                }
                else
                {
                    dtpNgayKham.Value = DateTime.Today;
                }

                if (item.GioKhamRaw.HasValue)
                {
                    dtpGioKham.Value = DateTime.Today.Add(item.GioKhamRaw.Value.ToTimeSpan());
                }
                else
                {
                    dtpGioKham.Value = DateTime.Now;
                }

                if (item.MaBs.HasValue)
                {
                    cboBacSi.SelectedValue = item.MaBs.Value;
                }

                if (!string.IsNullOrEmpty(item.TrangThai))
                {
                    cboTrangThai.SelectedItem = item.TrangThai;
                }
            }
        }

        /// <summary>
        /// 7. Validate: không cho đặt lịch khám vào ngày trong quá khứ; không được bỏ trống Tên bệnh nhân và chưa chọn Bác sĩ
        /// </summary>
        private bool ValidateLichKham()
        {
            if (string.IsNullOrWhiteSpace(txtTenBenhNhan.Text))
            {
                MessageBox.Show("Vui lòng nhập tên bệnh nhân!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenBenhNhan.Focus();
                return false;
            }

            if (cboBacSi.SelectedValue == null || !int.TryParse(cboBacSi.SelectedValue.ToString(), out int maBs) || maBs <= 0)
            {
                MessageBox.Show("Vui lòng chọn bác sĩ khám!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboBacSi.Focus();
                return false;
            }

            // Không cho đặt lịch khám vào ngày trong quá khứ (so với ngày hiện tại)
            if (dtpNgayKham.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Không được đặt lịch khám vào ngày trong quá khứ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayKham.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Thêm lịch khám mới
        /// </summary>
        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateLichKham()) return;

            try
            {
                using var context = new AnKhangClinicContext();

                var lichKham = new LichKham
                {
                    TenBenhNhan = txtTenBenhNhan.Text.Trim(),
                    Sdt = txtSdt.Text.Trim(),
                    NgayKham = DateOnly.FromDateTime(dtpNgayKham.Value.Date),
                    GioKham = TimeOnly.FromDateTime(dtpGioKham.Value),
                    MaBs = (int)cboBacSi.SelectedValue!,
                    TrangThai = cboTrangThai.SelectedItem?.ToString() ?? "Chờ khám"
                };

                context.LichKhams.Add(lichKham);
                await context.SaveChangesAsync();

                MessageBox.Show("Thêm lịch khám thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDanhSachLichKhamAsync();
                ResetInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm lịch khám: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sửa thông tin lịch khám đã chọn
        /// </summary>
        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (!_selectedMaLich.HasValue)
            {
                MessageBox.Show("Vui lòng chọn một lịch khám từ danh sách để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateLichKham()) return;

            try
            {
                using var context = new AnKhangClinicContext();
                var lichKham = await context.LichKhams.FindAsync(_selectedMaLich.Value);
                if (lichKham == null)
                {
                    MessageBox.Show("Không tìm thấy lịch khám cần cập nhật!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                lichKham.TenBenhNhan = txtTenBenhNhan.Text.Trim();
                lichKham.Sdt = txtSdt.Text.Trim();
                lichKham.NgayKham = DateOnly.FromDateTime(dtpNgayKham.Value.Date);
                lichKham.GioKham = TimeOnly.FromDateTime(dtpGioKham.Value);
                lichKham.MaBs = (int)cboBacSi.SelectedValue!;
                lichKham.TrangThai = cboTrangThai.SelectedItem?.ToString() ?? "Chờ khám";

                await context.SaveChangesAsync();

                MessageBox.Show("Cập nhật lịch khám thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDanhSachLichKhamAsync();
                ResetInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật lịch khám: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 5. Xóa lịch khám: Bắt buộc hiển thị hộp thoại xác nhận YesNo trước khi gọi SaveChangesAsync()
        /// </summary>
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (!_selectedMaLich.HasValue)
            {
                MessageBox.Show("Vui lòng chọn một lịch khám từ danh sách để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var context = new AnKhangClinicContext();
                var lichKham = await context.LichKhams.FindAsync(_selectedMaLich.Value);
                if (lichKham == null)
                {
                    MessageBox.Show("Không tìm thấy lịch khám cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hộp thoại xác nhận YesNo bắt buộc
                var confirmResult = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa lịch khám của bệnh nhân '{lichKham.TenBenhNhan}' (Mã lịch: {lichKham.MaLich})?",
                    "Xác nhận xóa lịch khám",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    context.LichKhams.Remove(lichKham);
                    await context.SaveChangesAsync();

                    MessageBox.Show("Xóa lịch khám thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDanhSachLichKhamAsync();
                    ResetInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa lịch khám: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Làm mới form và nạp lại toàn bộ dữ liệu
        /// </summary>
        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Today.AddDays(-30);
            dtpDenNgay.Value = DateTime.Today.AddDays(30);
            if (cboLocBacSi.Items.Count > 0)
            {
                cboLocBacSi.SelectedIndex = 0;
            }

            await LoadDanhSachLichKhamAsync();
            ResetInputs();
        }

        /// <summary>
        /// 6. Tìm kiếm kết hợp theo khoảng ngày và Bác sĩ
        /// </summary>
        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("'Từ ngày' không được lớn hơn 'Đến ngày'!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await LoadDanhSachLichKhamAsync();
        }

        /// <summary>
        /// 2. Mở Form phụ "Quản lý Bác sĩ", tự động đồng bộ lại ComboBox sau khi đóng form
        /// </summary>
        private async void btnQuanLyBacSi_Click(object sender, EventArgs e)
        {
            using var formBacSi = new FormQuanLyBacSi();
            formBacSi.ShowDialog();

            // Đồng bộ lại danh sách bác sĩ lên Form chính sau khi cập nhật bên Form Bác sĩ
            await LoadBacSiCombosAsync();
            await LoadDanhSachLichKhamAsync();
        }

        /// <summary>
        /// Class trợ giúp hiển thị ComboBox Bác sĩ
        /// </summary>
        private class BacSiComboItem
        {
            public int MaBs { get; set; }
            public string DisplayText { get; set; } = string.Empty;
        }
    }
}
