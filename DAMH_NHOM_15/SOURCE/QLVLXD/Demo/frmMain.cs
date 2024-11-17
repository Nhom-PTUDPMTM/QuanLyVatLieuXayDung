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

namespace Demo
{
    public partial class frmMain : MetroSet_UI.Forms.MetroSetForm
    {
        string maNVDN = string.Empty;
        public frmMain()
        {
            InitializeComponent();
            pnlButtonQL.BorderColor = Color.Transparent;
            pnlFormQL.BorderColor = Color.Transparent;
            metroSetTabControl1.SelectedIndex = 0;
        }
        public frmMain(string maNV)
        {
            InitializeComponent();
            pnlButtonQL.BorderColor = Color.Transparent;
            pnlFormQL.BorderColor = Color.Transparent;
            metroSetTabControl1.SelectedIndex = 0;
            maNVDN = maNV;
            if (maNVDN != string.Empty)
            {
                txtMaNV.Text = maNVDN;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            pnlFormQL.Controls.Clear();
            frmNhanVien frm = new frmNhanVien();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pnlFormQL.Controls.Add(frm);
            frm.Show();
        }

        private void btnCungUng_Click(object sender, EventArgs e)
        {
            pnlFormQL.Controls.Clear();
            frmCungUng frm = new frmCungUng();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pnlFormQL.Controls.Add(frm);
            frm.Show();
        }

        private void btnDatHang_Click(object sender, EventArgs e)
        {
            pnlFormQL.Controls.Clear();
            frmDatHang frm = new frmDatHang();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pnlFormQL.Controls.Add(frm);
            frm.Show();
        }

        private void btnGiaoHang_Click(object sender, EventArgs e)
        {
            pnlFormQL.Controls.Clear();
            frmGiaoHang frm = new frmGiaoHang(maNVDN);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pnlFormQL.Controls.Add(frm);
            frm.Show();
        }

        private void btnHangHoa_Click(object sender, EventArgs e)
        {
            pnlFormQL.Controls.Clear();
            frmHangHoa frm = new frmHangHoa();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pnlFormQL.Controls.Add(frm);
            frm.Show();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            pnlFormQL.Controls.Clear();
            frmKhachHang frm = new frmKhachHang();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pnlFormQL.Controls.Add(frm);
            frm.Show();
        }

        private void btnLoaiHang_Click(object sender, EventArgs e)
        {
            pnlFormQL.Controls.Clear();
            frmLoaiHang frm = new frmLoaiHang();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pnlFormQL.Controls.Add(frm);
            frm.Show();
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            pnlFormQL.Controls.Clear();
            frmNhaCungCap frm = new frmNhaCungCap();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pnlFormQL.Controls.Add(frm);
            frm.Show();
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            pnlFormQL.Controls.Clear();
            frmNhapHang frm = new frmNhapHang(maNVDN);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pnlFormQL.Controls.Add(frm);
            frm.Show();
        }

        private void btnXuatHang_Click(object sender, EventArgs e)
        {
            pnlFormQL.Controls.Clear();
            frmXuatHang frm = new frmXuatHang();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pnlFormQL.Controls.Add(frm);
            frm.Show();
        }
    }
}
