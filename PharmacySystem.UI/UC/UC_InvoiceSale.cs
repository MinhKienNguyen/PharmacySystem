using DevExpress.XtraEditors;
using PharmacySystem.BLL.Implement;
using PharmacySystem.BLL.Interfaces;
using PharmacySystem.DAL.Object;
using System;

namespace PharmacySystem.UI.UC
{
    public partial class UC_InvoiceSale : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly IProductBLL _productBLL;
        public UC_InvoiceSale()
        {
            InitializeComponent();
            _productBLL = new ProductBLL();
            btnAdd.Click += BtnAdd_Click;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvProduct.FocusedRowHandle < 0)
                    return;
                var rowSelect = (ProductInfor)gvProduct.GetFocusedRow();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void UC_InvoiceSale_Load(object sender, EventArgs e)
        {
            try
            {
                var productTypes = _productBLL.GetProductTypes();
                lkProductType.DataSource = productTypes;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void itemProductType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var productTypeId = itemProductType.EditValue.ToString();
                if (string.IsNullOrEmpty(productTypeId))
                    return;
                var products = _productBLL.GetProductByProductType(productTypeId);
                gcProduct.DataSource = products;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void gvProduct_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
    }
}
