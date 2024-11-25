using BLL_DAL;
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
    public partial class frmDuDoan : MetroSet_UI.Forms.MetroSetForm
    {
        public frmDuDoan()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            //Lấy dữ liệu từ DAL
            var dal = new DonHangDAL();
            var danhSachDonHang = dal.getDonHangData();

            //Binding vào Combobox
            var danhSachKH = danhSachDonHang.Select(d => d.MaKH).Distinct().ToList();   
            var danhSachHH = danhSachDonHang.Select(d => d.MaHH).Distinct().ToList();

            cbbMaKH.DataSource = danhSachKH;
            cbbMaHH.DataSource = danhSachHH;    
        }

        // Nút Huấn Luyện
        private void btnHuanLuyen_Click(object sender, EventArgs e)
        {
            try
            {
                // Đường dẫn tới file CSV
                string csvPath = @"D:\Hoc_Ki_7_HUIT\PTPM\Do_An\QuanLyVatLieuXayDung\DAMH_NHOM_15\SOURCE\QLVLXD\Demo\bin\DemandForecastingModel.csv"; // Đổi lại theo đường dẫn thực tế

                // Huấn luyện mô hình từ file CSV
                DuDoanBLL bll = new DuDoanBLL();
                bll.HuanLuyenMoHinh(csvPath);

                MessageBox.Show("Huấn luyện thành công! Mô hình đã được lưu.");

                // Các bước dự đoán vẫn giữ nguyên ở đây...
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        private void btnDuDoan_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.Title = "Chọn file dự đoán";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string csvPath = openFileDialog.FileName;
                    string outputModelPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DemandForecastingModel.zip");

                    try
                    {
                        // Kiểm tra xem mô hình đã được huấn luyện và lưu chưa
                        if (System.IO.File.Exists(outputModelPath))
                        {
                            // Mô hình đã có sẵn, thực hiện dự đoán
                            DuDoanBLL bllForPrediction = new DuDoanBLL();
                            string maKH = cbbMaKH.SelectedItem?.ToString();
                            string maHH = cbbMaHH.SelectedItem?.ToString();
                            DateTime ngayXuat = dateTimePicker1.Value;

                            if (string.IsNullOrEmpty(maKH) || string.IsNullOrEmpty(maHH))
                            {
                                MessageBox.Show("Vui lòng chọn đầy đủ thông tin khách hàng và hàng hóa!");
                                return;
                            }

                            var ketQua = bllForPrediction.DuDoanSoLuong(maKH, maHH, ngayXuat);

                            // Hiển thị kết quả dự đoán
                            txtDuDoan.Text = ketQua.SLDuDoan.ToString("N2");
                            MessageBox.Show("Dự đoán thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Mô hình chưa được huấn luyện. Vui lòng huấn luyện mô hình trước.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn file dữ liệu dự đoán.");
                }
            }
        }
    }
}
