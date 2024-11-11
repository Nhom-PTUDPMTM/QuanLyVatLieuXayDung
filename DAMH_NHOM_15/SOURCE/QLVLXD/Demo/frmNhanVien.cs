using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace Demo
{
    public partial class frmNhanVien : Form
    {
        VLXDDataContext vlxd = new VLXDDataContext();
        public frmNhanVien()
        {
            

            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            load();
        }
         private void load()
        { 
            dgvDS.Rows.Clear();
         
          
            
        
        }

        private void dgvDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow r = dgvDS.Rows[e.RowIndex];
                    txtMaNV.Text = r.Cells[0].Value.ToString();
                    txtTenNV.Text = r.Cells[1].Value.ToString();
                    txtMatKhau.Text = r.Cells[2].Value.ToString();
                    txtGioiTinh.Text = r.Cells[3].Value.ToString();
                    dtpNgaySinh.Text = r.Cells[4].Value.ToString();
                    txtDiaChi.Text = r.Cells[5].Value.ToString();
                    txtSDT.Text = r.Cells[6].Value.ToString();
                    txtChucvu.Text = r.Cells[7].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message);
                }
            }

        }
    }
}
