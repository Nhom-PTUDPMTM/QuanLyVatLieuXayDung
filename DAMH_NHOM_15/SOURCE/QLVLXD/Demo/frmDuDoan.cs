using BLL_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            // Lấy dữ liệu từ DAL
            var dal = new DonHangDAL();
            var danhSachDonHang = dal.getDonHangData();

            // Binding vào Combobox
            var danhSachKH = danhSachDonHang.Select(d => d.MaKH).Distinct().ToList();
            var danhSachHH = danhSachDonHang.Select(d => d.MaHH).Distinct().ToList();

            cbbMaKH.DataSource = danhSachKH;
            cbbMaHH.DataSource = danhSachHH;
        }

        private void btnDuDoan_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.Title = "Chọn file CSV để dự đoán";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string csvPath = openFileDialog.FileName;

                    try
                    {
                        // Kiểm tra đầu vào: Khách hàng và hàng hóa
                        string maKH = cbbMaKH.SelectedItem?.ToString();
                        string maHH = cbbMaHH.SelectedItem?.ToString();
                        DateTime ngayXuat = dateTimePicker1.Value;

                        if (string.IsNullOrEmpty(maKH) || string.IsNullOrEmpty(maHH))
                        {
                            MessageBox.Show("Vui lòng chọn đầy đủ thông tin khách hàng và hàng hóa!");
                            return;
                        }

                        // Kiểm tra nếu file CSV không tồn tại
                        if (!System.IO.File.Exists(csvPath))
                        {
                            MessageBox.Show("File không tồn tại.");
                            return;
                        }

                        // Tạo BLL để huấn luyện và dự đoán
                        DuDoanBLL bllForPrediction = new DuDoanBLL();
                        bllForPrediction.HuanLuyenMoHinh(csvPath); // Huấn luyện mô hình từ file CSV

                        // Đọc dữ liệu từ file CSV (bỏ qua dòng header)
                        var data = System.IO.File.ReadAllLines(csvPath).Skip(1);

                        StringBuilder result = new StringBuilder();
                        foreach (var line in data)
                        {
                            var columns = line.Split(',');

                            // Giả sử các cột của CSV theo thứ tự: MaKH, MaHH, SLXuat, NgayXuat
                            string customerCode = columns[0];  // MaKH
                            string productCode = columns[1];   // MaHH
                            int quantity = int.Parse(columns[2]); // SLXuat
                            DateTime exportDate = DateTime.Parse(columns[3]); // Ngày xuất

                            // Dự đoán số lượng sản phẩm
                            var predictionResult = bllForPrediction.DuDoanSoLuong(customerCode, productCode, exportDate);

                            // Lưu kết quả vào StringBuilder
                            result.AppendLine($"{customerCode}, {productCode}, {exportDate.ToShortDateString()}, {predictionResult.SLDuDoan}");
                        }

                        // Hiển thị kết quả dự đoán
                        txtDuDoan.Text = result.ToString();
                        MessageBox.Show("Dự đoán hoàn tất!");
                    }
                    catch (Exception ex)
                    {
                        // Hiển thị lỗi nếu có
                        MessageBox.Show($"Đã xảy ra lỗi khi dự đoán: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn file CSV.");
                }
            }
        }
    }
}
