using System;
using DAL;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class LoaiHangBLL
    {
        VLXDDataContext vlxd = new VLXDDataContext();
        public DataTable getName()
        {
            DataTable dt = new DataTable();
            var kq = from tcs in vlxd.LoaiHangs
                     select new
                     {
                         MaLoai = tcs.MaLoai,
                         TenLoai = tcs.TenLoai
                     };
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
        public LoaiHang getByCode(string code)
        {
            return vlxd.LoaiHangs.Where(t => t.MaLoai == code).FirstOrDefault();
        }
    }
}
