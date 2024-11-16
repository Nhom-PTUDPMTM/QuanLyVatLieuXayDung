using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAL;
using DAL;

namespace Demo
{
    public partial class frmXuatHang : Form
    {
        LoaiHangBLL lh = new LoaiHangBLL();
        ChiTietPhieuXuatBLL ctpx = new ChiTietPhieuXuatBLL();
        PhieuXuatBLL px = new PhieuXuatBLL();
        SanPhamBLL hh = new SanPhamBLL();
        NhanVienBLL nv = new NhanVienBLL();
        KhachHangBLL kh = new KhachHangBLL();

        public frmXuatHang()
        {
            InitializeComponent();
            btnHuyPhieuXuat.Enabled = btnLuuPhieuXuat.Enabled = btnLuu.Enabled = false;
            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Xóa");
            chuotPhai.Items.AddRange(new ToolStripItem[] { deleteItem });
            deleteItem.Click += new EventHandler(DeleteItem_Click);
        }
        private void DeleteItem_Click(object sender, EventArgs e)
        {
            if (dgvCTPhieuXuat.CurrentRow != null)
            {
                DataGridViewRow row = dgvCTPhieuXuat.CurrentRow;
                if (row != null)
                {
                    ChiTietPhieuXuat ctpn = ctpx.getByCodeProduct(txtMaPhieuXuat.Text, row.Cells[0].Value.ToString()); 
                    if (ctpn != null)
                    {
                        PhieuXuat pxx = px.getByCode(txtMaPhieuXuat.Text);
                        if (pxx != null)
                        {
                            pxx.ThanhTien -= ctpn.ThanhTien;
                            px.updatePhieuXuat(pxx);
                        }
                        HangHoa sp = hh.getSanPhamByCode(ctpn.MaHH);
                        if (sp != null)
                        {
                            sp.SoLuongTon += ctpn.SLXuat;
                            hh.updateSanPham(sp.MaHH, sp);
                        }
                        ctpx.deleteChiTietPhieuXuat(ctpn.MaHDXuat, ctpn.MaHH);

                        DataTable kq = ctpx.getAllbycode(txtMaPhieuXuat.Text);
                        if (kq != null)
                        {
                            dgvCTPhieuXuat.DataSource = null;
                            dgvCTPhieuXuat.DataSource = kq;
                            if(dgvCTPhieuXuat.Columns.Count > 6)
                            {
                                dgvCTPhieuXuat.Columns[5].Visible = false;
                                dgvCTPhieuXuat.Columns[6].Visible = false;
                            }
                        }
                    }
                }
                MessageBox.Show("Đã sản phẩm khỏi danh sách sản phẩm");
            }
        }


        private void frmXuatHang_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadData2();
            cboTinhTrang.Items.Add("Pending");
            cboTinhTrang.Items.Add("Completed");
            cboTinhTrang.SelectedIndex = 0;
        }
        public void LoadData()
        {

            DataTable dt = lh.getName();
            cboLoaiHang.DataSource = dt;
            cboLoaiHang.DisplayMember = "TenLoai";
            cboLoaiHang.ValueMember = "MaLoai";
        }
        public void LoadData2()
        {
            DataTable dt = nv.getAll();
            cboNhanVien.DataSource = dt;
            cboNhanVien.DisplayMember = "TenNV";
            cboNhanVien.ValueMember = "MaNV";

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
                        ChiTietPhieuXuat ct = new ChiTietPhieuXuat();
                        ct.MaHDXuat = txtMaPhieuXuat.Text;
                        HangHoa sp = hh.getSanPhamByCode(r.Cells[1].Value.ToString());
                        if (sp != null)
                        {
                            if (sp.SoLuongTon > 0)
                            {
                                ct.MaHH = sp.MaHH;
                                ct.DonGiaXuat = sp.DonGia;
                                ct.SLXuat = 1;
                                ct.ThanhTien = ct.DonGiaXuat * ct.SLXuat;
                                tong += (double)ct.ThanhTien;
                                ctpx.insertChiTietPhieuXuat(ct);
                            }
                            else
                            {
                               
                                MessageBox.Show($"Sản phẩm {sp.TenHH} đã hết hàng.");
                            }
                        }
                    }
                }
            }
            PhieuXuat pxx = px.getByCode(txtMaPhieuXuat.Text);
            if(pxx != null)
            {
                pxx.ThanhTien = tong;
                px.updatePhieuXuat(pxx);
            }
            DataTable dt = ctpx.getAllbycode(txtMaPhieuXuat.Text);
            dgvCTPhieuXuat.DataSource = dt;

            if (dgvCTPhieuXuat.Columns.Count > 6)
            {
                dgvCTPhieuXuat.Columns[5].Visible = false;
                dgvCTPhieuXuat.Columns[6].Visible = false;
            }


            DataTable dt2=px.getByDate(dtpStart.Value, dtpEnd.Value);
            dgvPhieuxuat.DataSource = dt2;
           

            btnLuu.Enabled = true;
        }

        private void cboLoaiHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maLoai = cboLoaiHang.SelectedValue.ToString();
            DataTable dt = hh.getbyLoaiHang(maLoai);
            dgvSanPham.DataSource = dt;
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

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DataTable dt = px.getByDate(dtpStart.Value, dtpEnd.Value);
            dgvPhieuxuat.DataSource = dt;

        }
        


        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            string MaNV = cboNhanVien.SelectedValue.ToString();
            string MaKH = txtMaKH.Text;
            PhieuXuat p = new PhieuXuat();
            p.ThanhTien = 0;
            p.MaNV = MaNV;
            p.NgayXuat = DateTime.Now;
            p.MaKH = MaKH;
            p.TinhTrang = cboTinhTrang.SelectedItem.ToString();
           

            DataTable dt2 = px.getALL();
            int dem = dt2.Rows.Count;

            string ma = "PX" + (dem + 1).ToString("D3");
            while (px.getByCode(ma) != null)
            {
                dem++;
                ma = "PX" + (dem + 1).ToString("D3");
            }
            p.MaHDXuat = ma;
           

            DataTable listPN = px.getALL();
            DataRow newRow = listPN.NewRow();
            newRow["MaHDXuat"] = p.MaHDXuat;
            newRow["NgayXuat"] = p.NgayXuat;
            newRow["MaNV"] = p.MaNV;
            newRow["MaKH"] = p.MaKH;
            newRow["TinhTrang"] = p.TinhTrang;
            newRow["ThanhTien"] = p.ThanhTien;
            listPN.Rows.Add(newRow);
            dgvPhieuxuat.DataSource = listPN;



            btnHuyPhieuXuat.Enabled = btnLuuPhieuXuat .Enabled = true;
        }

        private void btnHuyPhieuXuat_Click(object sender, EventArgs e)
        {
            string maHDXuat = txtMaPhieuXuat.Text;
            DataTable dt = ctpx.getAllbycode(maHDXuat);
            foreach (DataRow r in dt.Rows)
            {
                ctpx.deleteChiTietPhieuXuat(r["MaHDXuat"].ToString(), r["MaHH"].ToString());
            }
            px.deletePhieuXuat(maHDXuat);
            DataTable dt2 = px.getALL();
            dgvPhieuxuat.DataSource = dt2;
            btnHuyPhieuXuat.Enabled = btnLuuPhieuXuat.Enabled = false;

        }

        private void btnLuuPhieuXuat_Click(object sender, EventArgs e)
        {
            btnHuyPhieuXuat.Enabled = btnLuuPhieuXuat.Enabled = false;

            foreach (DataGridViewRow r in dgvPhieuxuat.Rows)
            {
                if (!r.IsNewRow)
                {
                    var maPhieuXuat = r.Cells[0].Value?.ToString();
                    if (string.IsNullOrEmpty(maPhieuXuat)) continue;

                    PhieuXuat kq = px.getByCode(maPhieuXuat);
                    if (kq == null)
                    {
                        
                        PhieuXuat p = new PhieuXuat
                        {
                            MaHDXuat = maPhieuXuat,
                            NgayXuat = r.Cells[1].Value != null ? Convert.ToDateTime(r.Cells[1].Value.ToString()) : DateTime.Now,
                            MaNV = r.Cells[2].Value?.ToString(),
                            MaKH = r.Cells[3].Value?.ToString() != "" ? r.Cells[3].Value?.ToString() : "KH002",
                            TinhTrang = r.Cells[4].Value?.ToString(),
                            ThanhTien = r.Cells[5].Value != null ? Convert.ToDouble(r.Cells[5].Value.ToString()) : 0
                        };

                        if (!px.insertPhieuXuat(p))
                        {
                            MessageBox.Show("Không thể lưu phiếu xuất: " + maPhieuXuat);
                        }
                    }
                }
            }

            DataTable dt = px.getALL();
            dgvPhieuxuat.DataSource = null;
            dgvPhieuxuat.DataSource = dt;
        }


        private void dgvPhieuxuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaPhieuXuat.Text = dgvPhieuxuat.Rows[index].Cells[0].Value.ToString();
                dtpNgayXuat.Value = Convert.ToDateTime(dgvPhieuxuat.Rows[index].Cells[1].Value.ToString());
                cboNhanVien.SelectedValue = dgvPhieuxuat.Rows[index].Cells[2].Value.ToString();
                txtMaKH.Text = dgvPhieuxuat.Rows[index].Cells[3].Value.ToString();
                cboTinhTrang.SelectedItem = dgvPhieuxuat.Rows[index].Cells[4].Value.ToString();
                txtThanhTien.Text = dgvPhieuxuat.Rows[index].Cells[5].Value.ToString();
                DataTable dt = ctpx.getAllbycode(txtMaPhieuXuat.Text);
                dgvCTPhieuXuat.DataSource = dt;
                if (dgvCTPhieuXuat.Columns.Count > 6)
                {
                    dgvCTPhieuXuat.Columns[5].Visible = false;
                    dgvCTPhieuXuat.Columns[6].Visible = false;
                }
                btnLuu.Enabled = true;
            }


        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            PhieuXuat phieu = px.getByCode(txtMaPhieuXuat.Text);
            DataTable dt = ctpx.toPrint(phieu.MaHDXuat);
            dt.PrimaryKey = null;
            DataColumn col = new DataColumn("STT", typeof(int));
            dt.Columns.Add(col);
            col.SetOrdinal(0);
            int len = dt.Rows.Count;
            for (int i = 0; i < len; i++)
            {
                dt.Rows[i]["STT"] = i + 1;
            }
            List<int> lst = ConvertUltil.ConvertDateTimeToList(phieu.NgayXuat ?? DateTime.Now);
            NhanVien nvv = nv.getByCode(phieu.MaNV);

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Tennhanvien", nvv.TenNV == null ? "Không có" : nvv.TenNV.ToString());
            dic.Add("MaPhieu", phieu.MaHDXuat.ToString());
            dic.Add("Ngay", lst[0].ToString());
            dic.Add("Thang", lst[1].ToString());
            dic.Add("Nam", lst[2].ToString());
            if (dgvPhieuxuat.CurrentCell != null)
            {
                int rowIndex = dgvPhieuxuat.CurrentCell.RowIndex;
                var selectedRow = dgvPhieuxuat.Rows[rowIndex];
                string code = selectedRow.Cells[1].Value?.ToString();
                if (!string.IsNullOrEmpty(code))
                {
                    KhachHang khh = kh.getbycode(phieu.MaKH);
                    if (khh != null)
                    {
                        dic.Add("Tenkhachhang", khh.TenKH == null ? "Không có" : khh.TenKH.ToString());
                        dic.Add("DiaChi", khh.DiaChi == null ? "Không có" : khh.DiaChi.ToString());
                        dic.Add("SDT", khh.SDT == null ? "Không có" : khh.SDT.ToString());
                    }
                }

            }
            dic.Add("TongTien", phieu.ThanhTien.ToString());
            dic.Add("TongTienChu", ConvertUltil.ConvertNumberToString(int.Parse(phieu.ThanhTien.ToString())));
            dic.Add("NguoiLapPhieu", nvv.TenNV.ToString());
            WordExport wd = new WordExport(Application.StartupPath + "\\pxx.dotx", true);
            wd.WriteFields(dic);
            wd.WriteTable(dt, 1);
            MessageBox.Show("Xuất xong !!");


        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            try
            {
                double tong = 0;
                foreach (DataGridViewRow r in dgvCTPhieuXuat.Rows)
                {
                    if (!r.IsNewRow)
                    {
                        ChiTietPhieuXuat ct = new ChiTietPhieuXuat();
                        ct.MaHDXuat = r.Cells[1].Value.ToString();
                        ct.MaHH = r.Cells[0].Value.ToString();
                        double donGia;
                        int soLuong;
                        if (string.IsNullOrEmpty(ct.MaHDXuat) || string.IsNullOrEmpty(ct.MaHH) ||
                          !double.TryParse(r.Cells[3].Value?.ToString(), out donGia) ||
                           !int.TryParse(r.Cells[2].Value?.ToString(), out soLuong))
                        {
                            MessageBox.Show("Dữ liệu không hợp lệ! Vui lòng kiểm tra lại các trường dữ liệu.");
                            continue;
                        }
                        ChiTietPhieuXuat ctt = ctpx.getByCodeProduct(ct.MaHDXuat, ct.MaHH);

                        if (ctt != null)
                        {
                          

                            ctt.SLXuat = soLuong;
                            ctt.ThanhTien = soLuong * donGia;
                            ctpx.updateChiTietPhieuXuat(ctt);
                            tong += (double)ctt.ThanhTien;


                        }
                        else {
                            if(!string.IsNullOrEmpty(ct.MaHH))
                            {
                                ChiTietPhieuXuat newCT = new ChiTietPhieuXuat 
                                {
                                    MaHDXuat =ct.MaHDXuat,
                                    MaHH = ct.MaHH,
                                    DonGiaXuat = donGia,
                                    SLXuat = soLuong,
                                    ThanhTien = soLuong * donGia
                                };
                                tong += (double)newCT.ThanhTien;
                                ctpx.insertChiTietPhieuXuat(newCT);
                            }
                            else
                            {
                                MessageBox.Show("Dữ liệu không hợp lệ! Vui lòng kiểm tra lại các trường dữ liệu.");
                            }
                        }

                        HangHoa sp2 = hh.getSanPhamByCode(ct.MaHH);
                        if (sp2 != null)
                        {
                            if (sp2.SoLuongTon >= soLuong)
                            {
                                sp2.SoLuongTon -= soLuong; 
                                hh.updateSanPham(sp2.MaHH, sp2); 
                            }
                            else
                            {
                                MessageBox.Show("Số lượng tồn không đủ để xuất hàng.");
                                return;
                            }
                        }

                        PhieuXuat pxx = px.getByCode(txtMaPhieuXuat.Text);
                        if (pxx != null)
                        {
                            pxx.ThanhTien = tong;
                            px.updatePhieuXuat(pxx);
                        }
                        

                    }
                }

                DataTable dt2 = px.getByDate(dtpStart.Value, dtpEnd.Value);
                dgvPhieuxuat.DataSource = dt2;
                LoadData();
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

        private void dgvCTPhieuXuat_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dgvCTPhieuXuat.Columns["SLXuat"].Index)
            {
                try
                {
                    double dongia = Convert.ToDouble(dgvCTPhieuXuat.Rows[e.RowIndex].Cells["DonGiaXuat"].Value);
                    int soluong = Convert.ToInt32(dgvCTPhieuXuat .Rows[e.RowIndex].Cells["SLXuat"].Value);
                    double thanhtien = dongia * soluong;
                    dgvCTPhieuXuat.Rows[e.RowIndex].Cells["ThanhTien"].Value = thanhtien;
                    btnLuu.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi tính toán lại thành tiền: " + ex.Message);
                }
            }

        }
    }
}
