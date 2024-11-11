<<<<<<< HEAD
﻿
using Microsoft.Office.Interop.Word;
=======
﻿using DAL;
>>>>>>> main
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
using System.Data;
using DAL;

=======
>>>>>>> main

namespace BLL_DAL
{
    public class NhanVienBLL
    {
        VLXDDataContext vlxd = new VLXDDataContext();
<<<<<<< HEAD
        public System.Data.DataTable getAllNhanVien()
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            var tblNhanVien = from nv in vlxd.NhanViens select nv;
            dt.Columns.Clear();
            dt.Columns.Add();
            return dt;


=======
        public NhanVien getByCode(string code)
        {
            return vlxd.NhanViens.Where(t => t.MaNV == code).FirstOrDefault();
>>>>>>> main
        }
    }
}
