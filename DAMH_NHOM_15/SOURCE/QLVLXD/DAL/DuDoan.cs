using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
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
        public string MaKH { get; set; }
        public string MaHH { get; set; }
        public int SLXuat { get; set; }
        public DateTime NgayXuat { get; set; }
    }
}
