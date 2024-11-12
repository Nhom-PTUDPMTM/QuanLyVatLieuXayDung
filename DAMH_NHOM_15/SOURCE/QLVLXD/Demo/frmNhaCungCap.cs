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
    public partial class frmNhaCungCap : Form
    {
        NhaCungCapBLL ncc = new NhaCungCapBLL();
        bool isAdd = false, isUpdate = false;
        public frmNhaCungCap()
        {
            InitializeComponent();
            loadData();
        }

        public void loadData()
        {
            dgvDataNCC.DataSource = null;
            DataTable dt = ncc.getAll();
            dgvDataNCC.DataSource = dt;
        }

        public void clearData()
        {
            txtMaNCC.Clear();
            txtDiaChiNCC.Clear();
            txtTenNCC.Clear();
            txtSDTNCC.Clear();
        }

        private void dgvDataNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int index = e.RowIndex;
                txtMaNCC.Text = dgvDataNCC.Rows[index].Cells[0].Value.ToString();
                txtTenNCC.Text = dgvDataNCC.Rows[index].Cells[1].Value.ToString();
                txtDiaChiNCC.Text = dgvDataNCC.Rows[index].Cells[2].Value.ToString();
                txtSDTNCC.Text = dgvDataNCC.Rows[index].Cells[3].Value.ToString();
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdd = true;
            txtTenNCC.Enabled = true;
            txtDiaChiNCC.Enabled = true;
            txtSDTNCC.Enabled = true;
            clearData();
            txtMaNCC.Text = ncc.GetNextMaNCC();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Hiển thị MessageBox xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa NCC này?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kiểm tra kết quả trả về từ MessageBox
            if (result == DialogResult.Yes)
            {
                var nhaCC = ncc.getByCode(txtMaNCC.Text); // Lấy thông tin nhà cung cấp được chọn

                if (nhaCC != null)
                {
                    
                    ncc.deleteItemNCC(nhaCC);

                    MessageBox.Show("Xóa NCC thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy NCC để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtTenNCC.Enabled = true;
            txtDiaChiNCC.Enabled = true;
            txtSDTNCC.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isAdd)
            {
                // Kiểm tra xem các TextBox có giá trị hay không
                if (string.IsNullOrEmpty(txtMaNCC.Text) || string.IsNullOrEmpty(txtTenNCC.Text) ||
                    string.IsNullOrEmpty(txtDiaChiNCC.Text) || string.IsNullOrEmpty(txtSDTNCC.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                // Tạo đối tượng NhaCC mới từ dữ liệu nhập vào
                var nhaCC = new NhaCC()
                {
                    MaNCC = txtMaNCC.Text,
                    TenNCC = txtTenNCC.Text,
                    DiaChi = txtDiaChiNCC.Text,
                    SDT = txtSDTNCC.Text
                };

                // Gọi phương thức thêm nhà cung cấp
                if (ncc.addItemNCC(nhaCC))
                {
                    MessageBox.Show("Thêm NCC thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm NCC.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (isUpdate)
            {
                // Kiểm tra lại các TextBox
                if (string.IsNullOrEmpty(txtMaNCC.Text) || string.IsNullOrEmpty(txtTenNCC.Text) ||
                    string.IsNullOrEmpty(txtDiaChiNCC.Text) || string.IsNullOrEmpty(txtSDTNCC.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                // Tạo đối tượng NhaCC cũ (trước khi sửa) và đối tượng NhaCC mới (sau khi sửa)
                var nhaCCCurrent = new NhaCC()
                {
                    MaNCC = txtMaNCC.Text,
                    TenNCC = "",           
                    DiaChi = "",
                    SDT = ""
                };

                var nhaCCNew = new NhaCC()
                {
                    MaNCC = txtMaNCC.Text,
                    TenNCC = txtTenNCC.Text,
                    DiaChi = txtDiaChiNCC.Text,
                    SDT = txtSDTNCC.Text
                };

                // Gọi phương thức sửa nhà cung cấp, truyền cả đối tượng cũ và mới
                if (ncc.updateItemNCC(nhaCCCurrent, nhaCCNew))
                {
                    MessageBox.Show("Sửa NCC thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                    dgvDataNCC.Refresh();
                }
                else
                {
                    MessageBox.Show("Lỗi khi sửa NCC.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            clearData();
        }
    }
}
