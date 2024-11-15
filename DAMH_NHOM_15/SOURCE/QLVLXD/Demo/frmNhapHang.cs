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
    public partial class frmNhapHang : Form
    {
        NhaCungCapBLL nccBLL = new NhaCungCapBLL();
        SanPhamBLL hanghoaBLL = new SanPhamBLL();
        PhieuNhapBLL phieunhapBLL = new PhieuNhapBLL();
        ChiTietPhieuNhapBLL CTphieunhapBLL = new ChiTietPhieuNhapBLL();
        NhanVienBLL nhanVienBLL = new NhanVienBLL();
        public frmNhapHang()
        {
            InitializeComponent();
            btnHuyPhieuNhap.Enabled = btnLuuPhieuNhap.Enabled = btnLuu.Enabled = false;
            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Xóa");
            chuotPhai.Items.AddRange(new ToolStripItem[] { deleteItem });
            deleteItem.Click += new EventHandler(DeleteItem_Click);
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

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DataTable dt = phieunhapBLL.getByDate(dtpStart.Value, dtpEnd.Value);
            dgvPhieuNhap.DataSource = null;
            dgvPhieuNhap.DataSource = dt;
            if(dt.Columns.Count > 6)
            {
                dgvPhieuNhap.Columns[6].Visible = false;
                dgvPhieuNhap.Columns[7].Visible = false;
            }
        }

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            double tong = 0;
            foreach (DataGridViewRow r in dgvSanPham.Rows)
            {
                if (!r.IsNewRow)
                {
                    bool isChecked = Convert.ToBoolean(r.Cells[0].Value);
                    if (isChecked)
                    {
                        ChiTietPhieuNhap ct = new ChiTietPhieuNhap();
                        ct.MaHDNhap = txtMaPhieuNhap.Text;
                        HangHoa sp = hanghoaBLL.getSanPhamByCode(r.Cells[1].Value.ToString());
                        if (sp != null)
                        {
                            ct.MaHH = sp.MaHH;
                            ct.DonGiaNhap = sp.DonGia;
                            ct.SLNhap = 1;
                            ct.ThanhTien = ct.DonGiaNhap * ct.SLNhap;
                            tong += (double)ct.ThanhTien;
                            CTphieunhapBLL.addItem(ct);
                        }
                    }
                }
            }
            PhieuNhap pn = phieunhapBLL.getByCode(txtMaPhieuNhap.Text); 
            if (pn != null) 
            { 
                NhaCC ncc = nccBLL.getByCode(cboNhaCungCap.SelectedValue.ToString()); 
                if (ncc != null) 
                { 
                    pn.NhaCC = ncc; 
                    pn.MaNCC = ncc.MaNCC; 
                } 
                pn.ThanhTien = tong; 
                phieunhapBLL.updatePhieuNhap(pn); 
            }
            DataTable kq = CTphieunhapBLL.getAllByCode(txtMaPhieuNhap.Text);
            if (kq != null)
            {
                dgvCTPhieuNhap.DataSource = null;
                dgvCTPhieuNhap.DataSource = kq;
                dgvCTPhieuNhap.Columns[5].Visible = false;
                dgvCTPhieuNhap.Columns[6].Visible = false;
            }
            DataTable dt = phieunhapBLL.getByDate(dtpStart.Value, dtpEnd.Value);
            if(dt!= null)
            {
                dgvPhieuNhap.DataSource = null;
                dgvPhieuNhap.DataSource = dt;
                dgvPhieuNhap.Columns[6].Visible = false;
                dgvPhieuNhap.Columns[7].Visible = false;
            }
            btnLuu.Enabled = true;
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            PhieuNhap phieu = phieunhapBLL.getByCode(txtMaPhieuNhap.Text.Trim());
            DataTable dt = CTphieunhapBLL.toPrint(phieu.MaHDNhap);
            dt.PrimaryKey = null;
            DataColumn col = new DataColumn("STT", typeof(int));
            dt.Columns.Add(col);
            col.SetOrdinal(0);
            int len = dt.Rows.Count;
            for (int i = 0; i < len; i++)
            {
                dt.Rows[i]["STT"] = i + 1;
            }
            List<int> lst = ConvertUltil.ConvertDateTimeToList(phieu.NgayNhap ?? DateTime.Now);
            NhanVien nv = nhanVienBLL.getByCode(phieu.MaNV);
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("MaPhieu", phieu.MaHDNhap.ToString());
            dic.Add("Ngay", lst[0].ToString());
            dic.Add("Thang", lst[1].ToString());
            dic.Add("Nam", lst[2].ToString());
            if (dgvPhieuNhap.CurrentCell != null)
            {
                int rowIndex = dgvPhieuNhap.CurrentCell.RowIndex;
                var selectedRow = dgvPhieuNhap.Rows[rowIndex];
                string code = selectedRow.Cells[1].Value?.ToString();
                if (!string.IsNullOrEmpty(code))
                {
                    NhaCC ncc = nccBLL.getByCode(code);
                    if (ncc != null)
                    {
                        dic.Add("NhaCungCap", ncc.TenNCC == null ? "Không có" : ncc.TenNCC.ToString());
                        dic.Add("DiaChi", ncc.DiaChi == null ? "Không có" : ncc.DiaChi.ToString());
                        dic.Add("SDT", ncc.SDT == null ? "Không có" : ncc.SDT.ToString());
                    }
                }
            }
            dic.Add("TongTien", phieu.ThanhTien.ToString());
            dic.Add("TongTienChu", ConvertUltil.ConvertNumberToString(int.Parse(phieu.ThanhTien.ToString())));
            dic.Add("NguoiLapPhieu", nv.TenNV.ToString());
            WordExport wd = new WordExport(Application.StartupPath + "\\Temp.dotx", true);
            wd.WriteFields(dic);
            wd.WriteTable(dt, 1);
            MessageBox.Show("Xuất xong !!");
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            string maNV = "NV001";
            PhieuNhap pn = new PhieuNhap();
            pn.ThanhTien = 0;
            pn.MaNV = maNV;
            DateTime dt = DateTime.Now;
            pn.NgayNhap = dt.Date;
            DataTable dt2 = phieunhapBLL.getAll();
            int dem = dt2.Rows.Count;
            pn.TinhTrang = "Chưa xác nhận";
            string ma = "PN" + (dem + 1).ToString("D3");
            while (phieunhapBLL.getByCode(ma) != null)
            {
                dem++;
                ma = "PN" + (dem + 1).ToString("D3");
            }
            pn.MaHDNhap = ma;
            DataTable listPN = phieunhapBLL.getAll();
            DataRow newRow = listPN.NewRow();
            newRow["MaHDNhap"] = pn.MaHDNhap;
            newRow["MaNV"] = pn.MaNV;
            newRow["NgayNhap"] = pn.NgayNhap;
            newRow["TinhTrang"] = pn.TinhTrang;
            newRow["ThanhTien"] = pn.ThanhTien;
            listPN.Rows.Add(newRow);
            dgvPhieuNhap.DataSource = null;
            dgvPhieuNhap.DataSource = listPN;
            dgvPhieuNhap.Columns[6].Visible = false;
            dgvPhieuNhap.Columns[7].Visible = false;
            btnHuyPhieuNhap.Enabled = btnLuuPhieuNhap.Enabled = true;
        }

        private void btnLuuPhieuNhap_Click(object sender, EventArgs e)
        {
            btnHuyPhieuNhap.Enabled = btnLuuPhieuNhap.Enabled = false;
            foreach (DataGridViewRow r in dgvPhieuNhap.Rows)
            {
                if (r.IsNewRow) continue;
                var maPhieuNhap = r.Cells[0].Value?.ToString();
                if (string.IsNullOrEmpty(maPhieuNhap)) continue;
                PhieuNhap kq = phieunhapBLL.getByCode(maPhieuNhap);
                if (kq == null)
                {
                    string maNV = "NV001";
                    string maNCC = r.Cells[1].Value?.ToString();
                    DateTime ngayNhap = r.Cells[3].Value != null && DateTime.TryParse(r.Cells[3].Value.ToString(), out DateTime parsedNgayNhap)
                                        ? parsedNgayNhap
                                        : DateTime.Now;
                    double thanhTien = r.Cells[5].Value != null && double.TryParse(r.Cells[5].Value.ToString(), out double parsedThanhTien)
                                       ? parsedThanhTien
                                       : 0;
                    PhieuNhap pn = new PhieuNhap
                    {
                        MaHDNhap = maPhieuNhap,
                        MaNCC = string.IsNullOrEmpty(maNCC) ? null : maNCC,
                        NgayNhap = ngayNhap,
                        ThanhTien = thanhTien,
                        MaNV = maNV,
                        TinhTrang = "Pending"
                    };
                    if (!phieunhapBLL.addItem(pn))
                    {
                        MessageBox.Show("Không thể lưu phiếu nhập: " + maPhieuNhap);
                    }
                }
            }
            DataTable dt = phieunhapBLL.getAll();
            dgvPhieuNhap.DataSource = null;
            dgvPhieuNhap.DataSource = dt;
            dgvPhieuNhap.Columns[6].Visible = false;
            dgvPhieuNhap.Columns[7].Visible = false;
        }

        private void btnHuyPhieuNhap_Click(object sender, EventArgs e)
        {
            btnHuyPhieuNhap.Enabled = btnLuuPhieuNhap.Enabled = false;
            DataTable dt = phieunhapBLL.getAll();
            dgvPhieuNhap.DataSource = null;
            dgvPhieuNhap.DataSource = dt;
            dgvPhieuNhap.Columns[6].Visible = false;
            dgvPhieuNhap.Columns[7].Visible = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            try
            {
                double tong = 0;
                foreach (DataGridViewRow r in dgvCTPhieuNhap.Rows)
                {
                    if (r.IsNewRow) continue;
                    string maPhieuNhap = r.Cells[1].Value?.ToString();
                    string maSanPham = r.Cells[0].Value?.ToString();
                    double donGia;
                    int soLuong;
                    if (string.IsNullOrEmpty(maPhieuNhap) || string.IsNullOrEmpty(maSanPham) ||
                        !double.TryParse(r.Cells[3].Value?.ToString(), out donGia) ||
                        !int.TryParse(r.Cells[2].Value?.ToString(), out soLuong))
                    {
                        MessageBox.Show("Dữ liệu không hợp lệ! Vui lòng kiểm tra lại các trường dữ liệu.");
                        continue;
                    }
                    ChiTietPhieuNhap ct = CTphieunhapBLL.getByCodeProduct(maPhieuNhap, maSanPham);
                    if (ct != null)
                    {
                        ct.SLNhap = soLuong;
                        ct.ThanhTien = soLuong * donGia;
                        CTphieunhapBLL.updateItem(ct, ct);
                        tong += (double)ct.ThanhTien;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(maPhieuNhap))
                        {
                            ChiTietPhieuNhap newCT = new ChiTietPhieuNhap
                            {
                                MaHDNhap = maPhieuNhap,
                                MaHH = maSanPham,
                                DonGiaNhap = donGia,
                                SLNhap = soLuong,
                                ThanhTien = soLuong * donGia
                            };
                            tong += (double)newCT.ThanhTien;
                            CTphieunhapBLL.addItem(newCT);
                        }
                        else
                        {
                            MessageBox.Show("Mã phiếu nhập không được để trống. Vui lòng nhập dữ liệu hợp lệ.");
                        }
                    }
                    HangHoa sp = hanghoaBLL.getSanPhamByCode(maSanPham);
                    if (sp != null)
                    {
                        sp.SoLuongTon += soLuong;
                        hanghoaBLL.updateSanPham(sp.MaHH, sp);
                    }
                }
                PhieuNhap pn = phieunhapBLL.getByCode(txtMaPhieuNhap.Text);
                if (pn != null)
                {
                    pn.ThanhTien = tong;
                    pn.TinhTrang = "Completed";
                }
                else
                {
                    MessageBox.Show("Không tìm thấy phiếu nhập với mã: " + txtMaPhieuNhap.Text);
                }
                phieunhapBLL.updatePhieuNhap(pn);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                btnLuu.Enabled = true;
            }
        }

        private void cboNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNhaCungCap.SelectedIndex >= 0)
            {
                try
                {
                    dgvSanPham.DataSource = null;
                    DataTable dt = hanghoaBLL.getByNhaCungCap(cboNhaCungCap.SelectedValue.ToString());
                    if (!dgvSanPham.Columns.Contains("them"))
                    {
                        DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
                        {
                            Name = "them",
                            HeaderText = "Thêm"
                        };
                        dgvSanPham.Columns.Add(checkBoxColumn);
                    }
                    dgvSanPham.DataSource = dt;
                    if (dgvSanPham.Columns.Count > 6)
                    {
                        dgvSanPham.Columns[7].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhieuNhap.Rows[e.RowIndex];
                txtMaPhieuNhap.Text = row.Cells[0].Value.ToString();
                dtpNgayNhap.Text = row.Cells[3].Value.ToString();
                txtThanhTien.Text = row.Cells[5].Value.ToString();
                DataTable dt = CTphieunhapBLL.getAllByCode(txtMaPhieuNhap.Text);
                dgvCTPhieuNhap.DataSource = null;
                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvCTPhieuNhap.DataSource = dt;
                    dgvCTPhieuNhap.Columns[5].Visible = false;
                    dgvCTPhieuNhap.Columns[6].Visible = false;
                }
                else
                {
                    DataTable emptyTable = new DataTable();
                    emptyTable.Columns.Add("MaHH");
                    emptyTable.Columns.Add("MaHDNhap");
                    emptyTable.Columns.Add("SLNhap");
                    emptyTable.Columns.Add("DonGiaNhap");
                    emptyTable.Columns.Add("ThanhTien");
                    dgvCTPhieuNhap.DataSource = emptyTable;
                }
            }
        }


        private void dgvCTPhieuNhap_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCTPhieuNhap.Columns["SLNhap"].Index)
            {
                try
                {
                    double dongia = Convert.ToDouble(dgvCTPhieuNhap.Rows[e.RowIndex].Cells["DonGiaNhap"].Value);
                    int soluong = Convert.ToInt32(dgvCTPhieuNhap.Rows[e.RowIndex].Cells["SLNhap"].Value);
                    double thanhtien = dongia * soluong;
                    dgvCTPhieuNhap.Rows[e.RowIndex].Cells["ThanhTien"].Value = thanhtien;
                    btnLuu.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi tính toán lại thành tiền: " + ex.Message);
                }
            }
        }
        private void DeleteItem_Click(object sender, EventArgs e)
        {
            if (dgvCTPhieuNhap.CurrentRow != null)
            {
                DataGridViewRow row = dgvCTPhieuNhap.CurrentRow;
                if (row != null)
                {
                    ChiTietPhieuNhap ctpn = CTphieunhapBLL.getByCodeProduct(txtMaPhieuNhap.Text, row.Cells[1].Value.ToString());
                    if (ctpn != null)
                    {
                        PhieuNhap pn = phieunhapBLL.getByCode(txtMaPhieuNhap.Text);
                        if (pn != null)
                        {
                            pn.ThanhTien -= ctpn.ThanhTien;
                            phieunhapBLL.updatePhieuNhap(pn);
                        }
                        CTphieunhapBLL.deleteItem(ctpn);
                        DataTable kq = CTphieunhapBLL.getAllByCode(txtMaPhieuNhap.Text);
                        if (kq != null)
                        {
                            dgvCTPhieuNhap.DataSource = null;
                            dgvCTPhieuNhap.DataSource = kq;
                            dgvCTPhieuNhap.Columns[5].Visible = false;
                            dgvCTPhieuNhap.Columns[6].Visible = false;
                        }
                    }
                }
                MessageBox.Show("Đã sản phẩm khỏi danh sách sản phẩm");
            }
        }
    }
}
