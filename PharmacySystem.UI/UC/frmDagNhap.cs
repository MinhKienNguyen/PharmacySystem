using DevExpress.XtraEditors;
using GiaoDien.DoMain;
using GiaoDien.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace GiaoDien.Views
{
    public partial class frmDagNhap : DevExpress.XtraEditors.XtraForm
    {
        LoginModel _loginModel = new LoginModel();
        public frmDagNhap()
        {
            InitializeComponent();
            txttaikhoan.Text = GiaoDien.Properties.Settings.Default.User;
            txtmk.Text = GiaoDien.Properties.Settings.Default.Pass;
            if (txttaikhoan.Text != "" && txtmk.Text != "")
                checkLuu.Checked = true;
            else
                checkLuu.Checked = false;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable table = _loginModel.GetDataLogin(txttaikhoan.Text, txtmk.Text);
            if(table == null || table.Rows.Count <= 0)
            {
                XtraMessageBox.Show(Commons.LoginError,Commons.Notify, MessageBoxButtons.OKCancel);
                return;
            }
            else if(Convert.ToInt16(table.Rows[0]["Error"].ToString()) < 0)
            {
                XtraMessageBox.Show(Commons.LoginKeyed, Commons.Notify, MessageBoxButtons.OKCancel);
                return;
            }
            //lưu lại tài khoản, mk
            if (checkLuu.Checked == true)
            {
                GiaoDien.Properties.Settings.Default.User = txttaikhoan.Text;
                GiaoDien.Properties.Settings.Default.Pass = txtmk.Text;
                GiaoDien.Properties.Settings.Default.Save();
            }
            else
            {
                GiaoDien.Properties.Settings.Default.User = "";
                GiaoDien.Properties.Settings.Default.Pass = "";
                GiaoDien.Properties.Settings.Default.Save();
            }
            if (Program.mainForm == null || Program.mainForm.IsDisposed)
            {
                Program.mainForm = new frmMain();
            }
            GiaoDien.Properties.Settings.Default.MaNV = table.Rows[0]["MaNhanVien"].ToString();
            GiaoDien.Properties.Settings.Default.TenNV = table.Rows[0]["TenNhanVien"].ToString();
            Program.mainForm.TenNhanVien = table.Rows[0]["TenNhanVien"].ToString();
            Program.mainForm.TenDangNhap = txttaikhoan.Text;
            this.Hide();
            Program.mainForm.Show();
        }


        private void txttaikhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void txtmk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(XtraMessageBox.Show(Commons.Cannel, Commons.Notify, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
            {
                this.Close();
            }
        }
    }
}