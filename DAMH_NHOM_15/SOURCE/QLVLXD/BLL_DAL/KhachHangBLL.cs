using DTO;
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
        // Áp dụng LinQ
        VLXDDataContext vlxd;
        public KhachHangBLL()
        {
            vlxd = new VLXDDataContext();
        }
        public DataTable getAll()
        {
            return DataProvider.Instance.executeQuery("SELECT * FROM KhachHang");
        }
        public DataTable SearchCustomer(string search)
        {
            DataTable dt = new DataTable();
            string searchLow = search.ToLower();
            var kq = from tcs in vlxd.KhachHangs
                     where tcs.DiaChi.ToLower().Contains(searchLow) || tcs.TenKH.ToLower().Contains(searchLow)
                            || tcs.GioiTinh.ToLower().Contains(searchLow) || tcs.NgaySinh.ToString().Contains(searchLow)
                            || tcs.SDT.ToString().Contains(searchLow) || tcs.LoaiKH.ToString().ToLower().Contains(searchLow)
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
        public KhachHang getByCode(string code)
        {
            return vlxd.KhachHangs.Where(t => t.MaKH == code).FirstOrDefault();
        }
        public bool updateItem(KhachHang newPN)
        {
            try
            {
                string ngaysinhFormatted = newPN.NgaySinh.HasValue ? $"'{newPN.NgaySinh.Value.ToString("yyyy-MM-dd")}'" : "NULL";
                string query = string.Format("update KhachHang set TenKH = N'{1}' , GioiTinh = N'{2}', NgaySinh = {3}, DiaChi = N'{4}', SDT = '{5}', LoaiKH = '{6}' where MaKH = '{0}'",
                    newPN.MaKH, newPN.TenKH, newPN.GioiTinh, ngaysinhFormatted, newPN.DiaChi, newPN.SDT, newPN.LoaiKH);
                int result = DataProvider.Instance.executeNonQuery(query);
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool addItem(KhachHang a)
        {
            bool b = false;
            if (a != null)
            {
                try
                {
                    vlxd.KhachHangs.InsertOnSubmit(a);
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
        public bool deleteItem(string a)
        {
            bool b = false;
            if (a != null)
            {
                try
                {
                    KhachHang kh = vlxd.KhachHangs.Where(t => t.MaKH == a).FirstOrDefault();
                    vlxd.KhachHangs.DeleteOnSubmit(kh);
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
