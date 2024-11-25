using BLL_DAL;
using DTO;
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
    public partial class frmNhanVien : MetroSet_UI.Forms.MetroSetForm
    {
        NhanVienBLL nhanVienBLL = new NhanVienBLL();
        VaiTroBLL vaiTroBLL = new VaiTroBLL();
        public frmNhanVien()
        {
            InitializeComponent();
        }



        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadNV();
        }
        public void LoadNV()
        {
            try
            {
                DataTable dt = nhanVienBLL.getAll();
                dgvDS.DataSource = dt;
                dgvDS.Columns["MaNV"].HeaderText = "Mã Nhân viên";
                dgvDS.Columns["TenNV"].HeaderText = "Tên nhân viên";
                dgvDS.Columns["MatKhau"].HeaderText = "Mật khẩu";
                dgvDS.Columns["GioiTinh"].HeaderText = "Giới tính";
                dgvDS.Columns["NgaySinh"].HeaderText = "Ngày sinh";
                dgvDS.Columns["DiaChi"].HeaderText = "Địa chỉ";
                dgvDS.Columns["SDT"].HeaderText = "Số điện thoại";
                dgvDS.Columns["ChucVu"].HeaderText = "Chức vụ";
                dgvDS.Columns["MaVT"].HeaderText = "Mã vai trò";
                DataTable dt2 = vaiTroBLL.getAll();
                cboVaiTro.DataSource = null;
                cboVaiTro.DataSource = dt2;
                cboVaiTro.DisplayMember = "TenVaiTro";
                cboVaiTro.ValueMember = "MaVaiTro";
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
        //Them

        private void button5_Click(object sender, EventArgs e)
        {
            bool result = nhanVienBLL.addNV(txtMaNV.Text, txtTenNV.Text, txtDiaChi.Text, txtSDT.Text, txtMatKhau.Text, txtGioiTinh.Text, txtChucvu.Text, dtpNgaySinh.Text, cboVaiTro.SelectedValue.ToString());
            if (result)
            {
                CustomMessageBox.Show("Thêm nhân viên thành công!");
                LoadNV();
            }
            else
            {
                CustomMessageBox.Show("Thêm nhân viên thất bại.");
            }
        }


        //Xoa

        private void button4_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            NhanVien nv = nhanVienBLL.getByCode(maNV);
            if (nv != null)
            {
                nhanVienBLL.deleteNV(maNV);
                LoadNV();
            }
        }

        private void dgvDS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgvDS.Rows[e.RowIndex];
                txtMaNV.Text = r.Cells[0].Value.ToString();
                txtTenNV.Text = r.Cells[1].Value.ToString();
                txtMatKhau.Text = r.Cells[2].Value.ToString();
                txtGioiTinh.Text = r.Cells[3].Value.ToString();
                dtpNgaySinh.Text = r.Cells[4].Value.ToString();
                txtDiaChi.Text = r.Cells[5].Value.ToString();
                txtSDT.Text = r.Cells[6].Value.ToString();
                txtChucvu.Text = r.Cells[7].Value.ToString();
            }

        }
        //sua
        private void button3_Click(object sender, EventArgs e)
        {
            bool result = nhanVienBLL.updateNV(txtMaNV.Text, txtTenNV.Text, txtDiaChi.Text, txtSDT.Text, txtMatKhau.Text, txtGioiTinh.Text, txtChucvu.Text, dtpNgaySinh.Text, cboVaiTro.SelectedValue.ToString());
            if (result)
            {
                CustomMessageBox.Show("Cập nhật nhân viên thành công!");
                LoadNV();
            }
            else
            {
                CustomMessageBox.Show("Cập nhật nhân viên thất bại.");
            }

        }
        //Luu
        private void button2_Click(object sender, EventArgs e)
        {

        }
        //huy
        private void button1_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtMatKhau.Text = "";
            txtGioiTinh.Text = "";
            dtpNgaySinh.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtChucvu.Text = "";

        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string tenNV = txtTimKiem.Text;
            DataTable dt = nhanVienBLL.searchNV(tenNV);
            dgvDS.DataSource = dt;


        }

    }
}
