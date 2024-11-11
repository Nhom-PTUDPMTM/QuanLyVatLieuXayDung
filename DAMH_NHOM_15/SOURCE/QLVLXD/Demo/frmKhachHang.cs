using BLL_DAL;
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
    public partial class frmKhachHang : Form
    {
        KhachHangBLL kh = new KhachHangBLL();
        bool isAdd = false, isUpdate = false;
        public frmKhachHang()
        {
            InitializeComponent();
        }

        public void reLoad()
        {
            //dgvData.Rows.Clear();
            //DataTable dt = kh.getAllKH();
            //dgvData.DataSource = dt;
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            reLoad();
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgvData.Rows[e.RowIndex];
                txtMaKH.Text = r.Cells[0].Value.ToString();
                txtTenKH.Text = r.Cells[1].Value.ToString();
                txtMatKhau.Text = r.Cells[2].Value.ToString();
                txtGioiTinh.Text = r.Cells[3].Value.ToString();
                dtpNgaySinh.Text = r.Cells[4].Value.ToString();
                txtDiaChi.Text = r.Cells[5].Value.ToString();
                txtSDT.Text = r.Cells[6].Value.ToString();
                txtLoaiKH.Text = r.Cells[7].Value.ToString();
            }
        }
    }
}
