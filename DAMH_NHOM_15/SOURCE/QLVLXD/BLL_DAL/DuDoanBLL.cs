using DAL;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class DuDoanBLL
    {
        MLContext mlContext = new MLContext();
        ITransformer model;

        public DuDoanBLL() 
        {
            //Load mô hình ML.NET đã huấn luyện
            model = mlContext.Model.Load("DemandForecastingModel.zip", out _);
        }

        //Phương thức để dự đoán
        public DuDoan DuDoanSoLuong(string maKH, string maHH, DateTime ngayXuat)
        {
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

        public void HuanLuyenMoHinh(string csvPath)
        {
            // Tạo context ML.NET
            MLContext mlContext = new MLContext();

            // Đọc dữ liệu từ file CSV
            var dataView = mlContext.Data.LoadFromTextFile<DonHangDTO>(
                csvPath, hasHeader: true, separatorChar: ',');

            // Xây dựng pipeline cho mô hình
            var pipeline = mlContext.Transforms.Categorical.OneHotEncoding("MaKH")
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("MaHH"))
                .Append(mlContext.Transforms.Concatenate("Features", "MaKH", "MaHH", "NgayXuat"))
                .Append(mlContext.Regression.Trainers.Sdca(labelColumnName: "SoLuong", featureColumnName: "Features"));

            // Huấn luyện mô hình
            var model = pipeline.Fit(dataView);

            // Tạo đường dẫn để lưu mô hình
            string directory = System.IO.Path.GetDirectoryName(csvPath);  // Lấy thư mục chứa file CSV
            string outputModelPath = System.IO.Path.Combine(directory, "DemandForecastingModel.zip");

            // Lưu mô hình vào file ZIP trong cùng thư mục với file CSV
            mlContext.Model.Save(model, dataView.Schema, outputModelPath);
        }

    }
}
