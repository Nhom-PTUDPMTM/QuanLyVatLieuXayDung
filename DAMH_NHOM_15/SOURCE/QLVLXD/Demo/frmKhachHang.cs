using BLL_DAL;
using DAL;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using MetroSet_UI.Forms;
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
        KhachHangBLL khachHangBLL = new KhachHangBLL();
        bool isAdd = false, isUpdate = false;
        public frmKhachHang()
        {
            InitializeComponent();
            btnHuy.Enabled = btnLuu.Enabled = txtMaKH.Enabled = false;
        }

        public void reLoad()
        {
            dgvData.DataSource = null;
            DataTable dt = khachHangBLL.getAll();
            dgvData.DataSource = dt;
            gridView1.Columns[2].Visible = false;
            gridView1.OptionsBehavior.Editable = false;
            var column = gridView1.Columns[3];
            gridView1.Columns[3].GroupIndex = 0;
            List<string> list = new List<string>();
            list.Add("Retail");
            list.Add("Wholesale");
            cboLoaiKH.Properties.Items.Clear();
            cboLoaiKH.Properties.Items.AddRange(list.ToArray());
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            reLoad();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdd = true;
            btnLuu.Enabled = !btnLuu.Enabled;
            btnHuy.Enabled = !btnHuy.Enabled;
            int sl = khachHangBLL.getAll().Rows.Count + 1;
            string ma = "KH" + sl.ToString("D3");
            while (khachHangBLL.getByCode(ma) != null)
            {
                sl++;
                ma = "KH" + sl.ToString("D3");
            }
            txtMaKH.Text = ma;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Bạn có muốn xóa khách hàng này không?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (khachHangBLL.deleteItem(txtMaKH.Text))
                {
                    reLoad();
                    MessageBox.Show(this, "Đã xóa thành công !!");
                }
                else
                    MessageBox.Show(this, "Lỗi khi xóa dữ liệu !!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            isUpdate = true;
            btnLuu.Enabled = !btnLuu.Enabled;
            btnHuy.Enabled = !btnHuy.Enabled;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isAdd)
            {
                isAdd = false;
                KhachHang them = new KhachHang()
                {
                    MaKH = txtMaKH.Text,
                    TenKH = txtTenKH.Text,
                    MatKhau = "",
                    GioiTinh = txtGioiTinh.Text,
                    NgaySinh = dtpNgaySinh.DateTime.Date,
                    DiaChi = txtDiaChi.Text,
                    SDT = txtSDT.Text,
                    LoaiKH = cboLoaiKH.Text == "Không có" ? null : cboLoaiKH.Text.ToString()
                };
                if (khachHangBLL.addItem(them))
                {
                    reLoad();
                    MessageBox.Show(this, "Đã thêm thành công !!");
                }
                else
                    MessageBox.Show(this, "Lỗi khi thêm dữ liệu !!");
            }
            else if (isUpdate)
            {
                isUpdate = false;
                KhachHang sua = new KhachHang()
                {
                    MaKH = txtMaKH.Text,
                    TenKH = txtTenKH.Text,
                    MatKhau = "",
                    GioiTinh = txtGioiTinh.Text,
                    NgaySinh = dtpNgaySinh.DateTime.Date,
                    DiaChi = txtDiaChi.Text,
                    SDT = txtSDT.Text,
                    LoaiKH = cboLoaiKH.Text == "Không có" ? null : cboLoaiKH.Text.ToString()
                };
                if (khachHangBLL.updateItem(sua))
                {
                    reLoad();
                    MessageBox.Show(this, "Đã sửa thành công !!");
                }
                else
                    MessageBox.Show(this, "Lỗi khi sửa dữ liệu !!");
            }
            btnLuu.Enabled = !btnLuu.Enabled;
            btnHuy.Enabled = !btnHuy.Enabled;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = !btnLuu.Enabled;
            btnHuy.Enabled = !btnHuy.Enabled;
            isAdd = isUpdate = false;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                GridView view = sender as GridView;
                var r = view.GetDataRow(e.FocusedRowHandle);
                if (r != null)
                {
                    txtMaKH.Text = r[0]?.ToString();
                    txtTenKH.Text = r[1]?.ToString();
                    txtGioiTinh.Text = r[3]?.ToString();
                    dtpNgaySinh.Text = r[4]?.ToString();
                    txtDiaChi.Text = r[5]?.ToString();
                    txtSDT.Text = r[6]?.ToString();
                    cboLoaiKH.Text = r[7]?.ToString();
                }
            }
        }
    }
}
