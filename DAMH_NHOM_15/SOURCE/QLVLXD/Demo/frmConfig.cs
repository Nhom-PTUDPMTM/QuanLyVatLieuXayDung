using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Demo
{
    public partial class frmConfig : MetroSet_UI.Forms.MetroSetForm
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void cboServerName_DropDown(object sender, EventArgs e)
        {
            cboServerName.DataSource = GetServerName();
            cboServerName.DisplayMember = "ServerName";
        }

        public DataTable GetServerName()
        {
            DataTable dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            return dt;
        }

        private void cboDatabase_DropDown(object sender, EventArgs e)
        {
            cboDatabase.DataSource = GetDatabase(cboServerName.Text, txtUsername.Text, txtPassword.Text);
            cboDatabase.DisplayMember = "name";
        }

        public DataTable GetDatabase(string pServer, string pUser, string pPass)
        {
            DataTable dt = new DataTable();
            //pServer = pServer.Trim() + "\\SQLEXPRESS";
            string connectionString = $"Data Source={pServer}; Initial Catalog=master; User ID={pUser}; pwd={pPass}";
            SqlDataAdapter adapter = new SqlDataAdapter("select name from sys.Databases", connectionString);
            adapter.Fill(dt);
            return dt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string server = cboServerName.Text.Trim();
            string database = cboDatabase.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(database) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                CustomMessageBox.Show("Vui lòng nhập đầy đủ thông tin cấu hình.", "Thông báo lỗi");
                return;
            }
            string connectionString = $"Data Source={server};Initial Catalog={database};User ID={username};Password={password}";
            Demo.Settings1.Default.STR1 = connectionString;
            Demo.Settings1.Default.Save();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    CustomMessageBox.Show("Kết nối thành công!", "Thông báo");
                    this.Close();
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("Kết nối thất bại: " + ex.Message, "Thông báo lỗi");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
