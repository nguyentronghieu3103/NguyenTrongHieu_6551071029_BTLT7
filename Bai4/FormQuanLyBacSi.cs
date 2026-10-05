using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Bai4.Models;

namespace Bai4
{
    public partial class FormQuanLyBacSi : Form
    {
        private int? _selectedMaBs = null;

        public FormQuanLyBacSi()
        {
            InitializeComponent();
        }

        private async void FormQuanLyBacSi_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
            ResetForm();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                using var context = new AnKhangClinicContext();
                var list = await context.BacSis
                    .OrderBy(b => b.MaBs)
                    .Select(b => new
                    {
                        b.MaBs,
                        b.HoTen,
                        b.ChuyenKhoa,
                        b.Sdt
                    })
                    .ToListAsync();

                dgvBacSi.DataSource = list;

                if (dgvBacSi.Columns["MaBs"] is { } colMaBs)
                    colMaBs.HeaderText = "Mã BS";
                if (dgvBacSi.Columns["HoTen"] is { } colHoTen)
                    colHoTen.HeaderText = "Họ và tên";
                if (dgvBacSi.Columns["ChuyenKhoa"] is { } colChuyenKhoa)
                    colChuyenKhoa.HeaderText = "Chuyên khoa";
                if (dgvBacSi.Columns["Sdt"] is { } colSdt)
                    colSdt.HeaderText = "Số điện thoại";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách bác sĩ: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetForm()
        {
            _selectedMaBs = null;
            txtMaBs.Clear();
            txtHoTen.Clear();
            txtChuyenKhoa.Clear();
            txtSdt.Clear();
            dgvBacSi.ClearSelection();
            txtHoTen.Focus();
        }

        private void dgvBacSi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvBacSi.Rows.Count) return;

            var row = dgvBacSi.Rows[e.RowIndex];
            if (row.Cells["MaBs"]?.Value != null && int.TryParse(row.Cells["MaBs"].Value?.ToString(), out int maBs))
            {
                _selectedMaBs = maBs;
                txtMaBs.Text = maBs.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? string.Empty;
                txtChuyenKhoa.Text = row.Cells["ChuyenKhoa"].Value?.ToString() ?? string.Empty;
                txtSdt.Text = row.Cells["Sdt"].Value?.ToString() ?? string.Empty;
            }
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Vui lòng nhập họ tên bác sĩ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            try
            {
                using var context = new AnKhangClinicContext();
                var bacSi = new BacSi
                {
                    HoTen = hoTen,
                    ChuyenKhoa = txtChuyenKhoa.Text.Trim(),
                    Sdt = txtSdt.Text.Trim()
                };

                context.BacSis.Add(bacSi);
                await context.SaveChangesAsync();

                MessageBox.Show("Thêm bác sĩ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm bác sĩ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (!_selectedMaBs.HasValue)
            {
                MessageBox.Show("Vui lòng chọn một bác sĩ từ danh sách để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hoTen = txtHoTen.Text.Trim();
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Vui lòng nhập họ tên bác sĩ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            try
            {
                using var context = new AnKhangClinicContext();
                var bacSi = await context.BacSis.FindAsync(_selectedMaBs.Value);
                if (bacSi == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin bác sĩ cần cập nhật!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bacSi.HoTen = hoTen;
                bacSi.ChuyenKhoa = txtChuyenKhoa.Text.Trim();
                bacSi.Sdt = txtSdt.Text.Trim();

                await context.SaveChangesAsync();

                MessageBox.Show("Cập nhật thông tin bác sĩ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật bác sĩ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (!_selectedMaBs.HasValue)
            {
                MessageBox.Show("Vui lòng chọn bác sĩ cần xóa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var context = new AnKhangClinicContext();
                var bacSi = await context.BacSis
                    .Include(b => b.LichKhams)
                    .FirstOrDefaultAsync(b => b.MaBs == _selectedMaBs.Value);

                if (bacSi == null)
                {
                    MessageBox.Show("Không tìm thấy bác sĩ cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (bacSi.LichKhams.Any())
                {
                    MessageBox.Show($"Bác sĩ '{bacSi.HoTen}' đang có {bacSi.LichKhams.Count} lịch hẹn khám trong hệ thống.\nKhông thể xóa do ràng buộc dữ liệu!", 
                        "Ràng buộc khóa ngoại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmResult = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa bác sĩ '{bacSi.HoTen}'?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    context.BacSis.Remove(bacSi);
                    await context.SaveChangesAsync();

                    MessageBox.Show("Đã xóa bác sĩ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa bác sĩ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
