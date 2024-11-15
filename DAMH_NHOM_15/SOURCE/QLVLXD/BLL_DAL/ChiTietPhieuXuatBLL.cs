using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class ChiTietPhieuXuatBLL
    {
        VLXDDataContext vlxd;
        public ChiTietPhieuXuatBLL()
        {
            vlxd = new VLXDDataContext();
        }
        public ChiTietPhieuXuat getByCodeBillAndProduct(string codeBill, string codeProduct)
        {
            return vlxd.ChiTietPhieuXuats.Where(t => t.MaHDXuat == codeBill && t.MaHH == codeProduct).FirstOrDefault();
        }
    }
}
