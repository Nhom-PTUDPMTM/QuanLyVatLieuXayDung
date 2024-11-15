using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class PhieuXuatBLL
    {
        VLXDDataContext vlxd;
        public PhieuXuatBLL()
        {
            vlxd = new VLXDDataContext();
        }
        public DataTable getAll()
        {
            return DataProvider.Instance.executeQuery("SELECT * FROM PhieuXuat");
        }
        public DataTable getAllPending()
        {
            return DataProvider.Instance.executeQuery("SELECT * FROM PhieuXuat WHERE TinhTrang = N'Pending'");
        }
        public PhieuXuat getByCode(string code)
        {
            if (string.IsNullOrEmpty(code)) return null;
            return vlxd.PhieuXuats.Where(t => t.MaHDXuat == code).FirstOrDefault();
        }
    }
}
