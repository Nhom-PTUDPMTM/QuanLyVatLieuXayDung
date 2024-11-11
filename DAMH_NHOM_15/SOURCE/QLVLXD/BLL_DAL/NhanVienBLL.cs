using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class NhanVienBLL
    {
        VLXDDataContext vlxd = new VLXDDataContext();
        public NhanVien getByCode(string code)
        {
            return vlxd.NhanViens.Where(t => t.MaNV == code).FirstOrDefault();
        }
    }
}
