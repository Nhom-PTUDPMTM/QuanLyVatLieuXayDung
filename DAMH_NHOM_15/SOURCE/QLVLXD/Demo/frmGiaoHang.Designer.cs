﻿namespace Demo
{
    partial class frmGiaoHang
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpNgayGiao = new System.Windows.Forms.DateTimePicker();
            this.txtSoLuongGiao = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvCTGiaoHang = new System.Windows.Forms.DataGridView();
            this.btnLuu = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.btnLoc = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtViTri = new System.Windows.Forms.TextBox();
            this.btnInPhieu = new System.Windows.Forms.Button();
            this.btnHuyPhieuNhap = new System.Windows.Forms.Button();
            this.btnLuuPhieuNhap = new System.Windows.Forms.Button();
            this.btnTaoMoi = new System.Windows.Forms.Button();
            this.dgvGiaoHang = new System.Windows.Forms.DataGridView();
            this.txtMaPhieuXuat = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaGiaoHang = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvPhieuXuat = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchPhieuXuat = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTGiaoHang)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoHang)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuXuat)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpNgayGiao);
            this.groupBox3.Controls.Add(this.txtSoLuongGiao);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.dgvCTGiaoHang);
            this.groupBox3.Controls.Add(this.btnLuu);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.dtpStart);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.dtpEnd);
            this.groupBox3.Controls.Add(this.btnLoc);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox3.Location = new System.Drawing.Point(316, 324);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(747, 259);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chi tiết phiếu nhập";
            // 
            // dtpNgayGiao
            // 
            this.dtpNgayGiao.Location = new System.Drawing.Point(116, 70);
            this.dtpNgayGiao.Name = "dtpNgayGiao";
            this.dtpNgayGiao.Size = new System.Drawing.Size(232, 26);
            this.dtpNgayGiao.TabIndex = 27;
            // 
            // txtSoLuongGiao
            // 
            this.txtSoLuongGiao.Location = new System.Drawing.Point(496, 71);
            this.txtSoLuongGiao.Name = "txtSoLuongGiao";
            this.txtSoLuongGiao.Size = new System.Drawing.Size(228, 26);
            this.txtSoLuongGiao.TabIndex = 26;
            this.txtSoLuongGiao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSoLuongGiao_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(370, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 18);
            this.label8.TabIndex = 23;
            this.label8.Text = "Số lượng giao";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.Location = new System.Drawing.Point(31, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 18);
            this.label9.TabIndex = 21;
            this.label9.Text = "Ngày giao";
            // 
            // dgvCTGiaoHang
            // 
            this.dgvCTGiaoHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTGiaoHang.Location = new System.Drawing.Point(12, 110);
            this.dgvCTGiaoHang.Name = "dgvCTGiaoHang";
            this.dgvCTGiaoHang.Size = new System.Drawing.Size(729, 137);
            this.dgvCTGiaoHang.TabIndex = 20;
            this.dgvCTGiaoHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCTGiaoHang_CellClick);
            this.dgvCTGiaoHang.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCTGiaoHang_CellEndEdit);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(659, 15);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(82, 40);
            this.btnLuu.TabIndex = 19;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(18, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Từ";
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(52, 25);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 26);
            this.dtpStart.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(258, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Đến";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(301, 25);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 26);
            this.dtpEnd.TabIndex = 7;
            // 
            // btnLoc
            // 
            this.btnLoc.Location = new System.Drawing.Point(507, 24);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(79, 25);
            this.btnLoc.TabIndex = 8;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtViTri);
            this.groupBox2.Controls.Add(this.btnInPhieu);
            this.groupBox2.Controls.Add(this.btnHuyPhieuNhap);
            this.groupBox2.Controls.Add(this.btnLuuPhieuNhap);
            this.groupBox2.Controls.Add(this.btnTaoMoi);
            this.groupBox2.Controls.Add(this.dgvGiaoHang);
            this.groupBox2.Controls.Add(this.txtMaPhieuXuat);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtMaGiaoHang);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox2.Location = new System.Drawing.Point(316, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(747, 309);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin giao hàng";
            // 
            // txtViTri
            // 
            this.txtViTri.Location = new System.Drawing.Point(296, 39);
            this.txtViTri.Name = "txtViTri";
            this.txtViTri.Size = new System.Drawing.Size(183, 26);
            this.txtViTri.TabIndex = 20;
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Location = new System.Drawing.Point(275, 263);
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.Size = new System.Drawing.Size(82, 40);
            this.btnInPhieu.TabIndex = 19;
            this.btnInPhieu.Text = "In phiếu";
            this.btnInPhieu.UseVisualStyleBackColor = true;
            // 
            // btnHuyPhieuNhap
            // 
            this.btnHuyPhieuNhap.Location = new System.Drawing.Point(599, 263);
            this.btnHuyPhieuNhap.Name = "btnHuyPhieuNhap";
            this.btnHuyPhieuNhap.Size = new System.Drawing.Size(142, 40);
            this.btnHuyPhieuNhap.TabIndex = 18;
            this.btnHuyPhieuNhap.Text = "Hủy giao hàng";
            this.btnHuyPhieuNhap.UseVisualStyleBackColor = true;
            this.btnHuyPhieuNhap.Click += new System.EventHandler(this.btnHuyPhieuNhap_Click);
            // 
            // btnLuuPhieuNhap
            // 
            this.btnLuuPhieuNhap.Location = new System.Drawing.Point(451, 263);
            this.btnLuuPhieuNhap.Name = "btnLuuPhieuNhap";
            this.btnLuuPhieuNhap.Size = new System.Drawing.Size(142, 40);
            this.btnLuuPhieuNhap.TabIndex = 17;
            this.btnLuuPhieuNhap.Text = "Lưu giao hàng";
            this.btnLuuPhieuNhap.UseVisualStyleBackColor = true;
            this.btnLuuPhieuNhap.Click += new System.EventHandler(this.btnLuuPhieuNhap_Click);
            // 
            // btnTaoMoi
            // 
            this.btnTaoMoi.Location = new System.Drawing.Point(363, 263);
            this.btnTaoMoi.Name = "btnTaoMoi";
            this.btnTaoMoi.Size = new System.Drawing.Size(82, 40);
            this.btnTaoMoi.TabIndex = 16;
            this.btnTaoMoi.Text = "Tạo mới";
            this.btnTaoMoi.UseVisualStyleBackColor = true;
            this.btnTaoMoi.Click += new System.EventHandler(this.btnTaoMoi_Click);
            // 
            // dgvGiaoHang
            // 
            this.dgvGiaoHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGiaoHang.Location = new System.Drawing.Point(12, 86);
            this.dgvGiaoHang.Name = "dgvGiaoHang";
            this.dgvGiaoHang.Size = new System.Drawing.Size(729, 171);
            this.dgvGiaoHang.TabIndex = 15;
            this.dgvGiaoHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGiaoHang_CellClick);
            // 
            // txtMaPhieuXuat
            // 
            this.txtMaPhieuXuat.Location = new System.Drawing.Point(592, 39);
            this.txtMaPhieuXuat.Name = "txtMaPhieuXuat";
            this.txtMaPhieuXuat.Size = new System.Drawing.Size(143, 26);
            this.txtMaPhieuXuat.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(482, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "Mã phiếu xuất";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(251, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "Vị trí";
            // 
            // txtMaGiaoHang
            // 
            this.txtMaGiaoHang.Location = new System.Drawing.Point(125, 39);
            this.txtMaGiaoHang.Name = "txtMaGiaoHang";
            this.txtMaGiaoHang.Size = new System.Drawing.Size(120, 26);
            this.txtMaGiaoHang.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(18, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Mã giao hàng";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvPhieuXuat);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(15, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 535);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách phiếu xuất";
            // 
            // dgvPhieuXuat
            // 
            this.dgvPhieuXuat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuXuat.Location = new System.Drawing.Point(6, 23);
            this.dgvPhieuXuat.Name = "dgvPhieuXuat";
            this.dgvPhieuXuat.Size = new System.Drawing.Size(283, 500);
            this.dgvPhieuXuat.TabIndex = 0;
            this.dgvPhieuXuat.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuXuat_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tìm hóa đơn";
            // 
            // txtSearchPhieuXuat
            // 
            this.txtSearchPhieuXuat.Location = new System.Drawing.Point(95, 9);
            this.txtSearchPhieuXuat.Name = "txtSearchPhieuXuat";
            this.txtSearchPhieuXuat.Size = new System.Drawing.Size(152, 20);
            this.txtSearchPhieuXuat.TabIndex = 15;
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Arial", 12F);
            this.btnTim.Location = new System.Drawing.Point(253, 1);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(57, 34);
            this.btnTim.TabIndex = 16;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            // 
            // frmGiaoHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 601);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.txtSearchPhieuXuat);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmGiaoHang";
            this.Text = "frmGiaoHang";
            this.Load += new System.EventHandler(this.frmGiaoHang_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTGiaoHang)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoHang)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuXuat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvCTGiaoHang;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnInPhieu;
        private System.Windows.Forms.Button btnHuyPhieuNhap;
        private System.Windows.Forms.Button btnLuuPhieuNhap;
        private System.Windows.Forms.Button btnTaoMoi;
        private System.Windows.Forms.DataGridView dgvGiaoHang;
        private System.Windows.Forms.TextBox txtMaPhieuXuat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaGiaoHang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvPhieuXuat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchPhieuXuat;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtViTri;
        private System.Windows.Forms.TextBox txtSoLuongGiao;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpNgayGiao;
    }
}