namespace Bai1
{
    partial class FormQuanLyTheLoai
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblMaTL = new System.Windows.Forms.Label();
            txtMaTL = new System.Windows.Forms.TextBox();
            lblTenTL = new System.Windows.Forms.Label();
            txtTenTL = new System.Windows.Forms.TextBox();
            lblMoTa = new System.Windows.Forms.Label();
            txtMoTa = new System.Windows.Forms.TextBox();
            lblTieuDeNgayTao = new System.Windows.Forms.Label();
            lblNgayTao = new System.Windows.Forms.Label();
            btnThem = new System.Windows.Forms.Button();
            btnSua = new System.Windows.Forms.Button();
            btnXoa = new System.Windows.Forms.Button();
            btnLamMoi = new System.Windows.Forms.Button();
            txtTimKiem = new System.Windows.Forms.TextBox();
            btnTimKiem = new System.Windows.Forms.Button();
            dgvTheLoai = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTheLoai).BeginInit();
            SuspendLayout();
            // 
            // lblMaTL
            // 
            lblMaTL.AutoSize = true;
            lblMaTL.Location = new System.Drawing.Point(20, 20);
            lblMaTL.Name = "lblMaTL";
            lblMaTL.Size = new System.Drawing.Size(68, 15);
            lblMaTL.TabIndex = 0;
            lblMaTL.Text = "Mã thể loại:";
            // 
            // txtMaTL
            // 
            txtMaTL.BackColor = System.Drawing.Color.LightGray;
            txtMaTL.Location = new System.Drawing.Point(120, 20);
            txtMaTL.Name = "txtMaTL";
            txtMaTL.ReadOnly = true;
            txtMaTL.Size = new System.Drawing.Size(300, 23);
            txtMaTL.TabIndex = 1;
            // 
            // lblTenTL
            // 
            lblTenTL.AutoSize = true;
            lblTenTL.Location = new System.Drawing.Point(20, 60);
            lblTenTL.Name = "lblTenTL";
            lblTenTL.Size = new System.Drawing.Size(71, 15);
            lblTenTL.TabIndex = 2;
            lblTenTL.Text = "Tên thể loại:";
            // 
            // txtTenTL
            // 
            txtTenTL.Location = new System.Drawing.Point(120, 60);
            txtTenTL.Name = "txtTenTL";
            txtTenTL.Size = new System.Drawing.Size(300, 23);
            txtTenTL.TabIndex = 3;
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new System.Drawing.Point(20, 100);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new System.Drawing.Size(41, 15);
            lblMoTa.TabIndex = 4;
            lblMoTa.Text = "Mô tả:";
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new System.Drawing.Point(120, 100);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtMoTa.Size = new System.Drawing.Size(300, 60);
            txtMoTa.TabIndex = 5;
            // 
            // lblTieuDeNgayTao
            // 
            lblTieuDeNgayTao.AutoSize = true;
            lblTieuDeNgayTao.Location = new System.Drawing.Point(450, 20);
            lblTieuDeNgayTao.Name = "lblTieuDeNgayTao";
            lblTieuDeNgayTao.Size = new System.Drawing.Size(58, 15);
            lblTieuDeNgayTao.TabIndex = 6;
            lblTieuDeNgayTao.Text = "Ngày tạo:";
            // 
            // lblNgayTao
            // 
            lblNgayTao.AutoSize = true;
            lblNgayTao.ForeColor = System.Drawing.Color.DarkBlue;
            lblNgayTao.Location = new System.Drawing.Point(520, 20);
            lblNgayTao.Name = "lblNgayTao";
            lblNgayTao.Size = new System.Drawing.Size(16, 15);
            lblNgayTao.TabIndex = 7;
            lblNgayTao.Text = "...";
            // 
            // btnThem
            // 
            btnThem.Location = new System.Drawing.Point(450, 60);
            btnThem.Name = "btnThem";
            btnThem.Size = new System.Drawing.Size(80, 28);
            btnThem.TabIndex = 8;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += BtnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new System.Drawing.Point(540, 60);
            btnSua.Name = "btnSua";
            btnSua.Size = new System.Drawing.Size(80, 28);
            btnSua.TabIndex = 9;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += BtnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new System.Drawing.Point(630, 60);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new System.Drawing.Size(80, 28);
            btnXoa.TabIndex = 10;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += BtnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new System.Drawing.Point(720, 60);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new System.Drawing.Size(80, 28);
            btnLamMoi.TabIndex = 11;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += BtnLamMoi_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new System.Drawing.Point(20, 180);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập tên thể loại để tìm kiếm...";
            txtTimKiem.Size = new System.Drawing.Size(300, 23);
            txtTimKiem.TabIndex = 12;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new System.Drawing.Point(330, 178);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new System.Drawing.Size(80, 28);
            btnTimKiem.TabIndex = 13;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += BtnTimKiem_Click;
            // 
            // dgvTheLoai
            // 
            dgvTheLoai.AllowUserToAddRows = false;
            dgvTheLoai.AllowUserToDeleteRows = false;
            dgvTheLoai.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvTheLoai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTheLoai.Location = new System.Drawing.Point(20, 220);
            dgvTheLoai.MultiSelect = false;
            dgvTheLoai.Name = "dgvTheLoai";
            dgvTheLoai.ReadOnly = true;
            dgvTheLoai.RowHeadersWidth = 51;
            dgvTheLoai.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvTheLoai.Size = new System.Drawing.Size(790, 220);
            dgvTheLoai.TabIndex = 14;
            dgvTheLoai.SelectionChanged += DgvTheLoai_SelectionChanged;
            // 
            // FormQuanLyTheLoai
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(834, 461);
            Controls.Add(lblMaTL);
            Controls.Add(txtMaTL);
            Controls.Add(lblTenTL);
            Controls.Add(txtTenTL);
            Controls.Add(lblMoTa);
            Controls.Add(txtMoTa);
            Controls.Add(lblTieuDeNgayTao);
            Controls.Add(lblNgayTao);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(txtTimKiem);
            Controls.Add(btnTimKiem);
            Controls.Add(dgvTheLoai);
            Name = "FormQuanLyTheLoai";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Quản Lý Thể Loại Sách - Tri Thức Books";
            Load += FormQuanLyTheLoai_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTheLoai).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblMaTL;
        private System.Windows.Forms.TextBox txtMaTL;
        private System.Windows.Forms.Label lblTenTL;
        private System.Windows.Forms.TextBox txtTenTL;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label lblTieuDeNgayTao;
        private System.Windows.Forms.Label lblNgayTao;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvTheLoai;
    }
}
