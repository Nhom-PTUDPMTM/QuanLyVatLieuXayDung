﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL_DAL
{
    public class SanPhamBLL
    {
        VLXDDataContext vlxd = new VLXDDataContext();
        public DataTable getAll()
        {
            DataTable dt = new DataTable();
            var kq = from tcs in vlxd.HangHoas
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
        public HangHoa getSanPhamByCode(string code)
        {
            return vlxd.HangHoas.Where(t => t.MaHH == code).FirstOrDefault();
        }
        public bool updateSanPham(string code, HangHoa a)
        {
            bool b = false;
            if (code != null && a != null)
            {
                HangHoa c = vlxd.HangHoas.Where(t => t.MaHH == code).FirstOrDefault();
                try
                {
                    if (c != null)
                    {
                        c.CungUngs = a.CungUngs != null ? a.CungUngs : c.CungUngs;
                        c.DonGia = a.DonGia != null ? a.DonGia : c.DonGia;
                        c.DonVi = a.DonVi != null ? a.DonVi : c.DonVi;
                        c.MaLoai = a.MaLoai != null ? a.MaLoai : c.MaLoai;
                        c.SoLuongTon = a.SoLuongTon != null ? a.SoLuongTon : c.SoLuongTon;
                        c.TenHH = a.TenHH != null ? a.TenHH : c.TenHH;
                        vlxd.SubmitChanges();
                        b = true;
                    }
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