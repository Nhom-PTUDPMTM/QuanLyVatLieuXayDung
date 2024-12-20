﻿using BLL_DAL;
using DAL;
using DevExpress.XtraEditors.Mask.Design;
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
    public partial class frmGiaoHang : MetroSet_UI.Forms.MetroSetForm
    {
        PhieuXuatBLL phieuXuatBLL = new PhieuXuatBLL();
        GiaoHangBLL giaoHangBLL = new GiaoHangBLL();
        CTGiaoHangBLL ctGiaoHangBLL = new CTGiaoHangBLL();
        ChiTietPhieuXuatBLL ctPhieuXuatBLL = new ChiTietPhieuXuatBLL();
        SanPhamBLL sanPhamBLL = new SanPhamBLL();
        private string maNV = string.Empty;
        public frmGiaoHang()
        {
            InitializeComponent();
            btnHuyPhieuNhap.Enabled = btnLuuPhieuNhap.Enabled = false;
            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Xóa");
            chuotPhai.Items.AddRange(new ToolStripItem[] { deleteItem });
            deleteItem.Click += new EventHandler(DeleteItem_Click);
        }
        public frmGiaoHang(string maNVDN)
        {
            InitializeComponent();
            maNV = maNVDN;
            btnHuyPhieuNhap.Enabled = btnLuuPhieuNhap.Enabled = false;
            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Xóa");
            chuotPhai.Items.AddRange(new ToolStripItem[] { deleteItem });
            deleteItem.Click += new EventHandler(DeleteItem_Click);
        }
        public void reload()
        {
            DataTable dt = phieuXuatBLL.getAllPending();
            dgvPhieuXuat.DataSource = null;
            dgvPhieuXuat.DataSource = dt;
            dgvPhieuXuat.Columns[0].HeaderText = "Mã phiếu xuất";
            dgvPhieuXuat.Columns[1].HeaderText = "Mã khách hàng";
            dgvPhieuXuat.Columns[2].HeaderText = "Mã nhân viên";
            dgvPhieuXuat.Columns[3].HeaderText = "Ngày xuất";
            dgvPhieuXuat.Columns[4].HeaderText = "Tình trạng";
            dgvPhieuXuat.Columns[5].HeaderText = "Thành tiền";
        }

        private void frmGiaoHang_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DataTable dt = ctGiaoHangBLL.getByDate(dtpStart.Value, dtpEnd.Value);
            dgvCTGiaoHang.DataSource = null;
            dgvCTGiaoHang.DataSource = dt;
            dgvCTGiaoHang.Columns[0].HeaderText = "Mã giao hàng";
            dgvCTGiaoHang.Columns[1].HeaderText = "Mã sản phẩm";
            dgvCTGiaoHang.Columns[2].HeaderText = "Mã nhân viên";
            dgvCTGiaoHang.Columns[3].HeaderText = "Ngày giao";
            dgvCTGiaoHang.Columns[4].HeaderText = "Số lượng giao";
            dgvCTGiaoHang.Columns[5].HeaderText = "Số lượng còn";
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            GiaoHang pn = new GiaoHang();
            pn.MaPX = dgvPhieuXuat.Rows[dgvPhieuXuat.CurrentCell.ColumnIndex].Cells[0].Value.ToString();
            pn.ViTri = txtViTri.Text;
            DataTable dt2 = giaoHangBLL.getAll();
            int dem = dt2.Rows.Count;
            string ma = "GH" + (dem + 1).ToString("D3");
            while(giaoHangBLL.getByCode(ma) != null)
            {
                dem++;
                ma = "GH" + (dem + 1).ToString("D3");
            }
            pn.MaGH = ma;
            DataTable listPN = giaoHangBLL.getAllByCodeBill(dgvPhieuXuat.Rows[dgvPhieuXuat.CurrentCell.ColumnIndex].Cells[0].Value.ToString());
            DataRow newRow = listPN.NewRow();
            newRow["MaGH"] = pn.MaGH;
            newRow["MaPX"] = pn.MaPX;
            newRow["ViTri"] = pn.ViTri;
            listPN.Rows.Add(newRow);
            dgvGiaoHang.DataSource = null;
            dgvGiaoHang.DataSource = listPN;
            dgvGiaoHang.Columns[0].HeaderText = "Mã giao hàng";
            dgvGiaoHang.Columns[1].HeaderText = "Mã phiếu xuất";
            dgvGiaoHang.Columns[2].HeaderText = "Vị trí";
            btnHuyPhieuNhap.Enabled = btnLuuPhieuNhap.Enabled = true;
        }

        private void btnLuuPhieuNhap_Click(object sender, EventArgs e)
        {
            btnHuyPhieuNhap.Enabled = btnLuuPhieuNhap.Enabled = false;
            foreach (DataGridViewRow r in dgvGiaoHang.Rows)
            {
                if (r.IsNewRow) continue;
                var ma = r.Cells[0].Value?.ToString();
                if (string.IsNullOrEmpty(ma)) continue;
                GiaoHang kq = giaoHangBLL.getByCode(ma);
                if (kq == null)
                {
                    string maPX = r.Cells[1].Value?.ToString();
                    string viTri = r.Cells[2].Value?.ToString();
                    GiaoHang pn = new GiaoHang
                    {
                        MaGH = ma,
                        MaPX = maPX,
                        ViTri = viTri
                    };
                    if (!giaoHangBLL.addItem(pn))
                    {
                        CustomMessageBox.Show("Không thể lưu phiếu giao hàng: " + ma);
                    }
                }
            }
            DataTable dt = giaoHangBLL.getAllByCodeBill(dgvPhieuXuat.Rows[dgvPhieuXuat.CurrentCell.ColumnIndex].Cells[0].Value.ToString());
            dgvGiaoHang.DataSource = null;
            dgvGiaoHang.DataSource = dt;
        }

        private void btnHuyPhieuNhap_Click(object sender, EventArgs e)
        {
            btnHuyPhieuNhap.Enabled = btnLuuPhieuNhap.Enabled = false;
            DataTable dt = giaoHangBLL.getAllByCodeBill(dgvPhieuXuat.Rows[dgvPhieuXuat.CurrentCell.ColumnIndex].Cells[0].Value.ToString());
            dgvGiaoHang.DataSource = null;
            dgvGiaoHang.DataSource = dt;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow r in dgvCTGiaoHang.Rows)
                {
                    if (!r.IsNewRow) continue;
                    string maSP = cboMaHH.SelectedValue.ToString();
                    string maGH = txtMaGiaoHang.Text;
                    int soLuongGiao, soLuongCon;
                    if (string.IsNullOrEmpty(maSP) || string.IsNullOrEmpty(maGH) ||
                        !int.TryParse(txtSoLuongGiao.Text, out soLuongGiao))
                    {
                        CustomMessageBox.Show("Dữ liệu không hợp lệ! Vui lòng kiểm tra lại các trường dữ liệu.");
                        continue;
                    }
                    ChiTietGiaoHang ct = ctGiaoHangBLL.getByCodeTransAndCodeProduct(maGH, maSP);
                    if (ct != null)
                    {
                        GiaoHang gh = giaoHangBLL.getByCode(maGH);
                        ChiTietPhieuXuat ctPX = ctPhieuXuatBLL.getByCodeBillAndProduct(gh.MaPX.ToString(), maSP);
                        int sl = int.Parse(r.Cells[4].Value.ToString());
                        if(sl < 0)
                        {
                            CustomMessageBox.Show("Số lượng không phù hợp tạo mã GH: " + ct.MaGH + " và mã SP: " + ct.MaSP + ".");
                            continue;
                        }
                        ct.SoLuongGiao = int.Parse(r.Cells[4].Value.ToString());
                        ct.SoLuongCon = ctPX.SLXuat - ct.SoLuongGiao;
                        if (ct.SoLuongCon < 0 || (ct.SoLuongGiao > ct.SoLuongCon) || ct.SoLuongGiao > ctPX.SLXuat) continue;
                        ctGiaoHangBLL.updateItem(ct);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(maGH))
                        {
                            GiaoHang gh = giaoHangBLL.getByCode(maGH);
                            ChiTietPhieuXuat ctPX = ctPhieuXuatBLL.getByCodeBillAndProduct(gh.MaPX.ToString(), maSP);
                            if (int.Parse(txtSoLuongGiao.Text) < 0)
                            {
                                CustomMessageBox.Show("Số lượng không phù hợp tạo mã GH: " + ct.MaGH + " và mã SP: " + ct.MaSP + ".");
                                continue;
                            }
                            if (ctPX != null)
                            {
                                ChiTietGiaoHang newCT = new ChiTietGiaoHang
                                {
                                    MaGH = maGH,
                                    MaNV = maNV,
                                    MaSP = maSP,
                                    NgayGiao = DateTime.Now.Date,
                                    SoLuongGiao = int.Parse(txtSoLuongGiao.Text),
                                    SoLuongCon = ctPX.SLXuat,
                                };
                                ctGiaoHangBLL.addItem(newCT);
                            }
                            else
                            {
                                CustomMessageBox.Show("Không có hàng hóa này trong chi tiết phiếu xuất.");
                            }
                        }
                        else
                        {
                            CustomMessageBox.Show("Mã phiếu nhập không được để trống. Vui lòng nhập dữ liệu hợp lệ.");
                        }
                    }
                }
                DataTable dt = ctGiaoHangBLL.getByCodeTrans(txtMaGiaoHang.Text);
                dgvCTGiaoHang.DataSource = null;
                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvCTGiaoHang.DataSource = dt;
                }
                else
                {
                    DataTable emptyTable = new DataTable();
                    emptyTable.Columns.Add("MaGH");
                    emptyTable.Columns.Add("MaSP");
                    emptyTable.Columns.Add("MaNV");
                    emptyTable.Columns.Add("NgayGiao");
                    emptyTable.Columns.Add("SoLuongGiao");
                    emptyTable.Columns.Add("SoLuongCon");
                    dgvCTGiaoHang.DataSource = emptyTable;
                }
                dgvCTGiaoHang.Columns[0].HeaderText = "Mã giao hàng";
                dgvCTGiaoHang.Columns[1].HeaderText = "Mã sản phẩm";
                dgvCTGiaoHang.Columns[2].HeaderText = "Mã nhân viên";
                dgvCTGiaoHang.Columns[3].HeaderText = "Ngày giao";
                dgvCTGiaoHang.Columns[4].HeaderText = "Số lượng giao";
                dgvCTGiaoHang.Columns[5].HeaderText = "Số lượng còn";
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                btnLuu.Enabled = false;
            }
        }

        private void dgvGiaoHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvGiaoHang.Rows[e.RowIndex];
                txtMaGiaoHang.Text = row.Cells[0].Value.ToString();
                txtMaPhieuXuat.Text = row.Cells[1].Value.ToString();
                txtViTri.Text = row.Cells[2].Value.ToString();
                cboMaHH.DataSource = null;
                DataTable hh = sanPhamBLL.getForComboBox();
                cboMaHH.DataSource = hh;
                cboMaHH.DisplayMember = "TenLoai";
                cboMaHH.ValueMember = "MaLoai";
                DataTable dt = ctGiaoHangBLL.getByCodeTrans(txtMaGiaoHang.Text);
                dgvCTGiaoHang.DataSource = null;
                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvCTGiaoHang.DataSource = dt;
                }
                else
                {
                    DataTable emptyTable = new DataTable();
                    emptyTable.Columns.Add("MaGH");
                    emptyTable.Columns.Add("MaSP");
                    emptyTable.Columns.Add("MaNV");
                    emptyTable.Columns.Add("NgayGiao");
                    emptyTable.Columns.Add("SoLuongGiao");
                    emptyTable.Columns.Add("SoLuongCon");
                    dgvCTGiaoHang.DataSource = emptyTable;
                }
                dgvCTGiaoHang.Columns[0].HeaderText = "Mã giao hàng";
                dgvCTGiaoHang.Columns[1].HeaderText = "Mã sản phẩm";
                dgvCTGiaoHang.Columns[2].HeaderText = "Mã nhân viên";
                dgvCTGiaoHang.Columns[3].HeaderText = "Ngày giao";
                dgvCTGiaoHang.Columns[4].HeaderText = "Số lượng giao";
                dgvCTGiaoHang.Columns[5].HeaderText = "Số lượng còn";
            }
        }

        private void dgvCTGiaoHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCTGiaoHang.Rows[e.RowIndex];
                dtpNgayGiao.Text = row.Cells[3].Value.ToString();
                txtSoLuongGiao.Text = row.Cells[4].Value.ToString();
                txtSoLuongGiao.TextAlign = HorizontalAlignment.Right;
            }
        }

        private void dgvCTGiaoHang_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCTGiaoHang.Columns["SoLuongGiao"].Index)
            {
                try
                {
                    GiaoHang gh = giaoHangBLL.getByCode(dgvCTGiaoHang.Rows[e.RowIndex].Cells[0].Value.ToString());
                    ChiTietPhieuXuat ctPX = ctPhieuXuatBLL.getByCodeBillAndProduct(gh.MaPX.ToString(), dgvCTGiaoHang.Rows[e.RowIndex].Cells[1].Value.ToString());
                    int soluonggiao = Convert.ToInt32(dgvCTGiaoHang.Rows[e.RowIndex].Cells["SoLuongGiao"].Value);
                    if (ctPX != null)
                    {
                        if(soluonggiao < 0 || soluonggiao > int.Parse(ctPX.SLXuat?.ToString()))
                        {
                            CustomMessageBox.Show("Số lượng giao sai tại mã giao hàng: " + dgvCTGiaoHang.Rows[e.RowIndex].Cells["MaGH"].Value + " và mã sản phẩm: " + dgvCTGiaoHang.Rows[e.RowIndex].Cells["MaSP"].Value + ".");
                            return;
                        }
                        int soluongcon = int.Parse(ctPX.SLXuat?.ToString()) - soluonggiao;
                        dgvCTGiaoHang.Rows[e.RowIndex].Cells["SoLuongCon"].Value = soluongcon;
                    }
                    btnLuu.Enabled = true;
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("Có lỗi khi tính toán lại thành tiền: " + ex.Message);
                }
            }
        }

        private void dgvPhieuXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhieuXuat.Rows[e.RowIndex];
                DataTable dt = giaoHangBLL.getAllByCodeBill(row.Cells["MaHDXuat"].Value.ToString());
                dgvGiaoHang.DataSource = null;
                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvGiaoHang.DataSource = dt;
                }
                else
                {
                    DataTable emptyTable = new DataTable();
                    emptyTable.Columns.Add("MaGC");
                    emptyTable.Columns.Add("MaPX");
                    emptyTable.Columns.Add("ViTri");
                    dgvGiaoHang.DataSource = emptyTable;
                }
                dgvGiaoHang.Columns[0].HeaderText = "Mã giao hàng";
                dgvGiaoHang.Columns[1].HeaderText = "Mã phiếu xuất";
                dgvGiaoHang.Columns[2].HeaderText = "Vị trí";
            }
        }

        private void txtSoLuongGiao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    int h = dgvCTGiaoHang.CurrentCell.RowIndex;
                    GiaoHang gh = giaoHangBLL.getByCode(dgvCTGiaoHang.Rows[h].Cells[0].Value.ToString());
                    ChiTietPhieuXuat ctPX = ctPhieuXuatBLL.getByCodeBillAndProduct(gh.MaPX.ToString(), dgvCTGiaoHang.Rows[h].Cells[1].Value.ToString());
                    int soluonggiao = Convert.ToInt32(dgvCTGiaoHang.Rows[h].Cells["SoLuongGiao"].Value);
                    if (ctPX != null)
                    {
                        if (soluonggiao < 0 || soluonggiao > int.Parse(ctPX.SLXuat?.ToString()))
                        {
                            CustomMessageBox.Show("Số lượng giao sai tại mã giao hàng: " + dgvCTGiaoHang.Rows[h].Cells["MaGH"].Value + " và mã sản phẩm: " + dgvCTGiaoHang.Rows[h].Cells["MaSP"].Value + ".");
                            return;
                        }
                        int soluongcon = int.Parse(ctPX.SLXuat?.ToString()) - soluonggiao;
                        dgvCTGiaoHang.Rows[h].Cells["SoLuongCon"].Value = soluongcon;
                    }
                    btnLuu.Enabled = true;
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("Có lỗi khi tính toán lại thành tiền: " + ex.Message);
                }
                e.SuppressKeyPress = true;
            }
        }
        private void DeleteItem_Click(object sender, EventArgs e)
        {
            if (dgvCTGiaoHang.CurrentRow != null)
            {
                DataGridViewRow row = dgvCTGiaoHang.CurrentRow;
                if (row != null)
                {
                    ChiTietGiaoHang ctpn = ctGiaoHangBLL.getByCodeTransAndCodeProduct(txtMaGiaoHang.Text, row.Cells[1].Value.ToString());
                    if (ctpn != null)
                    {
                        GiaoHang pn = giaoHangBLL.getByCode(txtMaGiaoHang.Text);
                        ctGiaoHangBLL.deleteItem(ctpn);
                        DataTable dt = ctGiaoHangBLL.getByCodeTrans(txtMaGiaoHang.Text);
                        if (dt != null)
                        {
                            dgvCTGiaoHang.DataSource = null;
                            dgvCTGiaoHang.DataSource = dt;
                            dgvCTGiaoHang.Columns[0].HeaderText = "Mã giao hàng";
                            dgvCTGiaoHang.Columns[1].HeaderText = "Mã sản phẩm";
                            dgvCTGiaoHang.Columns[2].HeaderText = "Mã nhân viên";
                            dgvCTGiaoHang.Columns[3].HeaderText = "Ngày giao";
                            dgvCTGiaoHang.Columns[4].HeaderText = "Số lượng giao";
                            dgvCTGiaoHang.Columns[5].HeaderText = "Số lượng còn";
                        }
                    }
                }
                CustomMessageBox.Show("Đã sản phẩm khỏi danh sách sản phẩm");
            }
        }

        private void cboMaHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboMaHH.SelectedIndex != -1)
            {
                btnLuu.Enabled = true;
            }
        }
    }
}
