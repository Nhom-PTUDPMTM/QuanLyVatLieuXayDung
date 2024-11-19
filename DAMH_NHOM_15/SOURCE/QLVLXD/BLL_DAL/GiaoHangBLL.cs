using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class GiaoHangBLL
    {
        VLXDDataContext vlxd;
        public GiaoHangBLL()
        {
            vlxd = new VLXDDataContext();
        }
        public DataTable getAllByCodeBill(string code)
        {
            return DataProvider.Instance.executeQuery("SELECT * FROM GiaoHang WHERE MaPX = '" + code + "'");
        }
        public DataTable getAll()
        {
            return DataProvider.Instance.executeQuery("SELECT * FROM GiaoHang");
        }
        public GiaoHang getByCode(string code)
        {
            return vlxd.GiaoHangs.Where(t => t.MaGH == code).FirstOrDefault();
        }
        public bool updateItem(GiaoHang newPN)
        {
            try
            {
                string query = string.Format("update GiaoHang set ViTri = N'{2}' where MaGH = '{0}' and MaPX = '{1}'", newPN.MaGH, newPN.MaPX, newPN.ViTri);
                int result = DataProvider.Instance.executeNonQuery(query);
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool addItem(GiaoHang a)
        {
            bool b = false;
            if (a != null)
            {
                try
                {
                    vlxd.GiaoHangs.InsertOnSubmit(a);
                    vlxd.SubmitChanges();
                    b = true;
                }
                catch
                {
                    b = false;
                }
            }
            return b;
        }
    }
}
