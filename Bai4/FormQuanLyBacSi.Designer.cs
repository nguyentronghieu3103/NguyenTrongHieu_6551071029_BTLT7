namespace Bai4
{
    partial class FormQuanLyBacSi
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            grpThongTin = new GroupBox();
            txtSdt = new TextBox();
            lblSdt = new Label();
            txtChuyenKhoa = new TextBox();
            lblChuyenKhoa = new Label();
            txtHoTen = new TextBox();
            lblHoTen = new Label();
            txtMaBs = new TextBox();
            lblMaBs = new Label();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnDong = new Button();
            dgvBacSi = new DataGridView();
            grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBacSi).BeginInit();
            SuspendLayout();
            // 
            // grpThongTin
            // 
            grpThongTin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpThongTin.Controls.Add(txtSdt);
            grpThongTin.Controls.Add(lblSdt);
            grpThongTin.Controls.Add(txtChuyenKhoa);
            grpThongTin.Controls.Add(lblChuyenKhoa);
            grpThongTin.Controls.Add(txtHoTen);
            grpThongTin.Controls.Add(lblHoTen);
            grpThongTin.Controls.Add(txtMaBs);
            grpThongTin.Controls.Add(lblMaBs);
            grpThongTin.Location = new Point(14, 12);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(680, 105);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin bác sĩ";
            // 
            // txtSdt
            // 
            txtSdt.Location = new Point(446, 62);
            txtSdt.Name = "txtSdt";
            txtSdt.Size = new Size(215, 23);
            txtSdt.TabIndex = 7;
            // 
            // lblSdt
            // 
            lblSdt.AutoSize = true;
            lblSdt.Location = new Point(356, 65);
            lblSdt.Name = "lblSdt";
            lblSdt.Size = new Size(79, 15);
            lblSdt.TabIndex = 6;
            lblSdt.Text = "Số điện thoại:";
            // 
            // txtChuyenKhoa
            // 
            txtChuyenKhoa.Location = new Point(446, 26);
            txtChuyenKhoa.Name = "txtChuyenKhoa";
            txtChuyenKhoa.Size = new Size(215, 23);
            txtChuyenKhoa.TabIndex = 5;
            // 
            // lblChuyenKhoa
            // 
            lblChuyenKhoa.AutoSize = true;
            lblChuyenKhoa.Location = new Point(356, 29);
            lblChuyenKhoa.Name = "lblChuyenKhoa";
            lblChuyenKhoa.Size = new Size(80, 15);
            lblChuyenKhoa.TabIndex = 4;
            lblChuyenKhoa.Text = "Chuyên khoa:";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(95, 62);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(235, 23);
            txtHoTen.TabIndex = 3;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(16, 65);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(46, 15);
            lblHoTen.TabIndex = 2;
            lblHoTen.Text = "Họ tên:";
            // 
            // txtMaBs
            // 
            txtMaBs.Location = new Point(95, 26);
            txtMaBs.Name = "txtMaBs";
            txtMaBs.ReadOnly = true;
            txtMaBs.Size = new Size(100, 23);
            txtMaBs.TabIndex = 1;
            // 
            // lblMaBs
            // 
            lblMaBs.AutoSize = true;
            lblMaBs.Location = new Point(16, 29);
            lblMaBs.Name = "lblMaBs";
            lblMaBs.Size = new Size(61, 15);
            lblMaBs.TabIndex = 0;
            lblMaBs.Text = "Mã bác sĩ:";
            // 
            // btnThem
            // 
            btnThem.Location = new Point(90, 126);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(80, 30);
            btnThem.TabIndex = 1;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(185, 126);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(80, 30);
            btnSua.TabIndex = 2;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(280, 126);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(80, 30);
            btnXoa.TabIndex = 3;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(375, 126);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(80, 30);
            btnLamMoi.TabIndex = 4;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnDong
            // 
            btnDong.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDong.Location = new Point(614, 126);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(80, 30);
            btnDong.TabIndex = 5;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = true;
            btnDong.Click += btnDong_Click;
            // 
            // dgvBacSi
            // 
            dgvBacSi.AllowUserToAddRows = false;
            dgvBacSi.AllowUserToDeleteRows = false;
            dgvBacSi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBacSi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBacSi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBacSi.Location = new Point(14, 168);
            dgvBacSi.MultiSelect = false;
            dgvBacSi.Name = "dgvBacSi";
            dgvBacSi.ReadOnly = true;
            dgvBacSi.RowHeadersWidth = 35;
            dgvBacSi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBacSi.Size = new Size(680, 260);
            dgvBacSi.TabIndex = 6;
            dgvBacSi.CellClick += dgvBacSi_CellClick;
            // 
            // FormQuanLyBacSi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(708, 442);
            Controls.Add(dgvBacSi);
            Controls.Add(btnDong);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(grpThongTin);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormQuanLyBacSi";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý Bác Sĩ - An Khang Clinic";
            Load += FormQuanLyBacSi_Load;
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBacSi).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpThongTin;
        private TextBox txtSdt;
        private Label lblSdt;
        private TextBox txtChuyenKhoa;
        private Label lblChuyenKhoa;
        private TextBox txtHoTen;
        private Label lblHoTen;
        private TextBox txtMaBs;
        private Label lblMaBs;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnDong;
        private DataGridView dgvBacSi;
    }
}
