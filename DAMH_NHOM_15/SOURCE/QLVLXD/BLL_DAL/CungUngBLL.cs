using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class CungUngBLL
    {
        VLXDDataContext vlxd;
        public CungUngBLL()
        {
            vlxd = new VLXDDataContext();
        }
        public bool updateItem(CungUng newPN)
        {
            try
            {
                string query = string.Format("update CungUng set TrangThai = N'{2}' where MaNCC = '{0}' and MaHH = '{1}'", newPN.MaNCC, newPN.MaHH, newPN.TrangThai);
                int result = DataProvider.Instance.executeNonQuery(query);
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool addItem(CungUng a)
        {
            bool b = false;
            if (a != null)
            {
                try
                {
                    vlxd.CungUngs.InsertOnSubmit(a);
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

        public bool removeItem(string maNCC, string maHH)
        {
            bool b = false;
            if (maHH != null && maNCC != null)
            {
                try
                {
                    CungUng a = vlxd.CungUngs.Where(t=>t.MaNCC == maNCC && t.MaHH == maHH).FirstOrDefault();
                    if(a != null)
                    {
                        vlxd.CungUngs.DeleteOnSubmit(a);
                        vlxd.SubmitChanges();
                    }
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
