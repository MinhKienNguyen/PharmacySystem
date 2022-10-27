using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using PharmacySystem.BLL.Implement;
using PharmacySystem.BLL.Interfaces;
using PharmacySystem.DAL.Object;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PharmacySystem.UI.UC
{
    public partial class UC_InvoiceSale : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly IProductBLL _productBLL;
        private readonly ISystemBLL _systemBLL;
        public UC_InvoiceSale()
        {
            InitializeComponent();
            _productBLL = new ProductBLL();
            _systemBLL = new SystemBLL();
            btnAdd.Click += BtnAdd_Click;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvProduct.FocusedRowHandle < 0)
                    return;
                var rowSelect = (ProductInfor)gvProduct.GetFocusedRow();
                gvInvoiceCharger.AddNewRow();
                gvInvoiceCharger.SetRowCellValue(GridControl.NewItemRowHandle, "ProductTypeId", rowSelect.ProductTypeId);
                gvInvoiceCharger.SetRowCellValue(GridControl.NewItemRowHandle, "ProductTypeName", rowSelect.ProductTypeName);
                gvInvoiceCharger.SetRowCellValue(GridControl.NewItemRowHandle, "ProductId", rowSelect.ProductId);
                gvInvoiceCharger.SetRowCellValue(GridControl.NewItemRowHandle, "ProductName", rowSelect.ProductName);
                gvInvoiceCharger.SetRowCellValue(GridControl.NewItemRowHandle, "UnitId", rowSelect.UnitId);
                gvInvoiceCharger.SetRowCellValue(GridControl.NewItemRowHandle, "ExportPrice", rowSelect.ExportPrice);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void BindingDGVInvoiceCharge(List<ProductCharge> productCharges)
        {
            try
            {
                BindingSource bsProductCharge = new BindingSource();
                bsProductCharge.DataSource = productCharges;
                gcInvoiceCharger.DataSource = bsProductCharge;
                lkDVT.DataSource = _systemBLL.GetAllUnit();
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
                BindingDGVInvoiceCharge(new List<ProductCharge>());
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

        private void gvInvoiceCharger_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
    }
}
