
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;


namespace BLL_DAL
{
    public class NhanVienBLL
    {
        VLXDDataContext vlxd = new VLXDDataContext();
        public System.Data.DataTable getAllNhanVien()
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            var tblNhanVien = from nv in vlxd.NhanViens select nv;
            dt.Columns.Clear();
            dt.Columns.Add();
            return dt;


        }
    }
}
