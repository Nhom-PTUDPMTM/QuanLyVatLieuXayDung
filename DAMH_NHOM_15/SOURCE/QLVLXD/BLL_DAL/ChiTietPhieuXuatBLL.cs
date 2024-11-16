using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL_DAL
{
    public class ChiTietPhieuXuatBLL
    {
        VLXDDataContext vlxd = new VLXDDataContext();
        public DataTable getAllbycode(string code)
        {
            DataTable dt = new DataTable();
            var kq = from tcs in vlxd.ChiTietPhieuXuats
                     where tcs.MaHDXuat == code
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
        public ChiTietPhieuXuat getByCodeProduct(string code, string productCode)
        {
            return vlxd.ChiTietPhieuXuats.Where(t => t.MaHDXuat == code && t.MaHH == productCode).FirstOrDefault();
        }
        public DataTable toPrint(string code)
        {
            DataTable dt = new DataTable();
            var kq = from rows in vlxd.ChiTietPhieuXuats
                     join sp in vlxd.HangHoas on rows.MaHH equals sp.MaHH
                     where rows.MaHDXuat == code
                     select new
                     {
                         MaSP = rows.MaHH,
                         TenSP = sp.TenHH,
                         SoLuong = rows.SLXuat,
                         DonGia = rows.DonGiaXuat,
                         ThanhTien = rows.ThanhTien
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
        public bool insertChiTietPhieuXuat(ChiTietPhieuXuat a)
        {
            try
            {
                vlxd.ChiTietPhieuXuats.InsertOnSubmit(a);
                vlxd.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateChiTietPhieuXuat(ChiTietPhieuXuat a)
        {
            try
            {
                ChiTietPhieuXuat c = vlxd.ChiTietPhieuXuats.Where(t => t.MaHDXuat == a.MaHDXuat && t.MaHH == a.MaHH).FirstOrDefault();
                c.SLXuat = a.SLXuat;
                c.DonGiaXuat = a.DonGiaXuat;
                c.ThanhTien = a.ThanhTien;
                vlxd.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteChiTietPhieuXuat(string codeBill, string codeProduct)
        {
            bool b = false;
            ChiTietPhieuXuat c = vlxd.ChiTietPhieuXuats.Where(t => t.MaHDXuat == codeBill && t.MaHH == codeProduct).FirstOrDefault();
            if (c != null)
            {
                try
                {
                    vlxd.ChiTietPhieuXuats.DeleteOnSubmit(c);
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
