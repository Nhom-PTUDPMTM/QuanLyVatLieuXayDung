using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class KhachHangBLL
    {
        VLXDDataContext vlxd = new VLXDDataContext();
        public KhachHang getbycode(string code)
        {
            return vlxd.KhachHangs.Where(t => t.MaKH == code).FirstOrDefault();
        }
        public DataTable getAll()
        {
            DataTable dt = new DataTable();
            var kq = from tcs in vlxd.KhachHangs
                     select tcs;
            if (kq.Any())
            {
                var firstItem = kq.First();
                foreach (var prop in firstItem.GetType().GetProperties())
                {
                    dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
                foreach (var item in kq)
                {
                    var row = dt.NewRow();
                    foreach (var prop in item.GetType().GetProperties())
                    {
                        row[prop.Name] = prop.GetValue(item, null) ?? DBNull.Value;
                    }
                    dt.Rows.Add(row);
                }
            }
            return dt;

        }
        // Áp dụng LinQ

    }
}
