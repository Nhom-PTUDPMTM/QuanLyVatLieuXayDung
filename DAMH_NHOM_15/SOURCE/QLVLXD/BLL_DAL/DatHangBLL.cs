using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL_DAL
{
    public class DatHangBLL
    {
        VLXDDataContext vlxd = new VLXDDataContext();
        public DataTable getbycode(string code)
        {
            DataTable dt = new DataTable();
            var kq = from tcs in vlxd.DonHangs
                     where tcs.MaPX == code
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

        public DonHang getByCodeTK(string codeTK, string codePX)
        {
            return vlxd.DonHangs.Where(t => t.MaTK == codeTK && t.MaPX == codePX).FirstOrDefault();
        }
        public DataTable getAll()
        {
            DataTable dt = new DataTable();
            var kq = from tcs in vlxd.DonHangs
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
        
        public bool insertDonHang(DonHang dh)
        {
            try
            {
                vlxd.DonHangs.InsertOnSubmit(dh);
                vlxd.SubmitChanges();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public bool updateDonHang(DonHang dh)
        {
            try
            {
                DonHang c = vlxd.DonHangs.Where(t => t.MaPX == dh.MaPX).FirstOrDefault();
                c.MaTK = dh.MaTK;
                c.NgayDat = dh.NgayDat;
                c.NgayGiao = dh.NgayGiao;
                c.ThanhTien = dh.ThanhTien;
                c.ViTri = dh.ViTri;
                c.TinhTrang = dh.TinhTrang;
                vlxd.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteDonHang(string code)
        {
            try
            {
                DonHang c = vlxd.DonHangs.Where(t => t.MaPX == code).FirstOrDefault();
                vlxd.DonHangs.DeleteOnSubmit(c);
                vlxd.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
