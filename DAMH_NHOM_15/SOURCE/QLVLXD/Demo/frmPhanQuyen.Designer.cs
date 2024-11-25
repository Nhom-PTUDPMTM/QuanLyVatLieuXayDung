namespace Demo
{
    partial class frmPhanQuyen
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
            this.dgvData = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkHoatDong = new DevExpress.XtraEditors.CheckEdit();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.cboVaiTro = new DevExpress.XtraEditors.LookUpEdit();
            this.cboManHinh = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHoatDong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVaiTro.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboManHinh.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.Location = new System.Drawing.Point(15, 179);
            this.dgvData.MainView = this.gridView1;
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(865, 336);
            this.dgvData.TabIndex = 0;
            this.dgvData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.dgvData;
            this.gridView1.Name = "gridView1";
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.label11.Location = new System.Drawing.Point(259, 8);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(371, 37);
            this.label11.TabIndex = 102;
            this.label11.Text = "QUẢN LÝ PHÂN QUYỀN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(497, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 105;
            this.label3.Text = "Hoạt động";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(99, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 18);
            this.label1.TabIndex = 104;
            this.label1.Text = "Màn hình";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(99, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 18);
            this.label4.TabIndex = 103;
            this.label4.Text = "Vai trò";
            // 
            // chkHoatDong
            // 
            this.chkHoatDong.Location = new System.Drawing.Point(596, 89);
            this.chkHoatDong.Name = "chkHoatDong";
            this.chkHoatDong.Properties.Caption = "";
            this.chkHoatDong.Size = new System.Drawing.Size(75, 20);
            this.chkHoatDong.TabIndex = 108;
            // 
            // btnThem
            // 
            this.btnThem.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThem.Appearance.Options.UseFont = true;
            this.btnThem.Location = new System.Drawing.Point(486, 521);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(215, 52);
            this.btnThem.TabIndex = 110;
            this.btnThem.Text = "Thêm vai trò vào phân quyền";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.Location = new System.Drawing.Point(749, 521);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(131, 52);
            this.btnLuu.TabIndex = 111;
            this.btnLuu.Text = "Lưu toàn bộ";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // cboVaiTro
            // 
            this.cboVaiTro.Location = new System.Drawing.Point(184, 85);
            this.cboVaiTro.Name = "cboVaiTro";
            this.cboVaiTro.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboVaiTro.Properties.Appearance.Options.UseFont = true;
            this.cboVaiTro.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboVaiTro.Size = new System.Drawing.Size(258, 24);
            this.cboVaiTro.TabIndex = 112;
            this.cboVaiTro.EditValueChanged += new System.EventHandler(this.cboVaiTro_EditValueChanged);
            // 
            // cboManHinh
            // 
            this.cboManHinh.Location = new System.Drawing.Point(184, 129);
            this.cboManHinh.Name = "cboManHinh";
            this.cboManHinh.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cboManHinh.Properties.Appearance.Options.UseFont = true;
            this.cboManHinh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboManHinh.Size = new System.Drawing.Size(258, 24);
            this.cboManHinh.TabIndex = 113;
            // 
            // frmPhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 578);
            this.Controls.Add(this.cboManHinh);
            this.Controls.Add(this.cboVaiTro);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.chkHoatDong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dgvData);
            this.Name = "frmPhanQuyen";
            this.Load += new System.EventHandler(this.frmPhanQuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHoatDong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVaiTro.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboManHinh.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgvData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.CheckEdit chkHoatDong;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.LookUpEdit cboVaiTro;
        private DevExpress.XtraEditors.LookUpEdit cboManHinh;
    }
}