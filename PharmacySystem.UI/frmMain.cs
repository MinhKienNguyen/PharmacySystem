using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using PharmacySystem.UC;
using PharmacySystem.UI.UC;
using System;
using System.Windows.Forms;

namespace PharmacySystem.UI
{
    public partial class frmMain : RibbonForm
    {
        public string tenNhanVien;
        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        private string tenDangNhap;
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
        public frmMain()
        {
            InitializeComponent();
            Skins();
        }

        public void Skins()
        {
            DevExpress.LookAndFeel.DefaultLookAndFeel them = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            them.LookAndFeel.SkinName = "Office 2010 Blue";
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr;
            dr = XtraMessageBox.Show("Bạn có muốn thoát không ?","Thông báo !", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        public void AddTab(XtraTabControl XtraTabCha, string TabNameAdd, UserControl UserControl)
        {
            // Khởi tạo 1 Tab Con (XtraTabPage)
            DevExpress.XtraTab.XtraTabPage TAbAdd = new DevExpress.XtraTab.XtraTabPage();
            // Đặt đại cái tên cho nó là TestTab (Đây là tên nhé)
            TAbAdd.Name = "Tab";
            // Tên của nó là đối số như đã nói ở trên
            TAbAdd.Text = TabNameAdd;
            // Add đối số UserControl vào Tab con vừa khởi tạo ở trên
            TAbAdd.Controls.Add(UserControl);
            // Dock cho nó tràn hết TAb con đó
            UserControl.Dock = DockStyle.Fill;
            // Quăng nó lên TAb Cha (XtraTabCha là đối số thứ nhất như đã nói ở trên)
            XtraTabCha.TabPages.Add(TAbAdd);
        }

        private void AddTabControl(UserControl userControl, string itemTabName)
        {
            bool isExists = false;
            foreach (XtraTabPage tabItem in xtraTabControl.TabPages)
            {
                if (tabItem.Text == itemTabName)
                {
                    isExists = true;
                    xtraTabControl.SelectedTabPage = tabItem;
                }
            }
            if (isExists == false)
            {
                AddTab(xtraTabControl, itemTabName, userControl);
            }
        }

        /// <summary>
        /// xtraTabControl_CloseButtonClick -- sự kiện đóng tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xtraTabControl_CloseButtonClick(object sender, EventArgs e)
        {
            xtraTabControl.TabPages.RemoveAt(xtraTabControl.SelectedTabPageIndex);
            xtraTabControl.SelectedTabPageIndex = xtraTabControl.TabPages.Count - 1;
        }

        /// <summary>
        /// xtraTabControl_ControlAdded -- sự kiện add tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xtraTabControl_ControlAdded(object sender, ControlEventArgs e)
        {
            xtraTabControl.SelectedTabPageIndex = xtraTabControl.TabPages.Count - 1;
        }

        private void btItemMH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //UC_MangHinh mh = new UC_MangHinh();
            //AddTabControl(mh,"Màng hình");
        }

        private void btnthemngdungvaonhom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UC_Customer themnv = new UC_Customer();
            AddTabControl(themnv,"Khách hàng");
        }

        private void FindMenuPhanQuyen(RibbonControl ribbonControl)
        {
            foreach (RibbonPage RibPage in ribbonControl.Pages)
            {

                foreach (RibbonPageGroup RibPageGroup in RibPage.Groups)
                {
                    int PageGroup = 0;
                    int CounBarItem = 0;

                    foreach (BarItemLink BarItem in RibPageGroup.ItemLinks)
                    {
                        if (BarItem.GetType() == typeof(BarSubItemLink))
                        {
                            BarSubItemLink bsi = (BarSubItemLink)(BarItem);
                            foreach (BarItemLink bi in bsi.VisibleLinks)
                            {
                                foreach (string strValue in bi.Item.Tag.ToString().Split('|'))
                                {
                                    bi.Item.Visibility = BarItemVisibility.Always;
                                    PageGroup = 1;
                                    CounBarItem = 1;
                                }
                            }
                            if (CounBarItem == 1)
                            {
                                BarItem.Item.Visibility = BarItemVisibility.Always;
                            }
                        }
                        else
                        {
                            BarItem.Item.Visibility = BarItemVisibility.Always;
                            PageGroup = 1;
                        }
                    }
                    if (PageGroup == 1)
                    {
                        RibPage.Visible = true;
                        RibPageGroup.Visible = true;
                    }

                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            FindMenuPhanQuyen(this.ribbonControl1);
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Program.frmDN.Show();
        }

        private void btnphanquyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void btnHangHoa_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barButtonItem32_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {


        }

        private void btnqlnguoidung_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        private void btnkhachhang_ItemClick(object sender, ItemClickEventArgs e)
        {
            UC_Customer themnv = new UC_Customer();
            AddTabControl(themnv, "Khách hàng");
        }

        private void btnNhapHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            //UC_NhapHang uC_Nhap = new UC_NhapHang();
            //AddTabControl(uC_Nhap, "Nhập hàng");
        }

        private void btnBanHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            UC_InvoiceSale invoiceSale = new UC_InvoiceSale();
            AddTabControl(invoiceSale, "Lên hóa đơn thuốc");
        }

        private void btnHoaDon_ItemClick(object sender, ItemClickEventArgs e)
        {
            //UC_HoaDon uc_hoadon = new UC_HoaDon();
            //AddTabControl(uc_hoadon, "Hóa đơn");
        }

        private void btnDoiTra_ItemClick(object sender, ItemClickEventArgs e)
        {
            //UC_DoiTra uc_doiTra = new UC_DoiTra();
            //AddTabControl(uc_doiTra, "Đổi trả hàng");
        }

        private void BarItemDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            //DialogResult dr;
            //dr = XtraMessageBox.Show("Bạn có muốn thoát không ?", "Thông báo !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dr == DialogResult.Yes)
            //{
            //    this.Hide();
            //    frmDagNhap dn = new frmDagNhap();
            //    dn.Show();
            //}
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            //UC_ThongKeKho tk = new UC_ThongKeKho();
            //AddTabControl(tk, "Thống kê kho");
        }

        private void barButtonItem49_ItemClick(object sender, ItemClickEventArgs e)
        {
            //UC_DoanhThu dt = new UC_DoanhThu();
            //AddTabControl(dt, "Doanh thu");
        }

        private void barButtonItem31_ItemClick(object sender, ItemClickEventArgs e)
        {
            //UC_HoaDonDoiTra hddt = new UC_HoaDonDoiTra();
            //AddTabControl(hddt,"Hóa đơn đổi trả");
        }

        private void barButtonItem50_ItemClick(object sender, ItemClickEventArgs e)
        {
            //UC_ThongTin tt = new UC_ThongTin();
            //AddTabControl(tt,"thông tin phần mềm");
        }
    }
}
