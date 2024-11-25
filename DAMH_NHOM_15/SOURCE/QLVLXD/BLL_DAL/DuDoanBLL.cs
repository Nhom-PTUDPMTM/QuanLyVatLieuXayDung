using DAL;
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BLL_DAL
{
    public class DuDoanBLL
    {
        MLContext mlContext = new MLContext();
        ITransformer model;

        // Constructor: Nếu có đường dẫn mô hình thì tải mô hình đã huấn luyện
        public DuDoanBLL(string modelPath = null)
        {
            if (modelPath != null)
            {
                LoadModel(modelPath);  // Nếu có mô hình thì tải
            }
        }

        // Phương thức để load mô hình đã huấn luyện
        public void LoadModel(string modelPath)
        {
            try
            {
                model = mlContext.Model.Load(modelPath, out _);
            }
            catch (Exception ex)
            {
                throw new Exception($"Không thể tải mô hình từ: {modelPath}. Lỗi: {ex.Message}");
            }
        }

        // Phương thức huấn luyện mô hình từ file CSV
        public void HuanLuyenMoHinh(string csvPath)
        {
            try
            {
                // Tạo context ML.NET
                MLContext mlContext = new MLContext();

                // Đọc dữ liệu từ file CSV
                var dataView = mlContext.Data.LoadFromTextFile<DonHangDTO>(
                    csvPath, hasHeader: true, separatorChar: ',');

                // Xây dựng pipeline cho mô hình
                var pipeline = mlContext.Transforms.Categorical.OneHotEncoding("MaKH")
                    .Append(mlContext.Transforms.Categorical.OneHotEncoding("MaHH"))
                    .Append(mlContext.Transforms.Conversion.ConvertType("NgayXuat", outputKind: DataKind.Single))
                    .Append(mlContext.Transforms.Concatenate("Features", "MaKH", "MaHH", "NgayXuat"))
                    .Append(mlContext.Regression.Trainers.Sdca(labelColumnName: "SLXuat", featureColumnName: "Features"));

                // Huấn luyện mô hình
                var model = pipeline.Fit(dataView);

                // Tạo đường dẫn lưu file .zip
                string directory = Path.GetDirectoryName(csvPath); // Lấy thư mục chứa file CSV
                string outputModelPath = Path.Combine(directory, "DemandForecastingModel.zip");

                // Lưu mô hình vào file ZIP
                mlContext.Model.Save(model, dataView.Schema, outputModelPath);

                Console.WriteLine($"Mô hình đã được lưu tại: {outputModelPath}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi trong quá trình huấn luyện: {ex.Message}");
            }
        }

        // Phương thức dự đoán cho một dòng dữ liệu
        public DuDoan DuDoanSoLuong(string maKH, string maHH, DateTime ngayXuat)
        {
            if (model == null)
            {
                throw new InvalidOperationException("Mô hình chưa được tải.");
            }

            var predictionEngine = mlContext.Model.CreatePredictionEngine<DonHangDTO, DuDoan>(model);

            var input = new DonHangDTO
            {
                MaHH = maHH,
                MaKH = maKH,
                NgayXuat = ngayXuat
            };

            var result = predictionEngine.Predict(input);

            return new DuDoan
            {
                MaKH = maKH,
                MaHH = maHH,
                SLDuDoan = result.SLDuDoan
            };
        }

        // Phương thức dự đoán cho tất cả các dòng dữ liệu trong CSV
        public List<DuDoan> DuDoanTuCSV(string csvPath)
        {
            var results = new List<DuDoan>();

            if (model == null)
            {
                throw new InvalidOperationException("Mô hình chưa được tải hoặc huấn luyện.");
            }

            // Đọc dữ liệu từ CSV
            var data = File.ReadAllLines(csvPath).Skip(1); // Bỏ qua dòng header

            foreach (var line in data)
            {
                var columns = line.Split(',');

                // Giả sử các cột của CSV theo thứ tự: MaKH, MaHH,SLXuat,NgayXuat
                string customerCode = columns[0];  // MaKH
                string productCode = columns[1];   // MaHH
                DateTime exportDate = DateTime.Parse(columns[3]); // Ngày xuất

                // Dự đoán số lượng sản phẩm
                var predictionResult = DuDoanSoLuong(customerCode, productCode, exportDate);

                results.Add(predictionResult);
            }

            return results;
        }
    }
}
