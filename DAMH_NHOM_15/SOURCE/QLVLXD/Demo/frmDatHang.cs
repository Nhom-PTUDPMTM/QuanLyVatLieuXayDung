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
    public partial class frmDatHang : MetroSet_UI.Forms.MetroSetForm
    {
        KhachHangBLL kh = new KhachHangBLL();
        ChiTietPhieuXuatBLL ctpx = new ChiTietPhieuXuatBLL();
        PhieuXuatBLL px = new PhieuXuatBLL();
        DatHangBLL dh = new DatHangBLL();
        public frmDatHang()
        {
            InitializeComponent();
        }

        private void frmDatHang_Load(object sender, EventArgs e)
        {
            LoadKH();
            LoadPX();
            LoadDS();
            cboTinhTrang.Items.Add("Pending");
            cboTinhTrang.Items.Add("Delivered");
            cboTinhTrang.SelectedIndex = 0;
        }
        public void LoadKH()
        {
            DataTable dt = kh.getAll();
            cboMaKH.DataSource = dt;
            cboMaKH.DisplayMember = "MaKH";
            cboMaKH.ValueMember = "MaKH";

        }
        public void LoadPX()
        {
            DataTable dt = px.getALL();
            cboMaPX.DataSource = dt;
            cboMaPX.DisplayMember = "MaHDXuat";
            cboMaPX.ValueMember = "MaHDXuat";

        }
        public void LoadDS()
        {
            DataTable dt = dh.getAll();
            dgvDS.DataSource = dt;
            dgvDS.ReadOnly = true;
            dgvDS.Columns[9].Visible = false;
            dgvDS.Columns[8].Visible = false;

        }


        private void cboMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            string code = cboMaKH.SelectedValue?.ToString();
            KhachHang khach = kh.getByCode(code);
            if (khach != null)
            {
                txtTenKH.Text = khach.TenKH;
                txtDiaChi.Text = khach.DiaChi;
                txtSDT.Text = khach.SDT;
            }
            else
            {
                // Handle the case where no customer is found
                txtTenKH.Text = string.Empty;
                txtDiaChi.Text = string.Empty;
                txtSDT.Text = string.Empty;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                cboMaPX.SelectedValue = dgvDS.Rows[index].Cells[1].Value;
                cboMaKH.SelectedValue = dgvDS.Rows[index].Cells[0].Value;
                txtGhiChu.Text = dgvDS.Rows[index].Cells[4].Value.ToString();

                txtGiaoToi.Text = dgvDS.Rows[index].Cells[7].Value.ToString();

                dtpNgayDat.Value = Convert.ToDateTime(dgvDS.Rows[index].Cells[5].Value);
                cboTinhTrang.Text = dgvDS.Rows[index].Cells[3].Value.ToString();

                string cellValue = dgvDS.Rows[index].Cells[6].Value.ToString();
                DateTime dateValue;
                if (DateTime.TryParse(cellValue, out dateValue))
                {
                    dptNgaygiao.Value = dateValue;
                }
                else
                {
                    CustomMessageBox.Show("Invalid date format in the selected cell.");
                }
            }
        }



        private void btnSuaDon_Click(object sender, EventArgs e)
        {
            string MaPX = cboMaPX.SelectedValue.ToString();
            string MaKH = cboMaKH.SelectedValue.ToString();
            string Giaotoi = txtGiaoToi.Text;
            DonHang p = new DonHang();
            p.MaPX = MaPX;
            p.ThanhTien = 0;
            p.NgayDat = dtpNgayDat.Value.Date;
            p.NgayGiao = dptNgaygiao.Value.Date;
            p.MaTK = MaKH;
            p.ViTri = Giaotoi;
            p.TinhTrang = cboTinhTrang.SelectedItem.ToString();
            p.GhiChu = txtGhiChu.Text;

            if (dh.updateDonHang(p))
            {
                CustomMessageBox.Show("Sửa thành công");
                LoadDS();
            }
            else
            {
                CustomMessageBox.Show("Sửa thất bại");
            }

        }

        private void btnTaoDon_Click(object sender, EventArgs e)
        {
            string MaPX = cboMaPX.SelectedValue.ToString();
            string MaKH = cboMaKH.SelectedValue.ToString();
            string Giaotoi = txtGiaoToi.Text;
            DonHang p = new DonHang();
            p.MaPX = MaPX;
            p.ThanhTien = 0;
            p.NgayDat = DateTime.Now.Date;
            p.NgayGiao = dptNgaygiao.Value.Date;
            p.MaTK = MaKH;
            p.ViTri = Giaotoi;
            p.TinhTrang = cboTinhTrang.SelectedItem.ToString();
            p.GhiChu = txtGhiChu.Text;

            DataTable list = dh.getAll();
            DataRow newRow = list.NewRow();
            newRow["MaTK"] = p.MaTK;
            newRow["MaPX"] = p.MaPX;
            newRow["NgayDat"] = p.NgayDat;
            newRow["NgayGiao"] = p.NgayGiao;
            newRow["ViTri"] = p.ViTri;
            newRow["TinhTrang"] = p.TinhTrang;
            newRow["ThanhTien"] = p.ThanhTien;
            newRow["GhiChu"] = p.GhiChu;
            list.Rows.Add(newRow);
            dgvDS.DataSource = list;
            dgvDS.ReadOnly = true;



        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string MaPX = cboMaPX.SelectedValue.ToString();
            if (dh.deleteDonHang(MaPX))
            {
                CustomMessageBox.Show("Xóa thành công");
                LoadDS();
            }
            else
            {
                CustomMessageBox.Show("Xóa thất bại");
            }



        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgvDS.Rows)
            {
                if (!r.IsNewRow && dgvDS.Rows[r.Index + 1].IsNewRow)
                {
                    var ma = r.Cells[0].Value?.ToString();
                    if (string.IsNullOrEmpty(ma)) continue;

                    DonHang kq = dh.getByCode(ma);
                    if (kq == null)
                    {

                        PhieuXuat newPX = px.getByCode(r.Cells[1].Value?.ToString());
                        DonHang p = new DonHang
                        {
                            MaTK = ma,
                            MaPX = r.Cells[1].Value?.ToString(),

                            NgayDat = r.Cells[5].Value != null ? Convert.ToDateTime(r.Cells[5].Value.ToString()) : DateTime.Now,
                            NgayGiao = r.Cells[6].Value != null ? Convert.ToDateTime(r.Cells[6].Value.ToString()) : DateTime.Now,
                            ViTri = r.Cells[7].Value?.ToString(),
                            TinhTrang = r.Cells[3].Value?.ToString(),
                            GhiChu = r.Cells[4].Value?.ToString(),
                            ThanhTien = newPX != null ? newPX.ThanhTien : 0
                        };

                        //Console.WriteLine(p.MaTK + '|' + p.MaPX + '|');

                        if (!dh.insertDonHang(p))
                        {
                            CustomMessageBox.Show("Không thể lưu đơn hàng: " + ma);
                            Console.WriteLine($"Lỗi khi lưu đơn hàng {ma}");
                        }
                    }
                }
            }

            DataTable dt = dh.getAll();
            dgvDS.DataSource = null;
            dgvDS.DataSource = dt;
            if (dgvDS.Columns.Count > 8)
            {
                dgvDS.Columns[8].Visible = false;
                dgvDS.Columns[9].Visible = false;
            }
            dgvDS.ReadOnly = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            string maKT = cboMaKH.SelectedValue.ToString();
            DataTable dt = dh.getbycode(maKT);

            dh.deleteDonHang(maKT);
            DataTable dt2 = dh.getAll();
            dgvDS.DataSource = dt2;
            dgvDS.ReadOnly = true;
            //btnHuyPhieuXuat.Enabled = btnLuuPhieuXuat.Enabled = false;

        }
    }
}
