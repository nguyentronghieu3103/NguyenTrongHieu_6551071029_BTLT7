using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Bai1.Models;

namespace Bai1
{
    public partial class FormQuanLyTheLoai : Form
    {
        // TODO: Thay đổi chuỗi kết nối này cho phù hợp với SQL Server của bạn
        private const string ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=QuanLyNhaSachMini;Integrated Security=True;TrustServerCertificate=True";

        public FormQuanLyTheLoai()
        {
            InitializeComponent();
        }

        private QuanLyNhaSachMiniContext GetContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<QuanLyNhaSachMiniContext>();
            optionsBuilder.UseSqlServer(ConnectionString);
            return new QuanLyNhaSachMiniContext(optionsBuilder.Options);
        }

        private async void FormQuanLyTheLoai_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData(string keyword = "")
        {
            try
            {
                using var context = GetContext();
                var query = context.TheLoaiSaches.AsQueryable();
                
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    query = query.Where(t => t.TenTheLoai.Contains(keyword));
                }

                var data = await query.Select(t => new {
                    t.MaTl,
                    t.TenTheLoai,
                    t.MoTa,
                    t.SoLuongSach,
                    t.NgayTao
                }).ToListAsync();

                dgvTheLoai.DataSource = data;
                
                // Customize columns
                if (dgvTheLoai.Columns.Count > 0)
                {
                    if (dgvTheLoai.Columns["MaTl"] != null) dgvTheLoai.Columns["MaTl"]!.HeaderText = "Mã TL";
                    if (dgvTheLoai.Columns["TenTheLoai"] != null) dgvTheLoai.Columns["TenTheLoai"]!.HeaderText = "Tên thể loại";
                    if (dgvTheLoai.Columns["MoTa"] != null) dgvTheLoai.Columns["MoTa"]!.HeaderText = "Mô tả";
                    if (dgvTheLoai.Columns["SoLuongSach"] != null) dgvTheLoai.Columns["SoLuongSach"]!.HeaderText = "Số lượng sách";
                    if (dgvTheLoai.Columns["NgayTao"] != null) dgvTheLoai.Columns["NgayTao"]!.HeaderText = "Ngày tạo";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvTheLoai_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTheLoai.CurrentRow != null)
            {
                var row = dgvTheLoai.CurrentRow;
                txtMaTL.Text = row.Cells["MaTl"].Value?.ToString();
                txtTenTL.Text = row.Cells["TenTheLoai"].Value?.ToString();
                txtMoTa.Text = row.Cells["MoTa"].Value?.ToString();
                
                var ngayTao = row.Cells["NgayTao"].Value;
                lblNgayTao.Text = ngayTao != null ? Convert.ToDateTime(ngayTao).ToString("dd/MM/yyyy HH:mm:ss") : "...";
            }
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaTL.Clear();
            txtTenTL.Clear();
            txtMoTa.Clear();
            txtTimKiem.Clear();
            lblNgayTao.Text = "...";
            txtTenTL.Focus();
            _ = LoadData(); // Reload all data
        }

        private async void BtnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenTL.Text))
            {
                MessageBox.Show("Tên thể loại không được bỏ trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var context = GetContext();
                
                // Check duplicate
                bool isExist = await context.TheLoaiSaches.AnyAsync(t => t.TenTheLoai.ToLower() == txtTenTL.Text.ToLower().Trim());
                if (isExist)
                {
                    MessageBox.Show("Tên thể loại đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newTheLoai = new TheLoaiSach
                {
                    TenTheLoai = txtTenTL.Text.Trim(),
                    MoTa = txtMoTa.Text.Trim()
                };

                context.TheLoaiSaches.Add(newTheLoai);
                await context.SaveChangesAsync();
                
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnLamMoi_Click(this, EventArgs.Empty); // Refresh
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaTL.Text))
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenTL.Text))
            {
                MessageBox.Show("Tên thể loại không được bỏ trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var context = GetContext();
                int id = int.Parse(txtMaTL.Text);
                
                var theLoai = await context.TheLoaiSaches.FindAsync(id);
                if (theLoai == null)
                {
                    MessageBox.Show("Không tìm thấy thể loại cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool isExist = await context.TheLoaiSaches.AnyAsync(t => t.MaTl != id && t.TenTheLoai.ToLower() == txtTenTL.Text.ToLower().Trim());
                if (isExist)
                {
                    MessageBox.Show("Tên thể loại đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                theLoai.TenTheLoai = txtTenTL.Text.Trim();
                theLoai.MoTa = txtMoTa.Text.Trim();

                await context.SaveChangesAsync();
                
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadData(txtTimKiem.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaTL.Text))
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa thể loại này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes) return;

            try
            {
                using var context = GetContext();
                int id = int.Parse(txtMaTL.Text);
                
                var theLoai = await context.TheLoaiSaches.FindAsync(id);
                if (theLoai != null)
                {
                    context.TheLoaiSaches.Remove(theLoai);
                    await context.SaveChangesAsync();
                    
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnLamMoi_Click(this, EventArgs.Empty);
                }
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("Không thể xóa thể loại này vì đang có sách tham chiếu (Lỗi khóa ngoại)!", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            await LoadData(keyword);
        }
    }
}
