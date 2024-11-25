using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace BLL_DAL
{
    public class VaiTroBLL
    {
        VLXDDataContext vlxd;
        public VaiTroBLL() {
            vlxd = new VLXDDataContext();
        }
        public VaiTro getByCode(string code)
        {
            return vlxd.VaiTros.Where(t => t.MaVaiTro == code).FirstOrDefault();
        }
        public DataTable getAll()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaVaiTro");
            dt.Columns.Add("TenVaiTro");
           
            foreach (VaiTro nv in vlxd.VaiTros)
            {
                dt.Rows.Add(nv.MaVaiTro, nv.TenVaiTro);
            }
            return dt;
        }

        public string getTenManHinh(string maMH)
        {
            return vlxd.ManHinhs.Where(t => t.MaMH == maMH).FirstOrDefault() != null ? vlxd.ManHinhs.Where(t => t.MaMH == maMH).FirstOrDefault().TenMH.ToString().Trim() : "NULL";
        }

        public bool addVT(string maVT, string tenVT)
        {
            try
            {
                VaiTro nv = new VaiTro
                {
                    MaVaiTro = maVT,
                    TenVaiTro = tenVT
                  

                };
                vlxd.VaiTros.InsertOnSubmit(nv);
                vlxd.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool updateVT(string maVT, string tenVT)
        {
            try
            {
                VaiTro nv = vlxd.VaiTros.FirstOrDefault(n => n.MaVaiTro == maVT);
                if (nv != null)
                {
                    nv.MaVaiTro = maVT;
                    nv.TenVaiTro = tenVT;
                   
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
        public void deleteVT(string MaVT)
        {
            VaiTro nv = getByCode(MaVT);
            vlxd.VaiTros.DeleteOnSubmit(nv);
            vlxd.SubmitChanges();
        

         }

}
}
