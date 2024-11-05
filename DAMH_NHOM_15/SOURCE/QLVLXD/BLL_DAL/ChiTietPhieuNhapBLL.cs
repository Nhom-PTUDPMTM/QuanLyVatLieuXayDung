using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class ChiTietPhieuNhapBLL
    {
        VLXDDataContext vlxd = new VLXDDataContext();
        public DataTable getAllByCode(string code)
        {
            DataTable dt = new DataTable();
            var kq = from tcs in vlxd.ChiTietPhieuNhaps
                     where tcs.MaHDNhap == code
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
        public ChiTietPhieuNhap getByCodeProduct(string code, string productCode)
        {
            return vlxd.ChiTietPhieuNhaps.Where(t => t.MaHDNhap == code && t.MaHH == productCode).FirstOrDefault();
        }
        public bool addItem(ChiTietPhieuNhap a)
        {
            bool b = false;
            if (a != null)
            {
                try
                {
                    vlxd.ChiTietPhieuNhaps.InsertOnSubmit(a);
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
        public bool updateItem(ChiTietPhieuNhap a, ChiTietPhieuNhap d)
        {
            bool b = false;
            if (a != null && d != null)
            {
                try
                {
                    a.SLNhap = d.SLNhap != null ? d.SLNhap : a.SLNhap;
                    a.ThanhTien = d.ThanhTien != null ? d.ThanhTien : a.ThanhTien;
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
        public bool deleteItem(ChiTietPhieuNhap a)
        {
            bool b = false;
            if (a != null)
            {
                try
                {
                    vlxd.ChiTietPhieuNhaps.DeleteOnSubmit(a);
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
