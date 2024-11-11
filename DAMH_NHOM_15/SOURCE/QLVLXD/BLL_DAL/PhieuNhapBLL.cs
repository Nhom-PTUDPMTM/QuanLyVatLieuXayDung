using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class PhieuNhapBLL
    {
        private VLXDDataContext vlxd;
        public PhieuNhapBLL()
        {
            vlxd = new VLXDDataContext();
        }
        public DataTable getAll()
        {
            DataTable dt = new DataTable();
            var kq = from tcs in vlxd.PhieuNhaps
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
        public DataTable getByDate(DateTime dateStart, DateTime dateEnd)
        {
            DataTable dt = new DataTable();
            var kq = from tcs in vlxd.PhieuNhaps
                     where tcs.NgayNhap <= dateEnd && tcs.NgayNhap >= dateStart
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
        public PhieuNhap getByCode(string code) 
        { 
            return vlxd.PhieuNhaps.Where(t => t.MaHDNhap == code).FirstOrDefault(); 
        }
        public bool updatePhieuNhap(PhieuNhap newPN)
        {
            try
            {
                string query = string.Format("update PhieuNhap set MaNCC = '{1}' , ThanhTien = {2}, TinhTrang = N'{3}' where MaHDNhap = '{0}'", newPN.MaHDNhap, newPN.MaNCC, newPN.ThanhTien, newPN.TinhTrang);
                int result = DataProvider.Instance.executeNonQuery(query);
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool addItem(PhieuNhap a)
        {
            bool b = false;
            if (a != null)
            {
                try
                {
                    vlxd.PhieuNhaps.InsertOnSubmit(a);
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
