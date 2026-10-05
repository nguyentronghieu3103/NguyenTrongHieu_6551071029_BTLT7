namespace Bai2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblSdt = new Label();
            txtSdt = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblNgaySinh = new Label();
            dtpNgaySinh = new DateTimePicker();
            lblHangThanhVien = new Label();
            cboHangThanhVien = new ComboBox();
            chkTrangThai = new CheckBox();
            grpGioiTinh = new GroupBox();
            radNu = new RadioButton();
            radNam = new RadioButton();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            txtTimKiemHoTen = new TextBox();
            lblTimKiemHang = new Label();
            cboTimKiemHang = new ComboBox();
            btnTimKiem = new Button();
            dgvHoiVien = new DataGridView();
            grpGioiTinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoiVien).BeginInit();
            SuspendLayout();
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(35, 30);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(54, 20);
            lblHoTen.TabIndex = 0;
            lblHoTen.Text = "Họ tên";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(145, 27);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(200, 27);
            txtHoTen.TabIndex = 1;
            // 
            // lblSdt
            // 
            lblSdt.AutoSize = true;
            lblSdt.Location = new Point(35, 75);
            lblSdt.Name = "lblSdt";
            lblSdt.Size = new Size(97, 20);
            lblSdt.TabIndex = 2;
            lblSdt.Text = "Số điện thoại";
            // 
            // txtSdt
            // 
            txtSdt.Location = new Point(145, 72);
            txtSdt.Name = "txtSdt";
            txtSdt.Size = new Size(200, 27);
            txtSdt.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(35, 120);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(145, 117);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 27);
            txtEmail.TabIndex = 5;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(35, 165);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(74, 20);
            lblNgaySinh.TabIndex = 6;
            lblNgaySinh.Text = "Ngày sinh";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(145, 162);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(200, 27);
            dtpNgaySinh.TabIndex = 7;
            // 
            // lblHangThanhVien
            // 
            lblHangThanhVien.AutoSize = true;
            lblHangThanhVien.Location = new Point(35, 210);
            lblHangThanhVien.Name = "lblHangThanhVien";
            lblHangThanhVien.Size = new Size(116, 20);
            lblHangThanhVien.TabIndex = 8;
            lblHangThanhVien.Text = "Hạng thành viên";
            // 
            // cboHangThanhVien
            // 
            cboHangThanhVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHangThanhVien.FormattingEnabled = true;
            cboHangThanhVien.Items.AddRange(new object[] { "Basic", "VIP", "Premium" });
            cboHangThanhVien.Location = new Point(145, 207);
            cboHangThanhVien.Name = "cboHangThanhVien";
            cboHangThanhVien.Size = new Size(200, 28);
            cboHangThanhVien.TabIndex = 9;
            // 
            // chkTrangThai
            // 
            chkTrangThai.AutoSize = true;
            chkTrangThai.Checked = true;
            chkTrangThai.CheckState = CheckState.Checked;
            chkTrangThai.Location = new Point(35, 255);
            chkTrangThai.Name = "chkTrangThai";
            chkTrangThai.Size = new Size(137, 24);
            chkTrangThai.TabIndex = 10;
            chkTrangThai.Text = "Đang hoạt động";
            chkTrangThai.UseVisualStyleBackColor = true;
            // 
            // grpGioiTinh
            // 
            grpGioiTinh.Controls.Add(radNu);
            grpGioiTinh.Controls.Add(radNam);
            grpGioiTinh.Location = new Point(390, 27);
            grpGioiTinh.Name = "grpGioiTinh";
            grpGioiTinh.Size = new Size(200, 75);
            grpGioiTinh.TabIndex = 11;
            grpGioiTinh.TabStop = false;
            grpGioiTinh.Text = "Giới tính";
            // 
            // radNu
            // 
            radNu.AutoSize = true;
            radNu.Location = new Point(115, 30);
            radNu.Name = "radNu";
            radNu.Size = new Size(50, 24);
            radNu.TabIndex = 1;
            radNu.TabStop = true;
            radNu.Text = "Nữ";
            radNu.UseVisualStyleBackColor = true;
            // 
            // radNam
            // 
            radNam.AutoSize = true;
            radNam.Checked = true;
            radNam.Location = new Point(25, 30);
            radNam.Name = "radNam";
            radNam.Size = new Size(62, 24);
            radNam.TabIndex = 0;
            radNam.TabStop = true;
            radNam.Text = "Nam";
            radNam.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(640, 25);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(140, 38);
            btnThem.TabIndex = 12;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(640, 75);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(140, 38);
            btnSua.TabIndex = 13;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(640, 125);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(140, 38);
            btnXoa.TabIndex = 14;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(640, 175);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(140, 38);
            btnLamMoi.TabIndex = 15;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // txtTimKiemHoTen
            // 
            txtTimKiemHoTen.Location = new Point(35, 310);
            txtTimKiemHoTen.Name = "txtTimKiemHoTen";
            txtTimKiemHoTen.PlaceholderText = "Nhập họ tên cần tìm...";
            txtTimKiemHoTen.Size = new Size(310, 27);
            txtTimKiemHoTen.TabIndex = 16;
            // 
            // lblTimKiemHang
            // 
            lblTimKiemHang.AutoSize = true;
            lblTimKiemHang.Location = new Point(365, 313);
            lblTimKiemHang.Name = "lblTimKiemHang";
            lblTimKiemHang.Size = new Size(116, 20);
            lblTimKiemHang.TabIndex = 17;
            lblTimKiemHang.Text = "Hạng thành viên";
            // 
            // cboTimKiemHang
            // 
            cboTimKiemHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTimKiemHang.FormattingEnabled = true;
            cboTimKiemHang.Items.AddRange(new object[] { "-- Tất cả --", "Basic", "VIP", "Premium" });
            cboTimKiemHang.Location = new Point(485, 310);
            cboTimKiemHang.Name = "cboTimKiemHang";
            cboTimKiemHang.Size = new Size(130, 28);
            cboTimKiemHang.TabIndex = 18;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(640, 305);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(140, 36);
            btnTimKiem.TabIndex = 19;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // dgvHoiVien
            // 
            dgvHoiVien.AllowUserToAddRows = false;
            dgvHoiVien.AllowUserToDeleteRows = false;
            dgvHoiVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoiVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoiVien.Location = new Point(35, 355);
            dgvHoiVien.MultiSelect = false;
            dgvHoiVien.Name = "dgvHoiVien";
            dgvHoiVien.ReadOnly = true;
            dgvHoiVien.RowHeadersWidth = 51;
            dgvHoiVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoiVien.Size = new Size(745, 270);
            dgvHoiVien.TabIndex = 20;
            dgvHoiVien.CellClick += dgvHoiVien_CellClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(815, 645);
            Controls.Add(dgvHoiVien);
            Controls.Add(btnTimKiem);
            Controls.Add(cboTimKiemHang);
            Controls.Add(lblTimKiemHang);
            Controls.Add(txtTimKiemHoTen);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(grpGioiTinh);
            Controls.Add(chkTrangThai);
            Controls.Add(cboHangThanhVien);
            Controls.Add(lblHangThanhVien);
            Controls.Add(dtpNgaySinh);
            Controls.Add(lblNgaySinh);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtSdt);
            Controls.Add(lblSdt);
            Controls.Add(txtHoTen);
            Controls.Add(lblHoTen);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Hội Viên Phòng Gym FitZone";
            Load += Form1_Load;
            grpGioiTinh.ResumeLayout(false);
            grpGioiTinh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoiVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblSdt;
        private TextBox txtSdt;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblNgaySinh;
        private DateTimePicker dtpNgaySinh;
        private Label lblHangThanhVien;
        private ComboBox cboHangThanhVien;
        private CheckBox chkTrangThai;
        private GroupBox grpGioiTinh;
        private RadioButton radNu;
        private RadioButton radNam;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private TextBox txtTimKiemHoTen;
        private Label lblTimKiemHang;
        private ComboBox cboTimKiemHang;
        private Button btnTimKiem;
        private DataGridView dgvHoiVien;
    }
}
