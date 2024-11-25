using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class DonHangDAL
    {
        private VLXDDataContext vlxd = new VLXDDataContext();
        public List<DonHangDTO> getDonHangData() 
        {
            return (from px in vlxd.PhieuXuats
                    join ct in vlxd.ChiTietPhieuXuats on px.MaHDXuat equals ct.MaHDXuat
                    select new DonHangDTO
                    {
                        MaKH = px.MaKH,
                        MaHH = ct.MaHH,
                        SLXuat = (int)ct.SLXuat,
                        NgayXuat = (DateTime)px.NgayXuat
                    }).ToList();
        }
    }
}
