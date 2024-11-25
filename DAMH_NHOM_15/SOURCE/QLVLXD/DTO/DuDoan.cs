using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    //Dùng cho kết quả dự đoán
    public class DuDoan
    {
        public string MaKH { get; set; }
        public string MaHH { get; set; }
        public float SLDuDoan { get; set; }
    }

    //Ánh xạ từ cơ sở dữ liệu
    public class DonHangDTO
    {
        [LoadColumn(0)]
        public string MaKH { get; set; }

        [LoadColumn(1)]
        public string MaHH { get; set; }

        [LoadColumn(2)]
        public float SLXuat { get; set; }

        [LoadColumn(3)]
        public DateTime NgayXuat { get; set; }
    }

}
