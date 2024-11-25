using Demo;
using MetroSet_UI.Controls;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAL;
using DTO;

namespace Demo
{
    public partial class frmMain : MetroSet_UI.Forms.MetroSetForm
    {
        NhanVienBLL nhanvienBLL = new NhanVienBLL();
        string maNVDN = string.Empty;
        string cv = string.Empty;
        List<string> lst;
        PhanQuyenBLL phanQuyenBLL = new PhanQuyenBLL();
        public frmMain()
        {
            InitializeComponent();
            pnlButtonQL.BorderColor = pnlButtonPQ.BorderColor = Color.Transparent;
            pnlFormQL.BorderColor = pnlPhanQuyen.BorderColor = Color.Transparent;
            metroSetTabControl1.SelectedIndex = 0;
            lst = new List<string>();
        }
        public frmMain(string maNV)
        {
            InitializeComponent();
            pnlButtonQL.BorderColor = pnlButtonPQ.BorderColor = Color.Transparent;
            pnlFormQL.BorderColor = pnlPhanQuyen.BorderColor = Color.Transparent;
            metroSetTabControl1.SelectedIndex = 0;
            maNVDN = maNV;
            if (maNVDN != string.Empty)
            {
                txtMaNV.Text = maNVDN;
                NhanVien nv = nhanvienBLL.getByCode(maNVDN);
                if (nv != null)
                {
                    txtTenNV.Text = nv.TenNV;
                    txtChucVu.Text = nv.ChucVu;
                    lst = new List<string>();
                    lst = phanQuyenBLL.getAllScreenForRole(nv.MaVT);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            if (phanQuyenBLL.ktraQuyen(lst, "frmNhanVien"))
            {
                pnlFormQL.Controls.Clear();
                frmNhanVien frm = new frmNhanVien();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlFormQL.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                CustomMessageBox.Show("Bạn không có quyền mở.");
            }
        }

        private void btnCungUng_Click(object sender, EventArgs e)
        {
            if (phanQuyenBLL.ktraQuyen(lst, "frmCungUng"))
            {
                pnlFormQL.Controls.Clear();
                frmCungUng frm = new frmCungUng();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlFormQL.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                CustomMessageBox.Show("Bạn không có quyền mở.");
            }
        }

        private void btnDatHang_Click(object sender, EventArgs e)
        {
            if (phanQuyenBLL.ktraQuyen(lst, "frmDatHang"))
            {
                pnlFormQL.Controls.Clear();
                frmDatHang frm = new frmDatHang();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlFormQL.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                CustomMessageBox.Show("Bạn không có quyền mở.");
            }
        }

        private void btnGiaoHang_Click(object sender, EventArgs e)
        {
            if (phanQuyenBLL.ktraQuyen(lst, "frmGiaoHang"))
            {
                pnlFormQL.Controls.Clear();
                frmGiaoHang frm = new frmGiaoHang(maNVDN);
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlFormQL.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                CustomMessageBox.Show("Bạn không có quyền mở.");
            }
        }

        private void btnHangHoa_Click(object sender, EventArgs e)
        {
            if (phanQuyenBLL.ktraQuyen(lst, "frmHangHoa"))
            {
                pnlFormQL.Controls.Clear();
                frmHangHoa frm = new frmHangHoa();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlFormQL.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                CustomMessageBox.Show("Bạn không có quyền mở.");
            }
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            if (phanQuyenBLL.ktraQuyen(lst, "frmKhachHang"))
            {
                pnlFormQL.Controls.Clear();
                frmKhachHang frm = new frmKhachHang();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlFormQL.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                CustomMessageBox.Show("Bạn không có quyền mở.");
            }
        }

        private void btnLoaiHang_Click(object sender, EventArgs e)
        {
            if (phanQuyenBLL.ktraQuyen(lst, "frmLoaiHang"))
            {
                pnlFormQL.Controls.Clear();
                frmLoaiHang frm = new frmLoaiHang();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlFormQL.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                CustomMessageBox.Show("Bạn không có quyền mở.");
            }
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            if (phanQuyenBLL.ktraQuyen(lst, "frmNhaCungCap"))
            {
                pnlFormQL.Controls.Clear();
                frmNhaCungCap frm = new frmNhaCungCap();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlFormQL.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                CustomMessageBox.Show("Bạn không có quyền mở.");
            }
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            if (phanQuyenBLL.ktraQuyen(lst, "frmNhapHang"))
            {
                pnlFormQL.Controls.Clear();
                frmNhapHang frm = new frmNhapHang(maNVDN);
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlFormQL.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                CustomMessageBox.Show("Bạn không có quyền mở.");
            }
        }

        private void btnXuatHang_Click(object sender, EventArgs e)
        {
            if (phanQuyenBLL.ktraQuyen(lst, "frmXuatHang"))
            {
                pnlFormQL.Controls.Clear();
                frmXuatHang frm = new frmXuatHang();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlFormQL.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                CustomMessageBox.Show("Bạn không có quyền mở.");
            }
        }

        private void btnVaiTro_Click(object sender, EventArgs e)
        {
            if (phanQuyenBLL.ktraQuyen(lst, "frmVaiTro"))
            {
                pnlPhanQuyen.Controls.Clear();
                frmVaiTro frm = new frmVaiTro();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlPhanQuyen.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                CustomMessageBox.Show("Bạn không có quyền mở.");
            }
        }

        private void btnManHinh_Click(object sender, EventArgs e)
        {
            if (phanQuyenBLL.ktraQuyen(lst, "frmManHinh"))
            {
                pnlPhanQuyen.Controls.Clear();
                frmManHinh frm = new frmManHinh();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlPhanQuyen.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                CustomMessageBox.Show("Bạn không có quyền mở.");
            }
        }

        private void btnPhanQuyen_Click(object sender, EventArgs e)
        {
            if (phanQuyenBLL.ktraQuyen(lst, "frmPhanQuyen"))
            {
                pnlPhanQuyen.Controls.Clear();
                frmPhanQuyen frm = new frmPhanQuyen();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlPhanQuyen.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                CustomMessageBox.Show("Bạn không có quyền mở.");
            }
        }

        private void btnDuDoan_Click(object sender, EventArgs e)
        {
            if (phanQuyenBLL.ktraQuyen(lst, "frmDuDoan"))
            {
                pnlPhanQuyen.Controls.Clear();
                frmDuDoan frm = new frmDuDoan();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlPhanQuyen.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                CustomMessageBox.Show("Bạn không có quyền mở.");
            }
        }
    }
}
