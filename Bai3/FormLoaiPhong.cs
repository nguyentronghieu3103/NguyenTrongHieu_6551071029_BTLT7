using System;
using System.Linq;
using System.Windows.Forms;
using Bai3.Models;

namespace Bai3
{
    public partial class FormLoaiPhong : Form
    {
        private int? _selectedMaLoai = null;

        public FormLoaiPhong()
        {
            InitializeComponent();
        }

        private void FormLoaiPhong_Load(object sender, EventArgs e)
        {
            LoadData();
            ResetForm();
        }

        private void LoadData()
        {
            try
            {
                using var context = new SunriseHomestayContext();
                var list = context.LoaiPhongs
                    .Select(lp => new
                    {
                        MaLoai = lp.MaLoai,
                        TenLoai = lp.TenLoai,
                        GiaMoiDem = lp.GiaMoiDem,
                        MoTa = lp.MoTa
                    })
                    .ToList();

                dgvLoaiPhong.DataSource = list;

                if (dgvLoaiPhong.Columns["MaLoai"] is DataGridViewColumn colMaLoai)
                    colMaLoai.HeaderText = "Mã loại";
                if (dgvLoaiPhong.Columns["TenLoai"] is DataGridViewColumn colTenLoai)
                    colTenLoai.HeaderText = "Tên loại";
                if (dgvLoaiPhong.Columns["GiaMoiDem"] is DataGridViewColumn colGiaMoiDem)
                {
                    colGiaMoiDem.HeaderText = "Giá mỗi đêm";
                    colGiaMoiDem.DefaultCellStyle.Format = "N0";
                }
                if (dgvLoaiPhong.Columns["MoTa"] is DataGridViewColumn colMoTa)
                    colMoTa.HeaderText = "Mô tả";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetForm()
        {
            _selectedMaLoai = null;
            txtMaLoai.Clear();
            txtTenLoai.Clear();
            txtGiaMoiDem.Clear();
            txtMoTa.Clear();
            dgvLoaiPhong.ClearSelection();
            txtTenLoai.Focus();
        }

        private void dgvLoaiPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvLoaiPhong.Rows.Count) return;

            var row = dgvLoaiPhong.Rows[e.RowIndex];
            if (row.Cells["MaLoai"].Value != null)
            {
                _selectedMaLoai = Convert.ToInt32(row.Cells["MaLoai"].Value);
                txtMaLoai.Text = _selectedMaLoai.ToString();
                txtTenLoai.Text = row.Cells["TenLoai"].Value?.ToString() ?? "";
                txtGiaMoiDem.Text = row.Cells["GiaMoiDem"].Value != null ? Convert.ToDecimal(row.Cells["GiaMoiDem"].Value).ToString("G29") : "";
                txtMoTa.Text = row.Cells["MoTa"].Value?.ToString() ?? "";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenLoai = txtTenLoai.Text.Trim();
            if (string.IsNullOrEmpty(tenLoai))
            {
                MessageBox.Show("Vui lòng nhập Tên loại phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoai.Focus();
                return;
            }

            if (!decimal.TryParse(txtGiaMoiDem.Text.Trim(), out decimal gia) || gia < 0)
            {
                MessageBox.Show("Giá mỗi đêm phải là số hợp lệ >= 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaMoiDem.Focus();
                return;
            }

            try
            {
                using var context = new SunriseHomestayContext();
                if (context.LoaiPhongs.Any(lp => lp.TenLoai.ToLower() == tenLoai.ToLower()))
                {
                    MessageBox.Show("Tên loại phòng này đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var loaiPhong = new LoaiPhong
                {
                    TenLoai = tenLoai,
                    GiaMoiDem = gia,
                    MoTa = txtMoTa.Text.Trim()
                };

                context.LoaiPhongs.Add(loaiPhong);
                context.SaveChanges();

                MessageBox.Show("Thêm loại phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!_selectedMaLoai.HasValue)
            {
                MessageBox.Show("Vui lòng chọn loại phòng cần sửa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenLoai = txtTenLoai.Text.Trim();
            if (string.IsNullOrEmpty(tenLoai))
            {
                MessageBox.Show("Vui lòng nhập Tên loại phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoai.Focus();
                return;
            }

            if (!decimal.TryParse(txtGiaMoiDem.Text.Trim(), out decimal gia) || gia < 0)
            {
                MessageBox.Show("Giá mỗi đêm phải là số hợp lệ >= 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaMoiDem.Focus();
                return;
            }

            try
            {
                using var context = new SunriseHomestayContext();
                var loaiPhong = context.LoaiPhongs.Find(_selectedMaLoai.Value);
                if (loaiPhong == null)
                {
                    MessageBox.Show("Không tìm thấy loại phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (context.LoaiPhongs.Any(lp => lp.MaLoai != _selectedMaLoai.Value && lp.TenLoai.ToLower() == tenLoai.ToLower()))
                {
                    MessageBox.Show("Tên loại phòng trùng với loại phòng khác đã có!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                loaiPhong.TenLoai = tenLoai;
                loaiPhong.GiaMoiDem = gia;
                loaiPhong.MoTa = txtMoTa.Text.Trim();

                context.SaveChanges();

                MessageBox.Show("Cập nhật loại phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!_selectedMaLoai.HasValue)
            {
                MessageBox.Show("Vui lòng chọn loại phòng cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var context = new SunriseHomestayContext();
                var loaiPhong = context.LoaiPhongs.Find(_selectedMaLoai.Value);
                if (loaiPhong == null)
                {
                    MessageBox.Show("Không tìm thấy loại phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra ràng buộc khóa ngoại
                bool isReferenced = context.Phongs.Any(p => p.MaLoai == _selectedMaLoai.Value);
                if (isReferenced)
                {
                    MessageBox.Show("Không thể xóa loại phòng này vì đang có phòng thuộc loại này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa loại phòng '{loaiPhong.TenLoai}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    context.LoaiPhongs.Remove(loaiPhong);
                    context.SaveChanges();

                    MessageBox.Show("Xóa loại phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
            LoadData();
        }
    }
}
