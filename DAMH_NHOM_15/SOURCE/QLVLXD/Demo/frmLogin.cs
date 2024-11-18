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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length == 0 || txtUsername.Text.Length == 0)
            {
                MetroSetMessageBox.Show(this, "Không thể để trống tài khoản hoặc mật khẩu !!", "Thông báo");
                return;
            }
            string kq = nhanVienBLL.checkAccount(txtUsername.Text, txtPassword.Text);
            if (kq == "None")
            {
                MetroSetMessageBox.Show(this, "Sai thông tin tài khoản hoặc mật khẩu !!", "Thông báo");
                return;
            }
            else if (kq == "Error")
            {
                MetroSetMessageBox.Show(this, "Xảy ra lỗi !!", "Thông báo");
                return;
            }
            frmMain frm = new frmMain(kq);
            this.Visible = false;
            frm.Show();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(50, 0, 0, 0);
            btnLogin.BackColor = Color.FromArgb(50, 0, 0, 0);
            btnExit.BackColor = Color.FromArgb(50, 0, 0, 0);
        }
    }
}
