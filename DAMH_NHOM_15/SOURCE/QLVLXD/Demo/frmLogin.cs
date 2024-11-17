using BLL_DAL;
using Btns;
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

namespace Demo
{
    public partial class frmLogin : MetroSet_UI.Forms.MetroSetForm
    {
        NhanVienBLL nhanVienBLL = new NhanVienBLL();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void login1_SubmitClicked(object sender, EventArgs e)
        {
            if (login1.UserName.Length == 0 || login1.Password.Length == 0)
            {
                CustomMessageBox.Show("Không thể để trống tài khoản hoặc mật khẩu !!", "Thông báo");
                return;
            }
            string kq = nhanVienBLL.checkAccount(login1.UserName, login1.Password);
            if (kq == "None")
            {
                CustomMessageBox.Show("Sai thông tin tài khoản hoặc mật khẩu !!", "Thông báo");
                return;
            }
            else if (kq == "Error")
            {
                CustomMessageBox.Show("Xảy ra lỗi !!", "Thông báo");
                return;
            }
            frmMain frm = new frmMain(kq);
            this.Visible = false;
            frm.Show();
        }

        private void login1_CancelClicked(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
