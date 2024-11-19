using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using UtilityTools;

namespace BLL_DAL
{
    public class NguoiDungDAL
    {
        SqlConnection _Sqlconn;
        public NguoiDungDAL()
        {
            _Sqlconn = new SqlConnection();
        }
        public int Check_Config(string sqlConn)
        {
            if (sqlConn == string.Empty)
                return 1;
            _Sqlconn = new SqlConnection(sqlConn);
            try
            {
                if (_Sqlconn.State == ConnectionState.Closed)
                    _Sqlconn.Open();
                return 0;
            }
            catch
            {
                return 2;
            }
        }
        public LoginResult Check_User(string user, string pass)
        {
            string _sql = "select * from NhanVien where TenNV='" + user + "' and MatKhau='" + pass + "'";
            SqlDataAdapter daUser = new SqlDataAdapter(_sql, _Sqlconn);
            DataTable dt = new DataTable();
            daUser.Fill(dt);
            if (dt.Rows.Count == 0)
                return UtilityTools.LoginResult.Disabled;
            else if(dt.Rows[0][2] == null || dt.Rows[0][2].ToString()=="0")
            {
                return UtilityTools.LoginResult.Invalid;
            }
            return UtilityTools.LoginResult.Suscess;
        }
    }
}
