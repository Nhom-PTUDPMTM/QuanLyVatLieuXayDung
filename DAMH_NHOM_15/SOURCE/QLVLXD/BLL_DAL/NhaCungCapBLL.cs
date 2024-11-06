using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics.Tensors;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL_DAL
{
    public class NhaCungCapBLL
    {
        VLXDDataContext vlxd = new VLXDDataContext();
        public DataTable getCodeAndName()
        {
            DataTable dt = new DataTable();
            var kq = from tcs in vlxd.NhaCCs
                     select new { 
                        MaNCC = tcs.MaNCC,
                        TenNCC = tcs.TenNCC
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
        public NhaCC getByCode(string code)
        {
            return vlxd.NhaCCs.Where(t => t.MaNCC == code).FirstOrDefault();
        }
    }
}
