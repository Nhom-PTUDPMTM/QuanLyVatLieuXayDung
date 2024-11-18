namespace Demo
{
    partial class frmMain
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
            this.metroSetTabControl1 = new MetroSet_UI.Controls.MetroSetTabControl();
            this.tabQuanLy = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.pnlButtonQL = new MetroSet_UI.Controls.MetroSetPanel();
            this.btnXuatHang = new MetroSet_UI.Controls.MetroSetButton();
            this.btnNhapHang = new MetroSet_UI.Controls.MetroSetButton();
            this.btnNhaCungCap = new MetroSet_UI.Controls.MetroSetButton();
            this.btnLoaiHang = new MetroSet_UI.Controls.MetroSetButton();
            this.btnKhachHang = new MetroSet_UI.Controls.MetroSetButton();
            this.btnHangHoa = new MetroSet_UI.Controls.MetroSetButton();
            this.btnDatHang = new MetroSet_UI.Controls.MetroSetButton();
            this.btnGiaoHang = new MetroSet_UI.Controls.MetroSetButton();
            this.btnNhanVien = new MetroSet_UI.Controls.MetroSetButton();
            this.btnCungUng = new MetroSet_UI.Controls.MetroSetButton();
            this.pnlFormQL = new MetroSet_UI.Controls.MetroSetPanel();
            this.styleManager1 = new MetroSet_UI.Components.StyleManager();
            this.tabThongTin = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.txtMaNV = new MetroSet_UI.Controls.MetroSetTextBox();
            this.metroSetLabel1 = new MetroSet_UI.Controls.MetroSetLabel();
            this.tabChucNang = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.btnThoat = new MetroSet_UI.Controls.MetroSetButton();
            this.metroSetTabControl1.SuspendLayout();
            this.tabQuanLy.SuspendLayout();
            this.pnlButtonQL.SuspendLayout();
            this.tabThongTin.SuspendLayout();
            this.tabChucNang.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroSetTabControl1
            // 
            this.metroSetTabControl1.AnimateEasingType = MetroSet_UI.Enums.EasingType.CubeOut;
            this.metroSetTabControl1.AnimateTime = 200;
            this.metroSetTabControl1.BackgroundColor = System.Drawing.Color.White;
            this.metroSetTabControl1.Controls.Add(this.tabQuanLy);
            this.metroSetTabControl1.Controls.Add(this.tabThongTin);
            this.metroSetTabControl1.Controls.Add(this.tabChucNang);
            this.metroSetTabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroSetTabControl1.IsDerivedStyle = true;
            this.metroSetTabControl1.ItemSize = new System.Drawing.Size(100, 38);
            this.metroSetTabControl1.Location = new System.Drawing.Point(17, 89);
            this.metroSetTabControl1.Name = "metroSetTabControl1";
            this.metroSetTabControl1.SelectedIndex = 1;
            this.metroSetTabControl1.SelectedTextColor = System.Drawing.Color.White;
            this.metroSetTabControl1.Size = new System.Drawing.Size(1193, 723);
            this.metroSetTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.metroSetTabControl1.Speed = 100;
            this.metroSetTabControl1.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetTabControl1.StyleManager = this.styleManager1;
            this.metroSetTabControl1.TabIndex = 1;
            this.metroSetTabControl1.ThemeAuthor = "Narwin";
            this.metroSetTabControl1.ThemeName = "MetroLight";
            this.metroSetTabControl1.UnselectedTextColor = System.Drawing.Color.Gray;
            this.metroSetTabControl1.UseAnimation = false;
            // 
            // tabQuanLy
            // 
            this.tabQuanLy.BaseColor = System.Drawing.Color.White;
            this.tabQuanLy.Controls.Add(this.pnlButtonQL);
            this.tabQuanLy.Controls.Add(this.pnlFormQL);
            this.tabQuanLy.Font = null;
            this.tabQuanLy.ImageIndex = 0;
            this.tabQuanLy.ImageKey = null;
            this.tabQuanLy.IsDerivedStyle = true;
            this.tabQuanLy.Location = new System.Drawing.Point(4, 42);
            this.tabQuanLy.Name = "tabQuanLy";
            this.tabQuanLy.Size = new System.Drawing.Size(1185, 677);
            this.tabQuanLy.Style = MetroSet_UI.Enums.Style.Light;
            this.tabQuanLy.StyleManager = this.styleManager1;
            this.tabQuanLy.TabIndex = 1;
            this.tabQuanLy.Text = "Quản lý";
            this.tabQuanLy.ThemeAuthor = "Narwin";
            this.tabQuanLy.ThemeName = "MetroLite";
            this.tabQuanLy.ToolTipText = null;
            // 
            // pnlButtonQL
            // 
            this.pnlButtonQL.BackgroundColor = System.Drawing.Color.White;
            this.pnlButtonQL.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.pnlButtonQL.BorderThickness = 0;
            this.pnlButtonQL.Controls.Add(this.btnXuatHang);
            this.pnlButtonQL.Controls.Add(this.btnNhapHang);
            this.pnlButtonQL.Controls.Add(this.btnNhaCungCap);
            this.pnlButtonQL.Controls.Add(this.btnLoaiHang);
            this.pnlButtonQL.Controls.Add(this.btnKhachHang);
            this.pnlButtonQL.Controls.Add(this.btnHangHoa);
            this.pnlButtonQL.Controls.Add(this.btnDatHang);
            this.pnlButtonQL.Controls.Add(this.btnGiaoHang);
            this.pnlButtonQL.Controls.Add(this.btnNhanVien);
            this.pnlButtonQL.Controls.Add(this.btnCungUng);
            this.pnlButtonQL.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.pnlButtonQL.IsDerivedStyle = true;
            this.pnlButtonQL.Location = new System.Drawing.Point(3, 3);
            this.pnlButtonQL.Name = "pnlButtonQL";
            this.pnlButtonQL.Size = new System.Drawing.Size(200, 668);
            this.pnlButtonQL.Style = MetroSet_UI.Enums.Style.Light;
            this.pnlButtonQL.StyleManager = null;
            this.pnlButtonQL.TabIndex = 3;
            this.pnlButtonQL.ThemeAuthor = "Narwin";
            this.pnlButtonQL.ThemeName = "MetroLite";
            // 
            // btnXuatHang
            // 
            this.btnXuatHang.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnXuatHang.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnXuatHang.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnXuatHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnXuatHang.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnXuatHang.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnXuatHang.HoverTextColor = System.Drawing.Color.White;
            this.btnXuatHang.IsDerivedStyle = true;
            this.btnXuatHang.Location = new System.Drawing.Point(0, 561);
            this.btnXuatHang.Name = "btnXuatHang";
            this.btnXuatHang.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnXuatHang.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnXuatHang.NormalTextColor = System.Drawing.Color.White;
            this.btnXuatHang.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnXuatHang.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnXuatHang.PressTextColor = System.Drawing.Color.White;
            this.btnXuatHang.Size = new System.Drawing.Size(200, 57);
            this.btnXuatHang.Style = MetroSet_UI.Enums.Style.Light;
            this.btnXuatHang.StyleManager = null;
            this.btnXuatHang.TabIndex = 0;
            this.btnXuatHang.Text = "Xuất hàng";
            this.btnXuatHang.ThemeAuthor = "Narwin";
            this.btnXuatHang.ThemeName = "MetroLite";
            this.btnXuatHang.Click += new System.EventHandler(this.btnXuatHang_Click);
            // 
            // btnNhapHang
            // 
            this.btnNhapHang.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnNhapHang.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnNhapHang.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnNhapHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnNhapHang.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnNhapHang.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnNhapHang.HoverTextColor = System.Drawing.Color.White;
            this.btnNhapHang.IsDerivedStyle = true;
            this.btnNhapHang.Location = new System.Drawing.Point(0, 498);
            this.btnNhapHang.Name = "btnNhapHang";
            this.btnNhapHang.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnNhapHang.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnNhapHang.NormalTextColor = System.Drawing.Color.White;
            this.btnNhapHang.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnNhapHang.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnNhapHang.PressTextColor = System.Drawing.Color.White;
            this.btnNhapHang.Size = new System.Drawing.Size(200, 57);
            this.btnNhapHang.Style = MetroSet_UI.Enums.Style.Light;
            this.btnNhapHang.StyleManager = null;
            this.btnNhapHang.TabIndex = 11;
            this.btnNhapHang.Text = "Nhập hàng";
            this.btnNhapHang.ThemeAuthor = "Narwin";
            this.btnNhapHang.ThemeName = "MetroLite";
            this.btnNhapHang.Click += new System.EventHandler(this.btnNhapHang_Click);
            // 
            // btnNhaCungCap
            // 
            this.btnNhaCungCap.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnNhaCungCap.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnNhaCungCap.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnNhaCungCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnNhaCungCap.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnNhaCungCap.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnNhaCungCap.HoverTextColor = System.Drawing.Color.White;
            this.btnNhaCungCap.IsDerivedStyle = true;
            this.btnNhaCungCap.Location = new System.Drawing.Point(0, 435);
            this.btnNhaCungCap.Name = "btnNhaCungCap";
            this.btnNhaCungCap.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnNhaCungCap.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnNhaCungCap.NormalTextColor = System.Drawing.Color.White;
            this.btnNhaCungCap.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnNhaCungCap.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnNhaCungCap.PressTextColor = System.Drawing.Color.White;
            this.btnNhaCungCap.Size = new System.Drawing.Size(200, 57);
            this.btnNhaCungCap.Style = MetroSet_UI.Enums.Style.Light;
            this.btnNhaCungCap.StyleManager = null;
            this.btnNhaCungCap.TabIndex = 10;
            this.btnNhaCungCap.Text = "Nhà cung cấp";
            this.btnNhaCungCap.ThemeAuthor = "Narwin";
            this.btnNhaCungCap.ThemeName = "MetroLite";
            this.btnNhaCungCap.Click += new System.EventHandler(this.btnNhaCungCap_Click);
            // 
            // btnLoaiHang
            // 
            this.btnLoaiHang.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnLoaiHang.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnLoaiHang.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnLoaiHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnLoaiHang.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnLoaiHang.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnLoaiHang.HoverTextColor = System.Drawing.Color.White;
            this.btnLoaiHang.IsDerivedStyle = true;
            this.btnLoaiHang.Location = new System.Drawing.Point(0, 373);
            this.btnLoaiHang.Name = "btnLoaiHang";
            this.btnLoaiHang.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnLoaiHang.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnLoaiHang.NormalTextColor = System.Drawing.Color.White;
            this.btnLoaiHang.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnLoaiHang.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnLoaiHang.PressTextColor = System.Drawing.Color.White;
            this.btnLoaiHang.Size = new System.Drawing.Size(200, 57);
            this.btnLoaiHang.Style = MetroSet_UI.Enums.Style.Light;
            this.btnLoaiHang.StyleManager = null;
            this.btnLoaiHang.TabIndex = 8;
            this.btnLoaiHang.Text = "Loại hàng";
            this.btnLoaiHang.ThemeAuthor = "Narwin";
            this.btnLoaiHang.ThemeName = "MetroLite";
            this.btnLoaiHang.Click += new System.EventHandler(this.btnLoaiHang_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnKhachHang.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnKhachHang.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnKhachHang.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnKhachHang.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnKhachHang.HoverTextColor = System.Drawing.Color.White;
            this.btnKhachHang.IsDerivedStyle = true;
            this.btnKhachHang.Location = new System.Drawing.Point(0, 311);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnKhachHang.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnKhachHang.NormalTextColor = System.Drawing.Color.White;
            this.btnKhachHang.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnKhachHang.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnKhachHang.PressTextColor = System.Drawing.Color.White;
            this.btnKhachHang.Size = new System.Drawing.Size(200, 57);
            this.btnKhachHang.Style = MetroSet_UI.Enums.Style.Light;
            this.btnKhachHang.StyleManager = null;
            this.btnKhachHang.TabIndex = 7;
            this.btnKhachHang.Text = "Khách hàng";
            this.btnKhachHang.ThemeAuthor = "Narwin";
            this.btnKhachHang.ThemeName = "MetroLite";
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnHangHoa
            // 
            this.btnHangHoa.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnHangHoa.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnHangHoa.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnHangHoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnHangHoa.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnHangHoa.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnHangHoa.HoverTextColor = System.Drawing.Color.White;
            this.btnHangHoa.IsDerivedStyle = true;
            this.btnHangHoa.Location = new System.Drawing.Point(0, 249);
            this.btnHangHoa.Name = "btnHangHoa";
            this.btnHangHoa.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnHangHoa.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnHangHoa.NormalTextColor = System.Drawing.Color.White;
            this.btnHangHoa.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnHangHoa.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnHangHoa.PressTextColor = System.Drawing.Color.White;
            this.btnHangHoa.Size = new System.Drawing.Size(200, 57);
            this.btnHangHoa.Style = MetroSet_UI.Enums.Style.Light;
            this.btnHangHoa.StyleManager = null;
            this.btnHangHoa.TabIndex = 6;
            this.btnHangHoa.Text = "Hàng hóa";
            this.btnHangHoa.ThemeAuthor = "Narwin";
            this.btnHangHoa.ThemeName = "MetroLite";
            this.btnHangHoa.Click += new System.EventHandler(this.btnHangHoa_Click);
            // 
            // btnDatHang
            // 
            this.btnDatHang.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnDatHang.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnDatHang.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnDatHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnDatHang.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnDatHang.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnDatHang.HoverTextColor = System.Drawing.Color.White;
            this.btnDatHang.IsDerivedStyle = true;
            this.btnDatHang.Location = new System.Drawing.Point(0, 125);
            this.btnDatHang.Name = "btnDatHang";
            this.btnDatHang.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnDatHang.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnDatHang.NormalTextColor = System.Drawing.Color.White;
            this.btnDatHang.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnDatHang.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnDatHang.PressTextColor = System.Drawing.Color.White;
            this.btnDatHang.Size = new System.Drawing.Size(200, 57);
            this.btnDatHang.Style = MetroSet_UI.Enums.Style.Light;
            this.btnDatHang.StyleManager = null;
            this.btnDatHang.TabIndex = 5;
            this.btnDatHang.Text = "Đặt hàng";
            this.btnDatHang.ThemeAuthor = "Narwin";
            this.btnDatHang.ThemeName = "MetroLite";
            this.btnDatHang.Click += new System.EventHandler(this.btnDatHang_Click);
            // 
            // btnGiaoHang
            // 
            this.btnGiaoHang.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnGiaoHang.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnGiaoHang.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnGiaoHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnGiaoHang.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnGiaoHang.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnGiaoHang.HoverTextColor = System.Drawing.Color.White;
            this.btnGiaoHang.IsDerivedStyle = true;
            this.btnGiaoHang.Location = new System.Drawing.Point(0, 187);
            this.btnGiaoHang.Name = "btnGiaoHang";
            this.btnGiaoHang.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnGiaoHang.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnGiaoHang.NormalTextColor = System.Drawing.Color.White;
            this.btnGiaoHang.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnGiaoHang.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnGiaoHang.PressTextColor = System.Drawing.Color.White;
            this.btnGiaoHang.Size = new System.Drawing.Size(200, 57);
            this.btnGiaoHang.Style = MetroSet_UI.Enums.Style.Light;
            this.btnGiaoHang.StyleManager = null;
            this.btnGiaoHang.TabIndex = 4;
            this.btnGiaoHang.Text = "Giao hàng";
            this.btnGiaoHang.ThemeAuthor = "Narwin";
            this.btnGiaoHang.ThemeName = "MetroLite";
            this.btnGiaoHang.Click += new System.EventHandler(this.btnGiaoHang_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnNhanVien.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnNhanVien.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnNhanVien.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnNhanVien.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnNhanVien.HoverTextColor = System.Drawing.Color.White;
            this.btnNhanVien.IsDerivedStyle = true;
            this.btnNhanVien.Location = new System.Drawing.Point(0, 63);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnNhanVien.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnNhanVien.NormalTextColor = System.Drawing.Color.White;
            this.btnNhanVien.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnNhanVien.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnNhanVien.PressTextColor = System.Drawing.Color.White;
            this.btnNhanVien.Size = new System.Drawing.Size(200, 57);
            this.btnNhanVien.Style = MetroSet_UI.Enums.Style.Light;
            this.btnNhanVien.StyleManager = null;
            this.btnNhanVien.TabIndex = 3;
            this.btnNhanVien.Text = "Nhân viên";
            this.btnNhanVien.ThemeAuthor = "Narwin";
            this.btnNhanVien.ThemeName = "MetroLite";
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnCungUng
            // 
            this.btnCungUng.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnCungUng.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnCungUng.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnCungUng.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCungUng.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnCungUng.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnCungUng.HoverTextColor = System.Drawing.Color.White;
            this.btnCungUng.IsDerivedStyle = true;
            this.btnCungUng.Location = new System.Drawing.Point(0, 1);
            this.btnCungUng.Name = "btnCungUng";
            this.btnCungUng.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnCungUng.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnCungUng.NormalTextColor = System.Drawing.Color.White;
            this.btnCungUng.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnCungUng.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnCungUng.PressTextColor = System.Drawing.Color.White;
            this.btnCungUng.Size = new System.Drawing.Size(200, 57);
            this.btnCungUng.Style = MetroSet_UI.Enums.Style.Light;
            this.btnCungUng.StyleManager = null;
            this.btnCungUng.TabIndex = 2;
            this.btnCungUng.Text = "Cung ứng";
            this.btnCungUng.ThemeAuthor = "Narwin";
            this.btnCungUng.ThemeName = "MetroLite";
            this.btnCungUng.Click += new System.EventHandler(this.btnCungUng_Click);
            // 
            // pnlFormQL
            // 
            this.pnlFormQL.BackgroundColor = System.Drawing.Color.White;
            this.pnlFormQL.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.pnlFormQL.BorderThickness = 1;
            this.pnlFormQL.IsDerivedStyle = true;
            this.pnlFormQL.Location = new System.Drawing.Point(209, 3);
            this.pnlFormQL.Name = "pnlFormQL";
            this.pnlFormQL.Size = new System.Drawing.Size(971, 668);
            this.pnlFormQL.Style = MetroSet_UI.Enums.Style.Light;
            this.pnlFormQL.StyleManager = null;
            this.pnlFormQL.TabIndex = 2;
            this.pnlFormQL.ThemeAuthor = "Narwin";
            this.pnlFormQL.ThemeName = "MetroLite";
            // 
            // styleManager1
            // 
            this.styleManager1.CustomTheme = "C:\\Users\\Thanh Vi\\AppData\\Roaming\\Microsoft\\Windows\\Templates\\ThemeFile.xml";
            this.styleManager1.MetroForm = this;
            this.styleManager1.Style = MetroSet_UI.Enums.Style.Light;
            this.styleManager1.ThemeAuthor = "Narwin";
            this.styleManager1.ThemeName = "MetroLight";
            // 
            // tabThongTin
            // 
            this.tabThongTin.BaseColor = System.Drawing.Color.White;
            this.tabThongTin.Controls.Add(this.txtMaNV);
            this.tabThongTin.Controls.Add(this.metroSetLabel1);
            this.tabThongTin.Font = null;
            this.tabThongTin.ImageIndex = 0;
            this.tabThongTin.ImageKey = null;
            this.tabThongTin.IsDerivedStyle = true;
            this.tabThongTin.Location = new System.Drawing.Point(4, 42);
            this.tabThongTin.Name = "tabThongTin";
            this.tabThongTin.Size = new System.Drawing.Size(1185, 677);
            this.tabThongTin.Style = MetroSet_UI.Enums.Style.Light;
            this.tabThongTin.StyleManager = this.styleManager1;
            this.tabThongTin.TabIndex = 2;
            this.tabThongTin.Text = "Thông tin cá nhân";
            this.tabThongTin.ThemeAuthor = "Narwin";
            this.tabThongTin.ThemeName = "MetroLite";
            this.tabThongTin.ToolTipText = null;
            // 
            // txtMaNV
            // 
            this.txtMaNV.AutoCompleteCustomSource = null;
            this.txtMaNV.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtMaNV.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtMaNV.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txtMaNV.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtMaNV.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txtMaNV.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.txtMaNV.Enabled = false;
            this.txtMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtMaNV.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtMaNV.Image = null;
            this.txtMaNV.IsDerivedStyle = true;
            this.txtMaNV.Lines = null;
            this.txtMaNV.Location = new System.Drawing.Point(283, 12);
            this.txtMaNV.MaxLength = 32767;
            this.txtMaNV.Multiline = false;
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.ReadOnly = false;
            this.txtMaNV.Size = new System.Drawing.Size(205, 26);
            this.txtMaNV.Style = MetroSet_UI.Enums.Style.Light;
            this.txtMaNV.StyleManager = null;
            this.txtMaNV.TabIndex = 1;
            this.txtMaNV.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMaNV.ThemeAuthor = "Narwin";
            this.txtMaNV.ThemeName = "MetroLite";
            this.txtMaNV.UseSystemPasswordChar = false;
            this.txtMaNV.WatermarkText = "";
            // 
            // metroSetLabel1
            // 
            this.metroSetLabel1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.metroSetLabel1.IsDerivedStyle = true;
            this.metroSetLabel1.Location = new System.Drawing.Point(157, 12);
            this.metroSetLabel1.Name = "metroSetLabel1";
            this.metroSetLabel1.Size = new System.Drawing.Size(129, 26);
            this.metroSetLabel1.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetLabel1.StyleManager = null;
            this.metroSetLabel1.TabIndex = 0;
            this.metroSetLabel1.Text = "Mã nhân viên";
            this.metroSetLabel1.ThemeAuthor = "Narwin";
            this.metroSetLabel1.ThemeName = "MetroLite";
            // 
            // tabChucNang
            // 
            this.tabChucNang.BaseColor = System.Drawing.Color.White;
            this.tabChucNang.Controls.Add(this.btnThoat);
            this.tabChucNang.Font = null;
            this.tabChucNang.ImageIndex = 0;
            this.tabChucNang.ImageKey = null;
            this.tabChucNang.IsDerivedStyle = true;
            this.tabChucNang.Location = new System.Drawing.Point(4, 42);
            this.tabChucNang.Name = "tabChucNang";
            this.tabChucNang.Size = new System.Drawing.Size(1185, 677);
            this.tabChucNang.Style = MetroSet_UI.Enums.Style.Light;
            this.tabChucNang.StyleManager = this.styleManager1;
            this.tabChucNang.TabIndex = 3;
            this.tabChucNang.Text = "Chức năng";
            this.tabChucNang.ThemeAuthor = "Narwin";
            this.tabChucNang.ThemeName = "MetroLite";
            this.tabChucNang.ToolTipText = null;
            // 
            // btnThoat
            // 
            this.btnThoat.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnThoat.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnThoat.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnThoat.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnThoat.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnThoat.HoverTextColor = System.Drawing.Color.White;
            this.btnThoat.IsDerivedStyle = true;
            this.btnThoat.Location = new System.Drawing.Point(432, 224);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnThoat.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnThoat.NormalTextColor = System.Drawing.Color.White;
            this.btnThoat.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnThoat.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnThoat.PressTextColor = System.Drawing.Color.White;
            this.btnThoat.Size = new System.Drawing.Size(129, 56);
            this.btnThoat.Style = MetroSet_UI.Enums.Style.Light;
            this.btnThoat.StyleManager = this.styleManager1;
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.ThemeAuthor = "Narwin";
            this.btnThoat.ThemeName = "MetroLight";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 818);
            this.Controls.Add(this.metroSetTabControl1);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Name = "frmMain";
            this.Padding = new System.Windows.Forms.Padding(14, 77, 14, 13);
            this.StyleManager = this.styleManager1;
            this.Text = "Phần mềm Quản Lý Vật Liệu Xây Dựng";
            this.ThemeName = "MetroLight";
            this.metroSetTabControl1.ResumeLayout(false);
            this.tabQuanLy.ResumeLayout(false);
            this.pnlButtonQL.ResumeLayout(false);
            this.tabThongTin.ResumeLayout(false);
            this.tabChucNang.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroSet_UI.Controls.MetroSetTabControl metroSetTabControl1;
        private MetroSet_UI.Child.MetroSetSetTabPage tabQuanLy;
        private MetroSet_UI.Child.MetroSetSetTabPage tabThongTin;
        private MetroSet_UI.Child.MetroSetSetTabPage tabChucNang;
        private MetroSet_UI.Controls.MetroSetButton btnThoat;
        private MetroSet_UI.Components.StyleManager styleManager1;
        private MetroSet_UI.Controls.MetroSetPanel pnlButtonQL;
        private MetroSet_UI.Controls.MetroSetButton btnDatHang;
        private MetroSet_UI.Controls.MetroSetButton btnGiaoHang;
        private MetroSet_UI.Controls.MetroSetButton btnNhanVien;
        private MetroSet_UI.Controls.MetroSetButton btnCungUng;
        private MetroSet_UI.Controls.MetroSetButton btnXuatHang;
        private MetroSet_UI.Controls.MetroSetPanel pnlFormQL;
        private MetroSet_UI.Controls.MetroSetButton btnNhaCungCap;
        private MetroSet_UI.Controls.MetroSetButton btnLoaiHang;
        private MetroSet_UI.Controls.MetroSetButton btnKhachHang;
        private MetroSet_UI.Controls.MetroSetButton btnHangHoa;
        private MetroSet_UI.Controls.MetroSetTextBox txtMaNV;
        private MetroSet_UI.Controls.MetroSetLabel metroSetLabel1;
        private MetroSet_UI.Controls.MetroSetButton btnNhapHang;
    }
}