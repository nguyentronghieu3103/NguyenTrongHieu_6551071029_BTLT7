using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Bai3.Models;

namespace Bai3
{
    public partial class Form1 : Form
    {
        private int? _selectedMaPhong = null;
        private string? _currentImageFileName = null;
        private readonly string _imagesDirectory = Path.Combine(Application.StartupPath, "Images");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EnsureImagesDirectory();
            LoadLoaiPhongCombos();
            if (cboTinhTrang.Items.Count > 0)
            {
                cboTinhTrang.SelectedIndex = 0;
            }
            if (cboLocTinhTrang.Items.Count > 0)
            {
                cboLocTinhTrang.SelectedIndex = 0;
            }
            LoadDanhSachPhong();
            ResetForm();
        }

        private void EnsureImagesDirectory()
        {
            if (!Directory.Exists(_imagesDirectory))
            {
                Directory.CreateDirectory(_imagesDirectory);
            }
        }

        /// <summary>
        /// Đọc ảnh an toàn không khóa file (tránh lỗi IOException khi ghi đè hoặc xóa)
        /// </summary>
        private Image? LoadImageWithoutLock(string? fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName)) return null;

            string fullPath = Path.Combine(_imagesDirectory, fileName);
            if (!File.Exists(fullPath)) return null;

            try
            {
                byte[] bytes = File.ReadAllBytes(fullPath);
                using var ms = new MemoryStream(bytes);
                return Image.FromStream(ms);
            }
            catch
            {
                return null;
            }
        }

        private void LoadLoaiPhongCombos()
        {
            try
            {
                using var context = new SunriseHomestayContext();
                var loaiPhongs = context.LoaiPhongs.OrderBy(x => x.TenLoai).ToList();

                // ComboBox chọn Loại phòng khi Thêm/Sửa
                cboLoaiPhong.DataSource = null;
                cboLoaiPhong.DisplayMember = "TenLoai";
                cboLoaiPhong.ValueMember = "MaLoai";
                cboLoaiPhong.DataSource = loaiPhongs;

                // ComboBox Lọc loại phòng khi Tìm kiếm
                var listLoc = new List<LoaiPhongLocItem>
                {
                    new LoaiPhongLocItem { MaLoai = 0, TenLoai = "Lọc theo loại phòng" }
                };
                foreach (var lp in loaiPhongs)
                {
                    listLoc.Add(new LoaiPhongLocItem { MaLoai = lp.MaLoai, TenLoai = lp.TenLoai });
                }

                cboLocLoaiPhong.DataSource = null;
                cboLocLoaiPhong.DisplayMember = "TenLoai";
                cboLocLoaiPhong.ValueMember = "MaLoai";
                cboLocLoaiPhong.DataSource = listLoc;
                cboLocLoaiPhong.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp danh sách loại phòng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDanhSachPhong()
        {
            try
            {
                using var context = new SunriseHomestayContext();

                // Dùng Include(x => x.MaLoaiNavigation) để Eager Loading quan hệ 1-n
                var query = context.Phongs
                    .Include(p => p.MaLoaiNavigation)
                    .AsQueryable();

                // 7. Tìm kiếm kết hợp theo Loại phòng VÀ Tình trạng phòng cùng lúc (LINQ Where)
                if (cboLocLoaiPhong.SelectedValue is int maLoai && maLoai > 0)
                {
                    query = query.Where(p => p.MaLoai == maLoai);
                }

                if (cboLocTinhTrang.SelectedIndex > 0 && cboLocTinhTrang.SelectedItem != null)
                {
                    string tinhTrang = cboLocTinhTrang.SelectedItem.ToString()!;
                    query = query.Where(p => p.TinhTrang == tinhTrang);
                }

                var list = query.OrderBy(p => p.MaPhong).ToList();

                var viewList = list.Select(p => new PhongViewModel
                {
                    MaPhong = p.MaPhong,
                    HinhAnh = LoadImageWithoutLock(p.HinhAnh),
                    TenHinhAnh = p.HinhAnh,
                    SoPhong = p.SoPhong,
                    TangSo = p.TangSo,
                    TenLoai = p.MaLoaiNavigation != null ? p.MaLoaiNavigation.TenLoai : "",
                    GiaMoiDem = p.MaLoaiNavigation?.GiaMoiDem,
                    TinhTrang = p.TinhTrang ?? "",
                    MaLoai = p.MaLoai
                }).ToList();

                dgvPhong.DataSource = viewList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách phòng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetForm()
        {
            _selectedMaPhong = null;
            _currentImageFileName = null;
            txtSoPhong.Clear();
            numTangSo.Value = 0;
            if (cboLoaiPhong.Items.Count > 0)
                cboLoaiPhong.SelectedIndex = 0;
            if (cboTinhTrang.Items.Count > 0)
                cboTinhTrang.SelectedIndex = 0;

            if (picHinhAnh.Image != null)
            {
                picHinhAnh.Image.Dispose();
                picHinhAnh.Image = null;
            }

            dgvPhong.ClearSelection();
            txtSoPhong.Focus();
        }

        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvPhong.Rows.Count) return;

            if (dgvPhong.Rows[e.RowIndex].DataBoundItem is PhongViewModel selected)
            {
                _selectedMaPhong = selected.MaPhong;
                txtSoPhong.Text = selected.SoPhong;
                numTangSo.Value = (selected.TangSo.HasValue && selected.TangSo.Value >= 0) ? selected.TangSo.Value : 0;

                if (selected.MaLoai.HasValue)
                {
                    cboLoaiPhong.SelectedValue = selected.MaLoai.Value;
                }

                if (!string.IsNullOrEmpty(selected.TinhTrang))
                {
                    cboTinhTrang.SelectedItem = selected.TinhTrang;
                }

                _currentImageFileName = selected.TenHinhAnh;

                if (picHinhAnh.Image != null)
                {
                    picHinhAnh.Image.Dispose();
                    picHinhAnh.Image = null;
                }

                picHinhAnh.Image = LoadImageWithoutLock(_currentImageFileName);
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Chọn hình ảnh phòng",
                Filter = "Tệp hình ảnh (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Tất cả tệp (*.*)|*.*"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    EnsureImagesDirectory();

                    string sourcePath = ofd.FileName;
                    string fileName = Path.GetFileName(sourcePath);
                    string destPath = Path.Combine(_imagesDirectory, fileName);

                    // Copy file ảnh vào thư mục Images của ứng dụng (nếu file nguồn không phải chính nó)
                    if (!string.Equals(Path.GetFullPath(sourcePath), Path.GetFullPath(destPath), StringComparison.OrdinalIgnoreCase))
                    {
                        File.Copy(sourcePath, destPath, true);
                    }

                    // Chỉ lưu TÊN FILE (không lưu full path)
                    _currentImageFileName = fileName;

                    // Hiển thị ngay lên PictureBox
                    if (picHinhAnh.Image != null)
                    {
                        picHinhAnh.Image.Dispose();
                        picHinhAnh.Image = null;
                    }
                    picHinhAnh.Image = LoadImageWithoutLock(_currentImageFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string soPhong = txtSoPhong.Text.Trim();
            if (string.IsNullOrEmpty(soPhong))
            {
                MessageBox.Show("Vui lòng nhập Số phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoPhong.Focus();
                return;
            }

            if (cboLoaiPhong.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Loại phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboTinhTrang.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn Tình trạng phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var context = new SunriseHomestayContext();

                // Kiểm tra trùng số phòng
                if (context.Phongs.Any(p => p.SoPhong.ToLower() == soPhong.ToLower()))
                {
                    MessageBox.Show($"Số phòng '{soPhong}' đã tồn tại! Vui lòng nhập số khác.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoPhong.Focus();
                    return;
                }

                var phong = new Phong
                {
                    SoPhong = soPhong,
                    TangSo = (int)numTangSo.Value,
                    MaLoai = Convert.ToInt32(cboLoaiPhong.SelectedValue),
                    TinhTrang = cboTinhTrang.SelectedItem.ToString(),
                    HinhAnh = _currentImageFileName
                };

                context.Phongs.Add(phong);
                context.SaveChanges();

                MessageBox.Show("Thêm phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachPhong();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!_selectedMaPhong.HasValue)
            {
                MessageBox.Show("Vui lòng chọn phòng cần sửa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string soPhong = txtSoPhong.Text.Trim();
            if (string.IsNullOrEmpty(soPhong))
            {
                MessageBox.Show("Vui lòng nhập Số phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoPhong.Focus();
                return;
            }

            if (cboLoaiPhong.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Loại phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboTinhTrang.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn Tình trạng phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var context = new SunriseHomestayContext();
                var phong = context.Phongs.Find(_selectedMaPhong.Value);
                if (phong == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin phòng trong cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra trùng số phòng với phòng khác
                if (context.Phongs.Any(p => p.MaPhong != _selectedMaPhong.Value && p.SoPhong.ToLower() == soPhong.ToLower()))
                {
                    MessageBox.Show($"Số phòng '{soPhong}' đã tồn tại ở phòng khác!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoPhong.Focus();
                    return;
                }

                phong.SoPhong = soPhong;
                phong.TangSo = (int)numTangSo.Value;
                phong.MaLoai = Convert.ToInt32(cboLoaiPhong.SelectedValue);
                phong.TinhTrang = cboTinhTrang.SelectedItem.ToString();
                phong.HinhAnh = _currentImageFileName;

                context.SaveChanges();

                MessageBox.Show("Cập nhật thông tin phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachPhong();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!_selectedMaPhong.HasValue)
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var context = new SunriseHomestayContext();
                var phong = context.Phongs.Find(_selectedMaPhong.Value);
                if (phong == null)
                {
                    MessageBox.Show("Không tìm thấy phòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa phòng '{phong.SoPhong}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    context.Phongs.Remove(phong);
                    context.SaveChanges();

                    MessageBox.Show("Xóa phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachPhong();
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
            cboLocLoaiPhong.SelectedIndex = 0;
            cboLocTinhTrang.SelectedIndex = 0;
            LoadLoaiPhongCombos();
            LoadDanhSachPhong();
            ResetForm();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadDanhSachPhong();
        }

        private void btnQuanLyLoaiPhong_Click(object sender, EventArgs e)
        {
            using var formLoai = new FormLoaiPhong();
            formLoai.ShowDialog();

            // Cập nhật lại ComboBox Loại phòng sau khi đóng form quản lý loại phòng
            LoadLoaiPhongCombos();
            LoadDanhSachPhong();
        }

        private class LoaiPhongLocItem
        {
            public int MaLoai { get; set; }
            public string TenLoai { get; set; } = string.Empty;
        }
    }
}
