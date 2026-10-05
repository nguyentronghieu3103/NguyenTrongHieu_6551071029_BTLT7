namespace Bai4
{
    partial class Form1
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
            lblTenBenhNhan = new Label();
            txtTenBenhNhan = new TextBox();
            lblSdt = new Label();
            txtSdt = new TextBox();
            lblNgayKham = new Label();
            dtpNgayKham = new DateTimePicker();
            lblGioKham = new Label();
            dtpGioKham = new DateTimePicker();
            lblBacSi = new Label();
            cboBacSi = new ComboBox();
            lblTrangThai = new Label();
            cboTrangThai = new ComboBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lblTuNgay = new Label();
            dtpTuNgay = new DateTimePicker();
            lblDenNgay = new Label();
            dtpDenNgay = new DateTimePicker();
            cboLocBacSi = new ComboBox();
            btnTimKiem = new Button();
            btnQuanLyBacSi = new Button();
            dgvLichKham = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvLichKham).BeginInit();
            SuspendLayout();
            // 
            // lblTenBenhNhan
            // 
            lblTenBenhNhan.AutoSize = true;
            lblTenBenhNhan.Location = new Point(25, 23);
            lblTenBenhNhan.Name = "lblTenBenhNhan";
            lblTenBenhNhan.Size = new Size(88, 15);
            lblTenBenhNhan.TabIndex = 0;
            lblTenBenhNhan.Text = "Tên bệnh nhân:";
            // 
            // txtTenBenhNhan
            // 
            txtTenBenhNhan.Location = new Point(125, 20);
            txtTenBenhNhan.Name = "txtTenBenhNhan";
            txtTenBenhNhan.Size = new Size(195, 23);
            txtTenBenhNhan.TabIndex = 1;
            // 
            // lblSdt
            // 
            lblSdt.AutoSize = true;
            lblSdt.Location = new Point(25, 60);
            lblSdt.Name = "lblSdt";
            lblSdt.Size = new Size(79, 15);
            lblSdt.TabIndex = 2;
            lblSdt.Text = "Số điện thoại:";
            // 
            // txtSdt
            // 
            txtSdt.Location = new Point(125, 57);
            txtSdt.Name = "txtSdt";
            txtSdt.Size = new Size(195, 23);
            txtSdt.TabIndex = 3;
            // 
            // lblNgayKham
            // 
            lblNgayKham.AutoSize = true;
            lblNgayKham.Location = new Point(25, 98);
            lblNgayKham.Name = "lblNgayKham";
            lblNgayKham.Size = new Size(71, 15);
            lblNgayKham.TabIndex = 4;
            lblNgayKham.Text = "Ngày khám:";
            // 
            // dtpNgayKham
            // 
            dtpNgayKham.CustomFormat = "dd/MM/yyyy";
            dtpNgayKham.Format = DateTimePickerFormat.Custom;
            dtpNgayKham.Location = new Point(125, 94);
            dtpNgayKham.Name = "dtpNgayKham";
            dtpNgayKham.Size = new Size(195, 23);
            dtpNgayKham.TabIndex = 5;
            // 
            // lblGioKham
            // 
            lblGioKham.AutoSize = true;
            lblGioKham.Location = new Point(340, 60);
            lblGioKham.Name = "lblGioKham";
            lblGioKham.Size = new Size(61, 15);
            lblGioKham.TabIndex = 6;
            lblGioKham.Text = "Giờ khám:";
            // 
            // dtpGioKham
            // 
            dtpGioKham.CustomFormat = "hh:mm tt";
            dtpGioKham.Format = DateTimePickerFormat.Custom;
            dtpGioKham.Location = new Point(340, 80);
            dtpGioKham.Name = "dtpGioKham";
            dtpGioKham.ShowUpDown = true;
            dtpGioKham.Size = new Size(115, 23);
            dtpGioKham.TabIndex = 7;
            // 
            // lblBacSi
            // 
            lblBacSi.AutoSize = true;
            lblBacSi.Location = new Point(480, 60);
            lblBacSi.Name = "lblBacSi";
            lblBacSi.Size = new Size(41, 15);
            lblBacSi.TabIndex = 8;
            lblBacSi.Text = "Bác sĩ:";
            // 
            // cboBacSi
            // 
            cboBacSi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBacSi.FormattingEnabled = true;
            cboBacSi.Location = new Point(480, 80);
            cboBacSi.Name = "cboBacSi";
            cboBacSi.Size = new Size(270, 23);
            cboBacSi.TabIndex = 9;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(775, 60);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(62, 15);
            lblTrangThai.TabIndex = 10;
            lblTrangThai.Text = "Trạng thái:";
            // 
            // cboTrangThai
            // 
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Items.AddRange(new object[] { "Chờ khám", "Đã khám", "Đã hủy" });
            cboTrangThai.Location = new Point(775, 80);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(180, 23);
            cboTrangThai.TabIndex = 11;
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThem.Location = new Point(690, 16);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(65, 30);
            btnThem.TabIndex = 12;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSua.Location = new Point(765, 16);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(65, 30);
            btnSua.TabIndex = 13;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXoa.Location = new Point(840, 16);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(65, 30);
            btnXoa.TabIndex = 14;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.Location = new Point(915, 16);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(75, 30);
            btnLamMoi.TabIndex = 15;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // lblTuNgay
            // 
            lblTuNgay.AutoSize = true;
            lblTuNgay.Location = new Point(25, 140);
            lblTuNgay.Name = "lblTuNgay";
            lblTuNgay.Size = new Size(52, 15);
            lblTuNgay.TabIndex = 16;
            lblTuNgay.Text = "Từ ngày:";
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.Location = new Point(82, 136);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(115, 23);
            dtpTuNgay.TabIndex = 17;
            // 
            // lblDenNgay
            // 
            lblDenNgay.AutoSize = true;
            lblDenNgay.Location = new Point(215, 140);
            lblDenNgay.Name = "lblDenNgay";
            lblDenNgay.Size = new Size(60, 15);
            lblDenNgay.TabIndex = 18;
            lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.Location = new Point(280, 136);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(115, 23);
            dtpDenNgay.TabIndex = 19;
            // 
            // cboLocBacSi
            // 
            cboLocBacSi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocBacSi.FormattingEnabled = true;
            cboLocBacSi.Location = new Point(415, 136);
            cboLocBacSi.Name = "cboLocBacSi";
            cboLocBacSi.Size = new Size(255, 23);
            cboLocBacSi.TabIndex = 20;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(685, 133);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(80, 28);
            btnTimKiem.TabIndex = 21;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnQuanLyBacSi
            // 
            btnQuanLyBacSi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnQuanLyBacSi.Location = new Point(875, 133);
            btnQuanLyBacSi.Name = "btnQuanLyBacSi";
            btnQuanLyBacSi.Size = new Size(115, 28);
            btnQuanLyBacSi.TabIndex = 22;
            btnQuanLyBacSi.Text = "Quản lý Bác sĩ";
            btnQuanLyBacSi.UseVisualStyleBackColor = true;
            btnQuanLyBacSi.Click += btnQuanLyBacSi_Click;
            // 
            // dgvLichKham
            // 
            dgvLichKham.AllowUserToAddRows = false;
            dgvLichKham.AllowUserToDeleteRows = false;
            dgvLichKham.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLichKham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLichKham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLichKham.Location = new Point(25, 175);
            dgvLichKham.MultiSelect = false;
            dgvLichKham.Name = "dgvLichKham";
            dgvLichKham.ReadOnly = true;
            dgvLichKham.RowHeadersWidth = 35;
            dgvLichKham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLichKham.Size = new Size(965, 380);
            dgvLichKham.TabIndex = 23;
            dgvLichKham.CellClick += dgvLichKham_CellClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1014, 576);
            Controls.Add(dgvLichKham);
            Controls.Add(btnQuanLyBacSi);
            Controls.Add(btnTimKiem);
            Controls.Add(cboLocBacSi);
            Controls.Add(dtpDenNgay);
            Controls.Add(lblDenNgay);
            Controls.Add(dtpTuNgay);
            Controls.Add(lblTuNgay);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(cboTrangThai);
            Controls.Add(lblTrangThai);
            Controls.Add(cboBacSi);
            Controls.Add(lblBacSi);
            Controls.Add(dtpGioKham);
            Controls.Add(lblGioKham);
            Controls.Add(dtpNgayKham);
            Controls.Add(lblNgayKham);
            Controls.Add(txtSdt);
            Controls.Add(lblSdt);
            Controls.Add(txtTenBenhNhan);
            Controls.Add(lblTenBenhNhan);
            MinimumSize = new Size(950, 500);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Lịch Khám Bệnh - An Khang Clinic";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLichKham).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTenBenhNhan;
        private TextBox txtTenBenhNhan;
        private Label lblSdt;
        private TextBox txtSdt;
        private Label lblNgayKham;
        private DateTimePicker dtpNgayKham;
        private Label lblGioKham;
        private DateTimePicker dtpGioKham;
        private Label lblBacSi;
        private ComboBox cboBacSi;
        private Label lblTrangThai;
        private ComboBox cboTrangThai;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lblTuNgay;
        private DateTimePicker dtpTuNgay;
        private Label lblDenNgay;
        private DateTimePicker dtpDenNgay;
        private ComboBox cboLocBacSi;
        private Button btnTimKiem;
        private Button btnQuanLyBacSi;
        private DataGridView dgvLichKham;
    }
}
