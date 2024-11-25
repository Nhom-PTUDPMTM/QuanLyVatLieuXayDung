using BLL_DAL;
using DTO;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class frmPhanQuyen : MetroSet_UI.Forms.MetroSetForm
    {
        PhanQuyenBLL phanQuyenBLL = new PhanQuyenBLL();
        ManHinhBLL manHinhBLL = new ManHinhBLL();
        VaiTroBLL vaiTroBLL = new VaiTroBLL();
        public frmPhanQuyen()
        {
            InitializeComponent();
            gridView1.OptionsBehavior.AllowAddRows = DefaultBoolean.False;
        }

        public void reLoad()
        {
            DataTable dt = manHinhBLL.getAll();
            cboManHinh.Properties.DataSource = null;
            cboManHinh.Properties.DataSource = dt;
            cboManHinh.Properties.DisplayMember = "TenMH";
            cboManHinh.Properties.ValueMember = "MaMH";
            DataTable dt2 = vaiTroBLL.getAll();
            cboVaiTro.Properties.DataSource = null;
            cboVaiTro.Properties.DataSource = dt2;
            cboVaiTro.Properties.DisplayMember = "TenVaiTro";
            cboVaiTro.Properties.ValueMember = "MaVaiTro";
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                GridView view = sender as GridView;
                var r = view.GetDataRow(e.FocusedRowHandle);
                if (r != null)
                {
                    cboManHinh.EditValue = r[2]?.ToString().Trim();
                    chkHoatDong.Checked = int.Parse(r[3].ToString().Trim()) == 1;
                }
            }

        }

        private void cboVaiTro_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxEdit comboBoxEdit = sender as ComboBoxEdit;

            if (comboBoxEdit != null)
            {
                string selectedValue = comboBoxEdit.SelectedItem.ToString().Trim();
                dgvData.DataSource = null;
                DataTable dt = phanQuyenBLL.getAllForDataGridView(selectedValue);
                dgvData.DataSource = dt;
                gridView1.Columns[0].Visible = false;
                gridView1.Columns[1].Caption = "Mã màn hình";
                gridView1.Columns[2].Caption = "Tên màn hình";
                gridView1.Columns[3].Caption = "Quyền";
                RepositoryItemCheckEdit checkEdit = new RepositoryItemCheckEdit
                {
                    ValueChecked = 1,
                    ValueUnchecked = 0,
                    NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
                };
                gridView1.Columns[3].ColumnEdit = checkEdit;
                gridView1.Columns[3].OptionsColumn.AllowEdit = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LookUpEdit cbe = cboVaiTro as LookUpEdit;
            if (cbe != null)
            {
                object selectedValue = cbe.EditValue;
                if (selectedValue == null)
                {
                    CustomMessageBox.Show("Vui lòng chọn vai trò !");
                    return;
                }
                string role = selectedValue.ToString().Trim();
                phanQuyenBLL.addAllScreenForRole(role);
                dgvData.DataSource = null;
                DataTable dt = phanQuyenBLL.getAllForDataGridView(role);
                dgvData.DataSource = dt;
                if (gridView1.Columns.Count > 0)
                {
                    gridView1.Columns[0].Visible = false;
                    gridView1.Columns[1].Caption = "Mã màn hình";
                    gridView1.Columns[2].Caption = "Tên màn hình";
                    gridView1.Columns[3].Caption = "Quyền";
                    RepositoryItemCheckEdit checkEdit = new RepositoryItemCheckEdit
                    {
                        ValueChecked = 1,
                        ValueUnchecked = 0,
                        NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
                    };
                    gridView1.Columns[3].ColumnEdit = checkEdit;
                    gridView1.Columns[3].OptionsColumn.AllowEdit = true;
                }
            }
            else
            {
                CustomMessageBox.Show("Giá trị của vai trò không phù hợp");
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int rowCount = gridView1.RowCount;
            for (int i = 0; i < rowCount; i++)
            {
                var rowData = gridView1.GetRow(i);
                if (rowData != null)
                {
                    string maVaiTro = gridView1.GetRowCellValue(i, gridView1.Columns[0])?.ToString().Trim();
                    string maMH = gridView1.GetRowCellValue(i, gridView1.Columns[1])?.ToString().Trim();
                    int hoatDongInt = (gridView1.GetRowCellValue(i, gridView1.Columns[3]) as int?) ?? 0;
                    bool hoatDong = hoatDongInt == 1;
                    PhanQuyen sua = new PhanQuyen()
                    {
                        MaVaiTro = maVaiTro,
                        MaMH = maMH,
                        HoatDong = hoatDong ? 1 : 0
                    };
                    if (!phanQuyenBLL.updateItem(sua))
                        CustomMessageBox.Show("Lỗi cập nhật tại hàng " + (i + 1).ToString() + ".");
                }
            }
            LookUpEdit cbe = cboVaiTro as LookUpEdit;
            if (cbe != null)
            {
                object selectedValue = cbe.EditValue;
                if (selectedValue == null)
                {
                    CustomMessageBox.Show("Vui lòng chọn vai trò !");
                    return;
                }
                string role = selectedValue.ToString().Trim();
                phanQuyenBLL.addAllScreenForRole(role);
                dgvData.DataSource = null;
                DataTable dt = phanQuyenBLL.getAllForDataGridView(role);
                dgvData.DataSource = dt;
                if (gridView1.Columns.Count > 0)
                {
                    gridView1.Columns[0].Visible = false;
                    gridView1.Columns[1].Caption = "Mã màn hình";
                    gridView1.Columns[2].Caption = "Tên màn hình";
                    gridView1.Columns[3].Caption = "Quyền";
                    RepositoryItemCheckEdit checkEdit = new RepositoryItemCheckEdit
                    {
                        ValueChecked = 1,
                        ValueUnchecked = 0,
                        NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
                    };
                    gridView1.Columns[3].ColumnEdit = checkEdit;
                    gridView1.Columns[3].OptionsColumn.AllowEdit = true;
                }
            }
        }


        private void frmPhanQuyen_Load(object sender, EventArgs e)
        {
            reLoad();
        }

        private void cboVaiTro_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lookup = sender as LookUpEdit;
            if (lookup != null)
            {
                object selectedValue = lookup.EditValue;
                if (selectedValue != null)
                {
                    string selectedRole = selectedValue.ToString().Trim();
                    DataTable dt = phanQuyenBLL.getAllForDataGridView(selectedRole);
                    dgvData.DataSource = null;
                    dgvData.DataSource = dt;
                    if (gridView1.Columns.Count > 0)
                    {
                        gridView1.Columns[0].Visible = false;
                        gridView1.Columns[1].Caption = "Mã màn hình";
                        gridView1.Columns[2].Caption = "Tên màn hình";
                        gridView1.Columns[3].Caption = "Quyền";
                        RepositoryItemCheckEdit checkEdit = new RepositoryItemCheckEdit
                        {
                            ValueChecked = 1,
                            ValueUnchecked = 0,
                            NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
                        };
                        gridView1.Columns[3].ColumnEdit = checkEdit;
                        gridView1.Columns[3].OptionsColumn.AllowEdit = true;
                    }
                }
            }
        }
    }
}
