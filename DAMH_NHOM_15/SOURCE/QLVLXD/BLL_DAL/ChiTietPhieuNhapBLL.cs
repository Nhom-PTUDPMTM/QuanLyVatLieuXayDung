using DTO;
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
        public DataTable toPrint(string code)
        {
            DataTable dt = new DataTable();
            var kq = from rows in vlxd.ChiTietPhieuNhaps
                     join sp in vlxd.HangHoas on rows.MaHH equals sp.MaHH
                     where rows.MaHDNhap == code
                     select new
                     {
                         MaSP = rows.MaHH,
                         TenSP = sp.TenHH,
                         SoLuong = rows.SLNhap,
                         DonGia = rows.DonGiaNhap,
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
                dt.Columns["MaSP"].ColumnName = "Mã sản phẩm";
                dt.Columns["TenSP"].ColumnName = "Tên sản phẩm";
                dt.Columns["SoLuong"].ColumnName = "Số lượng";
                dt.Columns["DonGia"].ColumnName = "Đơn giá";
                dt.Columns["ThanhTien"].ColumnName = "Thành tiền";
            }
            return dt;
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
            try
            {
                string query = string.Format("update ChiTietPhieuNhap set SLNhap = {2} , ThanhTien = {3} where MaHDNhap = '{0}' and MaHH = '{1}'", a.MaHDNhap, a.MaHH, d.SLNhap != null ? d.SLNhap : a.SLNhap, d.ThanhTien != null ? d.ThanhTien : a.ThanhTien);
                int result = DataProvider.Instance.executeNonQuery(query);
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
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
