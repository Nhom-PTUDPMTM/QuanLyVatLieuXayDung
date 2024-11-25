using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;
using UtilityTools;

namespace BLL_DAL
{
    public class NguoiDungBUS
    {
        SqlConnection conn;
        NguoiDungDAL daNguoiDung = new NguoiDungDAL();
        public void CreateConnection(string sql)
        {
            conn = new SqlConnection(sql);
        }
        public int checkConfig(string sql)
        {
            return daNguoiDung.Check_Config(sql);
        }
        public LoginResult checkLogin(NguoiDung nguoiDung)
        {
            return daNguoiDung.Check_User(nguoiDung.User, nguoiDung.Pass);
        }
        public void TestConnection()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            if (conn.State == ConnectionState.Open)
                return;
        }
        public DataTable ExcuteQuery(string pQuery)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(pQuery, conn);
            da.Fill(dt);
            return dt;
        }
        public bool Insert(string pQuery)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(pQuery, conn);
            int kq = cmd.ExecuteNonQuery();
            conn.Close();
            if (kq >= 1)
                return true;
            else
                return false;
        }
        public bool Update(string pQuery)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(pQuery, conn);
            int kq = cmd.ExecuteNonQuery();
            conn.Close();
            if (kq >= 1)
                return true;
            else
                return false;
        }
        public bool Delete(string pQuery)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand(pQuery, conn);
            int kq = cmd.ExecuteNonQuery();
            conn.Close();
            if (kq >= 1)
                return true;
            else
                return false;
        }
    }
}
