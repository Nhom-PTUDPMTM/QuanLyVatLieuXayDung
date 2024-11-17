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
using DAL;

namespace Demo
{
    public partial class frmCungUng : MetroSet_UI.Forms.MetroSetForm
    {
        SanPhamBLL sanPhamBLL = new SanPhamBLL();
        NhaCungCapBLL nhaCCBLL = new NhaCungCapBLL();
        CungUngBLL cungUngBLL = new CungUngBLL();
        bool isAdd = false, isUpdate = false;
        public frmCungUng()
        {
            InitializeComponent();
        }

        private void frmCungUng_Load(object sender, EventArgs e)
        {
            reLoad();
        }

        private void cboNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboNCC.SelectedIndex >= 0)
            {
                DataTable dt = sanPhamBLL.getByNhaCungCap(cboNCC.SelectedValue.ToString());
                dgvData.DataSource = null;
                dgvData.DataSource = dt;
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgvData.Rows[e.RowIndex];
                txtMaSP.Text = r.Cells[0].Value.ToString();
                txtTenSP.Text = r.Cells[1].Value.ToString();
                txtLoaiSP.Text = r.Cells[2].Value.ToString();
                txtDonVi.Text = r.Cells[3].Value.ToString();
                txtSL.Text = r.Cells[5].Value.ToString();
                txtDonGia.Text = r.Cells[4].Value.ToString();
            }
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {

        }

        private void btns1_AddClicked(object sender, EventArgs e)
        {
            Button save = btns1.Controls.OfType<Button>().FirstOrDefault(b => b.Name == "btnSave");
            Button cancel = btns1.Controls.OfType<Button>().FirstOrDefault(b => b.Name == "btnSkip");
            save.Enabled = !save.Enabled;
            cancel.Enabled = !cancel.Enabled;
            isAdd = true;
        }

        private void btns1_CancelClicked(object sender, EventArgs e)
        {
            Button save = btns1.Controls.OfType<Button>().FirstOrDefault(b => b.Name == "btnSave");
            Button cancel = btns1.Controls.OfType<Button>().FirstOrDefault(b => b.Name == "btnSkip");
            save.Enabled = !save.Enabled;
            cancel.Enabled = !cancel.Enabled;
            isAdd = false;
            isUpdate = false;
        }

        private void btns1_DeleteClicked(object sender, EventArgs e)
        {
            DialogResult result = CustomMessageBox.ShowYesNo("Bạn có muốn xóa sản phẩm này khỏi nhà cung ứng này không?", "Xác nhận xóa");
            if (result == DialogResult.Yes)
            {
                if (cungUngBLL.removeItem(cboNCC.SelectedValue.ToString(), txtMaSP.Text))
                {
                    reLoad();
                    CustomMessageBox.Show("Đã xóa thành công !!");
                }
                else
                    CustomMessageBox.Show("Lỗi khi xóa dữ liệu !!");
            }
        }

        private void btns1_FixClicked(object sender, EventArgs e)
        {
            Button save = btns1.Controls.OfType<Button>().FirstOrDefault(b => b.Name == "btnSave");
            Button cancel = btns1.Controls.OfType<Button>().FirstOrDefault(b => b.Name == "btnSkip");
            save.Enabled = !save.Enabled;
            cancel.Enabled = !cancel.Enabled;
            isUpdate = true;
        }

        private void btns1_SaveClicked(object sender, EventArgs e)
        {
            if (isAdd)
            {
                isAdd = false;
                try
                {
                    CungUng them = new CungUng()
                    {
                        MaHH = txtMaSP.Text,
                        MaNCC = cboNCC.SelectedValue.ToString(),
                        TrangThai = "Pending",
                    };
                    HangHoa hh = sanPhamBLL.getSanPhamByCode(txtMaSP.Text);
                    if(hh == null)
                        sanPhamBLL.addItem(hh);
                    if (cungUngBLL.addItem(them))
                    {
                        reLoad();
                        CustomMessageBox.Show("Đã thêm thành công !!");
                    }
                    else
                        CustomMessageBox.Show("Lỗi khi thêm dữ liệu !!");
                }
                catch
                {
                    MessageBox.Show("Lỗi khi thêm dữ liệu !!");
                }
            }
            else if (isUpdate)
            {
                isUpdate = false;
                CungUng sua = new CungUng()
                {
                    MaHH = txtMaSP.Text,
                    MaNCC = cboNCC.SelectedValue.ToString(),
                    TrangThai = "Pending",
                };
                if (cungUngBLL.updateItem(sua))
                {
                    reLoad();
                    CustomMessageBox.Show("Đã sửa thành công !!");
                }
                else
                    CustomMessageBox.Show("Lỗi khi sửa dữ liệu !!");
            }
            Button save = btns1.Controls.OfType<Button>().FirstOrDefault(b => b.Name == "btnSave");
            Button cancel = btns1.Controls.OfType<Button>().FirstOrDefault(b => b.Name == "btnSkip");
            save.Enabled = !save.Enabled;
            cancel.Enabled = !cancel.Enabled;
        }

        public void reLoad()
        {
            DataTable dt = nhaCCBLL.getCodeAndName();
            cboNCC.DataSource = dt;
            cboNCC.DisplayMember = "TenNCC";
            cboNCC.ValueMember = "MaNCC";
        }
    }
}
