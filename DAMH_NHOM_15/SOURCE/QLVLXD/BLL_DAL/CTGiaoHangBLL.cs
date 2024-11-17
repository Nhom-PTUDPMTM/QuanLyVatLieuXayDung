using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class CTGiaoHangBLL
    {
        VLXDDataContext vlxd;
        public CTGiaoHangBLL()
        {
            vlxd = new VLXDDataContext();
        }
        public DataTable getByCodeTrans(string code)
        {
            return DataProvider.Instance.executeQuery("SELECT * FROM ChiTietGiaoHang WHERE MaGH = '" + code + "'");
        }
        public ChiTietGiaoHang getByCodeTransAndCodeProduct(string codeTrans, string codeProduct)
        {
            return vlxd.ChiTietGiaoHangs.Where(t => t.MaGH == codeTrans && t.MaSP == codeProduct).FirstOrDefault();
        }
        public DataTable getByDate(DateTime start, DateTime end)
        {
            DataTable dt = new DataTable();
            var kq = from tcs in vlxd.PhieuNhaps
                     where tcs.NgayNhap <= end && tcs.NgayNhap >= start
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
        public bool updateItem(ChiTietGiaoHang newPN)
        {
            try
            {
                string ngaygiaoFormatted = $"'{newPN.NgayGiao.ToString("yyyy-MM-dd")}'";
                string query = string.Format("update ChiTietGiaoHang set MaNV = '{2}', NgayGiao = {3}, SoLuongGiao = {4}, SoLuongCon = {5} where MaGH = '{0}' and MaSP = '{1}'", newPN.MaGH, newPN.MaSP, newPN.MaNV, ngaygiaoFormatted, newPN.SoLuongGiao, newPN.SoLuongCon);
                int result = DataProvider.Instance.executeNonQuery(query);
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool addItem(ChiTietGiaoHang a)
        {
            bool b = false;
            if (a != null)
            {
                try
                {
                    vlxd.ChiTietGiaoHangs.InsertOnSubmit(a);
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
