using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class PhieuXuatBLL
    {
        VLXDDataContext vlxd;
        public PhieuXuatBLL()
        {
            vlxd = new VLXDDataContext();
        }
        public DataTable getAll()
        {
            return DataProvider.Instance.executeQuery("SELECT * FROM PhieuXuat");
        }
        public DataTable getAllPending()
        {
            return DataProvider.Instance.executeQuery("SELECT * FROM PhieuXuat WHERE TinhTrang = N'Pending'");
        }
        public PhieuXuat getByCode(string code)
        {
            if (string.IsNullOrEmpty(code)) return null;
            return vlxd.PhieuXuats.Where(t => t.MaHDXuat == code).FirstOrDefault();
        }
        public DataTable getALL()
        {
            DataTable dt = new DataTable();
            var kq = from tcs in vlxd.PhieuXuats
                     select new
                     {
                         MaHDXuat = tcs.MaHDXuat,
                         NgayXuat = tcs.NgayXuat,
                         MaNV = tcs.MaNV,
                         MaKH = tcs.MaKH,
                         TinhTrang = tcs.TinhTrang,
                         ThanhTien = tcs.ThanhTien
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
        public DataTable getByDate(DateTime dateStart, DateTime dateEnd)
        {
            DataTable dt = new DataTable();
            var kq = from tcs in vlxd.PhieuXuats
                     where tcs.NgayXuat <= dateEnd && tcs.NgayXuat >= dateStart
                     select new
                     {
                         MaHDXuat = tcs.MaHDXuat,
                         NgayXuat = tcs.NgayXuat,
                         MaNV = tcs.MaNV,
                         MaKH = tcs.MaKH,
                         TinhTrang = tcs.TinhTrang,
                         ThanhTien = tcs.ThanhTien
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
        public DataTable getByMaHDXuat(string maHDXuat)
        {
            DataTable dt = new DataTable();
            var kq = from tcs in vlxd.PhieuXuats
                     where tcs.MaHDXuat == maHDXuat
                     select new
                     {
                         MaHDXuat = tcs.MaHDXuat,
                         NgayXuat = tcs.NgayXuat,
                         MaNV = tcs.MaNV,
                         MaKH = tcs.MaKH,
                         TinhTrang = tcs.TinhTrang,
                         ThanhTien = tcs.ThanhTien
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

        public bool updatePhieuXuat(PhieuXuat px)
        {
            try
            {
                PhieuXuat p = vlxd.PhieuXuats.Where(t => t.MaHDXuat == px.MaHDXuat).FirstOrDefault();
                if (p != null)
                {
                    p.MaHDXuat = px.MaHDXuat;
                    p.NgayXuat = px.NgayXuat;
                    p.MaNV = px.MaNV;
                    p.MaKH = px.MaKH;
                    p.TinhTrang = px.TinhTrang;
                    p.ThanhTien = px.ThanhTien;
                    vlxd.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }

        }


        public bool insertPhieuXuat(PhieuXuat px)
        {
            try
            {
                vlxd.PhieuXuats.InsertOnSubmit(px);
                vlxd.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deletePhieuXuat(string code)
        {
            bool b = false;
            PhieuXuat p = vlxd.PhieuXuats.Where(t => t.MaHDXuat == code).FirstOrDefault();
            if (p != null)
            {
                try
                {
                    vlxd.PhieuXuats.DeleteOnSubmit(p);
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
