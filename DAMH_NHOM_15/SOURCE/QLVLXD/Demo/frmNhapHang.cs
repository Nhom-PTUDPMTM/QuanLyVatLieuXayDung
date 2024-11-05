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
    public partial class frmNhapHang : Form
    {
        NhaCungCapBLL nccBLL = new NhaCungCapBLL();
        public frmNhapHang()
        {
            InitializeComponent();
            btnHuyPhieuNhap.Enabled = btnLuuPhieuNhap.Enabled = btnLuu.Enabled = false;
        }

        public void reLoad()
        {
            DataTable dt = nccBLL.getCodeAndName();
            cboNhaCungCap.DataSource = null;
            cboNhaCungCap.DataSource = dt;
            cboNhaCungCap.DisplayMember = "TenNCC";
            cboNhaCungCap.ValueMember = "MaNCC";
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            reLoad();
        }
    }
}
