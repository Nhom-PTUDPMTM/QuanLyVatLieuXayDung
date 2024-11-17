using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL_DAL
{
    public class NhanVienBLL
    {
        VLXDDataContext vlxd = new VLXDDataContext();
        public NhanVien getByCode(string code)
        {
            return vlxd.NhanViens.Where(t => t.MaNV == code).FirstOrDefault();
        }
        public DataTable getAll()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaNV");
            dt.Columns.Add("TenNV");
            dt.Columns.Add("MatKhau");
            dt.Columns.Add("GioiTinh");
            dt.Columns.Add("NgaySinh");
            dt.Columns.Add("DiaChi");
            dt.Columns.Add("SDT");
            dt.Columns.Add("ChucVu");
            foreach (NhanVien nv in vlxd.NhanViens)
            {
                dt.Rows.Add(nv.MaNV, nv.TenNV, nv.MatKhau, nv.GioiTinh, nv.NgaySinh, nv.DiaChi, nv.SDT, nv.ChucVu);
            }
            return dt;
        }

        public string checkAccount(string username, string password)
        {
            try
            {
                NhanVien check = vlxd.NhanViens.Where(t => t.TenNV == username && t.MatKhau == password).FirstOrDefault();
                if (string.IsNullOrEmpty(check.MaNV))
                    return "None";
                return check.MaNV;
            }
            catch
            {
                return "Error";
            }
        }

        public bool addNV(string maNV, string tenNV, string diaChi, string soDienThoai, string mk, string gt, string cv, string ngaysinh)
        {
            try
            {
                NhanVien nv = new NhanVien
                {
                    MaNV = maNV,
                    TenNV = tenNV,
                    DiaChi = diaChi,
                    SDT = soDienThoai,
                    MatKhau = mk,
                    GioiTinh = gt,
                    ChucVu = cv,
                    NgaySinh = DateTime.Parse(ngaysinh)

                };
                vlxd.NhanViens.InsertOnSubmit(nv);
                vlxd.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool updateNV(string maNV, string tenNV, string diaChi, string soDienThoai, string mk, string gt, string cv, string ngaysinh)
        {
            try
            {
                NhanVien nv = vlxd.NhanViens.FirstOrDefault(n => n.MaNV == maNV);
                if (nv != null)
                {
                    nv.TenNV = tenNV;
                    nv.DiaChi = diaChi;
                    nv.SDT = soDienThoai;
                    nv.MatKhau = mk;
                    nv.GioiTinh = gt;
                    nv.ChucVu = cv;
                    nv.NgaySinh = DateTime.Parse(ngaysinh);
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
        public void deleteNV(string MaNV)
        {
            NhanVien nv = getByCode(MaNV);
            vlxd.NhanViens.DeleteOnSubmit(nv);
            vlxd.SubmitChanges();
        }
        public DataTable searchNV(string tenNV)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("MaNV");
            dt.Columns.Add("TenNV");
            dt.Columns.Add("MatKhau");
            dt.Columns.Add("GioiTinh");
            dt.Columns.Add("NgaySinh");
            dt.Columns.Add("DiaChi");
            dt.Columns.Add("SDT");
            dt.Columns.Add("ChucVu");


            var results = vlxd.NhanViens.Where(nv => nv.TenNV.Contains(tenNV)).ToList();
            foreach (var nv in results)
            {
                dt.Rows.Add(nv.MaNV, nv.TenNV, nv.MatKhau, nv.GioiTinh, nv.NgaySinh, nv.DiaChi, nv.SDT, nv.ChucVu);
            }
            return dt;
        }

    }
}
