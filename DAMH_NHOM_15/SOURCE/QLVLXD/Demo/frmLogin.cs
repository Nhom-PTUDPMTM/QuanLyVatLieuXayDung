using BLL_DAL;
using Btns;
using Login2;
using MetroSet_UI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilityTools;
using DTO;

namespace Demo
{
    public partial class frmLogin : MetroSet_UI.Forms.MetroSetForm
    {
        NhanVienBLL nhanVienBLL = new NhanVienBLL();
        NguoiDungBUS busNguoiDung = new NguoiDungBUS();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                CustomMessageBox.Show("Không được bỏ trống tên tài khoản !!");
                txtUsername.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                CustomMessageBox.Show("Không được bỏ trống mật khẩu !!");
                txtPassword.Focus();
                return;
            }
            string strConn = Demo.Settings1.Default.STR1;
            int kq = busNguoiDung.checkConfig(strConn);
            if (kq == 0)
            {
                ProcessLogin();
            }
            else
            {
                if (kq == 2)
                {
                    CustomMessageBox.Show("Chuỗi cấu hình không phù hợp !!");
                }
                else
                {
                    CustomMessageBox.Show("Chưa cấu hình hệ thống !!");
                }
                ProcessConfig();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(50, 0, 0, 0);
            btnLogin.BackColor = Color.FromArgb(50, 0, 0, 0);
            btnExit.BackColor = Color.FromArgb(50, 0, 0, 0);
        }
        public void ProcessLogin()
        {
            LoginResult result;
            NguoiDung nguoiDung = new NguoiDung(txtUsername.Text, txtPassword.Text);
            result = busNguoiDung.checkLogin(nguoiDung);
            if (result == LoginResult.Invalid)
            {
                CustomMessageBox.Show("Tài khoản bị khóa !!");
                return;
            }
            else if (result == LoginResult.Disabled)
            {
                CustomMessageBox.Show("Sai thông tin tài khoản !!");
                return;
            }
            string kq = nhanVienBLL.checkAccount(txtUsername.Text, txtPassword.Text);
            frmMain frmMain = new frmMain(kq);
            if (frmMain == null || frmMain.IsDisposed)
            {
                frmMain = new frmMain();
            }
            this.Visible = false;
            frmMain.Show();
        }
        public void ProcessConfig()
        {
            frmConfig frmConfig = new frmConfig();
            frmConfig.Show();
        }
    }
}
