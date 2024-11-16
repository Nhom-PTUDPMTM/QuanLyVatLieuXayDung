namespace Demo
{
    partial class frmXuatHang
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
            this.components = new System.ComponentModel.Container();
            this.cboLoaiHang = new System.Windows.Forms.ComboBox();
            this.dgvCTPhieuXuat = new System.Windows.Forms.DataGridView();
            this.btnLuu = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnInPhieu = new System.Windows.Forms.Button();
            this.btnHuyPhieuXuat = new System.Windows.Forms.Button();
            this.btnLuuPhieuXuat = new System.Windows.Forms.Button();
            this.btnTaoMoi = new System.Windows.Forms.Button();
            this.dgvPhieuxuat = new System.Windows.Forms.DataGridView();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpNgayXuat = new System.Windows.Forms.DateTimePicker();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaPhieuXuat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLoc = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThemSanPham = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboTinhTrang = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chuotPhai = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTPhieuXuat)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuxuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboLoaiHang
            // 
            this.cboLoaiHang.FormattingEnabled = true;
            this.cboLoaiHang.Location = new System.Drawing.Point(169, 14);
            this.cboLoaiHang.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboLoaiHang.Name = "cboLoaiHang";
            this.cboLoaiHang.Size = new System.Drawing.Size(282, 28);
            this.cboLoaiHang.TabIndex = 21;
            this.cboLoaiHang.SelectedIndexChanged += new System.EventHandler(this.cboLoaiHang_SelectedIndexChanged);
            // 
            // dgvCTPhieuXuat
            // 
            this.dgvCTPhieuXuat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTPhieuXuat.ContextMenuStrip = this.chuotPhai;
            this.dgvCTPhieuXuat.Location = new System.Drawing.Point(15, 95);
            this.dgvCTPhieuXuat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvCTPhieuXuat.Name = "dgvCTPhieuXuat";
            this.dgvCTPhieuXuat.RowHeadersWidth = 62;
            this.dgvCTPhieuXuat.Size = new System.Drawing.Size(1094, 288);
            this.dgvCTPhieuXuat.TabIndex = 20;
            this.dgvCTPhieuXuat.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCTPhieuXuat_CellEndEdit);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(988, 38);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(101, 47);
            this.btnLuu.TabIndex = 19;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvCTPhieuXuat);
            this.groupBox3.Controls.Add(this.btnLuu);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox3.Location = new System.Drawing.Point(459, 560);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(1122, 374);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chi tiết phiếu xuất";
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Location = new System.Drawing.Point(412, 460);
            this.btnInPhieu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.Size = new System.Drawing.Size(123, 62);
            this.btnInPhieu.TabIndex = 19;
            this.btnInPhieu.Text = "In phiếu";
            this.btnInPhieu.UseVisualStyleBackColor = true;
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // btnHuyPhieuXuat
            // 
            this.btnHuyPhieuXuat.Location = new System.Drawing.Point(898, 460);
            this.btnHuyPhieuXuat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHuyPhieuXuat.Name = "btnHuyPhieuXuat";
            this.btnHuyPhieuXuat.Size = new System.Drawing.Size(213, 62);
            this.btnHuyPhieuXuat.TabIndex = 18;
            this.btnHuyPhieuXuat.Text = "Hủy phiếu xuất";
            this.btnHuyPhieuXuat.UseVisualStyleBackColor = true;
            this.btnHuyPhieuXuat.Click += new System.EventHandler(this.btnHuyPhieuXuat_Click);
            // 
            // btnLuuPhieuXuat
            // 
            this.btnLuuPhieuXuat.Location = new System.Drawing.Point(676, 460);
            this.btnLuuPhieuXuat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLuuPhieuXuat.Name = "btnLuuPhieuXuat";
            this.btnLuuPhieuXuat.Size = new System.Drawing.Size(213, 62);
            this.btnLuuPhieuXuat.TabIndex = 17;
            this.btnLuuPhieuXuat.Text = "Lưu phiếu xuất";
            this.btnLuuPhieuXuat.UseVisualStyleBackColor = true;
            this.btnLuuPhieuXuat.Click += new System.EventHandler(this.btnLuuPhieuXuat_Click);
            // 
            // btnTaoMoi
            // 
            this.btnTaoMoi.Location = new System.Drawing.Point(544, 460);
            this.btnTaoMoi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTaoMoi.Name = "btnTaoMoi";
            this.btnTaoMoi.Size = new System.Drawing.Size(123, 62);
            this.btnTaoMoi.TabIndex = 16;
            this.btnTaoMoi.Text = "Tạo mới";
            this.btnTaoMoi.UseVisualStyleBackColor = true;
            this.btnTaoMoi.Click += new System.EventHandler(this.btnTaoMoi_Click);
            // 
            // dgvPhieuxuat
            // 
            this.dgvPhieuxuat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuxuat.Location = new System.Drawing.Point(18, 187);
            this.dgvPhieuxuat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvPhieuxuat.Name = "dgvPhieuxuat";
            this.dgvPhieuxuat.RowHeadersWidth = 62;
            this.dgvPhieuxuat.Size = new System.Drawing.Size(1094, 263);
            this.dgvPhieuxuat.TabIndex = 15;
            this.dgvPhieuxuat.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuxuat_CellClick);
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Location = new System.Drawing.Point(946, 130);
            this.txtThanhTien.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.Size = new System.Drawing.Size(163, 35);
            this.txtThanhTien.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(819, 143);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 27);
            this.label6.TabIndex = 13;
            this.label6.Text = "Thành tiền";
            // 
            // dtpNgayXuat
            // 
            this.dtpNgayXuat.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayXuat.Location = new System.Drawing.Point(504, 137);
            this.dtpNgayXuat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpNgayXuat.Name = "dtpNgayXuat";
            this.dtpNgayXuat.Size = new System.Drawing.Size(300, 35);
            this.dtpNgayXuat.TabIndex = 12;
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Location = new System.Drawing.Point(9, 35);
            this.dgvSanPham.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.RowHeadersWidth = 62;
            this.dgvSanPham.Size = new System.Drawing.Size(424, 712);
            this.dgvSanPham.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(376, 143);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 27);
            this.label5.TabIndex = 11;
            this.label5.Text = "Ngày xuất";
            // 
            // txtMaPhieuXuat
            // 
            this.txtMaPhieuXuat.Location = new System.Drawing.Point(195, 143);
            this.txtMaPhieuXuat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMaPhieuXuat.Name = "txtMaPhieuXuat";
            this.txtMaPhieuXuat.Size = new System.Drawing.Size(178, 35);
            this.txtMaPhieuXuat.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(14, 150);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 27);
            this.label4.TabIndex = 9;
            this.label4.Text = "Mã phiếu xuất";
            // 
            // btnLoc
            // 
            this.btnLoc.Location = new System.Drawing.Point(921, 32);
            this.btnLoc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(118, 38);
            this.btnLoc.TabIndex = 8;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(580, 34);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(298, 35);
            this.dtpEnd.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(516, 43);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 27);
            this.label3.TabIndex = 6;
            this.label3.Text = "Đến";
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(188, 34);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(298, 35);
            this.dtpStart.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(136, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "Từ";
            // 
            // btnThemSanPham
            // 
            this.btnThemSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThemSanPham.Location = new System.Drawing.Point(348, 757);
            this.btnThemSanPham.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnThemSanPham.Name = "btnThemSanPham";
            this.btnThemSanPham.Size = new System.Drawing.Size(86, 57);
            this.btnThemSanPham.TabIndex = 1;
            this.btnThemSanPham.Text = ">>";
            this.btnThemSanPham.UseVisualStyleBackColor = true;
            this.btnThemSanPham.Click += new System.EventHandler(this.btnThemSanPham_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(5, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 27);
            this.label1.TabIndex = 20;
            this.label1.Text = "Loại Hàng";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnThemSanPham);
            this.groupBox1.Controls.Add(this.dgvSanPham);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(9, 74);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(442, 823);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sản phẩm";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboTinhTrang);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cboNhanVien);
            this.groupBox2.Controls.Add(this.txtMaKH);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnInPhieu);
            this.groupBox2.Controls.Add(this.btnHuyPhieuXuat);
            this.groupBox2.Controls.Add(this.btnLuuPhieuXuat);
            this.groupBox2.Controls.Add(this.btnTaoMoi);
            this.groupBox2.Controls.Add(this.dgvPhieuxuat);
            this.groupBox2.Controls.Add(this.txtThanhTien);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dtpNgayXuat);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtMaPhieuXuat);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnLoc);
            this.groupBox2.Controls.Add(this.dtpEnd);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dtpStart);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox2.Location = new System.Drawing.Point(461, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(1120, 536);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin phiếu xuất";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // cboTinhTrang
            // 
            this.cboTinhTrang.FormattingEnabled = true;
            this.cboTinhTrang.Location = new System.Drawing.Point(950, 82);
            this.cboTinhTrang.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboTinhTrang.Name = "cboTinhTrang";
            this.cboTinhTrang.Size = new System.Drawing.Size(163, 35);
            this.cboTinhTrang.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.Location = new System.Drawing.Point(819, 87);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 27);
            this.label9.TabIndex = 25;
            this.label9.Text = "Tình trạng";
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(188, 87);
            this.cboNhanVien.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(185, 35);
            this.cboNhanVien.TabIndex = 24;
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(593, 87);
            this.txtMaKH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(178, 35);
            this.txtMaKH.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(407, 90);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(178, 27);
            this.label8.TabIndex = 22;
            this.label8.Text = "Mã khách hàng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(24, 95);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 27);
            this.label7.TabIndex = 20;
            this.label7.Text = "Mã nhân viên";
            // 
            // chuotPhai
            // 
            this.chuotPhai.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.chuotPhai.Name = "chuotPhai";
            this.chuotPhai.Size = new System.Drawing.Size(61, 4);
            // 
            // frmXuatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1624, 929);
            this.Controls.Add(this.cboLoaiHang);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmXuatHang";
            this.Text = "frmXuatHang";
            this.Load += new System.EventHandler(this.frmXuatHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTPhieuXuat)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuxuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboLoaiHang;
        private System.Windows.Forms.DataGridView dgvCTPhieuXuat;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnInPhieu;
        private System.Windows.Forms.Button btnHuyPhieuXuat;
        private System.Windows.Forms.Button btnLuuPhieuXuat;
        private System.Windows.Forms.Button btnTaoMoi;
        private System.Windows.Forms.DataGridView dgvPhieuxuat;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpNgayXuat;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaPhieuXuat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThemSanPham;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboTinhTrang;
        private System.Windows.Forms.ContextMenuStrip chuotPhai;
    }
}