using BLL_DAL;
using DAL;
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
    public partial class frmLoaiHang : MetroSet_UI.Forms.MetroSetForm
    {
        LoaiHangBLL lh = new LoaiHangBLL();
        bool isAdd = false, isUpdate = false;
        public frmLoaiHang()
        {
            InitializeComponent();
            loadData();
        }

        public void loadData()
        {
            dgvDataLH.DataSource = null;
            DataTable dt = lh.getAll();
            dgvDataLH.DataSource = dt;
            cbbLH.DataSource = lh.getTinhTrangList();
        }

        public void clearData()
        {
            txtMaLH.Clear();
            txtTenLH.Clear();
            cbbLH.SelectedItem = 1;
        }

        private void dgvDataLH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int index = e.RowIndex;
                txtMaLH.Text = dgvDataLH.Rows[index].Cells[0].Value.ToString();
                txtTenLH.Text = dgvDataLH.Rows[index].Cells[1].Value.ToString();
                cbbLH.Text = dgvDataLH.Rows[index].Cells[2].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdd = true;
            txtTenLH.Enabled = true;
            cbbLH.Enabled = true;
            clearData();
            txtMaLH.Text = lh.GetNextMaLoaiHang();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Hiển thị MessageBox xác nhận
            DialogResult result = CustomMessageBox.ShowYesNo("Bạn có chắc chắn muốn xóa loại hàng này?", "Xóa");

            // Kiểm tra kết quả trả về từ MessageBox
            if (result == DialogResult.Yes)
            {
                var loaiHang = lh.getByCode(txtMaLH.Text); // Lấy thông tin loại hàng được chọn

                if (loaiHang != null)
                {

                    lh.deleteItemLoaiHang(loaiHang);

                    CustomMessageBox.Show("Xóa loại hàng thành công!", "Thành công");
                    loadData();
                }
                else
                {
                    CustomMessageBox.Show("Không tìm thấy loại hàng để xóa.", "Lỗi");
                }
            }
            else
            {
                CustomMessageBox.Show("Hủy thao tác xóa.", "Thông báo");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            isAdd = false;
            isUpdate = true;
            txtTenLH.Enabled = true;
            cbbLH.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isAdd)
            {
                // Kiểm tra xem các TextBox có giá trị hay không
                if (string.IsNullOrEmpty(txtMaLH.Text) || string.IsNullOrEmpty(txtTenLH.Text))
                {
                    CustomMessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                // Tạo đối tượng NhaCC mới từ dữ liệu nhập vào
                var loaiHang = new LoaiHang()
                {
                    MaLoai = txtMaLH.Text,
                    TenLoai = txtTenLH.Text,
                    TinhTrang = cbbLH.Text
                };

                // Gọi phương thức thêm nhà cung cấp
                if (lh.addItemLoaiHang(loaiHang))
                {
                    CustomMessageBox.Show("Thêm loại hàng thành công!", "Thành công");
                    loadData();
                }
                else
                {
                    CustomMessageBox.Show("Lỗi khi thêm loại hàng.", "Lỗi");
                }
            }
            else if (isUpdate)
            {
                // Kiểm tra lại các TextBox
                if (string.IsNullOrEmpty(txtMaLH.Text) || string.IsNullOrEmpty(txtTenLH.Text))
                {
                    CustomMessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                // Tạo đối tượng loại hàng cũ (trước khi sửa) và đối tượng loại hàng mới (sau khi sửa)
                var loaiHangCurrent = new LoaiHang()
                {
                    MaLoai = txtMaLH.Text,
                    TenLoai = "",
                    TinhTrang = cbbLH.Text
                };

                var loaiHangNew = new LoaiHang()
                {
                    MaLoai = txtMaLH.Text,
                    TenLoai = txtTenLH.Text,
                    TinhTrang = cbbLH.Text,
                };

                // Gọi phương thức sửa nhà cung cấp, truyền cả đối tượng cũ và mới
                if (lh.updateItemLoaiHang(loaiHangCurrent, loaiHangNew))
                {
                    CustomMessageBox.Show("Sửa loại hàng thành công!", "Thành công");
                    loadData();
                }
                else
                {
                    CustomMessageBox.Show("Lỗi khi sửa loại hàng.", "Lỗi");
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            clearData();
        }


    }
}
