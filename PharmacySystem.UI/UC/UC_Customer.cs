using DevExpress.XtraEditors;
using PharmacySystem.BLL.Implement;
using PharmacySystem.BLL.Interfaces;
using System;
using System.Linq;

namespace PharmacySystem.UC
{
    public partial class UC_Customer : XtraUserControl
    {
        private readonly ICustomerBLL _iCustomerBLL;
        public UC_Customer()
        {
            InitializeComponent();
            _iCustomerBLL = new CustomerBLL();
        }

        private void gvData_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void UC_Customer_Load(object sender, EventArgs e)
        {
            try
            {
                gcData.DataSource = _iCustomerBLL.GetCustomers().ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}
