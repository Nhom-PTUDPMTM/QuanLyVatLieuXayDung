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
    public partial class frmHangHoa : Form
    {
        HangHoaBLL hh = new HangHoaBLL();
        bool isAdd = false, isUpdate = false;
        public frmHangHoa()
        {
            InitializeComponent();
            loadData();
        }

        public void loadData()
        {
            dgvDataHH.DataSource = null;
            DataTable dt = hh.getAll();
            dgvDataHH.DataSource = dt;
            cbbMaLoai.DataSource = hh.getMaLoaiList();
        }

        public void clearData()
        {
            txtMaHH.Clear();
            txtTenHH.Clear();
            cbbMaLoai.SelectedItem = 1;
            txtDonVi.Clear();
            txtDonGia.Clear();
            txtSLT.Clear();
        }

        private void dgvDataHH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int index = e.RowIndex;
                txtMaHH.Text = dgvDataHH.Rows[index].Cells[0].Value.ToString();
                txtTenHH.Text = dgvDataHH.Rows[index].Cells[1].Value.ToString();
                cbbMaLoai.Text = dgvDataHH.Rows[index].Cells[2].Value.ToString();
                txtDonVi.Text = dgvDataHH.Rows[index].Cells[3].Value.ToString();
                txtDonGia.Text = dgvDataHH.Rows[index].Cells[4].Value.ToString();
                txtSLT.Text = dgvDataHH.Rows[index].Cells[5].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdd = true;
            txtTenHH.Enabled = true;
            cbbMaLoai.Enabled = true;
            txtDonVi.Enabled = true;
            txtDonGia.Enabled = true;
            txtSLT.Enabled = true;
            clearData();
            txtMaHH.Text = hh.GetNextMaHangHoa();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Hiển thị MessageBox xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hàng hóa này?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kiểm tra kết quả trả về từ MessageBox
            if (result == DialogResult.Yes)
            {
                var hanghoa = hh.getByCode(txtMaHH.Text); // Lấy thông tin hàng hóa được chọn

                if (hanghoa != null)
                {

                    hh.deleteItemHanghoa(hanghoa);

                    MessageBox.Show("Xóa hàng hóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hàng hóa để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Hủy thao tác xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            isAdd = false;
            isUpdate = true;
            txtTenHH.Enabled = true;
            cbbMaLoai.Enabled = true;
            txtDonVi.Enabled = true;
            txtDonGia.Enabled = true;
            txtSLT.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isAdd)
            {
                // Kiểm tra xem các TextBox có giá trị hay không
                if (string.IsNullOrEmpty(txtTenHH.Text) || string.IsNullOrEmpty(txtDonGia.Text) || string.IsNullOrEmpty(txtDonVi.Text) || string.IsNullOrEmpty(txtSLT.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                // Tạo đối tượng HangHoa mới từ dữ liệu nhập vào
                var hanghoa = new HangHoa()
                {
                    MaHH = txtMaHH.Text,
                    TenHH = txtTenHH.Text,
                    MaLoai = cbbMaLoai.Text,
                    DonVi = txtDonVi.Text,
                    DonGia = double.Parse(txtDonGia.Text),
                    SoLuongTon = int.Parse(txtSLT.Text)
                };

                // Gọi phương thức thêm nhà cung cấp
                if (hh.addItemHangHoa(hanghoa))
                {
                    MessageBox.Show("Thêm hàng hóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm hàng hóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (isUpdate)
            {
                // Kiểm tra lại các TextBox
                if (string.IsNullOrEmpty(txtTenHH.Text) || string.IsNullOrEmpty(txtDonGia.Text) || string.IsNullOrEmpty(txtDonVi.Text) || string.IsNullOrEmpty(txtSLT.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                // Tạo đối tượng hàng hóa cũ (trước khi sửa) và đối tượng hàng hóa mới (sau khi sửa)
                var hangHoaCurrent = new HangHoa()
                {
                    MaHH = txtMaHH.Text,
                    TenHH = "",
                    MaLoai = "",
                    DonVi = "",
                    DonGia = 0,
                    SoLuongTon = 0
                };

                var hangHoaNew = new HangHoa()
                {
                    MaHH = txtMaHH.Text,
                    TenHH = txtTenHH.Text,
                    MaLoai = cbbMaLoai.Text,
                    DonVi = txtDonVi.Text,
                    DonGia = double.Parse(txtDonGia.Text),
                    SoLuongTon = int.Parse(txtSLT.Text)
                };

                // Gọi phương thức sửa nhà cung cấp, truyền cả đối tượng cũ và mới
                if (hh.updateItemHangHoa(hangHoaCurrent, hangHoaNew))
                {
                    MessageBox.Show("Sửa hàng hóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
                else
                {
                    MessageBox.Show("Lỗi khi sửa hàng hóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            clearData();
        }
    }
}
